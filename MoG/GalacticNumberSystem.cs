using System;
using System.Collections.Generic;

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
    }

    public enum RomanDigit
    {
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }
}
