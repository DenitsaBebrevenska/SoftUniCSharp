﻿using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Models.Vehicles;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private IRepository<IUser> _users;
        private IRepository<IVehicle> _vehicles;
        private IRepository<IRoute> _routes;
        private int _routeEnumerator = 1;

        public Controller()
        {
            _users = new UserRepository();
            _vehicles = new VehicleRepository();
            _routes = new RouteRepository();
        }
        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            IUser user = _users.FindById(drivingLicenseNumber);

            if (user != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            _users.AddModel(new User(firstName, lastName, drivingLicenseNumber));
            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            var baseClassChildren = Assembly.GetAssembly(typeof(Vehicle))
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableTo(typeof(Vehicle)))
                .Select(t => t.Name);

            if (!baseClassChildren.Contains(vehicleType))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            if (_vehicles.GetAll().Any(v => v.LicensePlateNumber == licensePlateNumber))
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            Type currentType = Assembly.GetAssembly(typeof(Vehicle))
                .GetTypes()
                .FirstOrDefault(t => t.IsClass && !t.IsAbstract && t.Name == vehicleType);

            object instance = Activator.CreateInstance(currentType, new object[] { brand, model, licensePlateNumber });

            _vehicles.AddModel(instance as IVehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            if (_routes.GetAll()
                .Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length.Equals(length)))
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }

            if (_routes.GetAll()
                .Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length < length))
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }

            IRoute route = new Route(startPoint, endPoint, length, _routeEnumerator++);
            _routes.AddModel(route);

            IRoute longerRoute = _routes.GetAll()
                .FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length);

            if (longerRoute != null)
            {
                longerRoute.LockRoute();
            }

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = _users.FindById(drivingLicenseNumber);

            if (user.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }

            IVehicle vehicle = _vehicles.FindById(licensePlateNumber);

            if (vehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }

            IRoute route = _routes.FindById(routeId);

            if (route.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RepairVehicles(int count)
        {
            var vehiclesToRepair = _vehicles.GetAll()
                .Where(v => v.IsDamaged)
                .OrderBy(v => v.Brand)
                .ThenBy(v => v.Model)
                .Take(count)
                .ToList();

            foreach (var vehicle in vehiclesToRepair)
            {
                vehicle.ChangeStatus();
            }

            return string.Format(OutputMessages.RepairedVehicles, vehiclesToRepair.Count());
        }

        public string UsersReport()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("*** E-Drive-Rent ***");

            foreach (var user in _users.GetAll()
                         .OrderByDescending(u => u.Rating)
                         .ThenBy(u => u.LastName)
                         .ThenBy(u => u.FirstName))
            {
                report.AppendLine(user.ToString());
            }

            return report.ToString().TrimEnd();
        }
    }
}
