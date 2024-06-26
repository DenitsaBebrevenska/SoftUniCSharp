﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private List<IPilot> pilots;
        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
            pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLaps = value;
            }

        }
        public bool TookPlace { get; set; }
        public ICollection<IPilot> Pilots => pilots.AsReadOnly();

        public void AddPilot(IPilot pilot)
            => pilots.Add(pilot);

        public string RaceInfo()
        {
            StringBuilder raceInfo = new StringBuilder();
            raceInfo.AppendLine($"The {RaceName} race has:");
            raceInfo.AppendLine($"Participants: {pilots.Count}");
            raceInfo.AppendLine($"Number of laps: {NumberOfLaps}");
            string tookPlaceString = TookPlace ? "Yes" : "No";
            raceInfo.AppendLine($"Took place: {tookPlaceString}");

            return raceInfo.ToString().TrimEnd();
        }
    }
}
