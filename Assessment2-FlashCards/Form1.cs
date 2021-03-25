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
        /// <summary>
        /// fileName represents the file name with filepath
        /// </summary>
        private string fileName;
        /// <summary>
        /// index represents the card that is currently on top
        /// m is minute in the timer
        /// s is second in the timer
        /// ms is millisecond in the timer
        /// mChosen is the minute the user choose from the combobox
        /// sChosen is the second the user choose from the combobox
        /// msChosen is the milisecond the user choose from the combobox
        /// dc is the deck count
        /// di is the deck index
        /// ti is the time index in from the combobox
 
        /// </summary>
        private int index, m, s, ms, mChosen, sChosen, msChosen, dc, di,ti;
        /// <summary>
        /// IsOnRaceMode indicates whether raceMode is on or not
        /// </summary>
        private bool isOnRaceMode;
        /// <summary>
        /// Array of decks loaded in the file combobox
        /// </summary>
        private Deck[] decks;
        /// <summary>
        /// A filename without filepath
        /// </summary>
        private string ShortFileName;
        /// <summary>
        /// isAutoFlip indicates whether the program should auto unflip the card or not
        /// </summary>
        private bool isAutoFlip ;
        /// <summary>
        /// A temporary attribute to store the value of isAutoFlip when enter raceMode
        /// </summary>
        private bool autoFliptemp;
        /// <summary>
        /// isTYSon indeicates whether test yourself mode is on or not
        /// </summary>
        private bool isTYSon;
        /// <summary>
        /// array of answers entered in test yourself mode
        /// </summary>
        private string[] answers;
        /// <summary>
        /// indicates whether tysButton has already been clicked or not
        /// </summary>
        private bool tysButtonClickedOnce;



        public Form1()
        {
            InitializeComponent();
           ///Initialise the array of decks
            decks = new Deck[100];
          

            /// Add time options to the time combobox
            TimeSelection.Items.Add("5 minute");
            TimeSelection.Items.Add("3 minute");
            TimeSelection.Items.Add("1 minute");
            
            

        }


        /// <summary>
        /// When the browse button click the file explorer will pop up and when we choose the file a deck will be created 
        /// with the name of the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// The method allows me to choose the deck that has already been loaded and initialise a new array of answer in tysMode
        /// It will also reset the text on the richtextbox and the progressbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When the load buuton is clicked the text on the richtextbox and progressbar will change to the topcard of the deck
        /// that has been loaded and it will enable all necessary buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Add the file name without file to fileCombobox
        /// </summary>
        public void AddDeck()
        {
            fileComboBox.Items.Add(ShortFileName);
        }


        /// <summary>
        /// Flip the card and update the text on the richTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flipButton_Click(object sender, EventArgs e)
        {
            decks[di].getCard().flipCard();
            UpdateCardText();
            /// this if statement is to stop the timer on racemode when the last card is fliped
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

        /// <summary>
        /// This method will change the topcard to the previous card and output it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            autoFlipCard(isAutoFlip);
            decks[di].previousCard();
            index = decks[di].getCardIndex();
            UpdateCardText();
            updateProgressBar();
            DisablePreviousButtonCheck();
            DisableNextButtonCheck();
            
            if(isTYSon == true)
            {
             ///this line is to make sure that the answerbox shows the answer you have already submitted
                answerBox.Text = answers[index];
                ///This if statement is to make sure that if the answer is typed,Skip will become next
                if(answerBox.Text != "")
                {
                    NextButton.Text = "Next";
                }
            }
           
        }
        /// <summary>
        /// When the next button is clicked get the next class and output it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
          
                answerBox.Text = answers[index];
            }
            
        }

        /// <summary>
        /// To shuffle cards and reset the index to 0 and output the new topcard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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

        /// <summary>
        /// get a random card and output it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// click to enable race mode and temporarily disable all the flashcard buttons until the user start the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// to start the timer and enable the flashcard buttons like next,flip,previous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
       ///If the start button is start and not resume,the deck will get refresh so the index will be 0
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
                ///To reset answer everytime you start the game
                if(StartButton.Text == "Start")
                {
                    resetAnswers();
                }
            }


        }


        /// <summary>
        /// To exit the racemode and come back to the main mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This button is to stop the timer and temporarily disble the flashcard control buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// This is to make the timer decrease 1 millisecond every interval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if(isTYSon == true)
                {
                    SubmitButton.Enabled = false;
                    flashCardBox.Text = "Your result: " + calResult().ToString() + "%" + "\n" + getResult() + "Correct answers:" + "\n" + getAllAnswers();
                    MessageBox.Show("TIME'S UP");
                }
            }

        }

        /// <summary>
        /// This is to restart the timer to the time chosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
        /// <summary>
        /// this allows you to choose whether you want the program to auto unflip cards or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This is when the chosen time is changed,the program will change the timer as well
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ti = TimeSelection.SelectedIndex;

            timeIndexCheck();
            TimerLabel.Text = getChosenTime();
            StartButton.Enabled = true;
            restartButton.Enabled = true;
            StartButton.Text = "Start";
        }

        /// <summary>
        /// this is to update the time everytime the timer tick
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// this is to get the time chosen from the combobox
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// this allows you to change the font
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fontButton_Click(object sender, EventArgs e)
        {
           
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                flashCardBox.Font = fontDialog1.Font;
                
            }
        }

        /// <summary>
        /// this allows you to enable test yourself mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TYSButton_Click(object sender, EventArgs e)
        {
            ///I have an if statement because i don't want to add another exit button 
            ///so I make it if you click the button once then enable if click again then disable
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
        /// <summary>
        /// This is for the user to submit the answer and store the answer in answers array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            answers[index] = answerBox.Text;
            NextButton.Text = "Next";
            ///This if statement is to get the result when the user submit the last question
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

        /// <summary>
        /// to control the visibility of the racemode buttons
        /// </summary>
        /// <param name="visibility"></param>
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

        /// <summary>
        /// To enable or disble the flashcard control buttons
        /// </summary>
        /// <param name="enable"></param>
        public void flashCardButtonsEnable(bool enable)
        {
            flipButton.Enabled = enable;
            NextButton.Enabled = enable;
            PreviousButton.Enabled = enable;
            ShuffleButton.Enabled = enable;
        }

     
        /// <summary>
        /// to check if the card is at card 1 if so then disable the previous button
        /// </summary>
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

        /// <summary>
        /// to check if the card is the last card if so then disable the next button
        /// </summary>
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
        /// <summary>
        /// to update the text on richtextbox
        /// </summary>
        public void UpdateCardText()
        {

          
            flashCardBox.Text =  decks[di].getCard().getCardText();
            flashCardBox.SelectionAlignment = HorizontalAlignment.Center;
            
        }
        /// <summary>
        /// to check whether you want the cards to be auto unflipped or not
        /// </summary>
        /// <param name="check"></param>
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
        /// <summary>
        /// when the time is chosen from the combobox this method will set the value of time
        /// </summary>
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
        /// <summary>
        /// To unflip all cards
        /// </summary>
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
        /// <summary>
        /// To update the progressbar
        /// </summary>
        public void updateProgressBar()
        {
            ProgressLabel.Text = "Card " + (index + 1).ToString() + "/" + decks[di].getDeckLength().ToString();
            progressBar1.Value = index + 1;
        }
        /// <summary>
        /// To calculate the result of the answers in test yourself mode
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// To put the user's answer in format
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// To get all the correct answers and put it in the format
        /// </summary>
        /// <returns></returns>
        public string getAllAnswers()
        {
            string result = "";
            for (int i = 0; i < decks[di].getDeckLength(); i++)
            {
                result += decks[di].getSpecificCard(i).getQuestion() + "\n" +":"+ decks[di].getSpecificCard(i).getAnswer() + "\n";
            }
            return result;

        }
        /// <summary>
        /// To reset all the answers
        /// </summary>
        public void resetAnswers()
        {
            for(int i=0;i < decks[di].getDeckLength(); i++)
            {
                answers[i] = "";
            }
        }
    }
}
