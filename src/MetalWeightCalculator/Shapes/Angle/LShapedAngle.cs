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

namespace MetalWeightCalculator
{
    using System;
    using FluentValidation;
    using MetalWeightCalculator.Shapes.Angle.Arguments;
    using MetalWeightCalculator.Shapes.Angle.Validators;

    /// <summary>
    /// Calculating the weight or length of a Square bar made of different metals (steel pipes, stainless steel, copper, etc.).
    /// </summary>
    public class LShapedAngle : Shape
    {
        private static readonly LShapedAngleValidator Validator = new LShapedAngleValidator();

        private LShapedAngle()
        {
        }

        /// <summary>
        /// Calculating the weight of a L-Shaped angle.
        /// </summary>
        /// <param name="height">Size (vertical) in millimetres.</param>
        /// <param name="width">Size (horizontal) in millimetres.</param>
        /// <param name="thickness">Thickness in millimetres.</param>
        /// <param name="length">Length in millimetres.</param>
        /// <param name="density">Density of the metal from which the L-Shaped angle is made in g/cm³.</param>
        /// <returns>Weight of a L-Shaped angle in kilograms.</returns>
        /// <exception cref="MetalWeightCalculator.InvalidArgumentsException">At least one of the passed arguments does not meet the parameter specification of the called method.</exception>
        public static double CalculateWeight(double height, double width, double thickness, double length, double density)
        {
            var lShapedAngleArgument = new LShapedAngleArgument(height, width, thickness, 0, length, density);
            var results = Validator.Validate(lShapedAngleArgument, ruleSet: "Common,Length");

            if (!results.IsValid)
            {
                InvalidArgumentsHandler(results);
            }

            return (height + width - thickness) / 1000 * thickness * length * density;
        }

        /// <summary>
        /// Calculating the lenght of a L-Shaped angle.
        /// </summary>
        /// <param name="height">Size (vertical) in millimetres.</param>
        /// <param name="width">Size (horizontal) in millimetres.</param>
        /// <param name="thickness">Thickness in millimetres.</param>
        /// <param name="weight">Weight in kilograms.</param>
        /// <param name="density">Density of the metal from which the L-Shaped angle is made in g/cm³.</param>
        /// <returns>Lenght of a L-Shaped angle in millimetres.</returns>
        /// <exception cref="MetalWeightCalculator.InvalidArgumentsException">At least one of the passed arguments does not meet the parameter specification of the called method.</exception>
        public static double CalculateLength(double height, double width, double thickness, double weight, double density)
        {
            var lShapedAngleArgument = new LShapedAngleArgument(height, width, thickness, weight, 0, density);
            var results = Validator.Validate(lShapedAngleArgument, ruleSet: "Common,Weight");

            if (!results.IsValid)
            {
                InvalidArgumentsHandler(results);
            }

            return weight / ((height + width - thickness) / 1000 * thickness * density);
        }
    }
}
