using System;

namespace BitOperations
{
    /// <summary>
    /// Provides static metohods with numbers.
    /// </summary>
    public static class NumbersExtension
    {
        /// <summary>
        /// Inserts first (j - i + 1), (i less or equals j) bits sequence from second number into first number from i to j position.
        /// </summary>
        /// <param name="sourceNumber">First number.</param>
        /// <param name="anotherNumber">Second number.</param>
        /// <param name="i">i position.</param>
        /// <param name="j">j position.</param>
        /// <returns>Changed first number (see summary).</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when i or j is less than 0 or more than 31.</exception>
        /// <exception cref="ArgumentException">Thrown when i is more than j.</exception>
        public static int InsertNumberIntoAnother(int sourceNumber, int anotherNumber, int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentException("i should be less than or equal to j");
            }

            int digitsQuantity = sizeof(int) * 8;
            if ((i < 0) || (i > digitsQuantity - 1))
            {
                throw new ArgumentOutOfRangeException("i", "i range is from 0 to 31 (including)");
            }

            if ((j < 0) || (j > digitsQuantity - 1))
            {
                throw new ArgumentOutOfRangeException("j", "j range is from 0 to 31 (including)");
            }

            int mask = GetMask(j - i + 1, digitsQuantity);
            anotherNumber &= mask; // выделение последовательности битов
            anotherNumber <<= i; // сдвиг на позицию i
            int shiftedInvertedMask = ~(mask << i); // инвертирование и сдвиг маски на позиции c i по j
            sourceNumber &= shiftedInvertedMask; // зануление позиций source с i по j
            sourceNumber |= anotherNumber; // вставка последовательности

            return sourceNumber;
        }

        private static int GetMask(int maskBitsQuantity, int digitsQuantity)
        {
            if (maskBitsQuantity == digitsQuantity)
            {
                return -1;
            }

            int mask = 1;
            mask = (mask << maskBitsQuantity) - 1;

            return mask;
        }
    }
}