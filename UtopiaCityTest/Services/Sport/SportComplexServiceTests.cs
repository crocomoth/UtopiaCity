using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCity.Models.Sport.Enums;
using Xunit;

namespace UtopiaCityTest.Services.Sport
{
    public class SportComplexServiceTests : BaseServiceTest
    {
        public SportComplexServiceTests()
        {
            Setup();
        }

        [Fact]
        public void GetAllSportComplexes_ReturnsItems_IfItExistsInDb()
        {
            //arrange
            var localOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "UtopiaCityTest").Options;
            using(var context = new ApplicationDbContext(localOptions))
            {
                context.SportComplex.AddRange(ArrayOfSportComplexesForTests());
                context.SaveChanges();
            }

            using(var context = new ApplicationDbContext(localOptions))
            {
                var service = new SportComplexService(context);

                //act
                var result = service.GetAllSportComplexes();

                //assert
                Assert.Equal(3, result.Count);
                /*Assert.Equal("1", result[0].SportComplexId);
                Assert.Equal("2", result[1].SportComplexId);
                Assert.Equal("3", result[2].SportComplexId);*/
                Assert.Collection(result, 
                    item => item.SportComplexId.Equals("9"), 
                    item => item.SportComplexId.Equals("4"), 
                    item => item.SportComplexId.Equals("5"));
            }
        }

        /*public void GetSportComplexById_ReturnsItem_IfItExistsInDb()
        {

        }*/

        private SportComplex[] ArrayOfSportComplexesForTests()
        {
            SportComplex[] sportComplexes = new SportComplex[]
                {
                    new SportComplex
                    {
                        SportComplexId = "1",
                        Title = "title_1",
                        NumberOfSeats = 100,
                        TypeOfSport = TypesOfSport.Athletics,
                        Address = "address_1",
                        BuildDate = new DateTime(2021, 10, 12),
                        SportEvents = null
                    },

                    new SportComplex
                    {
                        SportComplexId = "2",
                        Title = "title_2",
                        NumberOfSeats = 200,
                        TypeOfSport = TypesOfSport.FigureSkating,
                        Address = "address_2",
                        BuildDate = new DateTime(2022, 10, 12),
                        SportEvents = null
                    },

                    new SportComplex
                    {
                        SportComplexId = "3",
                        Title = "title_3",
                        NumberOfSeats = 300,
                        TypeOfSport = TypesOfSport.Motorsport,
                        Address = "address_3",
                        BuildDate = new DateTime(2023, 10, 12),
                        SportEvents = null
                    },
                };

            return sportComplexes;
        }
    }
}
