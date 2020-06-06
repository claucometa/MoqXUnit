using Microsoft.Extensions.DependencyInjection;
using System;

namespace MoqXUnit
{
    public class TestFixture
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public TestFixture()
        {
            var collection = new ServiceCollection();

            ConfigureServices(collection);

            ServiceProvider = collection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection collection)
        {
            collection.AddSingleton<Workflow>();
            collection.AddSingleton<BusinessContext>();
            collection.AddSingleton<Robot1>();
            collection.AddSingleton<Robot2>();
            collection.AddSingleton<Robot3>();
            collection.AddScoped<IProdutoRepo, ProdutoRepo>();
            collection.AddScoped<Func<Robots, IRobot>>(
                ServiceProvider => key => RobotSelector(key));
        }

        private IRobot RobotSelector(Robots arg) => 
            arg switch {
                Robots.Robo1 => new Robot1(),
                Robots.Robo2 => new Robot2(),
                Robots.Robo3 => new Robot3(),
                _ => null };
    }
}