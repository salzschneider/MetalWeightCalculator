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

    public class TShapedAngleTest
    {
        [Theory]
        [InlineData(100, 200, 10, 20, 5000, 7.85, 149.14999999999998)]
        [InlineData(100, 200, 10, 10, 5000, 7.85, 113.82499999999999)]
        [InlineData(100, 200, 10, 20, 5000, 2.72, 51.68000000000001)]
        [InlineData(100, 200, 10, 10, 5000, 2.72, 39.440000000000005)]
        public void CalculateWeight_ValidParameters_Weight(double height, double flangeWidth, double flangeThickness, double stemThickness, double length, double density, double expected)
        {
            // arrange, act
            var actual = TShapedAngle.CalculateWeight(height, flangeWidth, flangeThickness, stemThickness, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 200, 10, 20, 5000, 7.85)]
        [InlineData(100, -1, 10, 20, 5000, 7.85)]
        [InlineData(100, 200, 0, 20, 5000, 7.85)]
        [InlineData(100, 200, 10, -1, 5000, 7.85)]
        [InlineData(100, 200, 10, 20, 0, 7.85)]
        [InlineData(100, 200, 10, 20, 5000, -1)]
        public void CalculateWeight_ZeroOrLessArguments_ThrowException(double height, double flangeWidth, double flangeThickness, double stemThickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => TShapedAngle.CalculateWeight(height, flangeWidth, flangeThickness, stemThickness, length, density));
        }

        [Theory]
        [InlineData(200, 100, 200, 20, 5000, 7.85)]
        [InlineData(200, 100, 200.001, 20, 5000, 7.85)]
        [InlineData(200, 100, 1500, 20, 5000, 7.85)]
        public void CalculateWeight_InvalidHeightFlangeThicknessRatio_ThrowException(
            double height, double flangeWidth, double flangeThickness, double stemThickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => TShapedAngle.CalculateWeight(height, flangeWidth, flangeThickness, stemThickness, length, density));
        }

        [Theory]
        [InlineData(200, 100, 10, 100, 5000, 7.85)]
        [InlineData(200, 100, 10, 100.001, 5000, 7.85)]
        [InlineData(200, 100, 10, 1500, 5000, 7.85)]
        public void CalculateWeight_InvalidFlangeWidthStemThicknessRatio_ThrowException(
           double height, double flangeWidth, double flangeThickness, double stemThickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => TShapedAngle.CalculateWeight(height, flangeWidth, flangeThickness, stemThickness, length, density));
        }

        [Theory]
        [InlineData(100, 200, 10, 20, 149.14999999999998, 7.85, 4999.999999999999)]
        [InlineData(100, 200, 10, 10, 113.82499999999999, 7.85, 4999.999999999999)]
        [InlineData(100, 200, 10, 20, 51.68000000000001, 2.72, 5000.000000000001)]
        [InlineData(100, 200, 10, 10, 39.440000000000005, 2.72, 5000)]
        public void CalculateLength_ValidParameters_Length(double height, double flangeWidth, double flangeThickness, double stemThickness, double weight, double density, double expected)
        {
            // arrange, act
            var actual = TShapedAngle.CalculateLength(height, flangeWidth, flangeThickness, stemThickness, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 200, 10, 20, 5000, 7.85)]
        [InlineData(100, -1, 10, 20, 5000, 7.85)]
        [InlineData(100, 200, 0, 20, 5000, 7.85)]
        [InlineData(100, 200, 10, -1, 5000, 7.85)]
        [InlineData(100, 200, 10, 20, 0, 7.85)]
        [InlineData(100, 200, 10, 20, 5000, -1)]
        public void CalculateLength_ZeroOrLessArguments_ThrowException(double height, double flangeWidth, double flangeThickness, double stemThickness, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => TShapedAngle.CalculateLength(height, flangeWidth, flangeThickness, stemThickness, weight, density));
        }

        [Theory]
        [InlineData(200, 100, 200, 20, 5000, 7.85)]
        [InlineData(200, 100, 200.001, 20, 5000, 7.85)]
        [InlineData(200, 100, 1500, 20, 5000, 7.85)]
        public void CalculateLength_InvalidHeightFlangeThicknessRatio_ThrowException(
           double height, double flangeWidth, double flangeThickness, double stemThickness, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => TShapedAngle.CalculateLength(height, flangeWidth, flangeThickness, stemThickness, weight, density));
        }

        [Theory]
        [InlineData(200, 100, 10, 100, 5000, 7.85)]
        [InlineData(200, 100, 10, 100.001, 5000, 7.85)]
        [InlineData(200, 100, 10, 1500, 5000, 7.85)]
        public void CalculateLength_InvalidFlangeWidthStemThicknessRatio_ThrowException(
           double height, double flangeWidth, double flangeThickness, double stemThickness, double weight, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => TShapedAngle.CalculateLength(height, flangeWidth, flangeThickness, stemThickness, weight, density));
        }
    }
}
