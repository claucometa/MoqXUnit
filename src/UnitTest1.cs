using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MoqXUnit
{
    public class UnitTest1 : IClassFixture<StartUp>
    {
        private readonly ServiceProvider serviceProvider;

        public UnitTest1(StartUp fixture)
        {
            this.serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void TestRobo1()
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<BusinessContext>();
            context.workflow.Run(Robots.Robo1);
        }
        
        [Fact]
        public void TestRobo2()
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<BusinessContext>();
            context.workflow.Run(Robots.Robo2);
        }

        [Fact]
        public void TestRobo3()
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<BusinessContext>();
            context.workflow.Run(Robots.Robo3);
        }
    }
}
