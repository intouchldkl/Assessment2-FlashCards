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
        private int index, m, s, ms, mChosen, sChosen, msChosen, dc, di,ti;
        private bool isOnRaceMode;
        private Deck[] decks;
        private string ShortFileName;
        private bool isAutoFlip ;
        private bool autoFliptemp;
        private bool isTYSon;
        private string[] answers;
        private bool tysButtonClickedOnce;



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
                loadButton.Enabled = true;
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
            UpdateCardText();
            index = decks[di].getCardIndex();
           progressBar1.Minimum = 0;
            progressBar1.Maximum = decks[di].getDeckLength();
            updateProgressBar();
            answers = new string[decks[di].getDeckLength()];


        }

        private void loadButton_Click(object sender, EventArgs e)
        {

            UpdateCardText();
            index = decks[di].getCardIndex();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = decks[di].getDeckLength();
            updateProgressBar();
            progressBar1.Visible = true;
            ProgressLabel.Visible = true;
            flashCardButtonsEnable(true);
            randomButton.Enabled = true;
            raceMode.Enabled = true;
            checkBox1.Enabled = true;
            DisablePreviousButtonCheck();
            loadButton.Enabled = false;
            answers = new string[decks[di].getDeckLength()];

        }



        public void AddDeck()
        {
            fileComboBox.Items.Add(ShortFileName);
        }



        private void flipButton_Click(object sender, EventArgs e)
        {
            decks[di].getCard().flipCard();
            UpdateCardText();
            if (isOnRaceMode == true && progressBar1.Value == decks[di].getDeckLength())
            {

                flashCardButtonsEnable(false);
                timer1.Enabled = false;
                StartButton.Enabled = false;
                StopButton.Enabled = false;
                ExitRaceModeButton.Enabled = true;
                ShuffleButton.Visible = true;
                ShuffleButton.Enabled = true;
                TimeSelection.Enabled = true;


            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            autoFlipCard(isAutoFlip);
            decks[di].previousCard();
            index = decks[di].getCardIndex();
            UpdateCardText();
            updateProgressBar();
            DisablePreviousButtonCheck();
            DisableNextButtonCheck();
           
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            autoFlipCard(isAutoFlip);
            decks[di].nextCard();
            index = decks[di].getCardIndex();
            UpdateCardText();
            updateProgressBar();
            DisablePreviousButtonCheck();
            DisableNextButtonCheck();
            if(isTYSon == true)
            {
                NextButton.Text = "Skip";
                answerBox.Text = "";
            }
            
        }

        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            autoFlipCard(isAutoFlip);
            decks[di].shuffleDeck();
            index = 0;
            UpdateCardText();
            updateProgressBar();
            DisablePreviousButtonCheck();
            DisableNextButtonCheck();
            if(isOnRaceMode == true)
            {
                flashCardButtonsEnable(false);
                ShuffleButton.Enabled = true;
            }
          
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            autoFlipCard(isAutoFlip);
            decks[di].getRandomCard();
            index = decks[di].getCardIndex();
            UpdateCardText();
            updateProgressBar();
            DisablePreviousButtonCheck();
            DisableNextButtonCheck();
            
        }

        private void raceMode_Click(object sender, EventArgs e)
        {
            unFlipAllCards();
            decks[di].refreshDeck();
            index = decks[di].getCardIndex();
            UpdateCardText();
            updateProgressBar();
            RaceModeButtonsVisibility(true);
            randomButton.Visible = false;
            flashCardButtonsEnable(false);
            ShuffleButton.Enabled = true;
            raceMode.Enabled = false;
            isOnRaceMode = true;
            StartButton.Text = "Start";
            autoFliptemp = checkBox1.Checked;
            checkBox1.Checked = true;
            isAutoFlip = true;
            checkBox1.Visible = false;
            TYSButton.Visible = true;

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
       
            if (StartButton.Text == "Start")
            {
                if (decks[di].getCard().isFlipped() == true)
                {
                    decks[di].getCard().flipCard();
                }
                decks[di].refreshDeck();
                index = decks[di].getCardIndex();
                updateProgressBar();
            }
            StartButton.Text = "Start";
            ms = 10;
            timer1.Enabled = true;
            StopButton.Enabled = true;
            flashCardButtonsEnable(true);
            ShuffleButton.Visible = false;
            DisablePreviousButtonCheck();
            DisableNextButtonCheck();
            UpdateCardText();
            TimeSelection.Enabled = false;
            ExitRaceModeButton.Enabled = false;
            StartButton.Enabled = false;
            TYSButton.Visible = false;
            if (isTYSon == true)
            {
               
                answerBox.Enabled = true;
                SubmitButton.Enabled = true;
                flipButton.Enabled = false;
            }


        }



        private void ExitRaceModeButton_Click(object sender, EventArgs e)
        {
            if (decks[di].getCard().isFlipped() == true)
            {
                decks[di].getCard().flipCard();
            }
            isOnRaceMode = false;
            raceMode.Enabled = true;
            StartButton.Enabled = false;
            StopButton.Enabled = false;
            restartButton.Enabled = false;
            TimerLabel.Text = "00:00:00";
            RaceModeButtonsVisibility(false);
            flashCardButtonsEnable(true);
            randomButton.Visible = true;
            decks[di].refreshDeck();
            index = decks[di].getCardIndex();
            UpdateCardText();
            checkBox1.Checked = autoFliptemp;
            isAutoFlip = autoFliptemp;
            checkBox1.Visible = true;
            ShuffleButton.Visible = true;
            TYSButton.Visible = false;

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            flashCardButtonsEnable(false);
            timer1.Enabled = false;
            StopButton.Enabled = false;
            StartButton.Text = "Resume";
            TimeSelection.Enabled = true;
            ExitRaceModeButton.Enabled = true;
            StartButton.Enabled = true;
            TYSButton.Visible = true;
            if (isTYSon == true)
            {
                answerBox.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerLabel.Text = getTime();
            ms -= 1;

            if (ms == 0)
            {
                ms = 9;
                s -= 1;
            }
            else if (s == 0)
            {
                s = 59;
                m -= 1;
            }
            else if (m < 0)
            {
                TimerLabel.Text = "00:00:00";
                flashCardBox.Text = "TIME'S UP";
                flashCardBox.SelectionAlignment = HorizontalAlignment.Center;
                timer1.Enabled = false;
                ShuffleButton.Enabled = true;
                ExitRaceModeButton.Enabled = true;
                TimeSelection.Enabled = true;
                StopButton.Enabled = false;
                flashCardButtonsEnable(false);
            }

        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            if (decks[di].getCard().isFlipped() == true)
            {
                decks[di].getCard().flipCard();
            }
            timeIndexCheck();
            TimerLabel.Text = getChosenTime();
            timer1.Enabled = false;
            flashCardButtonsEnable(false);
            ShuffleButton.Enabled = true;
            ShuffleButton.Visible = true;
            StartButton.Enabled = true;
            decks[di].refreshDeck();
            index = decks[di].getCardIndex();
            UpdateCardText();
            updateProgressBar();
            StartButton.Text = "Start";
            TimeSelection.Enabled = true;
            ExitRaceModeButton.Enabled = true;
            StartButton.Enabled = true;
            TYSButton.Visible = true;
            if (isTYSon == true)
            {
                answerBox.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                isAutoFlip = true;
                unFlipAllCards();
            }
            else if(checkBox1.Checked == false)
            {
                isAutoFlip = false;
            }
        }

        private void TimeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ti = TimeSelection.SelectedIndex;

            timeIndexCheck();
            TimerLabel.Text = getChosenTime();
            StartButton.Enabled = true;
            restartButton.Enabled = true;
            StartButton.Text = "Start";
        }

        public string getTime()
        {
            string m1 = m.ToString();
            string s1 = s.ToString();
            string ms1 = ms.ToString();

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

        private void fontButton_Click(object sender, EventArgs e)
        {
           
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                flashCardBox.Font = fontDialog1.Font;
                
            }
        }

        private void TYSButton_Click(object sender, EventArgs e)
        {
            if(tysButtonClickedOnce == false)
            {
              
                isTYSon = true;
                TYSButton.BackColor = Color.Green;
                NextButton.Text = "Skip";
                answerLabel.Visible = true;
                answerBox.Visible = true;
                SubmitButton.Visible = true;
                tysButtonClickedOnce = true;
                decks[di].refreshDeck();
                UpdateCardText();
                updateProgressBar();
                StartButton.Enabled = false;
                restartButton.Enabled = false;
                TimerLabel.Text = "00:00:00";
                StartButton.Text = "Start";
                

            }
            else if(tysButtonClickedOnce == true)
            {
                isTYSon = false;
                TYSButton.BackColor = Color.White;
                NextButton.Text = "Next";
                answerLabel.Visible = false;
                answerBox.Visible = false;
                SubmitButton.Visible = false;
                tysButtonClickedOnce = false;
                decks[di].refreshDeck();
                UpdateCardText();
                updateProgressBar();
                StartButton.Enabled = false;
                restartButton.Enabled = false;
                TimerLabel.Text = "00:00:00";
                StartButton.Text = "Start";
            }
           

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            answers[index] = answerBox.Text;
            NextButton.Text = "Next";
            if (index+1 == decks[di].getDeckLength())
            {
                timer1.Enabled = false;
                flashCardButtonsEnable(false);
                SubmitButton.Enabled = false;
                flashCardBox.Text = "Your result: " + calResult().ToString() +"%"+  "\n" + getResult() + "Correct answers:" + "\n" + getAllAnswers();
                string text = "You got " + calResult() + "%";
                MessageBox.Show(text);
                StartButton.Enabled = false;
                StopButton.Enabled = false;
                ExitRaceModeButton.Enabled = true;
                ShuffleButton.Visible = true;
                ShuffleButton.Enabled = true;
                TimeSelection.Enabled = true;
                answerBox.Text = "";
                resetAnswers();
                

            }

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

     

        public void DisablePreviousButtonCheck()
        {
            if (progressBar1.Value == 1)
            {
                PreviousButton.Enabled = false;
            }
            else
            {
                PreviousButton.Enabled = true;
            }
        }
        public void DisableNextButtonCheck()
        {
            if (progressBar1.Value == decks[di].getDeckLength())
            {
                NextButton.Enabled = false;

            }
            else
            {
                NextButton.Enabled = true;
            }
        }
        public void UpdateCardText()
        {

          
            flashCardBox.Text =  decks[di].getCard().getCardText();
            flashCardBox.SelectionAlignment = HorizontalAlignment.Center;
            
        }
        public void autoFlipCard(bool check)
        {
            if(check == true)
            {
                if (decks[di].getCard().isFlipped() == true)
                {
                    decks[di].getCard().flipCard();
                }
            }  
        }
        public void timeIndexCheck()
        {
            if (ti == 0)
            {
                m = 5;
                mChosen = 5;
                s = 0;
                ms = 0;
                sChosen = 0;
                msChosen = 0;

            }
            else if (ti == 1)
            {
                m = 3;
                mChosen = 3;
                s = 0;
                ms = 0;
                sChosen = 0;
                msChosen = 0;

            }
            else if (ti == 2)
            {
                m = 1;
                mChosen = 1;
                s = 0;
                ms = 0;
                sChosen = 0;
                msChosen = 0;

            }
           
        }
        public void unFlipAllCards()
        {
            for (int i = 0; i < decks[di].getDeckLength(); i++)
            {
                if (decks[di].getSpecificCard(i).isFlipped() == true)
                {
                    decks[di].getSpecificCard(i).flipCard();
                }
            }
        }
        public void updateProgressBar()
        {
            ProgressLabel.Text = "Card " + (index + 1).ToString() + "/" + decks[di].getDeckLength().ToString();
            progressBar1.Value = index + 1;
        }
        public double calResult()
        {
            double percent = 0;
            int total = 0;
            for (int i = 0; i < decks[di].getDeckLength(); i++)
            {
                if(answers[i] == decks[di].getSpecificCard(i).getAnswer())
                {
                    total+=1;
                }
            }
            percent =  (Convert.ToDouble(total) / Convert.ToDouble(decks[di].getDeckLength())) * 100 ;
            percent = Math.Round(percent);
            return percent;
           
        }
        public string getResult()
        {
            string result = "";
            string tick;
            for (int i = 0; i < decks[di].getDeckLength();i++)
            {
                if(answers[i] == decks[di].getSpecificCard(i).getAnswer())
                {
                    tick = "✓";
                }
                else
                {
                    tick = "✘";
                }
                result += tick + answers[i] + "\n";

                
                

             }
            return result;
        }
        public string getAllAnswers()
        {
            string result = "";
            for (int i = 0; i < decks[di].getDeckLength(); i++)
            {
                result += decks[di].getSpecificCard(i).getAnswer() + "\n";
            }
            return result;

        }
        public void resetAnswers()
        {
            for(int i=0;i < decks[di].getDeckLength(); i++)
            {
                answers[i] = "";
            }
        }
    }
}
