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

    public class UShapedAngleTest
    {
        [Theory]
        [InlineData(500, 100, 5, 100, 5, 10, 6000, 7.85, 277.89)]
        [InlineData(500, 100, 5, 100, 5, 10, 6000, 2.72, 96.28800000000001)]
        [InlineData(1000, 250, 15, 350, 25, 30, 6500, 7.85, 2107.3325)]
        [InlineData(1000, 250, 15, 350, 25, 30, 6500, 2.72, 730.1840000000001)]
        public void CalculateWeight_ValidParameters_Weight(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double length,
            double density,
            double expected)
        {
            // arrange, act
            var actual = UShapedAngle.CalculateWeight(height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 100, 5, 100, 5, 10, 6000, 7.85)]
        [InlineData(500, 0, 5, 100, 5, 10, 6000, 7.85)]
        [InlineData(500, 100, -1, 100, 5, 10, 6000, 7.85)]
        [InlineData(500, 100, 5, 0, 5, 10, 6000, 7.85)]
        [InlineData(500, 100, 5, 100, -1, 10, 6000, 7.85)]
        [InlineData(500, 100, 5, 100, 5, 0, 6000, 7.85)]
        [InlineData(500, 100, 5, 100, 5, 10, -1, 7.85)]
        [InlineData(500, 100, 5, 100, 5, 10, 6000, 0)]
        public void CalculateWeight_ZeroOrLessArguments_ThrowException(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double length,
            double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => UShapedAngle.CalculateWeight(
                height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, length, density));
        }

        [Theory]
        [InlineData(500, 100, 499, 100, 1, 10, 6000, 7.85)]
        [InlineData(500, 100, 499, 100, 2, 10, 6000, 7.85)]
        [InlineData(500, 100, 499.999, 100, 0.001, 10, 6000, 7.85)]
        [InlineData(500, 100, 0.0001, 100, 499.9999, 10, 6000, 7.85)]
        [InlineData(500, 100, 490, 100, 500, 10, 6000, 7.85)]
        public void CalculateWeight_InvalidHeightTopFlangeThicknessBottomFlangeThicknessRatio_ThrowException(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double length,
            double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => UShapedAngle.CalculateWeight(
                height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, length, density));
        }

        [Theory]
        [InlineData(500, 100, 5, 120, 5, 100, 6000, 7.85)]
        [InlineData(500, 100, 5, 120, 5, 100.1, 6000, 7.85)]
        [InlineData(500, 100, 5, 120, 5, 1500, 6000, 7.85)]
        public void CalculateWeight_InvalidTopFlangeWidthStemThicknessRatio_ThrowException(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double length,
            double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => UShapedAngle.
                CalculateWeight(height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, length, density));
        }

        [Theory]
        [InlineData(500, 120, 5, 100, 5, 100, 6000, 7.85)]
        [InlineData(500, 120, 5, 100, 5, 100.1, 6000, 7.85)]
        [InlineData(500, 120, 5, 1100, 5, 1500, 6000, 7.85)]
        public void CalculateWeight_InvalidBottomFlangeWidthStemThicknessRatio_ThrowException(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double length,
            double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => UShapedAngle.
                CalculateWeight(height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, length, density));
        }

        [Theory]
        [InlineData(500, 100, 5, 100, 5, 10, 277.89, 7.85, 6000)]
        [InlineData(500, 100, 5, 100, 5, 10, 96.28800000000001, 2.72, 6000)]
        [InlineData(1000, 250, 15, 350, 25, 30, 2107.3325, 7.85, 6500)]
        [InlineData(1000, 250, 15, 350, 25, 30, 730.1840000000001, 2.72, 6500)]
        public void CalculateLength_ValidParameters_Length(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double weight,
            double density,
            double expected)
        {
            // arrange, act
            var actual = UShapedAngle.CalculateLength(height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 100, 5, 100, 5, 10, 6000, 7.85)]
        [InlineData(500, 0, 5, 100, 5, 10, 6000, 7.85)]
        [InlineData(500, 100, -1, 100, 5, 10, 6000, 7.85)]
        [InlineData(500, 100, 5, 0, 5, 10, 6000, 7.85)]
        [InlineData(500, 100, 5, 100, -1, 10, 6000, 7.85)]
        [InlineData(500, 100, 5, 100, 5, 0, 6000, 7.85)]
        [InlineData(500, 100, 5, 100, 5, 10, -1, 7.85)]
        [InlineData(500, 100, 5, 100, 5, 10, 6000, 0)]
        public void CalculateLength_ZeroOrLessArguments_ThrowException(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double weight,
            double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => UShapedAngle.CalculateLength(
                height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, weight, density));
        }

        [Theory]
        [InlineData(500, 100, 499, 100, 1, 10, 6000, 7.85)]
        [InlineData(500, 100, 499, 100, 2, 10, 6000, 7.85)]
        [InlineData(500, 100, 499.999, 100, 0.001, 10, 6000, 7.85)]
        [InlineData(500, 100, 0.0001, 100, 499.9999, 10, 6000, 7.85)]
        [InlineData(500, 100, 490, 100, 500, 10, 6000, 7.85)]
        public void CalculateLength_InvalidHeightTopFlangeThicknessBottomFlangeThicknessRatio_ThrowException(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double weight,
            double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => UShapedAngle.CalculateLength(
                height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, weight, density));
        }

        [Theory]
        [InlineData(500, 100, 5, 120, 5, 100, 6000, 7.85)]
        [InlineData(500, 100, 5, 120, 5, 100.1, 6000, 7.85)]
        [InlineData(500, 100, 5, 120, 5, 1500, 6000, 7.85)]
        public void CalculateLength_InvalidTopFlangeWidthStemThicknessRatio_ThrowException(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double weight,
            double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => UShapedAngle.
                CalculateLength(height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, weight, density));
        }

        [Theory]
        [InlineData(500, 120, 5, 100, 5, 100, 6000, 7.85)]
        [InlineData(500, 120, 5, 100, 5, 100.1, 6000, 7.85)]
        [InlineData(500, 120, 5, 1100, 5, 1500, 6000, 7.85)]
        public void CalculateLength_InvalidBottomFlangeWidthStemThicknessRatio_ThrowException(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double weight,
            double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => UShapedAngle.
                CalculateLength(height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, weight, density));
        }
    }
}
