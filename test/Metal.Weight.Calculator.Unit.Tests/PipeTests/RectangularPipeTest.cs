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

namespace Metal.Weight.Calculator.Unit.Tests
{
    using Metal.Weight.Calculator;
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
    }
}
