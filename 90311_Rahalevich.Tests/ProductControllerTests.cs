using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using _90311_Rahalevich.Controllers;
using _90311_Rahalevich.DAL.Entities;
using Xunit;
using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Moq;

namespace _90311_Rahalevich.Tests
{
    public class ProductControllerTests
    {
        //[Theory]
        //[MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        //public void ControllerGetsProperPage(int page, int qty, int id)
        //{
        //    // Arrange
        //    var controller = new ProductController();
        //    controller._insulins = TestData.GetInsulinsList();
        //    // Act
        //    var result = controller.Index(pageNo: page, group: null) as ViewResult;
        //    var model = result?.Model as List<Insulin>;
        //    // Assert
        //    Assert.NotNull(model);
        //    Assert.Equal(qty, model.Count);
        //    Assert.Equal(id, model[0].InsulinId);
        //}
        [Fact]
        public void ControllerSelectsGroup()
        {
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());

            controllerContext.HttpContext = moqHttpContext.Object;
            var controller = new ProductController()
            { ControllerContext = controllerContext };
        }

    }
}

