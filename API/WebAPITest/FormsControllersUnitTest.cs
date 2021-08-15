using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using WebAPI.Controllers;
using WebAPI.Models;
using WebAPI.Services;
using Xunit;

namespace WebAPITest
{
    public class FormsControllersUnitTest
    {
        private readonly Mock<IFormServices> _mockFormService;
        private readonly FormsController _formController;
        private readonly FormDataController _formDataController;
        public FormsControllersUnitTest()
        {
            _mockFormService = new Mock<IFormServices>();
            _formController = new FormsController(_mockFormService.Object);
            _formDataController = new FormDataController(_mockFormService.Object);
        }

        [Fact]
        public async void Test_AddForm_ReturnsResult_ReturnValue()
        {
            //Arrange
            var newForm = new Form
            {
                FormName = "My new Test Form",
                
            };
            _mockFormService.Setup(x => x.AddForm(newForm)).ReturnsAsync(1);

            //Act
            var response = await _formController.AddForm(newForm);

            //Assert
            //Expected 1, Actual result.Value
            var result = Assert.IsType<CreatedAtActionResult>(response);
            Assert.Equal(1, result.Value);
        }

        [Fact]
        public async void Test_AddFormData_ReturnsResult_ReturnValue()
        {
            //Arrange
            var newFormData = new FormData
            {
                FormId = 1,
                FormItem = "TestData11~TestData12~TestData13~TestData14~TestData15",
            };
            _mockFormService.Setup(x => x.AddFormData(newFormData)).ReturnsAsync(2);

            //Act
            var response = await _formDataController.AddFormData(newFormData);

            //Assert
            //Expected 1, Actual result.Value
            var result = Assert.IsType<CreatedAtActionResult>(response);
            Assert.Equal(2, result.Value);
        }

        [Fact]
        public async void Test_UpdateFormData_ReturnsResult_ReturnValue()
        {
            //Arrange
            var updatedFormData = new FormData
            {
                FormDataId= 1,
                FormItem = "TestData11~TestData12~TestData13~TestData14~TestData15",
            };
            _mockFormService.Setup(x => x.UpdateFormData(updatedFormData)).ReturnsAsync(1);

            //Act
            var response = await _formDataController.UpdateFormData(updatedFormData);

            //Assert
            //Expected 1, Actual result.Value
            var result = Assert.IsType<OkResult>(response);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void Test_DaleteFormData_Return_StatusCode()
        {
            //Arrange
            var formDataId = 1;
            _mockFormService.Setup(x => x.DeleteFormData(formDataId)).ReturnsAsync(1);

            //Act
            var response = await _formDataController.DeleteFormData(formDataId);

            //Assert
            //Expected 200, Actual result.StatusCode
            var result = Assert.IsType<OkResult>(response);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
