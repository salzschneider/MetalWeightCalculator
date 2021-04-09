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

    public class RoundBarTest
    {
        [Theory]
        [InlineData(1000, 1000, 7.85, 6165.375582669969)]
        [InlineData(2500, 5000, 7.85, 192667.98695843652)]
        [InlineData(1000, 1000, 2.72, 2136.2830044410593)]
        [InlineData(2500, 5000, 2.72, 66758.8438887831)]
        public void CalculateWeight_ValidParameters_Weight(double diameter, double length, double density, double expected)
        {
            // arrange, act
            var actual = RoundBar.CalculateWeight(diameter, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000, 1000, Density.Steel, 6165.375582669969)]
        [InlineData(2500, 5000, Density.Steel, 192667.98695843652)]
        [InlineData(1000, 1000, Density.Aluminium, 2136.2830044410593)]
        [InlineData(2500, 5000, Density.Aluminium, 66758.8438887831)]
        public void CalculateWeight_ValidParametersWithMaterialName_Weight(double diameter, double length, double density, double expected)
        {
            // arrange, act
            var actual = RoundBar.CalculateWeight(diameter, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 2, 1000)]
        [InlineData(100, 0, 1000)]
        [InlineData(100, 2, -1)]
        public void CalculateWeight_InvalidArguments_ThrowException(double diameter, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => RoundBar.CalculateWeight(diameter, length, density));
        }

        [Theory]
        [InlineData(1000, 6165.375582669969, 7.85, 1000)]
        [InlineData(2500, 192667.98695843652, 7.85, 5000)]
        [InlineData(1000, 2136.2830044410593, 2.72, 1000.0000000000001)]
        [InlineData(2500, 66758.8438887831, 2.72, 5000)]
        public void CalculateLength_ValidParameters_Length(double diameter, double weight, double density, double expected)
        {
            // arrange, act
            var actual = RoundBar.CalculateLength(diameter, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000, 6165.375582669969, Density.Steel, 1000)]
        [InlineData(2500, 192667.98695843652, Density.Steel, 5000)]
        [InlineData(1000, 2136.2830044410593, Density.Aluminium, 1000.0000000000001)]
        [InlineData(2500, 66758.8438887831, Density.Aluminium, 5000)]
        public void CalculateLength_ValidParametersWithMaterialName_Length(double diameter, double weight, double density, double expected)
        {
            // arrange, act
            var actual = RoundBar.CalculateLength(diameter, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 2, 1000)]
        [InlineData(100, 0, 1000)]
        [InlineData(100, 2, -1)]
        public void CalculateLenght_InvalidArguments_ThrowException(double diameter, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => RoundBar.CalculateLength(diameter, weight, density));
        }
    }
}
