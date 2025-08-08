using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class _2221_FindTriangularSumOfAnArray
    {
        public int TriangularSum(int[] nums)
        {
            while (nums.Length > 1)
            {
                int[] newNums = new int[nums.Length - 1];
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    newNums[i] = (nums[i] + nums[i + 1]) % 10;
                }
                nums = newNums;
            }

            return nums[0];
        }

        public static void Run()
        {
            var solution = new _2221_FindTriangularSumOfAnArray();
            int[] nums = { 1,2,3,4,5 };
            int result = solution.TriangularSum(nums);
            Console.WriteLine($"Triangular Sum: {result}"); // Expected output: 8
        }
    }
}
