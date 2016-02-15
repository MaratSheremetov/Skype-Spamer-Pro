using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYPE4COMLib;
using System.Threading;

namespace Skype_Spamer_Pro
{

    public partial class Form1 : Form
    {
        Skype skype = new Skype();

        string pup;
        Thread[] tFlood;
        int numThread;
        int _time;
        string text;
        int numLetter;

        bool isWork = true;
        bool t = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            isWork = false;
            t = false;
            MessageBox.Show("Спам остоновлен");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Pup_TextChanged(object sender, EventArgs e)
        {

        }

        private void Num_Letter_TextChanged(object sender, EventArgs e)
        {

        }

        private void Thread_TextChanged(object sender, EventArgs e)
        {

        }

        private void TExt_TextChanged(object sender, EventArgs e)
        {

        }

        private void time_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tree_Click(object sender, EventArgs e)
        {
            t = true;
            Thread t1 = new Thread(_Tree);
            t1.IsBackground = true;
            t1.Start();
           
        }
        public void _Tree()
        {
            while (t)
            {
                Thread.Sleep(50);
                for (int i = 0; i < 2; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                skype.ChangeUserStatus(TUserStatus.cusDoNotDisturb);
                                break;
                            }

                        case 1:
                            {
                                skype.ChangeUserStatus(TUserStatus.cusOnline);
                                break;
                            }


                    }
                }
            }
        }

        private void Startus_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pup = Pup.Text;
            numLetter = int.Parse(Num_Letter.Text);
            numThread = int.Parse(_Thread.Text);
            text = TExt.Text;
            _time = int.Parse(time.Text);

            tFlood = new Thread[numThread];
            isWork = true;
            for (int i = 0; i < numThread; i++)
            {
                tFlood[i] = new Thread(Spam);
                tFlood[i].IsBackground = true;
                tFlood[i].Start();
            }
        }

        private void Spam()
        {
            if (!skype.Client.IsRunning)
            {
                skype.Client.Start();
            }
            skype.Attach();
            int i = 0;
            while (i < numLetter)
            {
                if(!isWork)
                {
                    break;
                }
                skype.SendMessage(pup, text);
                Thread.Sleep(_time);
                i++;
            }
        }
    }
}
