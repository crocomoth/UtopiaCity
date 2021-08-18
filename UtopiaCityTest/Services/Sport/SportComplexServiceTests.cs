using UtopiaCity.Data;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using Xunit;
using System.Linq;
using UtopiaCityTest.Common.ObjectsForTests;

namespace UtopiaCityTest.Services.Sport
{
    public class SportComplexServiceTests : BaseServiceTest
    {
        private readonly SportComplex _sportComplexForTests;
        private readonly SportComplex[] _sportComplexesForTests;

        public SportComplexServiceTests()
        {
            Setup();
            _sportComplexForTests = SportObjectsForTests.SportComplexForTests();
            _sportComplexesForTests = SportObjectsForTests.ArrayOfSportComplexesForTests();
        }

        [Fact]
        public void GetAllSportComplexes_ReturnsItems_IfItExistsInDb()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.AddRange(_sportComplexesForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportComplexService(context);

                //act
                var result = service.GetAllSportComplexes();

                //assert
                Assert.NotNull(result);
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
                context.SportComplex.Add(_sportComplexForTests);
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
                service.AddSportComplexToDb(_sportComplexForTests);
            }

            using (var context = new ApplicationDbContext(options))
            {
                //act
                var result = context.SportComplex.FirstOrDefault(x => x.SportComplexId.Equals(_sportComplexForTests.SportComplexId));

                //assert
                Assert.NotNull(result);
                Assert.Equal(_sportComplexForTests.SportComplexId, result.SportComplexId);
            }
        }

        [Fact]
        public void RemoveSportComplexFromDb_RemovesItem()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.Add(_sportComplexForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportComplexService(context);
                service.RemoveSportComplexFromDb(_sportComplexForTests);

                //act 
                var result = context.SportComplex.Any(x => x.SportComplexId.Equals(_sportComplexForTests.SportComplexId));

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
                context.SportComplex.Add(_sportComplexForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportComplexService(context);
                service.UpdateSportComplexInDb(new SportComplex
                {
                    SportComplexId = _sportComplexForTests.SportComplexId,
                    Title = "New Title",
                    BuildDate = _sportComplexForTests.BuildDate,
                    NumberOfSeats = 100,
                    Address = "new address",
                    TypeOfSport = _sportComplexForTests.TypeOfSport,
                    SportEvents = null
                });

                //act
                var result = context.SportComplex.FirstOrDefault(x => x.SportComplexId.Equals(_sportComplexForTests.SportComplexId));

                //assert
                Assert.NotNull(result);
                Assert.Equal(_sportComplexForTests.SportComplexId, result.SportComplexId);
                Assert.Equal("New Title", result.Title);
                Assert.Equal(_sportComplexForTests.BuildDate, result.BuildDate);
                Assert.Equal(100, result.NumberOfSeats);
                Assert.Equal("new address", result.Address);
                Assert.Equal(_sportComplexForTests.TypeOfSport, result.TypeOfSport);
                Assert.Null(result.SportEvents);
            }
        }
    }
}
