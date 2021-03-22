using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Assessment2_FlashCards
{
    class Deck
    {
        private Card[] cards;
        private string fileName;
        private int topCard;
        private int length;


        /// <summary>
        /// Constructor for the Deck class
        /// </summary>
        /// <param name="fileName"></param>
        public Deck(string fileName)
        {
            this.fileName = fileName;
           
            loadData();
        }
        /// <summary>
        /// Mutator-make the topCard increase by 1
        /// </summary>
        public void nextCard()
        {
            topCard++;
            if(topCard >= cards.Length)
            {
                topCard = 0;
            }
            
        }

        /// <summary>
        /// Mutator-Make the topCard decrease by 1
        /// </summary>
        public void previousCard()
        {
           if(topCard <= 0)
            {
                topCard = cards.Length;
            }
            topCard--;
            
        }
        /// <summary>
        /// Replace the topCard by a random number
        /// </summary>
        public void getRandomCard()
        {
            Random rnd = new Random();
            topCard = rnd.Next(0, cards.Length - 1);
            
            
        }
        
        /// <summary>
        /// To read file and construct the cards array
        /// </summary>
        public void loadData()
        {
            //This part is to get the length of the file
            length = 0;
            StreamReader fileReader = new StreamReader(fileName);
            while ((fileReader.ReadLine()) != null)
            {
                length++;
            }
            //

            //This part is to get the input from the file and put it in the constructor
            fileReader = new StreamReader(fileName);
            string line = fileReader.ReadLine();
           cards = new Card[length - 1];
            int count = 0;
            while ((line = fileReader.ReadLine()) != null)
            {
                string[] cells = line.Split(',');
                string Q = cells[0];
                string A = cells[1];

                cards[count] = new Card(Q, A);
                count++;

            }
            //
        }

        /// <summary>
        /// Generate two random numbers to use it as indexes in cards array and swap the two around 100 times
        /// </summary>
        public void shuffleDeck()
        {
            
            Random rnd = new Random();
            for (int i = 0;i < 100;i++)
            {
                int z = rnd.Next(0, cards.Length - 1);
                int r = rnd.Next(0, cards.Length - 1);
                Card Temp = cards[z];
                cards[z] = cards[r];
                cards[r] = Temp;

            }
        }

        /// <summary>
        /// Accessor to a card object
        /// </summary>
        /// <returns></returns>
        /// Returns a Card object
        public Card getCard()
        {
            return cards[topCard];
          
        }
        
        /// <summary>
        /// Accessor to the length of the deck
        /// </summary>
        /// <returns></returns>
        /// returns deck length
        public int getDeckLength()
        {
            return length - 1;
        }

        /// <summary>
        /// Accessor to the index of the top card of the deck
        /// </summary>
        /// <returns></returns>
        /// returns topCard
        public int getCardIndex()
        {
            return topCard;
        }

        /// <summary>
        /// Mutator-Reset the topCard to 0
        /// </summary>
        public void refreshDeck()
        {
            topCard = 0;
         
        }
        public Card getSpecificCard(int i)
        {
            return cards[i];
        }
    }
}
