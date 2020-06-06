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

        [Fact]
        public void TestMockRobotInterface()
        {
            Workflow workflow = new Workflow((key) => new Mock<IRobot>().Object);
            workflow.Run(Robots.Robo1);
        }

        [Theory]
        [InlineData(Robots.Robo1)]
        [InlineData(Robots.Robo2)]
        [InlineData(Robots.Robo3)]
        public void TestWorkflow(Robots tipo)
        {
            Workflow workflow = new Workflow((key) => TestFixture.RobotSelector(key));

            try
            {
                workflow.Run(tipo);
            }
            catch (Exception e)
            {
                Assert.EndsWith(e.Message, tipo.ToString());
            }
        }

        [Theory]
        [InlineData(Robots.Robo1)]
        [InlineData(Robots.Robo2)]
        [InlineData(Robots.Robo3)]
        public void TestBusinessScope(Robots tipo)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<BusinessContext>();

            try
            {
                context.Workflow.Run(tipo);
            }
            catch (Exception e)
            {
                Assert.EndsWith(e.Message, tipo.ToString());
            }
        }
    }
}
