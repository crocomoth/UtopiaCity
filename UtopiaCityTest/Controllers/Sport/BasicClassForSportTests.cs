using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UtopiaCityTest.Controllers.Sport
{
    public static class BasicClassForSportTests
    {
        public static Mock<T> CreateDbContextMock<T>() where T : DbContext => new Mock<T>(new DbContextOptions<T>());

        public static Mock<K> CreateServiceMock<T, K>(Mock<T> context) where T : DbContext where K : class => new Mock<K>(context.Object);

        public static IMapper ConfigMapper(params Profile[] profiles)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                foreach(Profile profile in profiles)
                {
                    mc.AddProfile(profile);
                }
            });

            return mappingConfig.CreateMapper();
        }
    }
}
