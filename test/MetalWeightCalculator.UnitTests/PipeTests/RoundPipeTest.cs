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

    public class RoundPipeTest
    {
        [Theory]
        [InlineData(100, 10, 1000, 7.85, 22.195352097611888)]
        [InlineData(222, 8, 5000, 7.85, 211.10245995061973)]
        [InlineData(100, 10, 1000, 2.72, 7.690618815987815)]
        [InlineData(500, 8, 5000, 2.72, 168.16819810960021)]
        public void CalculateWeight_ValidParameters_Weight(double diameter, double thickness, double length, double density, double expected)
        {
            // arrange, act
            var actual = RoundPipe.CalculateWeight(diameter, thickness, length, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 2, 1000, 1)]
        [InlineData(100, 0, 1000, 1)]
        [InlineData(100, 2, -1, 1)]
        [InlineData(100, 2, 1000, 0)]
        public void CalculateWeight_ZeroOrLessArguments_ThrowException(double diameter, double thickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => RoundPipe.CalculateWeight(diameter, thickness, length, density));
        }

        [Theory]
        [InlineData(100, 100, 1000, 1)]
        [InlineData(100, 100.01, 1000, 0)]
        public void CalculateWeight_InvalidDiameterThicknessRatio_ThrowException(double diameter, double thickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => RoundPipe.CalculateWeight(diameter, thickness, length, density));
        }

        [Theory]
        [InlineData(100, 10, 22.195352097611888, 7.85, 1000)]
        [InlineData(222, 8, 211.10245995061973, 7.85, 5000)]
        [InlineData(100, 10, 7.690618815987815, 2.72, 1000)]
        [InlineData(500, 8, 168.16819810960021, 2.72, 5000)]
        public void CalculateLength_ValidParameters_Length(double diameter, double thickness, double weight, double density, double expected)
        {
            // arrange, act
            var actual = RoundPipe.CalculateLength(diameter, thickness, weight, density);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 2, 1000, 1)]
        [InlineData(100, 0, 1000, 1)]
        [InlineData(100, 2, -1, 1)]
        [InlineData(100, 2, 1000, 0)]
        public void CalculateLength_ZeroOrLessArguments_ThrowException(double diameter, double thickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => RoundPipe.CalculateLength(diameter, thickness, length, density));
        }

        [Theory]
        [InlineData(100, 100, 1000, 1)]
        [InlineData(100, 100.01, 1000, 0)]
        public void CalculateLength_InvalidDiameterThicknessRatio_ThrowException(double diameter, double thickness, double length, double density)
        {
            // arrange, act, assert
            Assert.Throws<MetalWeightCalculator.InvalidArgumentsException>(() => RoundPipe.CalculateLength(diameter, thickness, length, density));
        }
    }
}
