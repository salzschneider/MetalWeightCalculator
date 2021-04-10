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

    public class LShapedAngleTest
    {
        [Theory]
        [InlineData(100, 200, 10, 5000, 7.85, 113825)]
        [InlineData(100, 200, 10, 5000, 2.72, 39440)]
        [InlineData(222, 111, 8, 4500, 7.85, 91845)]
        [InlineData(222, 111, 8, 4500, 2.72, 31824.000000000004)]
        public void CalculateWeight_ValidParameters_Weight(double height, double width, double thickness, double length, double density, double expected)
        {
            // arrange, act
            var actual = LShapedAngle.CalculateWeight(height, width, thickness, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 200, 10, 2000, 7.85)]
        [InlineData(100, -1, 10, 2000, 7.85)]
        [InlineData(100, 200, 0, 2000, 7.85)]
        [InlineData(100, 200, 10, -1, 7.85)]
        [InlineData(100, 200, 10, 2000, 0)]
        public void CalculateWeight_ZeroOrLessArguments_ThrowException(double height, double width, double thickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => LShapedAngle.CalculateWeight(height, width, thickness, length, density));
        }

        [Theory]
        [InlineData(200, 100, 300, 1000, 7.85)]
        [InlineData(200, 100, 300.1, 1000, 7.85)]
        [InlineData(200, 100, 4500, 1000, 7.85)]
        public void CalculateWeight_InvalidHeightWidthThicknessRatio_ThrowException(double height, double width, double thickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => LShapedAngle.CalculateWeight(height, width, thickness, length, density));
        }

        [Theory]
        [InlineData(100, 200, 10, 113825, 7.85, 5000.000000000001)]
        [InlineData(100, 200, 10, 39440, 2.72, 5000)]
        [InlineData(222, 111, 8, 91845, 7.85, 4500)]
        [InlineData(222, 111, 8, 31824.000000000004, 2.72, 4500)]
        public void CalculateLength_ValidParameters_Length(double height, double width, double thickness, double weight, double density, double expected)
        {
            // arrange, act
            var actual = LShapedAngle.CalculateLength(height, width, thickness, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 200, 10, 2000, 7.85)]
        [InlineData(100, -1, 10, 2000, 7.85)]
        [InlineData(100, 200, 0, 2000, 7.85)]
        [InlineData(100, 200, 10, -1, 7.85)]
        [InlineData(100, 200, 10, 2000, 0)]
        public void CalculateLength_ZeroOrLessArguments_ThrowException(double height, double width, double thickness, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => LShapedAngle.CalculateLength(height, width, thickness, weight, density));
        }

        [Theory]
        [InlineData(200, 100, 300, 1000, 7.85)]
        [InlineData(200, 100, 300.1, 1000, 7.85)]
        [InlineData(200, 100, 4500, 1000, 7.85)]
        public void CalculateLength_InvalidHeightWidthThicknessRatio_ThrowException(double height, double width, double thickness, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => LShapedAngle.CalculateLength(height, width, thickness, weight, density));
        }
    }
}
