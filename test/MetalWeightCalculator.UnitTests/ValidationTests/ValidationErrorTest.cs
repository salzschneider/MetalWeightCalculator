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
    using System;
    using MetalWeightCalculator;
    using Xunit;

    public class ValidationErrorTest
    {
        [Theory]
        [InlineData("ArgumentNameHere", null, ErrorCodes.GreaterThanZero, "")]
        [InlineData("ArgumentNameHere", null, ErrorCodes.InvalidRatio, "")]
        public void ValidationError_NullErrorMessage_EmptyStringErrorMessage(string argumentName, string errorMessage, ErrorCodes errorCode, string expected)
        {
            // arrange, act
            var actualValidationError = new ValidationError(argumentName, errorMessage, errorCode);
            var actual = actualValidationError.ErrorMessage;

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null, "errorMessageHere", ErrorCodes.GreaterThanZero)]
        [InlineData("", "errorMessageHere", ErrorCodes.GreaterThanZero)]
        public void ValidationError_InvalidArgumentName_ThrowException(string argumentName, string errorMessage, ErrorCodes errorCode)
        {
            // arrange, act, assert
            Assert.Throws<ArgumentException>(() => new ValidationError(argumentName, errorMessage, errorCode));
        }
    }
}
