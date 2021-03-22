
namespace Assessment2_FlashCards
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.FlashCardDetail = new System.Windows.Forms.Label();
            this.fileComboBox = new System.Windows.Forms.ComboBox();
            this.FileLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.flipButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ShuffleButton = new System.Windows.Forms.Button();
            this.randomButton = new System.Windows.Forms.Button();
            this.raceMode = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimerLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.TimeSelection = new System.Windows.Forms.ComboBox();
            this.selectTimeLabel = new System.Windows.Forms.Label();
            this.ExitRaceModeButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.flashCardBox = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fontButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "FLASHCARD";
            // 
            // FlashCardDetail
            // 
            this.FlashCardDetail.AutoSize = true;
            this.FlashCardDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlashCardDetail.Location = new System.Drawing.Point(299, 207);
            this.FlashCardDetail.Name = "FlashCardDetail";
            this.FlashCardDetail.Size = new System.Drawing.Size(138, 13);
            this.FlashCardDetail.TabIndex = 2;
            this.FlashCardDetail.Text = "Please browse your file";
            this.FlashCardDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fileComboBox
            // 
            this.fileComboBox.FormattingEnabled = true;
            this.fileComboBox.Location = new System.Drawing.Point(239, 29);
            this.fileComboBox.Name = "fileComboBox";
            this.fileComboBox.Size = new System.Drawing.Size(224, 21);
            this.fileComboBox.TabIndex = 3;
            this.fileComboBox.SelectedIndexChanged += new System.EventHandler(this.fileComboBox_SelectedIndexChanged);
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileLabel.Location = new System.Drawing.Point(200, 30);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(33, 16);
            this.FileLabel.TabIndex = 4;
            this.FileLabel.Text = "File:";
            // 
            // browseButton
            // 
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.Location = new System.Drawing.Point(480, 27);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Enabled = false;
            this.PreviousButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviousButton.Location = new System.Drawing.Point(208, 329);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(95, 23);
            this.PreviousButton.TabIndex = 6;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // flipButton
            // 
            this.flipButton.BackColor = System.Drawing.Color.Red;
            this.flipButton.Enabled = false;
            this.flipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flipButton.Location = new System.Drawing.Point(351, 322);
            this.flipButton.Name = "flipButton";
            this.flipButton.Size = new System.Drawing.Size(75, 35);
            this.flipButton.TabIndex = 7;
            this.flipButton.Text = "FLIP!";
            this.flipButton.UseVisualStyleBackColor = false;
            this.flipButton.Click += new System.EventHandler(this.flipButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Enabled = false;
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(480, 328);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 8;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(17, 119);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(143, 17);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Visible = false;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressLabel.Location = new System.Drawing.Point(14, 149);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(68, 15);
            this.ProgressLabel.TabIndex = 10;
            this.ProgressLabel.Text = "Progress ";
            this.ProgressLabel.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.Enabled = false;
            this.ShuffleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShuffleButton.Location = new System.Drawing.Point(17, 354);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(75, 29);
            this.ShuffleButton.TabIndex = 11;
            this.ShuffleButton.Text = "Shuffle";
            this.ShuffleButton.UseVisualStyleBackColor = true;
            this.ShuffleButton.Click += new System.EventHandler(this.ShuffleButton_Click);
            // 
            // randomButton
            // 
            this.randomButton.Enabled = false;
            this.randomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomButton.Location = new System.Drawing.Point(109, 354);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(75, 29);
            this.randomButton.TabIndex = 12;
            this.randomButton.Text = "Random";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // raceMode
            // 
            this.raceMode.Enabled = false;
            this.raceMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raceMode.Location = new System.Drawing.Point(641, 354);
            this.raceMode.Name = "raceMode";
            this.raceMode.Size = new System.Drawing.Size(111, 29);
            this.raceMode.TabIndex = 13;
            this.raceMode.Text = "Race Mode";
            this.raceMode.UseVisualStyleBackColor = true;
            this.raceMode.Click += new System.EventHandler(this.raceMode_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(636, 139);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(128, 31);
            this.TimerLabel.TabIndex = 14;
            this.TimerLabel.Text = "00:00:00";
            this.TimerLabel.Visible = false;
            // 
            // StartButton
            // 
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(653, 187);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 15;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Visible = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(653, 226);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 16;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Visible = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.Enabled = false;
            this.restartButton.Location = new System.Drawing.Point(653, 264);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(75, 23);
            this.restartButton.TabIndex = 17;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Visible = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // TimeSelection
            // 
            this.TimeSelection.FormattingEnabled = true;
            this.TimeSelection.Location = new System.Drawing.Point(643, 91);
            this.TimeSelection.Name = "TimeSelection";
            this.TimeSelection.Size = new System.Drawing.Size(121, 21);
            this.TimeSelection.TabIndex = 18;
            this.TimeSelection.Visible = false;
            this.TimeSelection.SelectedIndexChanged += new System.EventHandler(this.TimeSelection_SelectedIndexChanged);
            // 
            // selectTimeLabel
            // 
            this.selectTimeLabel.AutoSize = true;
            this.selectTimeLabel.Location = new System.Drawing.Point(597, 94);
            this.selectTimeLabel.Name = "selectTimeLabel";
            this.selectTimeLabel.Size = new System.Drawing.Size(40, 13);
            this.selectTimeLabel.TabIndex = 19;
            this.selectTimeLabel.Text = "Select:";
            this.selectTimeLabel.Visible = false;
            // 
            // ExitRaceModeButton
            // 
            this.ExitRaceModeButton.CausesValidation = false;
            this.ExitRaceModeButton.Location = new System.Drawing.Point(653, 294);
            this.ExitRaceModeButton.Name = "ExitRaceModeButton";
            this.ExitRaceModeButton.Size = new System.Drawing.Size(75, 23);
            this.ExitRaceModeButton.TabIndex = 20;
            this.ExitRaceModeButton.Text = "Exit";
            this.ExitRaceModeButton.UseVisualStyleBackColor = true;
            this.ExitRaceModeButton.Visible = false;
            this.ExitRaceModeButton.Click += new System.EventHandler(this.ExitRaceModeButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.Location = new System.Drawing.Point(573, 27);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 21;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // flashCardBox
            // 
            this.flashCardBox.BackColor = System.Drawing.Color.CadetBlue;
            this.flashCardBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.flashCardBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flashCardBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flashCardBox.Location = new System.Drawing.Point(230, 139);
            this.flashCardBox.Name = "flashCardBox";
            this.flashCardBox.ReadOnly = true;
            this.flashCardBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.flashCardBox.Size = new System.Drawing.Size(315, 178);
            this.flashCardBox.TabIndex = 22;
            this.flashCardBox.Text = "\n\n\n\n\t\t\t\n\tPLEASE BROWSE YOUR FILE";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(17, 57);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 17);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Auto unflip";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // fontButton
            // 
            this.fontButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontButton.Location = new System.Drawing.Point(665, 27);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(75, 23);
            this.fontButton.TabIndex = 24;
            this.fontButton.Text = "Font";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fontButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.flashCardBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.ExitRaceModeButton);
            this.Controls.Add(this.selectTimeLabel);
            this.Controls.Add(this.TimeSelection);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.raceMode);
            this.Controls.Add(this.randomButton);
            this.Controls.Add(this.ShuffleButton);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.flipButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.FileLabel);
            this.Controls.Add(this.fileComboBox);
            this.Controls.Add(this.FlashCardDetail);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
      
        private System.Windows.Forms.Label FlashCardDetail;
        private System.Windows.Forms.ComboBox fileComboBox;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button flipButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ShuffleButton;
        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.Button raceMode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.ComboBox TimeSelection;
        private System.Windows.Forms.Label selectTimeLabel;
        private System.Windows.Forms.Button ExitRaceModeButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.RichTextBox flashCardBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button fontButton;
    }
}

