using System;
using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private string _name;
        private string _category;
        private int _capacity;
        public University(int id, string name, string category, int capacity, IReadOnlyCollection<int> requiredSubjects)
        {
            Id = id;
            Name = name;
            Category = category;
            Capacity = capacity;
            RequiredSubjects = requiredSubjects;
        }

        public int Id { get; private set; }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                _name = value;
            }
        }

        public string Category
        {
            get => _category;
            private set
            {
                if (value != "Technical"
                    && value != "Economical"
                    && value != "Humanity")
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
                _category = value;
            }
        }

        public int Capacity
        {
            get => _capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }
                _capacity = value;
            }
        }
        public IReadOnlyCollection<int> RequiredSubjects { get; private set; }
    }
}
