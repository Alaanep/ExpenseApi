﻿using System;
namespace BirdLayingEggsEx
{
    public class BrokenEgg: Egg
    {
        public BrokenEgg(double size, string color): base(0, $"broken {color}")
        {
            Console.WriteLine("A bird laid a broken egg");
        }
    }
}
