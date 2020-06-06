using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Xunit;

namespace MoqXUnit
{
    public class UnitTest1 : IClassFixture<TestFixture>
    {
        private readonly IServiceProvider serviceProvider;

        public UnitTest1(TestFixture fixture)
        {
            this.serviceProvider = fixture.ServiceProvider;
        }

        [Theory]
        [InlineData(Robots.Robo1)]
        [InlineData(Robots.Robo2)]
        [InlineData(Robots.Robo3)]
        public void TestMockRobot(Robots tipo)
        {
            Workflow workflow = new Workflow((key) => new Mock<IRobot>().Object);
            workflow.Run(tipo);
        }

        [Theory]
        [InlineData(Robots.Robo1, "1")]
        [InlineData(Robots.Robo2, "2")]
        [InlineData(Robots.Robo3, "3")]
        public void TestRobot(Robots tipo, string result)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<BusinessContext>();

            try
            {
                context.Workflow.Run(tipo);
            }
            catch (Exception e)
            {
                Assert.Equal(result, e.Message);
            }
        }
    }
}
