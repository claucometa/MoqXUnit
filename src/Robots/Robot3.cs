using System;

namespace MoqXUnit
{
    public class Robot3 : IRobot
    {
        public void Run()
        {
            throw new Exception("3");
        }
    }
}