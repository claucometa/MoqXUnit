using System;

namespace MoqXUnit
{
    public class Robot1 : IRobot
    {
        public void Run()
        {
            throw new Exception("1");
        }
    }
}