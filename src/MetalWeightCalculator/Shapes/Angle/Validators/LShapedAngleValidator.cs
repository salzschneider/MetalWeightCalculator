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

namespace MetalWeightCalculator.Shapes.Angle.Validators
{
    using FluentValidation;
    using MetalWeightCalculator.Shapes.Angle.Arguments;

    internal class LShapedAngleValidator : AbstractValidator<LShapedAngleArgument>
    {
        public LShapedAngleValidator()
        {
            RuleSet("Common", () =>
            {
                RuleFor(x => x.Height)
                    .GreaterThan(0)
                    .WithName("height")
                    .WithErrorCode(ErrorCodes.GreaterThanZero.ToString());
                RuleFor(x => x.Width)
                    .GreaterThan(0)
                    .WithName("width")
                    .WithErrorCode(ErrorCodes.GreaterThanZero.ToString());
                RuleFor(x => x.Thickness)
                    .GreaterThan(0)
                    .WithName("thickness")
                    .WithErrorCode(ErrorCodes.GreaterThanZero.ToString());
                RuleFor(x => x.Density)
                    .GreaterThan(0)
                    .WithName("density")
                    .WithErrorCode(ErrorCodes.GreaterThanZero.ToString());
                RuleFor(x => (x.Height + x.Width) - x.Thickness)
                    .GreaterThan(0)
                    .WithMessage("Invalid sides-thickness ratio.")
                    .WithName("height")
                    .WithErrorCode(ErrorCodes.InvalidRatio.ToString());
            });

            RuleSet("Weight", () =>
            {
                RuleFor(x => x.Weight)
                    .GreaterThan(0)
                    .WithName("weight")
                    .WithErrorCode(ErrorCodes.GreaterThanZero.ToString());
            });

            RuleSet("Length", () =>
            {
                RuleFor(x => x.Length)
                    .GreaterThan(0)
                    .WithName("length")
                    .WithErrorCode(ErrorCodes.GreaterThanZero.ToString());
            });
        }
    }
}
