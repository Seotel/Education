﻿using System;

namespace TestingLibrary
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Add()
        {
            return this.FirstNumber + this.SecondNumber;
        }
    }
}