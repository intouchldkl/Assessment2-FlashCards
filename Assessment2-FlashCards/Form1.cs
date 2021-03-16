using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessment2_FlashCards
{
    public partial class Form1 : Form
    {
        private string fileName;
        Deck deck;
        private int index = 0;
        public Form1()
        {
            InitializeComponent();
            

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true

            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                deck = new Deck(fileName);
                FlashCardDetail.Text = deck.getCard(0).getCardText();
                ProgressLabel.Text = "Progress " + (index + 1).ToString() + "/" + deck.getCardLength().ToString();
                progressBar1.Minimum = 0;
                progressBar1.Maximum = deck.getCardLength();
                progressBar1.Value = index + 1;
            }


        }

       

        private void flipButton_Click(object sender, EventArgs e)
        {
            deck.getCard(index).flipCard();
            FlashCardDetail.Text = deck.getCard(index).getCardText();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            index = deck.previousCard();
            FlashCardDetail.Text = deck.getCard(index).getCardText();
            ProgressLabel.Text = "Progress " + (index +1).ToString() + "/" + deck.getCardLength().ToString();
            progressBar1.Value = index + 1;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            index = deck.nextCard();
            FlashCardDetail.Text = deck.getCard(index).getCardText();
            ProgressLabel.Text = "Progress " + (index + 1).ToString() + "/" + deck.getCardLength().ToString();
            progressBar1.Value = index + 1;
        }

        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            deck.shuffleDeck();
            index = 0;
            FlashCardDetail.Text = deck.getCard(index).getCardText();
            ProgressLabel.Text = "Progress " + (index + 1).ToString() + "/" + deck.getCardLength().ToString();
            progressBar1.Value = index + 1;
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            index = deck.getRandomCard();
            FlashCardDetail.Text = deck.getCard(index).getCardText();
            ProgressLabel.Text = "Progress " + (index + 1).ToString() + "/" + deck.getCardLength().ToString();
            progressBar1.Value = index + 1;
        }

        
    }
}
