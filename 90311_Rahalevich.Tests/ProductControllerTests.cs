using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using _90311_Rahalevich.Controllers;
using _90311_Rahalevich.DAL.Entities;
using Xunit;
using System;
using System.Text;

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
            //arrange
            var controller = new ProductController();
            var data = TestData.GetInsulinsList();
            controller._insulins = data;
            var comparer = Comparer<Insulin>.GetComparer((d1, d2) => d1.InsulinId.Equals(d2.InsulinId));
            //act
            var result = controller.Index(2) as ViewResult;
            var model = result.Model as List<Insulin>;
            //assert
            Assert.Equal(2, model.Count);
            Assert.Equal(data[2], model[0], comparer);
        }

    }
}

