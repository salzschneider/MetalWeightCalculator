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

    public class FlatBarTest
    {
        [Theory]
        [InlineData(1000, 20, 1000, 7.85, 157)]
        [InlineData(1000, 20, 1000, 2.72, 54.400000000000006)]
        [InlineData(2500, 45, 5000, 7.85, 4415.625)]
        [InlineData(2500, 45, 5000, 2.72, 1530)]
        public void CalculateWeight_ValidParameters_Weight(double size, double thickness, double length, double density, double expected)
        {
            // arrange, act
            var actual = FlatBar.CalculateWeight(size, thickness, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000, 20, 1000, Density.Steel, 157)]
        [InlineData(1000, 20, 1000, Density.Aluminium, 54.400000000000006)]
        [InlineData(2500, 45, 5000, Density.Steel, 4415.625)]
        [InlineData(2500, 45, 5000, Density.Aluminium, 1530)]
        public void CalculateWeight_ValidParametersWithMaterialName_Weight(double size, double thickness, double length, double density, double expected)
        {
            // arrange, act
            var actual = FlatBar.CalculateWeight(size, thickness, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 20, 1000, 7.85)]
        [InlineData(1000, -1, 1000, 7.85)]
        [InlineData(1000, 20, 0, 7.85)]
        [InlineData(1000, 20, 1000, 0)]
        public void CalculateWeight_InvalidArguments_ThrowException(double size, double thickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => FlatBar.CalculateWeight(size, thickness, length, density));
        }

        [Theory]
        [InlineData(1000, 20, 157, 7.85, 1000)]
        [InlineData(1000, 20, 54.400000000000006, 2.72, 1000)]
        [InlineData(2500, 45, 4415.625, 7.85, 5000)]
        [InlineData(2500, 45, 1530, 2.72, 5000)]
        public void CalculateLength_ValidParameters_Length(double size, double thickness, double weight, double density, double expected)
        {
            // arrange, act
            var actual = FlatBar.CalculateLength(size, thickness, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000, 20, 157, Density.Steel, 1000)]
        [InlineData(1000, 20, 54.400000000000006, Density.Aluminium, 1000)]
        [InlineData(2500, 45, 4415.625, Density.Steel, 5000)]
        [InlineData(2500, 45, 1530, Density.Aluminium, 5000)]
        public void CalculateLength_ValidParametersWithMaterialName_Length(double size, double thickness, double weight, double density, double expected)
        {
            // arrange, act
            var actual = FlatBar.CalculateLength(size, thickness, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 20, 1000, 7.85)]
        [InlineData(1000, -1, 1000, 7.85)]
        [InlineData(1000, 20, 0, 7.85)]
        [InlineData(1000, 20, 1000, 0)]
        public void CalculateLength_InvalidArguments_ThrowException(double size, double thickness, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => FlatBar.CalculateLength(size, thickness, weight, density));
        }
    }
}
