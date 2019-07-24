using System;
using System.Collections.Generic;
using System.Linq;

namespace MoG
{
    public class GalacticNumberSystem
    {

        private Dictionary<string, RomanDigit> _aliases = new Dictionary<string, RomanDigit>();

        public void SetAlias(RomanDigit digit, string alias)
        {
            _aliases[alias] = digit;
        }

        public RomanDigit GetAlias(string alias)
        {
            return _aliases[alias];
        }

        public int GetDecimalValue(string number)
        {
            var digits = number.Split(' ')
                               .Select(GetAlias)
                               .ToArray();
            if (digits.Length == 1)
                return (int)digits.Single();

            var pos = 0;
            var sum = 0;
            while (pos < digits.Length)
            {
                int value = 0;
                var current = (int)digits[pos];
                var next = pos < digits.Length - 1 ? (int)digits[pos + 1] : 0;
                if (next > current)
                {
                    value = next - current;
                    pos += 2;
                }
                else
                {
                    value = current;
                    pos++;
                }
                sum += value;
            }
            return sum;
        }
    }
}
