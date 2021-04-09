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
    using System.Linq;
    using MetalWeightCalculator;
    using Xunit;

    public class InvalidArgumentsExceptionTest
    {
        [Theory]
        [InlineData(-1, 2, 1000, 1)]
        [InlineData(0, 2, 1000, 1)]
        [InlineData(-11.22, 2, 1000, 1)]
        public void InvalidArgumentsException_GraterThanZeroProblemDiameter_ValidationErrors(double diameter, double thickness, double length, double density)
        {
            // arrange, act, assert
            var exception = Assert.Throws<InvalidArgumentsException>(() => RoundPipe.CalculateWeight(diameter, thickness, length, density));
            var validationErrors = exception.ValidationErrors;
            var validationError = validationErrors.First();

            Assert.Equal("diameter", validationError.ArgumentName);
            Assert.Equal(ErrorCodes.GreaterThanZero, validationError.ErrorCode);
            Assert.NotNull(validationErrors);
        }

        [Theory]
        [InlineData(100, 0, 1000, 1)]
        [InlineData(100, -1, 1000, 1)]
        [InlineData(100, -22.22, 1000, 1)]
        public void InvalidArgumentsException_GraterThanZeroProblemThickness_ValidationErrors(double diameter, double thickness, double length, double density)
        {
            // arrange, act, assert
            var exception = Assert.Throws<InvalidArgumentsException>(() => RoundPipe.CalculateWeight(diameter, thickness, length, density));
            var validationErrors = exception.ValidationErrors;
            var validationError = validationErrors.First();

            Assert.Equal("thickness", validationError.ArgumentName);
            Assert.Equal(ErrorCodes.GreaterThanZero, validationError.ErrorCode);
            Assert.NotNull(validationErrors);
        }

        [Theory]
        [InlineData(100, 100, 1000, 1)]
        [InlineData(100, 100.0001, 1000, 1)]
        [InlineData(100, 1000, 1000, 1)]
        public void InvalidArgumentsException_InvalidRatioProblem_ValidationErrors(double diameter, double thickness, double length, double density)
        {
            // arrange, act, assert
            var exception = Assert.Throws<InvalidArgumentsException>(() => RoundPipe.CalculateWeight(diameter, thickness, length, density));
            var validationErrors = exception.ValidationErrors;
            var validationError = validationErrors.First();

            Assert.Equal("diameter", validationError.ArgumentName);
            Assert.Equal(ErrorCodes.InvalidRatio, validationError.ErrorCode);
            Assert.NotNull(validationErrors);
        }
    }
}
