using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public class Binary
    {
        /* Write a function that takes an unsigned integer and return the number of '1' bits it has (also known as the Hamming weight).
         */
        public int HammingWeight(uint n)
        {
            int numberOfOne = 0;

            string nString = Convert.ToString(n, toBase: 2);

            foreach (char c in nString)
            {
                if (c == '1')
                {
                    numberOfOne++;
                }
            }

            return numberOfOne;
        }

        // Calculate the sum of two integers a and b, but you are Not allowed to use the operator + and -.
        public int SumOfTwoInteger(int a, int b)
        {
            string binaryA = Convert.ToString(a, 2).PadLeft(32, '0');
            string binaryB = Convert.ToString(b, 2).PadLeft(32, '0');
            int sum;
            StringBuilder sumBinary = new StringBuilder();
            char carry = '0';

            for (int i = binaryA.Length - 1; i > -1; --i)
            {
                int sumChar = Convert.ToInt32(binaryA[i].ToString()) ^ Convert.ToInt32(binaryB[i].ToString()) ^ Convert.ToInt32(carry.ToString());
                int carryNum;

                if (binaryA[i] == '0')
                {
                    carryNum = Convert.ToInt32(carry.ToString()) & Convert.ToInt32(binaryB[i].ToString()) ^ 0;
                }
                else
                {
                    carryNum = Convert.ToInt32(carry.ToString()) | Convert.ToInt32(binaryB[i].ToString());
                }

                if (carryNum == 0)
                {
                    carry = '0';
                }
                else
                {
                    carry = '1';
                }

                sumBinary.Append(sumChar.ToString());
            }
                    
            char[] sumBinaryArr = sumBinary.ToString().ToCharArray();

            Array.Reverse(sumBinaryArr);

            sum = Convert.ToInt32(new string(sumBinaryArr), 2);

            return sum;
        }
    }
}
