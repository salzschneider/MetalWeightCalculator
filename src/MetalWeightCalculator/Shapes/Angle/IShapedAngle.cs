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
    /// Calculating the weight or length of a I-Shaped angle made of different metals (steel pipes, stainless steel, copper, etc.).
    /// </summary>
    public class IShapedAngle : Shape
    {
        private static readonly IShapedAngleValidator Validator = new IShapedAngleValidator();

        private IShapedAngle()
        {
        }

        /// <summary>
        /// Calculating the weight of a I-Shaped angle.
        /// </summary>
        /// <param name="height">Size (vertical) from bottom to top in millimetres.</param>
        /// <param name="topFlangeWidth">Top flange width of the I-shape in millimetres.</param>
        /// <param name="topFlangeThickness">Average thickness of the top flange of the I-shape in millimetres.</param>
        /// <param name="bottomFlangeWidth">Bottom flange width of the I-shape in millimetres.</param>
        /// <param name="bottomFlangeThickness">Average thickness of the bottom flange of the I-shape in millimetres.</param>
        /// <param name="stemThickness">Thickness of the stem of the T-shape in millimetres.</param>
        /// <param name="length">Length in millimetres.</param>
        /// <param name="density">Density of the metal from which the I-Shaped angle is made in g/cm³.</param>
        /// <returns>Weight of a I-Shaped angle in kilograms.</returns>
        /// <exception cref="MetalWeightCalculator.InvalidArgumentsException">At least one of the passed arguments does not meet the parameter specification of the called method.</exception>
        public static double CalculateWeight(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double length,
            double density)
        {
            var iShapedAngleArgument = new IShapedAngleArgument(
                height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, 0, length, density);

            var results = Validator.Validate(iShapedAngleArgument, ruleSet: "Common,Length");

            if (!results.IsValid)
            {
                InvalidArgumentsHandler(results);
            }

            return ((topFlangeThickness * topFlangeWidth) + (bottomFlangeThickness * bottomFlangeWidth) + ((height - topFlangeThickness - bottomFlangeThickness) * stemThickness)) * (length / 1000) * (density / 1000);
        }

        /// <summary>
        /// Calculating the lenght of a I-Shaped angle.
        /// </summary>
        /// <param name="height">Size (vertical) from bottom to top in millimetres.</param>
        /// <param name="topFlangeWidth">Top flange width of the I-shape in millimetres.</param>
        /// <param name="topFlangeThickness">Average thickness of the top flange of the I-shape in millimetres.</param>
        /// <param name="bottomFlangeWidth">Bottom flange width of the I-shape in millimetres.</param>
        /// <param name="bottomFlangeThickness">Average thickness of the bottom flange of the I-shape in millimetres.</param>
        /// <param name="stemThickness">Thickness of the stem of the T-shape in millimetres.</param>
        /// <param name="weight">Weight in kilograms.</param>
        /// <param name="density">Density of the metal from which the I-Shaped angle is made in g/cm³.</param>
        /// <returns>Lenght of a I-Shaped angle in millimetres.</returns>
        /// <exception cref="MetalWeightCalculator.InvalidArgumentsException">At least one of the passed arguments does not meet the parameter specification of the called method.</exception>
        public static double CalculateLength(
            double height,
            double topFlangeWidth,
            double topFlangeThickness,
            double bottomFlangeWidth,
            double bottomFlangeThickness,
            double stemThickness,
            double weight,
            double density)
        {
            var iShapedAngleArgument = new IShapedAngleArgument(
                height, topFlangeWidth, topFlangeThickness, bottomFlangeWidth, bottomFlangeThickness, stemThickness, weight, 0, density);

            var results = Validator.Validate(iShapedAngleArgument, ruleSet: "Common,Weight");

            if (!results.IsValid)
            {
                InvalidArgumentsHandler(results);
            }

            return (weight * 1000000) / (((topFlangeThickness * topFlangeWidth) + (bottomFlangeThickness * bottomFlangeWidth) + ((height - topFlangeThickness - bottomFlangeThickness) * stemThickness)) * density);
        }
    }
}
