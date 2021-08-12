using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UtopiaCity.Data;
using UtopiaCity.Helpers.AutoMapper;
using UtopiaCity.Services.Sport;

namespace UtopiaCityTest.Controllers.Sport
{
    public abstract class DbContextAndServiceMocking<T> where T : class
    {
        protected Mock<T> _serviceMock;
        protected static IMapper _mapper;

        public void BasicMocking()
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
        }
    }
}
