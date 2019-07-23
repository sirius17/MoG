using System;
using System.Collections.Generic;

namespace MoG
{
    public class GalacticNumberSystem
    {

        private Dictionary<string, string> _aliases = new Dictionary<string, string>();

        public void SetAlias(string digit, string alias)
        {
            _aliases[alias] = digit;
        }

        public string GetAlias(string alias)
        {
            return _aliases[alias];
        }
    }
}
