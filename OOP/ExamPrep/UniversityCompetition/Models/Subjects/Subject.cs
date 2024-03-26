using System;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models.Subjects
{
    public abstract class Subject : ISubject
    {
        private string _name;

        protected Subject(string name, int id, double rate)
        {
            Name = name;
            Id = id;
            Rate = rate;
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
        public double Rate { get; private set; }
    }
}
