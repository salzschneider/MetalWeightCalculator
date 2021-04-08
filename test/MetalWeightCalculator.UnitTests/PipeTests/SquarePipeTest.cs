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
    using System;
    using Xunit;

    public class SquarePipeTest
    {
        [Theory]
        [InlineData(100, 2, 6000, 7.85, 36.602351999999996)]
        [InlineData(100, 2, 6000, 2.72, 12.682598400000002)]
        [InlineData(250, 10, 10500, 7.85, 777.10289999999986)]
        [InlineData(250, 10, 10500, 2.72, 269.26368)]
        public void CalculateWeight_ValidParameters_Weight(double side, double thickness, double length, double density, double expected)
        {
            // arrange, act
            var actual = SquarePipe.CalculateWeight(side, thickness, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(100, 2, 6000, Density.Steel, 36.602351999999996)]
        [InlineData(100, 2, 6000, Density.Aluminium, 12.682598400000002)]
        [InlineData(250, 10, 10500, Density.Steel, 777.10289999999986)]
        [InlineData(250, 10, 10500, Density.Aluminium, 269.26368)]
        public void CalculateWeight_ValidParametersWithMaterialName_Weight(double side, double thickness, double length, double density, double expected)
        {
            // arrange, act
            var actual = SquarePipe.CalculateWeight(side, thickness, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, -1, 0, -1)]
        [InlineData(-1, 2, 1000, 1)]
        [InlineData(100, 0, 1000, 1)]
        [InlineData(100, 2, -1, 1)]
        [InlineData(100, 2, 1000, 0)]
        public void CalculateWeight_InvalidArguments_ThrowException(double side, double thickness, double length, double density)
        {
            /*try
            {
                SquarePipe.CalculateWeight(side, thickness, length, density);
            }
            catch(Exception e)
            {

            }*/

            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => SquarePipe.CalculateWeight(side, thickness, length, density));
        }

        [Theory]
        [InlineData(100, 100, 1000, 1)]
        [InlineData(100, 100.01, 1000, 0)]
        public void CalculateWeight_InvalidSideThicknessRatio_ThrowException(double side, double thickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => SquarePipe.CalculateWeight(side, thickness, length, density));
        }

        [Theory]
        [InlineData(100, 2, 36.602351999999996, 7.85, 6000)]
        [InlineData(100, 2, 12.682598400000002, 2.72, 6000)]
        [InlineData(250, 10, 777.10289999999986, 7.85, 10500)]
        [InlineData(250, 10, 269.26368, 2.72, 10500.000000000002)]
        public void CalculateLength_ValidParameters_Length(double side, double thickness, double weight, double density, double expected)
        {
            // arrange, act
            var actual = SquarePipe.CalculateLength(side, thickness, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(100, 2, 36.602351999999996, Density.Steel, 6000)]
        [InlineData(100, 2, 12.682598400000002, Density.Aluminium, 6000)]
        [InlineData(250, 10, 777.10289999999986, Density.Steel, 10500)]
        [InlineData(250, 10, 269.26368, Density.Aluminium, 10500.000000000002)]
        public void CalculateLength_ValidParametersWithMaterialName_Length(double side, double thickness, double weight, double density, double expected)
        {
            // arrange, act
            var actual = SquarePipe.CalculateLength(side, thickness, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 2, 1000, 1)]
        [InlineData(100, 0, 1000, 1)]
        [InlineData(100, 2, -1, 1)]
        [InlineData(100, 2, 1000, 0)]
        public void CalculateLength_InvalidArguments_ThrowException(double side, double thickness, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => SquarePipe.CalculateLength(side, thickness, weight, density));
        }

        [Theory]
        [InlineData(100, 100, 1000, 1)]
        [InlineData(100, 100.01, 1000, 0)]
        public void CalculateLength_InvalidSideThicknessRatio_ThrowException(double side, double thickness, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => SquarePipe.CalculateLength(side, thickness, weight, density));
        }
    }
}
