using AutoMapper;
using Xunit;

namespace TCO.SNT.Tests
{
    public class AutomapperTests
    {
        [Fact]
        public void Test_Configuration_Is_Valid()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddMaps("TCO.SNT.UseCases");
                cfg.AddMaps("TCO.EInvoicing.UseCases");
            });

            // Assert
            config.AssertConfigurationIsValid();

        }
    }
}
