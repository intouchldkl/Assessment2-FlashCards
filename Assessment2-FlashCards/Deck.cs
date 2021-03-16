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


        public Deck(string fileName)
        {
            this.fileName = fileName;
           
            loadData();
        }
        public int nextCard()
        {
            topCard++;
            if(topCard >= cards.Length)
            {
                topCard = 0;
            }
            return topCard;
        }

        public int previousCard()
        {
           if(topCard <= 0)
            {
                topCard = cards.Length;
            }
            topCard--;
            return topCard;
        }

        public int getRandomCard()
        {
            Random rnd = new Random();
            topCard = rnd.Next(0, cards.Length - 1);
            return topCard;
            
        }
        
        public void loadData()
        {
            length = 0;
            StreamReader fileReader = new StreamReader(fileName);
            while ((fileReader.ReadLine()) != null)
            {
                length++;
            }


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
        }

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

        public Card getCard(int i)
        {
           if(i < cards.Length)
            {
                return cards[i];
            }
           else
            {
                return null;
            }
        }
        
        public int getCardLength()
        {
            return length - 1;
        }
    }
}
