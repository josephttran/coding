using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public class Binary
    {
        /* Given a non negative integer number num. 
         * For every numbers i in the range 0 ≤ i ≤ num 
         * calculate the number of 1's in their binary representation
         * and return them as an array.
         * O(n)
         */

        /*
         * 0,
         * 1,
         * 1, 2,
         * 1, 2, 2, 3,
         * 1, 2, 2, 3, 2, 3, 3, 4, 
         * 1, 2  2  3  2  3  3  4  2 3 3 4 3 4 4 5
         * 1, 2  2  3  2  3  3  4  2 3 3 4 3 4 4 5 3  ...  4 5 5 6              
        */
        public int[] CountBits(int num)
        {
            if (num == 0)
            {
                return new int[] { 0 };
            }

            if (num == 1)
            {
                return new int[] { 0, 1 };
            }

            int[] countArray = new int[num + 1];
            int pow = 1;
            int index = 2;
            
            countArray[0] = 0;
            countArray[1] = 1;

            while (index <= num)
            {
                int prevStart = (int) Math.Pow(2, pow - 1);
                int low = (int) Math.Pow(2, pow);
                int high = (int) Math.Pow(2, pow + 1) - 1;
                int mid = (int) Math.Ceiling((high + low) / 2.0);

                for (int i = low; i < mid && index <= num; ++i)
                {
                    countArray[i] = countArray[prevStart];
                    prevStart++;
                    index++;
                }

                prevStart = (int) Math.Pow(2, pow - 1);

                for (int j = mid; j <= high && index <= num; ++j)
                {
                    countArray[j] = countArray[prevStart] + 1;
                    prevStart++;
                    index++;
                }

                pow++;
            }

            return countArray;
        }

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
