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
        private IRepository<ISubject> subjects;
        private IRepository<IStudent> students;
        private IRepository<IUniversity> universities;
        private IFactory<ISubject> subjectFactory;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
            subjectFactory = new SubjectFactory();
        }
        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject = subjectFactory.Create(subjectType, subjectName, (subjects.Models.Count + 1).ToString());

            if (subject is null)
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.FindByName(subjectName) is not null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) is not null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> requiredSubjectsIds = new List<int>();
            requiredSubjects.ForEach(rs => requiredSubjectsIds.Add(subjects.FindByName(rs).Id));

            IUniversity university = new University(universities.Models.Count + 1, universityName, category, capacity, requiredSubjectsIds);
            universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.FindByName($"{firstName} {lastName}") is not null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            IStudent student = new Student(students.Models.Count + 1, firstName, lastName);
            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName,
                students.GetType().Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

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
            IStudent student = students.FindByName(studentName);

            if (student is null)
            {
                string[] fullName = studentName.Split(' ');
                return string.Format(OutputMessages.StudentNotRegitered, fullName[0], fullName[1]);
            }

            IUniversity university = universities.FindByName(universityName);

            if (university is null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            if (university.RequiredSubjects.Any(subject => !student.CoveredExams.Contains(subject)))
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
            IUniversity university = universities.FindById(universityId);
            StringBuilder report = new StringBuilder();
            report.AppendLine($"*** {university.Name} ***");
            report.AppendLine($"Profile: {university.Category}");
            int studentCount = students.Models
                .Count(s => s.University is not null && s.University.Name == university.Name);
            report.AppendLine($"Students admitted: {studentCount}");
            report.AppendLine($"University vacancy: {university.Capacity - studentCount}");

            return report.ToString().TrimEnd();
        }
    }
}
