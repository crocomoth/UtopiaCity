using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using UtopiaCity.Data;
using UtopiaCity.Helpers.AutoMapper;
using UtopiaCity.Models.Sport;
using UtopiaCity.Models.Sport.Enums;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCityTest.Controllers.Sport
{
    public class BasicClassForSportTests<T> where T : class
    {
        protected Mock<T> _serviceMock;
        protected static IMapper _mapper;
        protected static SportComplex SportComplexForTests;
        protected static SportComplexViewModel SportComplexViewModelForTests;

        public BasicClassForSportTests()
        {
            var applicationDbContextMock = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            _serviceMock = new Mock<T>(applicationDbContextMock.Object);
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new SportComplexProfile());
                    mc.AddProfile(new SportEventProfile());
                });

                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            if (SportComplexForTests == null)
            {
                SportComplexForTests = new SportComplex()
                {
                    SportComplexId = "1",
                    Title = "Title",
                    Address = "address",
                    NumberOfSeats = 100,
                    TypeOfSport = TypesOfSport.Athletics,
                    BuildDate = new DateTime(2021, 8, 10)
                };
            }

            if (SportComplexViewModelForTests == null)
            {
                SportComplexViewModelForTests = _mapper.Map<SportComplexViewModel>(SportComplexForTests);
            }
        }
    }
}
