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

    public class RectangularPipeTest
    {
        [Theory]
        [InlineData(100, 30, 2, 6000, 7.85, 23.414352)]
        [InlineData(100, 30, 2, 6000, 2.72, 8.112998400000002)]
        [InlineData(250, 120, 10, 10500, 7.85, 562.7978999999999)]
        [InlineData(250, 120, 10, 10500, 2.72, 195.00768)]
        public void CalculateWeight_ValidParameters_Weight(double sideA, double sideB, double thickness, double length, double density, double expected)
        {
            // arrange, act
            var actual = RectangularPipe.CalculateWeight(sideA, sideB, thickness, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 90, 2, 1000, 1)]
        [InlineData(100, 0, 2, 1000, 1)]
        [InlineData(100, 90, -1, 1000, 1)]
        [InlineData(100, 90, 2, 0, 1)]
        [InlineData(100, 90, 2, 1000, -1)]
        public void CalculateWeight_InvalidArguments_ThrowException(double sideA, double sideB, double thickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<System.ArgumentException>(() => RectangularPipe.CalculateWeight(sideA, sideB, thickness, length, density));
        }

        [Theory]
        [InlineData(1, 1, 0.7, 1000, 1)]
        [InlineData(100, 10, 39, 1000, 1)]
        public void CalculateWeight_InvalidSideThicknessRatio_ThrowException(double sideA, double sideB, double thickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<System.ArgumentException>(() => RectangularPipe.CalculateWeight(sideA, sideB, thickness, length, density));
        }

        [Theory]
        [InlineData(100, 30, 2, 6000, Density.Steel, 23.414352)]
        [InlineData(100, 30, 2, 6000, Density.Aluminium, 8.112998400000002)]
        [InlineData(250, 120, 10, 10500, Density.Steel, 562.7978999999999)]
        [InlineData(250, 120, 10, 10500, Density.Aluminium, 195.00768)]
        public void CalculateWeight_ValidParametersWithMaterialName_Weight(double sideA, double sideB, double thickness, double length, double density, double expected)
        {
            // arrange, act
            var actual = RectangularPipe.CalculateWeight(sideA, sideB, thickness, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(100, 30, 2, 23.414352, 7.85, 6000.000000000001)]
        [InlineData(100, 30, 2, 8.112998400000002, 2.72, 6000.000000000001)]
        [InlineData(250, 120, 10, 562.7978999999999, 7.85, 10500)]
        [InlineData(250, 120, 10, 195.00768, 2.72, 10500)]
        public void CalculateLength_ValidParameters_Length(double sideA, double sideB, double thickness, double weight, double density, double expected)
        {
            // arrange, act
            var actual = RectangularPipe.CalculateLength(sideA, sideB, thickness, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(100, 30, 2, 23.414352, Density.Steel, 6000.000000000001)]
        [InlineData(100, 30, 2, 8.112998400000002, Density.Aluminium, 6000.000000000001)]
        [InlineData(250, 120, 10, 562.7978999999999, Density.Steel, 10500)]
        [InlineData(250, 120, 10, 195.00768, Density.Aluminium, 10500)]
        public void CalculateLength_ValidParametersWithMaterialName_Length(double sideA, double sideB, double thickness, double weight, double density, double expected)
        {
            // arrange, act
            var actual = RectangularPipe.CalculateLength(sideA, sideB, thickness, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 90, 2, 1000, 1)]
        [InlineData(100, 0, 2, 1000, 1)]
        [InlineData(100, 90, -1, 1000, 1)]
        [InlineData(100, 90, 2, 0, 1)]
        [InlineData(100, 90, 2, 1000, -1)]

        public void CalculateLength_InvalidArguments_ThrowException(double sideA, double sideB, double thickness, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<System.ArgumentException>(() => RectangularPipe.CalculateLength(sideA, sideB, thickness, weight, density));
        }

        [Theory]
        [InlineData(1, 1, 0.7, 1000, 1)]
        [InlineData(100, 10, 39, 1000, 1)]
        public void CalculateLength_InvalidSideThicknessRatio_ThrowException(double sideA, double sideB, double thickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<System.ArgumentException>(() => RectangularPipe.CalculateLength(sideA, sideB, thickness, length, density));
        }
    }
}
