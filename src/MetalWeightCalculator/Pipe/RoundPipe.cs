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

    /// <summary>
    /// Calculating the weight or length of a round pipe made of different metals (steel pipes, stainless steel, copper, etc.).
    /// </summary>
    public static class RoundPipe
    {
        /// <summary>
        /// Calculating the weight of a round pipe.
        /// </summary>
        /// <param name="diameter">Diameter in millimetre.</param>
        /// <param name="thickness">Thickness in millimetre.</param>
        /// <param name="length">Length in millimetre.</param>
        /// <param name="density">Density of the metal from which the round pipe is made in g/cm³.</param>
        /// <returns>Weight of a round pipe in kg.</returns>
        public static double CalculateWeight(double diameter, double thickness, double length, double density)
        {
            return Math.PI * (density / 1000) * thickness * (diameter - thickness) * (length / 1000);
        }

        /// <summary>
        /// Calculating the length of a round pipe.
        /// </summary>
        /// <param name="diameter">Diameter in millimetre.</param>
        /// <param name="thickness">Thickness in millimetre.</param>
        /// <param name="weight">Weight in kilogram.</param>
        /// <param name="density">Density of the metal from which the round pipe is made in g/cm³.</param>
        /// <returns>Lenght of a round pipe in millimetre.</returns>
        public static double CalculateLength(double diameter, double thickness, double weight, double density)
        {
           return (weight / (Math.PI * (density / 1000) * thickness * (diameter - thickness))) * 1000;
        }
    }
}
