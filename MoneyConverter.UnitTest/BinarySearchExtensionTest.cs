using MoneyConvert.Core;
using Xunit;

namespace MoneyConverter.UnitTest
{
    public class BinarySearchExtensionTest
    {
        [Theory]
        [InlineData(8, new int[] { }, -1)]
        [InlineData(8, new int[] { 0 }, -1)]
        [InlineData(8, new int[] { 8 }, 0)]
        [InlineData(8, new int[] { 7, 9 }, -1)]
        [InlineData(8, new int[] { 7, 8 }, 1)]
        [InlineData(8, new int[] { 6, 7, 9 }, -1)]
        [InlineData(8, new int[] { 6, 8, 9 }, 1)]
        [InlineData(8, new int[] { 6, 7, 9, 10 }, -1)]
        [InlineData(8, new int[] { 5, 6, 8, 9 }, 2)]
        [InlineData(8, new int[] { 5, 6, 7, 9, 10 }, -1)]
        [InlineData(8, new int[] { 5, 6, 7, 8, 10 }, 3)]
        [InlineData(8, new int[] { 8, 9, 10, 11, 12 }, 0)]
        [InlineData(8, new int[] { 4, 5, 6, 7, 8 }, 4)]
        [InlineData(8, new int[] { 3, 4, 5, 6, 7 }, -1)]
        [InlineData(8, new int[] { 9, 10, 11, 12, 13 }, -1)]
        public void BinarySearch_Should_Return_Correct_Response(int value, int[] values, int expected)
        {
            int lastPos = values.Length - 1;

            if (values.Length == 0)
            {
                lastPos = 0;
            }

            int result = values.MyBinarySearch(value, 0, lastPos);

            Assert.Equal(expected, result);
        }
    }
}
