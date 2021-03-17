using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Assessment2_FlashCards
{
    

    public partial class Form1 : Form
    {
        private string fileName;
        Deck deck;
        private int index = 0;
        System.Timers.Timer t;
        private int m;
        private int s;
        private int ms;
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
                FlashCardDetail.Text = deck.getCard().getCardText();
                ProgressLabel.Text = "Progress " + (index + 1).ToString() + "/" + deck.getDeckLength().ToString();
                progressBar1.Minimum = 0;
                progressBar1.Maximum = deck.getDeckLength();
                progressBar1.Value = index + 1;
                ShuffleButton.Visible = true;
                randomButton.Visible = true;
                flipButton.Visible = true;
                NextButton.Visible = true;
                PreviousButton.Visible = true;
                progressBar1.Visible = true;
                ProgressLabel.Visible = true;
            }


        }

       

        private void flipButton_Click(object sender, EventArgs e)
        {
            deck.getCard().flipCard();
            FlashCardDetail.Text = deck.getCard().getCardText();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            deck.previousCard();
            index = deck.getCardIndex();
            FlashCardDetail.Text = deck.getCard().getCardText();
            ProgressLabel.Text = "Progress " + (index +1).ToString() + "/" + deck.getDeckLength().ToString();
            progressBar1.Value = index + 1;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            deck.nextCard();
            index = deck.getCardIndex();
            FlashCardDetail.Text = deck.getCard().getCardText();
            ProgressLabel.Text = "Progress " + (index + 1).ToString() + "/" + deck.getDeckLength().ToString();
            progressBar1.Value = index + 1;
        }

        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            deck.shuffleDeck();
            index = 0;
            FlashCardDetail.Text = deck.getCard().getCardText();
            ProgressLabel.Text = "Progress " + (index + 1).ToString() + "/" + deck.getDeckLength().ToString();
            progressBar1.Value = index + 1;
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            deck.getRandomCard();
            index = deck.getCardIndex();
            FlashCardDetail.Text = deck.getCard().getCardText();
            ProgressLabel.Text = "Progress " + (index + 1).ToString() + "/" + deck.getDeckLength().ToString();
            progressBar1.Value = index + 1;
        }

        private void raceMode_Click(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 100;
            t.Elapsed += OnTimeEvent;

        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
           Invoke(new Action(() =>
           {
               ms -= 1;
               if(ms == 0)
               {
                   ms = 10
               }
           }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        private void StopButton_Click(object sender, EventArgs e)
        {

        }

      
    }
}
