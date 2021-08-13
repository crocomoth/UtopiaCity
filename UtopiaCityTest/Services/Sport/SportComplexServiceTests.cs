using Microsoft.EntityFrameworkCore;
using System;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCity.Models.Sport.Enums;
using Xunit;
using System.Linq;

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
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.AddRange(ArrayOfSportComplexesForTests());
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportComplexService(context);

                //act
                var result = service.GetAllSportComplexes();

                //assert
                Assert.Equal(3, result.Count);
                Assert.Collection(result,
                    item => { Assert.Equal("1", item.SportComplexId); },
                    item => { Assert.Equal("2", item.SportComplexId); },
                    item => { Assert.Equal("3", item.SportComplexId); }
                );
            }
        }

        [Fact]
        public void GetSportComplexById_ReturnsItem_IfItExistsInDb()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.AddRange(ArrayOfSportComplexesForTests());
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportComplexService(context);

                //act
                var result = service.GetSportComplexById("1");

                //assert
                Assert.Equal("1", result.SportComplexId);
            }
        }

        [Fact]
        public void AddSportComplexToDb_AddsNewItem()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportComplexService(context);
                service.AddSportComplexToDb(sportComplexForTests);
            }

            using (var context = new ApplicationDbContext(options))
            {
                //act
                var result = context.SportComplex.FirstOrDefault(x => x.SportComplexId.Equals(sportComplexForTests.SportComplexId));

                //assert
                Assert.Equal(sportComplexForTests.SportComplexId, result.SportComplexId);
            }
        }

        [Fact]
        public void RemoveSportComplexFromDb_RemovesItem()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.Add(sportComplexForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportComplexService(context);
                service.RemoveSportComplexFromDb(sportComplexForTests);

                //act 
                var result = context.SportComplex.Any(x => x.SportComplexId.Equals(sportComplexForTests.SportComplexId));

                //assert
                Assert.Equal(bool.FalseString, result.ToString());
            }
        }

        [Fact]
        public void UpdateSportComplexInDb_UpdatesItem()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.Add(sportComplexForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportComplexService(context);
                service.UpdateSportComplexInDb(new SportComplex
                {
                    SportComplexId = sportComplexForTests.SportComplexId,
                    Title = "New Title",
                    BuildDate = sportComplexForTests.BuildDate,
                    NumberOfSeats = 100,
                    Address = "new address",
                    TypeOfSport = sportComplexForTests.TypeOfSport,
                    SportEvents = null
                });

                //act
                var result = context.SportComplex.FirstOrDefault(x => x.SportComplexId.Equals(sportComplexForTests.SportComplexId));

                //assert
                Assert.Equal(sportComplexForTests.SportComplexId, result.SportComplexId);
                Assert.Equal("New Title", result.Title);
                Assert.Equal(sportComplexForTests.BuildDate, result.BuildDate);
                Assert.Equal(100, result.NumberOfSeats);
                Assert.Equal("new address", result.Address);
                Assert.Equal(sportComplexForTests.TypeOfSport, result.TypeOfSport);
                Assert.Null(result.SportEvents);
            }
        }

        private SportComplex sportComplexForTests = new SportComplex
        {
            SportComplexId = "55",
            Title = "SportComplex",
            BuildDate = new DateTime(2001, 10, 15),
            NumberOfSeats = 550,
            Address = "address",
            TypeOfSport = TypesOfSport.Basketball,
            SportEvents = null
        };

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
