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
        private int index,m,s,ms,mChosen,sChosen,msChosen,dc,di;
        private bool isOnRaceMode;
        private Deck[] decks;
        private string ShortFileName;
        


        public Form1()
        {
            InitializeComponent();
            decks = new Deck[100];
            TimeSelection.Items.Add("5 minute");
            TimeSelection.Items.Add("3 minute");
            TimeSelection.Items.Add("1 minute");
           

        }
      

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                fileName = openFileDialog1.FileName;
                ShortFileName = openFileDialog1.SafeFileName;
                di = dc;
                decks[dc] = new Deck(fileName);
                dc += 1;
                AddDeck();

            }


        }

        private void fileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            di = fileComboBox.SelectedIndex;
            decks[di].refreshDeck();
            FlashCardDetail.Text = decks[di].getCard().getCardText();
            index = decks[di].getCardIndex();
            ProgressLabel.Text = "Card " + (index + 1).ToString() + "/" + decks[di].getDeckLength().ToString();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = decks[di].getDeckLength();
            progressBar1.Value = index + 1;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
           
            FlashCardDetail.Text = decks[di].getCard().getCardText();
            index = decks[di].getCardIndex();
            ProgressLabel.Text = "Card " + (index + 1).ToString() + "/" + decks[di].getDeckLength().ToString();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = decks[di].getDeckLength();
            progressBar1.Value = index + 1;
           
            progressBar1.Visible = true;
            ProgressLabel.Visible = true;
            flashCardButtonsEnable(true);
            randomButton.Enabled = true;
            raceMode.Enabled = true;
            if (progressBar1.Value == 1)
            {
                PreviousButton.Enabled = false;
            }
            else
            {
                PreviousButton.Enabled = true;
            }
        }

       

        public void AddDeck()
        {
            fileComboBox.Items.Add(ShortFileName);
        }

 

        private void flipButton_Click(object sender, EventArgs e)
        {
            decks[di].getCard().flipCard();
            FlashCardDetail.Text = decks[di].getCard().getCardText();
            if (isOnRaceMode == true && progressBar1.Value == decks[di].getDeckLength())
            {

                flashCardButtonsEnable(false);
                timer1.Enabled = false;
                StartButton.Enabled = false;
                StopButton.Enabled = false;
                ShuffleButton.Visible = true;
                ShuffleButton.Enabled = true;
                

            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (decks[di].getCard().isFlipped() == true)
            {
                decks[di].getCard().flipCard();
            }
            decks[di].previousCard();
            index = decks[di].getCardIndex();
            FlashCardDetail.Text = decks[di].getCard().getCardText();
            ProgressLabel.Text = "Card " + (index +1).ToString() + "/" + decks[di].getDeckLength().ToString();
            progressBar1.Value = index + 1;
            if (progressBar1.Value == 1)
            {
                PreviousButton.Enabled = false;
            }
            else
            {
                PreviousButton.Enabled = true;
            }
            if (progressBar1.Value == decks[di].getDeckLength())
            {
                NextButton.Enabled = false;
            }
            else
            {
                NextButton.Enabled = true;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
          if(decks[di].getCard().isFlipped()== true)
            {
                decks[di].getCard().flipCard();
            }
            decks[di].nextCard();
            index = decks[di].getCardIndex();
            FlashCardDetail.Text = decks[di].getCard().getCardText();
            ProgressLabel.Text = "Card " + (index + 1).ToString() + "/" + decks[di].getDeckLength().ToString();
            progressBar1.Value = index + 1;
           
            if (progressBar1.Value == 1)
            {
                PreviousButton.Enabled = false;
            }
            else
            {
                PreviousButton.Enabled = true;
            }
            if(progressBar1.Value == decks[di].getDeckLength())
            {
                NextButton.Enabled = false;
              
            }
            else
            {
                NextButton.Enabled = true; 
            }
        }

        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            if (decks[di].getCard().isFlipped() == true)
            {
                decks[di].getCard().flipCard();
            }
            decks[di].shuffleDeck();
            index = 0;
            FlashCardDetail.Text = decks[di].getCard().getCardText();
            ProgressLabel.Text = "Card " + (index + 1).ToString() + "/" + decks[di].getDeckLength().ToString();
            progressBar1.Value = index + 1;
            if (progressBar1.Value == 1)
            {
                PreviousButton.Enabled = false;
            }
            else
            {
                PreviousButton.Enabled = true;
            }
            if (progressBar1.Value == decks[di].getDeckLength())
            {
                NextButton.Enabled = false;
            }
            else
            {
                NextButton.Enabled = true;
            }
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            if (decks[di].getCard().isFlipped() == true)
            {
                decks[di].getCard().flipCard();
            }
            decks[di].getRandomCard();
            index = decks[di].getCardIndex();
            FlashCardDetail.Text = decks[di].getCard().getCardText();
            ProgressLabel.Text = "Card " + (index + 1).ToString() + "/" + decks[di].getDeckLength().ToString();
            progressBar1.Value = index + 1;
            if (progressBar1.Value == 1)
            {
                PreviousButton.Enabled = false;
            }
            else
            {
                PreviousButton.Enabled = true;
            }
            if (progressBar1.Value == decks[di].getDeckLength())
            {
                NextButton.Enabled = false;
            }
            else
            {
                NextButton.Enabled = true;
            }
        }

        private void raceMode_Click(object sender, EventArgs e)
        {
            decks[di].refreshDeck();
            index = decks[di].getCardIndex();
            ProgressLabel.Text = "Card " + (index + 1).ToString() + "/" + decks[di].getDeckLength().ToString();
            progressBar1.Value = index + 1;
            RaceModeButtonsVisibility(true);
            randomButton.Visible = false;
            flashCardButtonsEnable(false);
            ShuffleButton.Enabled = true;
            raceMode.Enabled = false;
            isOnRaceMode = true;

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Text = "Start";
            ms = 10;
            timer1.Enabled = true;
            flashCardButtonsEnable(true);
            ShuffleButton.Visible = false;
            if (progressBar1.Value == 1)
            {
                PreviousButton.Enabled = false;
            }
            else
            {
                PreviousButton.Enabled = true;
            }
            if (progressBar1.Value == decks[di].getDeckLength())
            {
                NextButton.Enabled = false;
                
            }
            else
            {
                NextButton.Enabled = true;
            }
            FlashCardDetail.Text = decks[di].getCard().getCardText();
        }

  

        private void ExitRaceModeButton_Click(object sender, EventArgs e)
        {
            isOnRaceMode = false;
            raceMode.Enabled = true;
            TimerLabel.Text = "00:00:00";
            RaceModeButtonsVisibility(false);
            flashCardButtonsEnable(true);
            randomButton.Visible = true;
            decks[di].refreshDeck();
            index = decks[di].getCardIndex();
            FlashCardDetail.Text = decks[di].getCard().getCardText();

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            flashCardButtonsEnable(false);
            timer1.Enabled = false;
            StartButton.Text = "Resume";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerLabel.Text = getTime();
            ms -= 1;
            
            if(ms == 0)
            {
                ms = 9;
                    s -= 1;
            }
            else if(s == 0)
            {
                s = 59;
                m -= 1;
            }
            else if(m < 0)
            {
                TimerLabel.Text = "00:00:00";
                FlashCardDetail.Text = "TIME'S UP";
                timer1.Enabled = false;
                ShuffleButton.Enabled = true;

            }
            
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            TimerLabel.Text = getChosenTime() ;
            timer1.Enabled = false;
            flashCardButtonsEnable(false);
            ShuffleButton.Enabled = true;
            ShuffleButton.Visible = true;
            StartButton.Enabled = true;
            StopButton.Enabled = true;
            decks[di].refreshDeck();
            index = decks[di].getCardIndex();
            FlashCardDetail.Text = decks[di].getCard().getCardText();
            ProgressLabel.Text = "Card " + (index + 1).ToString() + "/" + decks[di].getDeckLength().ToString();
            progressBar1.Value = index + 1;
        }

        private void TimeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = TimeSelection.SelectedIndex;
            if(i == 0)
            {
                m = 5;
                mChosen = 5;
                s = 0;
                ms = 0;
                sChosen = 0;
                msChosen = 0;
               
            }
            else if(i == 1)
            {
                m = 3;
                mChosen = 3;
                s = 0;
                ms = 0;
                sChosen = 0;
                msChosen = 0;

            }
            else if(i == 2)
            {
                m = 1;
                mChosen = 1;
                s = 0;
                ms = 0;
                sChosen = 0;
                msChosen = 0;

            }
           TimerLabel.Text = getChosenTime();
            StartButton.Enabled = true;
            StopButton.Enabled = true;
            restartButton.Enabled = true;
        }

    public string getTime()
        {
            string m1 = m.ToString();
            string s1 = s.ToString();
            string ms1 = ms.ToString();

            if(m1.Length == 1)
            {
                m1 = "0" + m1;
            }
            if (s1.Length == 1)
            {
                s1 = "0" + s1;
            }
            if (ms1.Length == 1)
            {
                ms1 = "0" + ms1;
            }

            return m1 + ":" + s1 + ":" + ms1;
        }
        public string getChosenTime()
        {
            string m1 = mChosen.ToString();
            string s1 = sChosen.ToString();
            string ms1 = msChosen.ToString();

            if (m1.Length == 1)
            {
                m1 = "0" + m1;
            }
            if (s1.Length == 1)
            {
                s1 = "0" + s1;
            }
            if (ms1.Length == 1)
            {
                ms1 = "0" + ms1;
            }

            return m1 + ":" + s1 + ":" + ms1;
        }

       public void RaceModeButtonsVisibility(bool visibility)
        {
            selectTimeLabel.Visible = visibility;
            TimerLabel.Visible = visibility;
            TimeSelection.Visible = visibility;
            StartButton.Visible = visibility;
            StopButton.Visible = visibility;
            restartButton.Visible = visibility;
            ExitRaceModeButton.Visible = visibility;
            
        }
        public void flashCardButtonsEnable(bool enable)
        {
            flipButton.Enabled = enable;
            NextButton.Enabled = enable;
            PreviousButton.Enabled = enable;
            ShuffleButton.Enabled = enable;
        }
    }
}
