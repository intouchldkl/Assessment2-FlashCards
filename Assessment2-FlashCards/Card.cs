using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2_FlashCards
{
    class Card
    {
        private string question;
        private string answer;
        private bool flipped;

        public Card(string question,string answer)
        {
            this.question = question;
            this.answer = answer;
        }

        public void flipCard()
        {
            if (flipped)
            {
                flipped = false;
            }
            else
            {
                flipped = true;
            }
        }

        public string getCardText()
        {
            if(flipped)
            {
                return answer;
            }
            else 
            {
                return question;
            }
        }

        public bool isFlipped()
        {
            return flipped;
        }
    }
}
