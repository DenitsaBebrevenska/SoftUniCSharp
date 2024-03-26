using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Factories;
using UniversityCompetition.Factories.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private IRepository<ISubject> _subjects;
        private IRepository<IStudent> _students;
        private IRepository<IUniversity> _universities;
        private IFactory<ISubject> _subjectFactory;
        private int subjectIds = 1;
        private int universityIds = 1;
        private int studentIds = 1;

        public Controller()
        {
            _subjects = new SubjectRepository();
            _students = new StudentRepository();
            _universities = new UniversityRepository();
            _subjectFactory = new SubjectFactory();
        }
        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject = _subjectFactory.Create(subjectType, subjectName, subjectIds.ToString());

            if (subject is null)
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (_subjects.FindByName(subjectName) is not null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            subjectIds++;
            _subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, _subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (_universities.FindByName(universityName) is not null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> requiredSubjectsIds = new List<int>();
            requiredSubjects.ForEach(rs => requiredSubjectsIds.Add(_subjects.FindByName(rs).Id));

            IUniversity university = new University(universityIds, universityName, category, capacity, requiredSubjectsIds);
            universityIds++;
            _universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, _universities.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (_students.FindByName($"{firstName} {lastName}") is not null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            IStudent student = new Student(studentIds, firstName, lastName);
            studentIds++;
            _students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName,
                _students.GetType().Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = _students.FindById(studentId);
            ISubject subject = _subjects.FindById(subjectId);

            if (student is null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }

            if (subject is null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }

            if (student.CoveredExams.Contains(subject.Id))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName,
                    subject.Name);
            }

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName,
                subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            IStudent student = _students.FindByName(studentName);

            if (student is null)
            {
                string[] fullName = studentName.Split(' ');
                return string.Format(OutputMessages.StudentNotRegitered, fullName[0], fullName[1]);
            }

            IUniversity university = _universities.FindByName(universityName);

            if (university is null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            if (student.CoveredExams.Intersect(university.RequiredSubjects).Count() != university.RequiredSubjects.Count)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University is not null && student.University.Name == universityName)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName,
                    universityName);
            }

            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName,
                universityName);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = _universities.FindById(universityId);
            StringBuilder report = new StringBuilder();
            report.AppendLine($"*** {university.Name} ***");
            report.AppendLine($"Profile: {university.Category}");
            int studentCount = _students.Models
                .Count(s => s.University is not null && s.University.Name == university.Name);
            report.AppendLine($"Students admitted: {studentCount}");
            report.AppendLine($"University vacancy: {university.Capacity - studentCount}");

            return report.ToString().TrimEnd();
        }
    }
}
