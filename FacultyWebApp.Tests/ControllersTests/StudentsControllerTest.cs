using FacultyWebApp.API.Controllers;
using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.BLL.Infrastructure;
using FacultyWebApp.BLL.Interfaces;
using FacultyWebApp.Domain.ActionModels;
using FacultyWebApp.Domain.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.Tests.ControllersTests
{
    public class StudentsControllerTest
    {
        private Mock<IStudentsService> _mockStudentsService;
        private Mock<ILogger<StudentsController>> _mockLogger;
        private StudentsController _studentsController;

        [SetUp]
        public void Initialize()
        {
            _mockStudentsService = new Mock<IStudentsService>();
            _mockLogger = new Mock<ILogger<StudentsController>>();

            //InitData
            _mockStudentsService.Setup(x => x.AllByFilters(It.IsAny<StudentListRequestModel>())).Throws(new ValidationException("Count of students by filter is 0", "Count"));
            _mockStudentsService.Setup(x => x.AllByFilters(It.Is<StudentListRequestModel>(x=>x.GroupId==1))).Returns(GetTestStudents);


            _mockStudentsService.Setup(x => x.AddStudent(It.IsAny<StudentDTO>()));
            _mockStudentsService.Setup(x => x.AddStudent(It.Is<StudentDTO>(x => x.PhoneNum == "+3806311"))).Throws(new ValidationException("Student was not founded", "id"));
            _mockStudentsService.Setup(x => x.AddStudent(It.Is<StudentDTO>(x => x.PhoneNum == "+380631190944"))).Throws(new Exception("Sample ex."));


            _mockStudentsService.Setup(x => x.ChangeStudent(It.IsAny<StudentDTO>()));
            _mockStudentsService.Setup(x => x.ChangeStudent(It.Is<StudentDTO>(x => x.Id == Guid.Parse("f3d58855-29e0-4d1a-a788-fec3d388c856")))).Throws(new ValidationException("Student was not founded", "id"));



            _mockStudentsService.Setup(x => x.GetStudentById(It.IsAny<Guid>())).Returns(() => throw new ValidationException("Student was not founded", "id"));
            _mockStudentsService.Setup(x => x.GetStudentById(Guid.Parse("9e254fbe-97eb-47b9-a751-0219689c62a5"))).Returns(() => new StudentDTO()
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

            //CreateController
            _studentsController = new StudentsController(_mockStudentsService.Object, _mockLogger.Object);
        }

        [Test]
        [TestCase(true,1, "Successfuly founded")]
        [TestCase(false, 3, "Count of students by filter is 0")]
        public void GetStudentsTest(bool isCorrect,int groupId, string statusMessage)
        {
            var result = _studentsController.AllByFilters(new StudentListRequestModel() { GroupId=groupId});
            if (isCorrect)
            {
                Assert.IsInstanceOf<OkObjectResult>(result, "Instance success result");
                AppResponseResult response = (AppResponseResult)((ObjectResult)result).Value;
                Assert.AreEqual(true, response.IsSuccessful);
                Assert.AreEqual(statusMessage, response.Message);
                Assert.IsNotNull(response.ResObj);
                Assert.AreEqual(2, ((List<StudentDTO>)response.ResObj).Count, "Count compare");
            }
            else
            {
                Assert.IsInstanceOf<BadRequestObjectResult>(result, "Instance badReques result");
                AppResponseResult response = (AppResponseResult)((ObjectResult)result).Value;
                Assert.AreEqual(false, response.IsSuccessful);
                Assert.AreEqual(statusMessage, response.Message);
                Assert.Null(response.ResObj);
            }

        }

        [Test]
        [TestCase("+380631190911", true, false, "Successfuly added")]
        [TestCase("+3806311", false, true, "ErrorPhoneNum")]
        [TestCase("+380631190944", false, false, "Error with student.")]
        public void AddStudentTest(string phoneNum, bool isCorrect, bool haveModelErorr, string statusMessage)
        {
            var student = new StudentDTO()
            {
                EducationTypeId = 1,
                EntryYear = 1,
                GroupId = 1,
                IsDeducted = false,
                Name = "Vitaliy",
                Surname = "Klichko",
                PhoneNum = phoneNum
            };

            if (haveModelErorr)
            {
                _studentsController.ModelState.AddModelError("PhoneNum", "ErrorPhoneNum");
            }

            var result = _studentsController.CreateStudent(student);

            if (isCorrect)
            {
                Assert.IsInstanceOf<OkObjectResult>(result, "Instance success result");
                AppResponseResult response = (AppResponseResult)((ObjectResult)result).Value;
                Assert.AreEqual(true, response.IsSuccessful);
                Assert.AreEqual(statusMessage, response.Message);
                Assert.IsNull(response.ResObj);
            }
            else
            {
                AppResponseResult response = (AppResponseResult)((ObjectResult)result).Value;
                Assert.AreEqual(false, response.IsSuccessful);
                Assert.NotNull(response.ResObj);
                if (response.Message.StartsWith("Error with student."))
                {
                    Assert.AreEqual("Error with dbcontext.", ((List<string>)response.ResObj)[0], "Compare errors");
                }
                else if (response.Message.StartsWith("One or more errors occured"))
                {
                    Assert.AreEqual("ErrorPhoneNum", ((List<string>)response.ResObj)[0], "Compare errors");
                }

            }
        }

        [Test]
        [TestCase("9e254fbe-97eb-47b9-a751-0219689c62a5", "+380631190911", true, false, "Successfuly updated")]
        [TestCase("f3d58855-29e0-4d1a-a788-fec3d388c856", "+380631190911", false, false, "Student was not founded")]
        [TestCase("9e254fbe-97eb-47b9-a751-0219689c62a5", "+3806311", false, true, "ErrorPhoneNum")]
        public void ChangeStudentTest(string id, string phoneNum, bool isCorrect, bool haveModelErorr, string statusMessage)
        {
            var student = new StudentDTO()
            {
                Id = Guid.Parse(id),
                EducationTypeId = 1,
                EntryYear = 1,
                GroupId = 1,
                IsDeducted = false,
                Name = "Vitaliy",
                Surname = "Klichko",
                PhoneNum = phoneNum
            };

            if (haveModelErorr)
            {
                _studentsController.ModelState.AddModelError("PhoneNum", "ErrorPhoneNum");
            }

            var result = _studentsController.ChangeStudent(student);
            if (isCorrect)
            {
                Assert.IsInstanceOf<OkObjectResult>(result, "Instance success result");
                AppResponseResult response = (AppResponseResult)((ObjectResult)result).Value;
                Assert.AreEqual(true, response.IsSuccessful);
                Assert.AreEqual(statusMessage, response.Message);
                Assert.IsNull(response.ResObj);
            }
            else
            {
                AppResponseResult response = (AppResponseResult)((ObjectResult)result).Value;
                switch (response.StatusCode)
                {
                    case 404:
                        Assert.AreEqual(false, response.IsSuccessful);
                        Assert.AreEqual(statusMessage, response.Message);
                        Assert.AreEqual(null, response.ResObj);
                        break;
                    case 400:
                        Assert.AreEqual(false, response.IsSuccessful);
                        Assert.NotNull(response.ResObj);
                        Assert.AreEqual("ErrorPhoneNum", ((List<string>)response.ResObj)[0], "Compare errors");
                        break;
                }
            }
        }

        [Test]
        [TestCase("9e254fbe-97eb-47b9-a751-0219689c62a5", true, "Successfuly founded")]
        [TestCase("d670ab36-a10d-4e77-b529-5c587369d8d0", false, "Student was not founded")]
        [TestCase("d670ab36-a10d-4e77-b529-5c587369d8d1", false, "Student was not founded")]
        public void GetStudentByIdTest(string id, bool isCorrect, string statusMessage)
        {
            var result = _studentsController.GetStudentById(Guid.Parse(id));
            if (isCorrect)
            {
                Assert.IsInstanceOf<OkObjectResult>(result, "Instance success result");
                AppResponseResult response = (AppResponseResult)((ObjectResult)result).Value;
                Assert.AreEqual(true, response.IsSuccessful);
                Assert.AreEqual(statusMessage, response.Message);
                Assert.IsNotNull(response.ResObj);
                Assert.IsAssignableFrom<StudentDTO>(response.ResObj);
            }
            else
            {
                AppResponseResult response = (AppResponseResult)((ObjectResult)result).Value;
                switch (response.StatusCode)
                {
                    case 404:
                        Assert.AreEqual(false, response.IsSuccessful);
                        Assert.AreEqual(statusMessage, response.Message);
                        Assert.AreEqual(null, response.ResObj);
                        break;
                    case 400:
                        Assert.AreEqual(false, response.IsSuccessful);
                        Assert.AreEqual(null, response.ResObj);
                        break;
                }
            }
        }


        #region Contsants
        private StudentListRequestModel GetModel()
        {
            return new StudentListRequestModel()
            {
                GroupId = 1
            };
        }

        private List<StudentDTO> GetTestStudents()
        {
            return new List<StudentDTO>()
            {
                new StudentDTO()
                {
                    Id=Guid.Parse("9e254fbe-97eb-47b9-a751-0219689c62a5"),
                    EducationTypeId=1,
                    EntryYear=1,
                    GroupId=1,
                    IsDeducted=false,
                    Name="Andrew",
                    Surname="Smirnov",
                    PhoneNum="+380945678948"
                },
                new StudentDTO()
                {
                    Id=Guid.Parse("d670ab36-a10d-4e77-b529-5c587369d8d0"),
                    EducationTypeId=1,
                    EntryYear=1,
                    GroupId=1,
                    IsDeducted=false,
                    Name="Viktor",
                    Surname="Coi",
                    PhoneNum="+380789489456"
                }
            };
        }
        #endregion
    }
}
