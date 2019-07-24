using System;
using System.Collections.Generic;

namespace MoG
{
    public class IntergalacticScript
    {
        public List<string> PlayScript(string[] dialogues)
        {
            var merchant = new Merchant();
            var responses = new List<string>();
            foreach( var dialogue in dialogues )
            {
                var isQuestion = dialogue.EndsWith("?", StringComparison.Ordinal);
                if (isQuestion == true)
                    responses.Add(merchant.Ask(dialogue).Text);
                else
                    merchant.Tell(dialogue);
            }
            return responses;
        }
    }
}
