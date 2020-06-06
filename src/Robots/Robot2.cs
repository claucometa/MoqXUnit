using System;

namespace MoqXUnit
{
    public class Robot2 : IRobot
    {
        public void Run()
        {
            throw new Exception("2");
        }
    }
}