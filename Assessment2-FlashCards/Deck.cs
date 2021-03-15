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

        public Deck(string fileName)
        {
            this.fileName = fileName;
            int length = 0;
            StreamReader fileReader = new StreamReader(fileName+".csv");
            while ((fileReader.ReadLine()) != null)
            {
                length++;
            }


            fileReader = new StreamReader(fileName +".csv");
            string line = fileReader.ReadLine();
            Card[] cards = new Card[length - 1];
            int count = 0;
            while ((line = fileReader.ReadLine()) != null)
            {
                string c = ",";
                string[] cells = line.Split(c.ToCharArray());
                string Q = cells[0];
                string A = cells[1];
               
                cards[count] = new Card(Q,A);
                count++;

            }
        }
        public Card nextCard(int i)
        {
            return cards[i + 1];
        }

        public Card previousCard(int i)
        {
            return cards[i - 1];
        }

        public Card getRandomCard()
        {
            int r = Random.Next(0, cards.Length - 1);
        }
        
        
    }
}
