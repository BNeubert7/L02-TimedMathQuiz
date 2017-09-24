using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L02_TimedMathQuiz
{
    public partial class Form1 : Form
    {

        Random randomizer = new Random();

        int addend1;
        int addend2;
        int minusend1;
        int minusend2;
        int multend1;
        int multend2;
        int divend1;
        int divend2;

        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\neube\source\repos\L02-TimedMathQuiz\Beep_01.wav");

        int timeLeft;

        public void startTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minusend1 = randomizer.Next(1, 101);
            minusend2 = randomizer.Next(1, minusend1);
            minusLeftLabel.Text = minusend1.ToString();
            minusRightLabel.Text = minusend2.ToString();
            difference.Value = 0;

            multend1 = randomizer.Next(2, 11);
            multend2 = randomizer.Next(2, 11);
            timesLeftLabel.Text = multend1.ToString();
            timesRightLabel.Text = multend2.ToString();
            product.Value = 0;

            divend2 = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            divend1 = divend2 * temporaryQuotient;
            dividedLeftLabel.Text = divend1.ToString();
            dividedRightLabel.Text = divend2.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startTheQuiz();
            startButton.Enabled = false;
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right! Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 5)
                    timeLabel.BackColor = Color.Red;
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");

                sum.Value = addend1 + addend2;
                difference.Value = minusend1 = minusend2;
                product.Value = multend1 * multend2;
                quotient.Value = divend1 / divend2;

                startButton.Enabled = true;
            }
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minusend1 - minusend2 == difference.Value)
                && multend1 * multend2 == product.Value
                && divend1 / divend2 == quotient.Value)
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        //SOUNDS BELOW ======================================================================
        private void BeepAdd(object sender, EventArgs e)
        {
            if (addend1 + addend2 == sum.Value)
            {
                player.Play();
            }
        }

        private void BeepSub(object sender, EventArgs e)
        {
            if (minusend1 - minusend2 == difference.Value)
            {
                player.Play();
            }
                
        }

        private void BeepMult(object sender, EventArgs e)
        {
            if (multend1 * multend2 == product.Value)
            {
                player.Play();
            }
        }

        private void BeepDiv(object sender, EventArgs e)
        {
            if (divend1 / divend2 == quotient.Value)
            {
                player.Play();
            }
        }
    }
}