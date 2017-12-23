using MoneyConvert.Core;
using Xunit;

namespace MoneyConverter.UnitTest
{
    public class CircularListUtilsTest
    {
        [Theory]
        [InlineData(5, new int[] { 2, 3, 4, 0, 1 }, false)]
        [InlineData(4, new int[] { 2, 3, 4, 0, 1 }, true)]
        [InlineData(3, new int[] { 4, 6, 11, -1, 1, 2, 3 }, true)]
        [InlineData(1, new int[] { }, false)]
        [InlineData(1, new int[] { 1 }, true)]
        [InlineData(1, new int[] { 2 }, false)]
        [InlineData(4, new int[] { 4, 6 }, true)]
        [InlineData(3, new int[] { 4, 6 }, false)]
        [InlineData(3, new int[] { 3, 4, 6 }, true)]
        [InlineData(3, new int[] { 3, 4, -1 }, true)]

        public void CircularList_Exists_Should_Return_Correct_Answer(int value, int[] values, bool expected)
        {
            bool result = CircularListUtils.Exists(value, values);
            Assert.Equal(expected, result);

        }
    }
}
