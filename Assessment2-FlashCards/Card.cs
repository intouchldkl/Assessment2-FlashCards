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

        /// <summary>
        ///  Constructor for a Card class
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        public Card(string question,string answer)
        {
            this.question = question;
            this.answer = answer;
        }

        /// <summary>
        /// A mutator that flips the card around
        /// </summary>
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

        /// <summary>
        /// An accessor to card text
        /// </summary>
        /// <returns></returns>
        /// returns the text on the card
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

        /// <summary>
        /// Accessor to check if the card is flipped
        /// </summary>
        /// <returns></returns>
        /// returns bool value,True indicates card is flipped 
        public bool isFlipped()
        {
            return flipped;
        }
        /// <summary>
        /// Accessor to get the answer of the card
        /// </summary>
        /// <returns></returns>
        /// answer
        public string getAnswer()
        {
            return answer;
        }
        /// <summary>
        /// Accessor to get the question of the card
        /// </summary>
        /// <returns></returns>
        public string getQuestion()
        {
            return question;
        }
    }
}
