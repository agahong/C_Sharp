﻿namespace _0507DLL
{
    class Cal
    {
        public float Result { get; private set; }

        public void Add(int num1, int num2) { Result = (float)num1 + num2; }
        public void Sub(int num1, int num2) { Result = (float)num1 - num2; }
        public void Mul(int num1, int num2) { Result = (float)num1 * num2; }
        public void Div(int num1, int num2) { Result = (float)num1 / num2; }
    }
}
