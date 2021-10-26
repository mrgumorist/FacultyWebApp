using FacultyWebApp.API.Controllers;
using FacultyWebApp.BLL.DTOs;
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
            _mockStudentsService.Setup(x => x.AllByFilters(GetModel())).Returns(GetTestStudents);

            //CreateController
            _studentsController = new StudentsController(_mockStudentsService.Object, _mockLogger.Object);
        }

        [Test]
        public void GetStudents()
        {
            var result =  _studentsController.AllByFilters(GetModel());
            Assert.IsInstanceOf<OkObjectResult>(result, "Instance result");
            var okResult = result as OkObjectResult;
            AppResponseResult appRes = (AppResponseResult)okResult.Value;
            Assert.IsAssignableFrom<AppResponseResult>(
                appRes, "Is needed model");
            Assert.AreEqual(2, ((List<StudentDTO>)appRes.ResObj).Count, "Count compare");
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
