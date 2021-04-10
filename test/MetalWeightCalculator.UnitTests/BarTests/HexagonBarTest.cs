// Copyright (c) 2021 Salzschneider and others
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

namespace MetalWeightCalculator.UnitTests
{
    using MetalWeightCalculator;
    using Xunit;

    public class HexagonBarTest
    {
        [Theory]
        [InlineData(1000, 1000, 7.85, 6798.299419707843)]
        [InlineData(1000, 1000, 2.72, 2355.589098293673)]
        [InlineData(2500, 5000, 7.85, 212446.8568658701)]
        [InlineData(2500, 5000, 2.72, 73612.1593216773)]
        public void CalculateWeight_ValidParameters_Weight(double oppositeDistance, double length, double density, double expected)
        {
            // arrange, act
            var actual = HexagonBar.CalculateWeight(oppositeDistance, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 2, 1000)]
        [InlineData(100, 0, 1000)]
        [InlineData(100, 2, -1)]
        public void CalculateWeight_ZeroOrLessArguments_ThrowException(double oppositeDistance, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => HexagonBar.CalculateWeight(oppositeDistance, length, density));
        }

        [Theory]
        [InlineData(1000, 6798.299419707843, 7.85, 1000)]
        [InlineData(1000, 2355.589098293673, 2.72, 999.9999999999999)]
        [InlineData(2500, 212446.8568658701, 7.85, 5000)]
        [InlineData(2500, 73612.1593216773, 2.72, 5000.000000000001)]
        public void CalculateLength_ValidParameters_Length(double oppositeDistance, double weight, double density, double expected)
        {
            // arrange, act
            var actual = HexagonBar.CalculateLength(oppositeDistance, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 2, 1000)]
        [InlineData(100, 0, 1000)]
        [InlineData(100, 2, -1)]
        public void CalculateLength_ZeroOrLessArguments_ThrowException(double oppositeDistance, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => HexagonBar.CalculateLength(oppositeDistance, weight, density));
        }
    }
}
