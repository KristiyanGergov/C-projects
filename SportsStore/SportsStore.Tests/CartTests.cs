﻿namespace SportsStore.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SportsStore.Domain.Entities;
    using System.Linq;
    using Moq;
    using SportsStore.Domain.Abstract;
    using SportsStore.WebUI.Controllers;
    using System.Web.Mvc;
    using SportsStore.WebUI.Models;
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_To_Cart()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
            }.AsQueryable());
            Cart cart = new Cart();
            CartController target = new CartController(mock.Object);
            target.AddToCart(cart, 1, null);
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductID, 1);
        }
        [TestMethod]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock
                .Setup(m => m.Products)
                .Returns(new Product[]
                            {
                                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                            }.AsQueryable());
            Cart cart = new Cart();
            // Arrange - create the controller      
            CartController target = new CartController(mock.Object);
            // Act - add a product to the cart          
            RedirectToRouteResult result = target.AddToCart(cart, 2, "myUrl");
            // Assert          
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }
        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            // Arrange - create a Cart         
            Cart cart = new Cart();
            // Arrange - create the controller  
            CartController target = new CartController(null);
            // Act - call the Index action method
            CartIndexViewModel result = (CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;
            // Assert            
            Assert.AreSame(result.Cart, cart);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
        }
    }
}