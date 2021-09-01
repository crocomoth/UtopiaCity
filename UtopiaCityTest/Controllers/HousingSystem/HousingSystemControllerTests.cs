using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using UtopiaCity.Controllers.HousingSystem;
using UtopiaCity.Data;
using UtopiaCity.Models.HousingSystem;
using UtopiaCity.Services.CityAdministration;
using UtopiaCity.Services.HousingSystem;
using Xunit;

namespace UtopiaCityTest.Controllers.HousingSystem
{
    public class HousingSystemControllerTests : IDisposable
    {

        private HousingSystemController controller;
        private Mock<RealEstateService> serviceMock;
        private Mock<ResidentAccountService> foreignServiceMock;
        private IMailService mailService;
        private IMapper mapper;

        public HousingSystemControllerTests()
        {
            var applicationDbContextMock = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            serviceMock = new Mock<RealEstateService>(applicationDbContextMock.Object);
            foreignServiceMock = new Mock<ResidentAccountService>(applicationDbContextMock.Object);
            controller = new HousingSystemController(serviceMock.Object, mailService, mapper,  foreignServiceMock.Object);
        }

        public void Dispose()
        {
        }

        [Fact]
        public void Index_ReturnsEmptyView_WhenThereIsNoModel()
        {
            // arrange         
            serviceMock.Setup(x => x.GetRealEstates()).ReturnsAsync(() => new List<RealEstate>());

            // act
            var result = controller.Index().GetAwaiter().GetResult();

            // assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
            Assert.True(viewResult.ViewName == "RealEstateListView");
        }

        [Fact]
        public void Index_ReturnsViewWithModel_WhenThereIsModel()
        {
            // arrange
            var model = new RealEstate
            {
                Id = "1",
                Street = "Test",
                Number = "Test",
                EstateType = RealEstateType.Apartment,
                CompletionYear = 2021
            };

            serviceMock.Setup(x => x.GetRealEstates()).ReturnsAsync(() => new List<RealEstate> { model });

            // act
            var result = controller.Index().GetAwaiter().GetResult();

            // assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
            Assert.True(viewResult.ViewName == "RealEstateListView");

            var viewModel = viewResult.Model as List<RealEstate>;
            Assert.True(viewModel != null);
            Assert.True(viewModel.Count == 1);
            Assert.Equal(model, viewModel[0]);
        }
    }
}
