using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RosetteStore.Domain.Abstract;
using RosetteStore.Domain.Entities;
using RosetteStore.WebUI.Controllers;
using RosetteStore.WebUI.Models;

namespace RosetteStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Generate_Category_Specific_Game_Count()
        {
            /// Организация (arrange)
            Mock<IRosetteRepository> mock = new Mock<IRosetteRepository>();
            mock.Setup(m => m.Rosettes).Returns(new List<Rosette>
    {
        new Rosette { RosetteId = 1, Name = "Игра1", Category="Cat1"},
        new Rosette { RosetteId = 2, Name = "Игра2", Category="Cat2"},
        new Rosette { RosetteId = 3, Name = "Игра3", Category="Cat1"},
        new Rosette { RosetteId = 4, Name = "Игра4", Category="Cat2"},
        new Rosette { RosetteId = 5, Name = "Игра5", Category="Cat3"}
    });
            RosetteController controller = new RosetteController(mock.Object);
            controller.pageSize = 3;

            // Действие - тестирование счетчиков товаров для различных категорий
            int res1 = ((RosettesListViewModel)controller.List("Cat1").Model).PagingInfo.TotalItems;
            int res2 = ((RosettesListViewModel)controller.List("Cat2").Model).PagingInfo.TotalItems;
            int res3 = ((RosettesListViewModel)controller.List("Cat3").Model).PagingInfo.TotalItems;
            int resAll = ((RosettesListViewModel)controller.List(null).Model).PagingInfo.TotalItems;

            // Утверждение
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);
        }
    }
}
