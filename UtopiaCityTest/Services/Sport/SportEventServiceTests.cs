using Microsoft.EntityFrameworkCore;
using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCityTest.Common.ObjectsForTests;
using Xunit;

namespace UtopiaCityTest.Services.Sport
{
    public class SportEventServiceTests : BaseServiceTest
    {
        private readonly SportEvent _sportEventForTests;
        private readonly SportEvent[] _sportEventsForTests;
        private readonly SportComplex _sportComplexForTests;
        private readonly SportComplex[] _sportComplexesForTests;

        public SportEventServiceTests()
        {
            Setup();
            _sportEventForTests = SportObjectsForTests.SportEventForTests();
            _sportEventsForTests = SportObjectsForTests.ArrayOfSportEventsForTests();
            _sportComplexForTests = SportObjectsForTests.SportComplexForTests();
            _sportComplexesForTests = SportObjectsForTests.ArrayOfSportComplexesForTests();
        }

        [Fact]
        public void GetAllSportEvents_ReturnsListOfSportEventWithSportComplexes()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.AddRange(_sportComplexesForTests);
                context.SportEvents.AddRange(_sportEventsForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportEventService(context);

                //act
                var result = service.GetAllSportEvents();

                //assert
                Assert.Collection(result,
                    item =>
                    {
                        Assert.Equal("1", item.SportEventId);
                        Assert.Equal("1", item.SportComplexId);
                        Assert.NotNull(item.SportComplex);
                    },
                    item =>
                    {
                        Assert.Equal("2", item.SportEventId);
                        Assert.Equal("2", item.SportComplexId);
                        Assert.NotNull(item.SportComplex);
                    },
                    item =>
                    {
                        Assert.Equal("3", item.SportEventId);
                        Assert.Equal("3", item.SportComplexId);
                        Assert.NotNull(item.SportComplex);
                    }
                );
            }
        }

        [Fact]
        public void GetSportEventById_ReturnsSportEvent_IfExists()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportEvents.Add(_sportEventForTests);
                context.SportComplex.Add(_sportComplexForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportEventService(context);

                //act
                var result = service.GetSportEventById("1");

                //assert
                Assert.Equal("1", result.SportEventId);
                Assert.Equal("title_1", result.Title);
                Assert.Equal("1", result.SportComplexId);
                Assert.Null(result.SportComplex);
            }
        }

        [Fact]
        public void GetSportEventById_ReturnsSportEventWithSportComplex_IfExists()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.Add(_sportComplexForTests);
                context.SportEvents.Add(_sportEventForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportEventService(context);

                //act
                var result = service.GetSportEventByIdWithSportComplex("1");

                //assert
                Assert.Equal("1", result.SportEventId);
                Assert.Equal("1", result.SportComplexId);
                Assert.NotNull(result.SportComplex);
            }
        }

        [Fact]
        public void AddSportEventToDbTest()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportEventService(context);
                service.AddSportEventToDb(_sportEventForTests);
            }

            using (var context = new ApplicationDbContext(options))
            {
                //act
                var result = context.SportEvents.FirstOrDefault(x => x.SportEventId.Equals(_sportEventForTests.SportEventId));

                //assert
                Assert.NotNull(result);
                Assert.Equal(_sportEventForTests.SportEventId, result.SportEventId);
            }
        }

        [Fact]
        public void RemoveSportEventFromDbTest()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportEvents.Add(_sportEventForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportEventService(context);
                service.RemoveSportEventFromDb(_sportEventForTests);

                //act
                var result = context.SportEvents.Any(x => x.SportEventId.Equals(_sportEventForTests.SportEventId));

                //assert
                Assert.Equal(bool.FalseString, result.ToString());
            }
        }

        [Fact]
        public void UpdateSportEventInDbTest()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportEvents.Add(_sportEventForTests);
                context.SportComplex.AddRange(_sportComplexesForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportEventService(context);
                service.UpdateSportEventInDb(new SportEvent
                {
                    SportEventId = _sportEventForTests.SportEventId,
                    Title = "new title_1",
                    DateOfTheEvent = _sportEventForTests.DateOfTheEvent,
                    SportComplexId = "2",
                    SportComplex = null
                });

                //act
                var result = context.SportEvents.Include(s => s.SportComplex).FirstOrDefault(x => x.SportEventId.Equals(_sportEventForTests.SportEventId));

                //assert
                Assert.NotNull(result);
                Assert.Equal(_sportEventForTests.SportEventId, result.SportEventId);
                Assert.Equal("new title_1", result.Title);
                Assert.Equal(_sportEventForTests.DateOfTheEvent, result.DateOfTheEvent);
                Assert.Equal("2", result.SportComplexId);
                Assert.NotNull(result.SportComplex);
            }
        }
    }
}