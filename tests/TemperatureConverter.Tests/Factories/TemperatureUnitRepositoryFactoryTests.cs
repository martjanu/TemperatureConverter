using TemperaturConverter.Domain.Core.Factories;
using TemperaturConverter.Domain.Core.Repositories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Models;

namespace TemperaturConverter.Tests.Factories
{
    public class TemperatureUnitRepositoryFactoryTests
    {
        [Fact]
        public void Create_ShouldReturn_NotNull()
        {
            // Arrange
            var factory = new TemperatureUnitRepositoryFactory();

            // Act
            var repository = factory.Create();

            // Assert
            Assert.NotNull(repository);
        }

        [Fact]
        public void Create_ShouldReturn_ITemperatureUnitRepository()
        {
            // Arrange
            var factory = new TemperatureUnitRepositoryFactory();

            // Act
            var repository = factory.Create();

            // Assert
            Assert.IsAssignableFrom<ITemperatureUnitRepository>(repository);
        }

        [Fact]
        public void Create_ShouldReturn_TemperatureUnitRepositoryInstance()
        {
            // Arrange
            var factory = new TemperatureUnitRepositoryFactory();

            // Act
            var repository = factory.Create();

            // Assert
            Assert.IsType<TemperatureUnitRepository>(repository);
        }

        [Fact]
        public void Create_WithUnits_ShouldContainProvidedUnits()
        {
            // Arrange
            var factory = new TemperatureUnitRepositoryFactory();
            var units = new Dictionary<string, ITemperatureUnit>
            {
                ["celsius"] = new CelsiusUnit(),
                ["fahrenheit"] = new FahrenheitUnit()
            };

            // Act
            var repository = factory.Create(units);

            // Assert
            Assert.NotNull(repository.GetUnit("celsius"));
            Assert.NotNull(repository.GetUnit("fahrenheit"));
        }
    }
}
