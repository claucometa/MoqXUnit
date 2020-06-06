using System;

namespace MoqXUnit
{
    public class Workflow
    {
        readonly Func<Robots, IRobot> robot;

        public Workflow(Func<Robots, IRobot> robot)
        {
            this.robot = robot;
        }

        public void Run(Robots tipo)
        {
            var x = robot(tipo);
            x.Run();
        }
    }
}