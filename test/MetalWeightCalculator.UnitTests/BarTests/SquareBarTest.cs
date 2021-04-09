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

    public class SquareBarTest
    {
        [Theory]
        [InlineData(1000, 1000, 7.85, 7850)]
        [InlineData(1000, 1000, 2.72, 2720)]
        [InlineData(2500, 5000, 7.85, 245312.5)]
        [InlineData(2500, 5000, 2.72, 85000)]
        public void CalculateWeight_ValidParameters_Weight(double size, double length, double density, double expected)
        {
            // arrange, act
            var actual = SquareBar.CalculateWeight(size, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000, 1000, Density.Steel, 7850)]
        [InlineData(1000, 1000, Density.Aluminium, 2720)]
        [InlineData(2500, 5000, Density.Steel, 245312.5)]
        [InlineData(2500, 5000, Density.Aluminium, 85000)]
        public void CalculateWeight_ValidParametersWithMaterialName_Weight(double size, double length, double density, double expected)
        {
            // arrange, act
            var actual = SquareBar.CalculateWeight(size, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 2, 1000)]
        [InlineData(100, 0, 1000)]
        [InlineData(100, 2, -1)]
        public void CalculateWeight_InvalidArguments_ThrowException(double size, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => SquareBar.CalculateWeight(size, length, density));
        }

        [Theory]
        [InlineData(1000, 7850, 7.85, 1000)]
        [InlineData(1000, 2720, 2.72, 1000)]
        [InlineData(2500, 245312.5, 7.85, 5000)]
        [InlineData(2500, 85000, 2.72, 5000)]
        public void CalculateLength_ValidParameters_Length(double size, double weight, double density, double expected)
        {
            // arrange, act
            var actual = SquareBar.CalculateLength(size, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000, 7850, 7.85, 1000)]
        [InlineData(1000, 2720, 2.72, 1000)]
        [InlineData(2500, 245312.5, 7.85, 5000)]
        [InlineData(2500, 85000, 2.72, 5000)]
        public void CalculateLength_ValidParametersWithMaterialName_Length(double size, double weight, double density, double expected)
        {
            // arrange, act
            var actual = SquareBar.CalculateLength(size, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 2, 1000)]
        [InlineData(100, 0, 1000)]
        [InlineData(100, 2, -1)]
        public void CalculateLength_InvalidArguments_ThrowException(double size, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => SquareBar.CalculateLength(size, weight, density));
        }
    }
}
