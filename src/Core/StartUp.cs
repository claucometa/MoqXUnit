using Microsoft.Extensions.DependencyInjection;
using System;

namespace MoqXUnit
{
    public class StartUp
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public StartUp()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<BusinessContext>();
            collection.AddScoped<Workflow>();
            collection.AddScoped<IProdutoRepo, ProdutoRepo>();
            collection.AddScoped<Func<Robots, IRobot>>(
                ServiceProvider => key =>
                {
                    switch (key)
                    {
                        case Robots.Robo1: return ServiceProvider.GetService<Robot1>();
                        case Robots.Robo2: return ServiceProvider.GetService<Robot2>();
                        case Robots.Robo3: return ServiceProvider.GetService<Robot3>();
                        default: return null;
                    }
                });

            ServiceProvider = collection.BuildServiceProvider();
        }
    }
}