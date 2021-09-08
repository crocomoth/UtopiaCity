using System;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Helpers.Automapper;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;
using UtopiaCityTest.Common.ObjectsForTests;
using UtopiaCityTest.Controllers.Sport;
using Xunit;

namespace UtopiaCityTest.Services.Sport
{
    public class RequestToAdministrationServiceTests : BaseServiceTest
    {
        private readonly RequestToAdministration _requestToAdministrationForTests;
        private readonly RequestToAdministration[] _requestsToAdministrationForTests;
        private readonly RequestToAdministrationViewModel[] _requestsToAdministrationViewModelsForTests;
        private readonly SportComplex _sportComplexForTests;
        private readonly SportComplex[] _sportComplexesForTests;

        public RequestToAdministrationServiceTests()
        {
            Setup();
            _sportComplexForTests = SportObjectsForTests.SportComplexForTests();
            _sportComplexesForTests = SportObjectsForTests.ArrayOfSportComplexesForTests();
            _requestToAdministrationForTests = SportObjectsForTests.RequestToAdministrationForTests();
            _requestsToAdministrationForTests = SportObjectsForTests.ArrayOfRequestsToAdministrationForTests();
            _requestsToAdministrationViewModelsForTests = SportObjectsForTests.ArrayOfRequestToAdministrationViewModelsForTests();
        }

        [Fact]
        public async Task GetAllRequestsToAdministration_ReturnsListOfRequestsToAdministrationWithSportComplexes()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.AddRange(_sportComplexesForTests);
                context.RequestsToAdministration.AddRange(_requestsToAdministrationForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new RequestToAdministrationService(context);

                //act
                var result = await service.GetAllRequestsToAdministration();

                //assert
                Assert.Collection(result,
                    item =>
                    {
                        Assert.Equal("1", item.Id);
                        Assert.Equal("1", item.SportComplexId);
                        Assert.NotNull(item.SportComplex);
                    },
                    item =>
                    {
                        Assert.Equal("2", item.Id);
                        Assert.Equal("2", item.SportComplexId);
                        Assert.NotNull(item.SportComplex);
                    },
                    item =>
                    {
                        Assert.Equal("3", item.Id);
                        Assert.Equal("3", item.SportComplexId);
                        Assert.NotNull(item.SportComplex);
                    }
                );
            }
        }

        [Fact]
        public async Task GetRequestsToAdministrationBySportComplexId_ReturnsListOfRequestsToAdministration()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.AddRange(_sportComplexesForTests);
                context.RequestsToAdministration.AddRange(_requestsToAdministrationForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new RequestToAdministrationService(context);

                //act
                var result = await service.GetRequestsToAdministrationBySportComplexId("1");

                //assert
                Assert.Collection(result,
                    item =>
                    {
                        Assert.Equal("1", item.Id);
                        Assert.Equal("1", item.SportComplexId);
                        Assert.NotNull(item.SportComplex);
                    }
                );
            }
        }

        [Fact]
        public async Task GetRequestsToAdministrationByDate_ReturnsListOfRequestsToAdministration()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.AddRange(_sportComplexesForTests);
                context.RequestsToAdministration.AddRange(_requestsToAdministrationForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new RequestToAdministrationService(context);

                //act
                var result = await service.GetRequestsToAdministrationByDate(new DateTime(2001, 1, 1));

                //assert
                Assert.Collection(result,
                    item =>
                    {
                        Assert.Equal(new DateTime(2001, 1, 1), item.DateOfRequest);
                        Assert.Equal("1", item.SportComplexId);
                        Assert.NotNull(item.SportComplex);
                    }
                );
            }
        }

        [Fact]
        public async Task GetRequestToAdministrationById_ReturnsRequestToAdministration()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.Add(_sportComplexForTests);
                context.RequestsToAdministration.Add(_requestToAdministrationForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new RequestToAdministrationService(context);

                //act
                var result = await service.GetRequestToAdministrationById("1");

                //assert
                Assert.NotNull(result);
                Assert.Equal("1", result.Id);
                Assert.Equal("1", result.SportComplexId);
                Assert.NotNull(result.SportComplex);
            }
        }

        [Fact]
        public async Task AddRequestToDbTest()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                var service = new RequestToAdministrationService(context);
                await service.AddRequestToDb(_requestToAdministrationForTests);
            }

            using (var context = new ApplicationDbContext(options))
            {
                //act
                var result = context.RequestsToAdministration.Any(x => x.Id.Equals(_requestToAdministrationForTests.Id));

                //assert
                Assert.True(result);
            }
        }

        [Fact]
        public async Task UpdateRequestInDbTest()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.RequestsToAdministration.Add(_requestToAdministrationForTests);
                context.SaveChanges();
            }
            
            using (var context = new ApplicationDbContext(options))
            {
                var service = new RequestToAdministrationService(context);
                await service.UpdateRequestInDb(new RequestToAdministration {
                    Id = _requestToAdministrationForTests.Id,
                    DateOfRequest = _requestToAdministrationForTests.DateOfRequest,
                    Description = "new_description_1",
                    IsApproved = true,
                    IsReviewed = true,
                    SportComplexId = _requestToAdministrationForTests.SportComplexId
                });

                //act
                var result = context.RequestsToAdministration.FirstOrDefault(x => x.Id.Equals(_requestToAdministrationForTests.Id));

                //assert
                Assert.Equal("1", result.Id);
                Assert.Equal("new_description_1", result.Description);
                Assert.Equal(_requestToAdministrationForTests.DateOfRequest, result.DateOfRequest);
                Assert.True(result.IsApproved);
                Assert.True(result.IsReviewed);
                Assert.Equal("1", result.SportComplexId);
                Assert.Null(result.SportComplex);
            }
        }

        [Fact]
        public async Task RemoveRequestFromDbTest()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.RequestsToAdministration.Add(_requestToAdministrationForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new RequestToAdministrationService(context);
                await service.RemoveRequestFromDb(_requestToAdministrationForTests);

                //act
                var result = context.RequestsToAdministration.Any(x => x.Id.Equals(_requestToAdministrationForTests.Id));

                //assert
                Assert.False(result);
            }
        }

        [Fact]
        public async Task CreatingRequestToAdministrationViewModelTest()
        {
            //arrange
            TearDown();
            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.AddRange(_sportComplexesForTests);
                context.RequestsToAdministration.AddRange(_requestsToAdministrationForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new RequestToAdministrationService(context);
                var requests = await service.GetAllRequestsToAdministration();

                //act
                var result = service.CreatingRequestToAdministationViewModel(requests, BasicClassForSportTests.ConfigMapper(new RequestToAdministrationProfile()));

                //assert
                Assert.Collection(result,
                    item =>
                    {
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[0].Id, item.Id);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[0].Description, item.Description);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[0].DateOfRequest, item.DateOfRequest);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[0].SportComplexId, item.SportComplexId);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[0].SportComplexTitle, item.SportComplexTitle);
                    },

                    item =>
                    {
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[1].Id, item.Id);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[1].Description, item.Description);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[1].DateOfRequest, item.DateOfRequest);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[1].SportComplexId, item.SportComplexId);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[1].SportComplexTitle, item.SportComplexTitle);
                    },

                    item =>
                    {
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[2].Id, item.Id);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[2].Description, item.Description);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[2].DateOfRequest, item.DateOfRequest);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[2].SportComplexId, item.SportComplexId);
                        Assert.Equal(_requestsToAdministrationViewModelsForTests[2].SportComplexTitle, item.SportComplexTitle);
                    }
                );
            }
        }
    }
}
