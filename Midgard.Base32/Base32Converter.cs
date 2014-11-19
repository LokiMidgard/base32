using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midgard.Base32
{
    public static class Base32Converter
    {
        private const string base32 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";


        /// <summary>
        ///     Converts an array of 8-bit unsigned integers to its equivalent string representation
        ///     that is encoded with base-32 digits.
        /// </summary>
        /// <param name="inArray">
        ///     An array of 8-bit unsigned integers.
        /// </param>
        /// <returns>
        ///     The string representation, in base 32, of the contents of inArray.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        ///     inArray is null.
        /// </exception>
        public static string ToBase32String(byte[] inArray)
        {
            if (inArray == null)
            {
                throw new ArgumentNullException("inArray");
            }
            int rest = inArray.Length % 5;
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < inArray.Length - rest; i += 5)
            {
                s.Append(base32[inArray[i] >> 3]); // Zichen 1
                s.Append(base32[((inArray[i] << 2) & 31) | ((inArray[i + 1] >> 6) & 31)]); // Zichen 2
                s.Append(base32[(inArray[i + 1] >> 1) & 31]); // Zichen 3
                s.Append(base32[((inArray[i + 1] << 4) & 31) | ((inArray[i + 2] >> 4) & 31)]); // Zichen 4
                s.Append(base32[((inArray[i + 2] << 1) & 31) | ((inArray[i + 3] >> 7) & 31)]); // Zichen 5
                s.Append(base32[(inArray[i + 3] >> 2) & 31]); // Zichen 6
                s.Append(base32[((inArray[i + 3] << 3) & 31) | ((inArray[i + 4] >> 5) & 31)]); // Zichen 7
                s.Append(base32[(inArray[i + 4]) & 31]); // Zichen 8
            }

            if (rest != 0)
            {
                var t = new byte[5];
                for (int i = inArray.Length - rest; i < inArray.Length; i++)
                    t[i - (inArray.Length - rest)] = inArray[i];

                if (rest >= 1)
                {
                    s.Append(base32[t[0] >> 3]); // Zichen 1
                    s.Append(base32[((t[0] << 2) & 31) | ((t[0 + 1] >> 6) & 31)]); // Zichen 2
                }
                else
                {
                    s.Append("="); // Zichen 1
                    s.Append("="); // Zichen 2
                }
                if (rest >= 2)
                {
                    s.Append(base32[(t[0 + 1] >> 1) & 31]); // Zichen 3
                    s.Append(base32[((t[0 + 1] << 4) & 31) | ((t[0 + 2] >> 4) & 31)]); // Zichen 4
                }
                else
                {
                    s.Append("="); // Zichen 3
                    s.Append("="); // Zichen 4
                }
                if (rest >= 3)
                {
                    s.Append(base32[((t[0 + 2] << 1) & 31) | ((t[0 + 3] >> 7) & 31)]); // Zichen 5
                }
                else
                {
                    s.Append("="); // Zichen 5
                }
                if (rest >= 4)
                {
                    s.Append(base32[(t[0 + 3] >> 2) & 31]); // Zichen 6
                    s.Append(base32[((t[0 + 3] << 3) & 31) | ((t[0 + 4] >> 5) & 31)]); // Zichen 7
                }
                else
                {
                    s.Append("="); // Zichen 6
                    s.Append("="); // Zichen 7
                }
                if (rest >= 5)
                {
                    s.Append(base32[(t[0 + 4]) & 31]); // Zichen 8
                }
                else
                {
                    s.Append("="); // Zichen 8
                }
            }
            return s.ToString();
        }

    }
}
