using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.BLL.Infrastructure;
using FacultyWebApp.BLL.Services;
using FacultyWebApp.DAL.Entities;
using FacultyWebApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.Tests.ServicesTests
{
    public class StudentsServiceTest
    {
        private Mock<IGenericRepository<Student>> _mockGenericRepo;
        private Mock<ILogger<StudentsService>> _mockLogger;
        private StudentsService _studentsService;

        [SetUp]
        public void Initialize()
        {
            _mockGenericRepo = new Mock<IGenericRepository<Student>>();
            _mockLogger = new Mock<ILogger<StudentsService>>();

            _mockGenericRepo.Setup(x => x.GetById(It.IsAny<Guid>())).Returns((Student)null);
            _mockGenericRepo.Setup(x => x.GetById(It.Is<Guid>(x => x == Guid.Parse("9e254fbe-97eb-47b9-a751-0219689c62a5")))).Returns(new Student()
            {
                Id = Guid.Parse("9e254fbe-97eb-47b9-a751-0219689c62a5"),
                EducationTypeId = 1,
                EntryYear = 1,
                GroupId = 1,
                IsDeducted = false,
                Name = "Andrew",
                Surname = "Smirnov",
                PhoneNum = "+380945678948"
            });
            _mockGenericRepo.Setup(x => x.GetById(It.Is<Guid>(x => x == Guid.Parse("d76b25e6-594a-43bd-b6e1-2ec5a25eddfb")))).Returns(new Student()
            {
                Id = Guid.Parse("d76b25e6-594a-43bd-b6e1-2ec5a25eddfb"),
                EducationTypeId = 1,
                EntryYear = 1,
                GroupId = 1,
                IsDeducted = false,
                IsDeleted = true,
                Name = "Andrew",
                Surname = "Smirnov",
                PhoneNum = "+380945678948"
            });
            _mockGenericRepo.Setup(x => x.GetById(It.Is<Guid>(x => x == Guid.Parse("05966702-7c40-4a7d-80dd-948fef678960")))).Returns(new Student()
            {
                Id = Guid.Parse("05966702-7c40-4a7d-80dd-948fef678960"),
                EducationTypeId = 1,
                EntryYear = 1,
                GroupId = 1,
                IsDeducted = false,
                Name = "Andre",
                Surname = "Smirnov",
                PhoneNum = "+380945678948"
            });

            _mockGenericRepo.Setup(x => x.Add(It.IsAny<Student>())).Throws(new Exception("Db exception"));
            _mockGenericRepo.Setup(x => x.Add(It.Is<Student>(x => x.GroupId > 0)));

            _mockGenericRepo.Setup(x => x.Update(It.IsAny<Student>()));
            _mockGenericRepo.Setup(x => x.Update(It.Is<Student>(x => x.Id == Guid.Parse("05966702-7c40-4a7d-80dd-948fef678960")))).Throws(new Exception("Any db exception"));

            _studentsService = new StudentsService(_mockGenericRepo.Object, _mockLogger.Object);
        }

        [Test]
        [TestCase(true, "9e254fbe-97eb-47b9-a751-0219689c62a5", "")]
        [TestCase(false, "f3d58855-29e0-4d1a-a788-fec3d388c856", "Student was not founded")]
        [TestCase(false, "d76b25e6-594a-43bd-b6e1-2ec5a25eddfb", "Student was deleted")]
        public void GetStudentByIdTest(bool isCorrect, string id, string message)
        {
            if (isCorrect)
            {
                var actionRes = _studentsService.GetStudentById(Guid.Parse(id));
                Assert.IsNotNull(actionRes);
                Assert.AreEqual(id, actionRes.Id.ToString());
            }
            else
            {
                var exception = Assert.Throws<ValidationException>(() => _studentsService.GetStudentById(Guid.Parse(id)));
                Assert.AreEqual(message, exception.Message);
            }

        }

        [Test]
        [TestCase(true, 1)]
        [TestCase(false, 0)]
        [TestCase(false, -5)]
        [TestCase(true, 4)]
        public void AddStudentTest(bool isCorrect, int groupId)
        {
            StudentDTO studentDTO = new StudentDTO()
            {
                EducationTypeId = 1,
                EntryYear = 1,
                GroupId = groupId,
                IsDeducted = false,
                Name = "Andrew",
                Surname = "Smirnov",
                PhoneNum = "+380945678948"
            };

            if (isCorrect)
            {
                Assert.DoesNotThrow(() => _studentsService.AddStudent(studentDTO));
            }
            else
            {
                var exception = Assert.Throws<Exception>(() => _studentsService.AddStudent(studentDTO));
                Assert.IsNotNull(exception.Message);
            }
        }

        [Test]
        [TestCase(true, "9e254fbe-97eb-47b9-a751-0219689c62a5", "Pavlik", "")]
        [TestCase(false, "f3d58855-29e0-4d1a-a788-fec3d388c856", "Chaplin", "Student was not founded")]
        [TestCase(false, "d76b25e6-594a-43bd-b6e1-2ec5a25eddfb", "Trump", "Student was deleted")]
        [TestCase(false, "05966702-7c40-4a7d-80dd-948fef678960", null, "Any db exception")]
        public void ChangeStudentTest(bool isCorrect, string id, string newName, string message)
        {
            StudentDTO studentDTO = new StudentDTO()
            {
                Id = Guid.Parse(id),
                EducationTypeId = 1,
                EntryYear = 1,
                GroupId = 1,
                IsDeducted = false,
                Name = newName,
                Surname = "Smirnov",
                PhoneNum = "+380945678948"
            };

            if (isCorrect)
            {
                Assert.DoesNotThrow(() => _studentsService.ChangeStudent(studentDTO));
            }
            else
            {
                Assert.Throws(Is.InstanceOf<Exception>()
                .And.Message.EqualTo(message),
              () => _studentsService.ChangeStudent(studentDTO));
            }
        }
    }
}
