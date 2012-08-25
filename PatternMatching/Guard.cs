/************************************************************************************\
* Copyright (c) 2012, Jon Hartwell                                                   *
* All rights reserved.                                                               *
*                                                                                    *
* Redistribution and use in source and binary forms, with or without                 *
* modification, are permitted provided that the following conditions are met:        *
*    * Redistributions of source code must retain the above copyright                *
*      notice, this list of conditions and the following disclaimer.                 *
*    * Redistributions in binary form must reproduce the above copyright             *
*      notice, this list of conditions and the following disclaimer in the           *
*      documentation and/or other materials provided with the distribution.          *
*    * Neither the name of the <organization> nor the                                *
*      names of its contributors may be used to endorse or promote products          *
*      derived from this software without specific prior written permission.         *
*                                                                                    *
* THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND    *
* ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED      *
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE             *
* DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY                 * 
* DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES         *
* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;       *
* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND        *
* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT         * 
* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS      *
* SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.                       *
\************************************************************************************/
namespace PatternMatching
{
    using System;

    /// <summary>
    /// Guard class that provides the base for pattern matching
    /// </summary>
    public class Guard
    {
        /// <summary>
        /// <see cref="System.Func<T>"/> that returns a bool and acts
        /// as the test condition for the pattern matching
        /// </summary>
        public Func<bool> Predicate { get; protected set; }

        /// <summary>
        /// <see cref="System.Func<T>"/> that returns an object and
        /// acts as the method to perform if the predicate returns
        /// true
        /// </summary>
        public Func<object> Action { get; protected set; }

        /// <summary>
        /// Overriding the | operator to provide "standard" pattern
        /// matching syntax
        /// </summary>
        /// <param name="a">The first item in the pattern matching</param>
        /// <param name="b">The second item in the pattern matching</param>
        /// <returns>Returns the first guard that is true or else
        /// returns null</returns>
        public static Guard operator |(Guard a, Guard b)
        {
            Guard c = null;
            if (a.Predicate.Invoke())
            {
                c = a;
            }
            else if (b.Predicate.Invoke())
            {
                c = b;
            }

            return c;
        }
    }
}
