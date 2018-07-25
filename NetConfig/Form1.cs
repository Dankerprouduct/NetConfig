using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace NetConfig
{

    public partial class Form1 : Form
    {

        int slotNum = 0;
        int portNum = 0;

        int idf_switchNum = 0;
        int idf_cableType = 1;
        int idf_portNum = 0;

        int idfNum = 0;

        int subnet = 0;

        string userLogin = " pi";  // <-- change these 2 for generic user account  
        string userPassword = "rasberry"; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
            GoFullscreen(false); 
            string buttonColor = "#f26430";
            panel1.BackColor = HexToColor("#2a2d34");
            panel2.BackColor = HexToColor("#2a2d34");

            this.BackColor = HexToColor("#2a2d34");

            SecondScreenPanel.BackColor = HexToColor("#2a2d34");



            // Exit Button
            exitButton.BackColor = HexToColor(buttonColor);
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.FlatAppearance.BorderColor = HexToColor(buttonColor);
            exitButton.ForeColor = Color.White;
            exitButton.Font = new Font("Calibri", 10);
            exitButton.Text = "Exit"; 

            //phone Button
            PhoneButton.BackColor = HexToColor(buttonColor);
            PhoneButton.FlatStyle = FlatStyle.Flat; 
            PhoneButton.FlatAppearance.BorderColor = HexToColor(buttonColor);
            PhoneButton.ForeColor = Color.White;
            PhoneButton.Font = new Font("Calibri", 24);
            PhoneButton.Text = "Phone"; 
            

            //WirelessAP Button
            WirelessAPButton.BackColor = HexToColor(buttonColor);
            WirelessAPButton.FlatStyle = FlatStyle.Flat;
            WirelessAPButton.FlatAppearance.BorderColor = HexToColor(buttonColor);
            WirelessAPButton.ForeColor = Color.White;
            WirelessAPButton.Font = new Font("Calibri", 24);
            WirelessAPButton.Text = "Wireless AP"; 


            // Button1
            button1.BackColor = HexToColor(buttonColor);
            button1.FlatStyle = FlatStyle.Flat; 
            button1.FlatAppearance.BorderColor = HexToColor(buttonColor);
            button1.ForeColor = Color.White;
            button1.Font = new Font("Calibri", 8.25f);

            // Button  2
            button2.BackColor = HexToColor(buttonColor);
            button2.FlatStyle = FlatStyle.Flat; 
            button2.FlatAppearance.BorderColor = HexToColor(buttonColor);
            button2.ForeColor = Color.White; 
            button2.Font = new Font("Calibri", 8.25f);

            // button 3
            button3.BackColor = HexToColor(buttonColor); ;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderColor = HexToColor(buttonColor);
            button3.ForeColor = Color.White; 
            button3.Font = new Font("Calibri", 8.25f);

            // button 4
            button4.BackColor = HexToColor(buttonColor);
            button4.FlatStyle = FlatStyle.Flat; 
            button4.FlatAppearance.BorderColor = HexToColor(buttonColor);
            button4.ForeColor = Color.White; 
            button4.Font = new Font("Calibri", 8.25f);

            // IDF Button 
            idfButton.BackColor = HexToColor(buttonColor); ;
            idfButton.FlatStyle = FlatStyle.Flat; 
            idfButton.FlatAppearance.BorderColor = HexToColor(buttonColor);
            idfButton.ForeColor = Color.White; 
            idfButton.Font = new Font("Calibri", 24);

            // mdf button
            mdfButton.BackColor = HexToColor(buttonColor);
            mdfButton.FlatStyle = FlatStyle.Flat;
            mdfButton.FlatAppearance.BorderColor = HexToColor(buttonColor);
            mdfButton.ForeColor = Color.White; 
            mdfButton.Font = new Font("Calibri", 24); 

            // increase cable button
            incrCablebttn.BackColor = HexToColor(buttonColor);
            incrCablebttn.FlatStyle = FlatStyle.Flat; 
            incrCablebttn.FlatAppearance.BorderColor = HexToColor(buttonColor);
            incrCablebttn.ForeColor = Color.White; 
            incrCablebttn.Font = new Font("Calibri", 10);

            // decrease cable button
            decrCableBttn.BackColor = HexToColor(buttonColor);
            decrCableBttn.FlatStyle = FlatStyle.Flat; 
            decrCableBttn.FlatAppearance.BorderColor = HexToColor(buttonColor);
            decrCableBttn.ForeColor = Color.White; 
            decrCableBttn.Font = new Font("Calibri", 10);

            // decrease switch button
            decrSwitchBttn.BackColor = HexToColor(buttonColor);
            decrSwitchBttn.FlatStyle = FlatStyle.Flat;
            decrSwitchBttn.FlatAppearance.BorderColor = HexToColor(buttonColor);
            decrSwitchBttn.ForeColor = Color.White;
            decrSwitchBttn.Font = new Font("Calibri", 10); 

            // decrease switch button
            incrSwitchBttn.BackColor = HexToColor(buttonColor);
            incrSwitchBttn.FlatStyle = FlatStyle.Flat;
            incrSwitchBttn.FlatAppearance.BorderColor = HexToColor(buttonColor);
            incrSwitchBttn.ForeColor = Color.White; 
            incrSwitchBttn.Font = new Font("Calibri", 10);

            //mdf finish button
            mdf_finishButton.BackColor = HexToColor(buttonColor);
            mdf_finishButton.FlatStyle = FlatStyle.Flat;
            mdf_finishButton.FlatAppearance.BorderColor = HexToColor(buttonColor);
            mdf_finishButton.ForeColor = Color.White;
            mdf_finishButton.Font = new Font("Calibri", 10);

            // increase port number button 
            incrSwPort.BackColor = HexToColor(buttonColor);
            incrSwPort.FlatStyle = FlatStyle.Flat;
            incrSwPort.FlatAppearance.BorderColor = HexToColor(buttonColor);
            incrSwPort.ForeColor = Color.White;
            incrSwPort.Font = new Font("Calibri", 10);

            // decrease port number button
            decrSwitchBttn.BackColor = HexToColor(buttonColor);
            decrSwitchBttn.FlatStyle = FlatStyle.Flat; 
            decrSwitchBttn.FlatAppearance.BorderColor = HexToColor(buttonColor);
            decrSwitchBttn.ForeColor = Color.White; 
            decrSwitchBttn.Font = new Font("Calibri", 10);

            // decrease Sw num, idk exactly what it does 
            decrSwNum.BackColor = HexToColor(buttonColor);
            decrSwNum.FlatStyle = FlatStyle.Flat; 
            decrSwNum.FlatAppearance.BorderColor = HexToColor(buttonColor);
            decrSwNum.ForeColor = Color.White;
            decrSwNum.Font = new Font("Calibri", 10);

            // idf finish button 
            idf_finishButton.BackColor = HexToColor(buttonColor);
            idf_finishButton.FlatStyle = FlatStyle.Flat; 
            idf_finishButton.FlatAppearance.BorderColor = HexToColor(buttonColor);
            idf_finishButton.ForeColor = Color.White; 
            idf_finishButton.Font = new Font("Calibri", 10);

            // increase slot button
            incrSlotbttn.BackColor = HexToColor(buttonColor);
            incrSlotbttn.FlatStyle = FlatStyle.Flat; 
            incrSlotbttn.FlatAppearance.BorderColor = HexToColor(buttonColor);
            incrSlotbttn.ForeColor = Color.White; 
            incrSlotbttn.Font = new Font("Calibri", 10);

            // decrease slot button
            decrSlotbttn.BackColor = HexToColor(buttonColor);
            decrSlotbttn.FlatStyle = FlatStyle.Flat; 
            decrSlotbttn.FlatAppearance.BorderColor = HexToColor(buttonColor);
            decrSlotbttn.ForeColor = Color.White; 
            decrSlotbttn.Font = new Font("Calibri", 10);

            // increase port num
            incrPortbttn.BackColor = HexToColor(buttonColor);
            incrPortbttn.FlatStyle = FlatStyle.Flat;
            incrPortbttn.FlatAppearance.BorderColor = HexToColor(buttonColor);
            incrPortbttn.ForeColor = Color.White; 
            incrPortbttn.Font = new Font("Calibri", 10);

            // decrease port num 
            decrPortbttn.BackColor = HexToColor(buttonColor);
            decrPortbttn.FlatStyle = FlatStyle.Flat; 
            decrPortbttn.FlatAppearance.BorderColor = HexToColor(buttonColor);
            decrPortbttn.ForeColor = Color.White;
            decrPortbttn.Font = new Font("Calibri", 10);

            // idf - increase by 5
            button5.BackColor = HexToColor(buttonColor);
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderColor = HexToColor(buttonColor);
            button5.ForeColor = Color.White;
            button5.Font = new Font("Calibri", 10);

            // idf - increase by 10
            button6.BackColor = HexToColor(buttonColor);
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderColor = HexToColor(buttonColor);
            button6.ForeColor = Color.White;
            button6.Font = new Font("Calibri", 10);

            // idf - decrease by 5
            button7.BackColor = HexToColor(buttonColor);
            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderColor = HexToColor(buttonColor);
            button7.ForeColor = Color.White;
            button7.Font = new Font("Calibri", 10);

            // idf - decrease by 10; 
            button8.BackColor = HexToColor(buttonColor);
            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderColor = HexToColor(buttonColor);
            button8.ForeColor = Color.White;
            button8.Font = new Font("Calibri", 10); 

            // label 7 
            label7.Font = new Font("Calibri", 40);
            label7.ForeColor = Color.White;

            // label 6
            label6.Font = new Font("Calibri", 40);
            label6.ForeColor = Color.White;

            //label 9
            label9.Font = new Font("Calibri", 15);
            label9.ForeColor = Color.White;

            // label1
            label1.Font = new Font("Calibri", 30);
            label1.ForeColor = Color.White;

            // label 4
            label4.Font = new Font("Calibri", 30);
            label4.ForeColor = Color.White;

            // label 5
            label5.Font = new Font("Calibri", 30);
            label5.ForeColor = Color.White;

            // idf switch label
            idf_switchNumLabel.Font = new Font("Calibri", 60);
            idf_switchNumLabel.ForeColor = Color.White;

            // idf num cabel label
            idf_numCableLabel.Font = new Font("Calibri", 60);
            idf_numCableLabel.ForeColor = Color.White;

            // idf port num label 
            idf_portNumLbl.Font = new Font("Calibri", 60);
            idf_portNumLbl.ForeColor = Color.White;

            // label 8
            label8.Font = new Font("Calibri", 30);
            label8.ForeColor = Color.White;

            // label 10
            label10.Font = new Font("Calibri", 20);
            label10.ForeColor = Color.White;

            // label 3
            label3.Font = new Font("Calibri", 30);
            label3.ForeColor = Color.White;

            // label 2
            label2.Font = new Font("Calibri", 30);
            label2.ForeColor = Color.White;

            // slot label
            slotLabel.Font = new Font("Calibri", 60);
            slotLabel.ForeColor = Color.White;

            // port num label 
            portNumLabel.Font = new Font("Calibri", 60);
            portNumLabel.ForeColor = Color.White; 
            

        }

        Color HexToColor(string hex)
        {
            return ColorTranslator.FromHtml(hex); 
        }

        // helper function for fullscreening for raspi pi
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            }
        }

        #region stage 1
        //shows the second screen
        private void PhoneButton_Click(object sender, EventArgs e)
        {
            PhoneButton.Hide();
            WirelessAPButton.Hide();


            SecondScreenPanel.Show();
        }


        /// <summary>
        ///  selects wireless ap 
        ///  shows second screen 
        ///  reveals mdf and idf buttonss
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WirelessAPButton_Click(object sender, EventArgs e)
        {
            PhoneButton.Hide();
            WirelessAPButton.Hide();
            
            SecondScreenPanel.Show();
            //mdfButton.Show();
        }
        #endregion 
        private void SecondScreenPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        #region stage 2 
        /// <summary>
        /// hides the second screen
        /// shows the mdf panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mdfButton_Click(object sender, EventArgs e)
        {
            SecondScreenPanel.Hide();
            panel1.Show();
            UpdateLabels();
        }

        /// <summary>
        /// hides the second panel showing the idf screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void idfButton_Click(object sender, EventArgs e)
        {
            SecondScreenPanel.Hide();

            panel2.Show();
            UpdateIDFLables(); 
        }

        #endregion

        #region MDF
        
        /// <summary>
        /// increases slot number by 1 
        /// updates labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void incrSlotbttn_Click_1(object sender, EventArgs e)
        {
            slotNum++;
            UpdateLabels();
        }

        /// <summary>
        /// decreases slot number by 1
        /// updates label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decrSlotbttn_Click_1(object sender, EventArgs e)
        {
            slotNum--;
            if(slotNum < 0)
            {
                slotNum = 0; 
            }
            UpdateLabels();
        }

        /// <summary>
        /// increases port number by 1
        /// updates labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void incrPortbttn_Click_1(object sender, EventArgs e)
        {
            portNum++;
            UpdateLabels();
        }

        /// <summary>
        /// decreases port number by 1
        /// updates label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decrPortbttn_Click_1(object sender, EventArgs e)
        {
            portNum--;
            if(portNum < 0)
            {
                portNum = 0; 
            }
            UpdateLabels();
        }

        /// <summary>
        /// updates:
        /// -slot label
        /// -port num label
        /// - label 10 *(subnet label) 
        /// </summary>
        void UpdateLabels()
        {
            slotLabel.Text = slotNum.ToString(); 
            portNumLabel.Text = portNum.ToString();
            label10.Text = "10." + subnet + ".0.1"; 
        }

        private void mdfPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion



        
        // increases idf switch number by 1 
        private void incrSwitchBttn_Click(object sender, EventArgs e)
        {
            idf_switchNum++;

            UpdateIDFLables();
        }

        // decreases idf switch number by 1 
        private void decrSwitchBttn_Click(object sender, EventArgs e)
        {
            idf_switchNum--;
            if(idf_switchNum < 0)
            {
                idf_switchNum = 0; 
            }
            UpdateIDFLables();
        }

        /// <summary>
        /// increases idf cable type by 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void incrCablebttn_Click(object sender, EventArgs e)
        {
            idf_cableType++;
            if (idf_cableType > 3)
            {
                idf_cableType = 1;
            }
            if (idf_cableType < 1)
            {
                idf_cableType = 3;
            }
            UpdateIDFLables();
            
        }

        /// <summary>
        /// decreases idf cable type by 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decrCableBttn_Click(object sender, EventArgs e)
        {
            idf_cableType--;
            if(idf_cableType > 3)
            {
                idf_cableType = 1;
            }
            if(idf_cableType < 1)
            {
                idf_cableType = 3;
            }
            UpdateIDFLables();
        }

        // increases idf port number by 1
        private void incrSwPort_Click(object sender, EventArgs e)
        {
            idf_portNum++;
            if (idf_portNum > 255)
            {
                idf_portNum = 0;
            }
            if (idf_portNum < 0)
            {
                idf_portNum = 255;
            }
            UpdateIDFLables();
        }
        
       
        // increases idf port number by 5
        private void button5_Click(object sender, EventArgs e)
        {
            idf_portNum += 5; 
            if (idf_portNum > 255)
            {
                idf_portNum = 0;
            }
            if (idf_portNum < 0)
            {
                idf_portNum = 255;
            }
            UpdateIDFLables();
        }

        // increases idf port number by 10
        private void button6_Click(object sender, EventArgs e)
        {
            idf_portNum += 10;
            if (idf_portNum > 255)
            {
                idf_portNum = 0;
            }
            if (idf_portNum < 0)
            {
                idf_portNum = 255;
            }
            UpdateIDFLables();
        }

        // decreases idf port number by 1 
        private void decrSwNum_Click(object sender, EventArgs e)
        {
            idf_portNum--;
            if (idf_portNum > 255)
            {
                idf_portNum = 0;
            }
            if (idf_portNum < 0)
            {
                idf_portNum = 255;
            }
            UpdateIDFLables();
        }

        // decreases idf port num by 5
        private void button7_Click(object sender, EventArgs e)
        {
            idf_portNum -= 5; 
            if (idf_portNum > 255)
            {
                idf_portNum = 0;
            }
            if (idf_portNum < 0)
            {
                idf_portNum = 255;
            }
            UpdateIDFLables();
        }

        // decreases idf port number by 10
        private void button8_Click(object sender, EventArgs e)
        {
            idf_portNum -= 10;
            if (idf_portNum > 255)
            {
                idf_portNum = 0;
            }
            if (idf_portNum < 0)
            {
                idf_portNum = 255;
            }
            UpdateIDFLables();
        }

        // updates IDF lables after every button click
        void UpdateIDFLables()
        {
            idf_switchNumLabel.Text = idf_switchNum.ToString();
            idf_numCableLabel.Text = idf_cableType.ToString();
            idf_portNumLbl.Text = idf_portNum.ToString();
            label6.Text = idfNum.ToString();
            label9.Text = "10." + subnet.ToString() + "." + (idfNum * 8).ToString() + ".1";
            switch (idf_cableType)
            {
                case 1:
                    {
                        label4.Text = "Copper";
                        break;
                    }
                case 2:
                    {
                        label4.Text = "Stack";
                        break;
                    }
                case 3:
                    {
                        label4.Text = "Fiber"; 
                        break;
                    }
            }
        }
        
        // resets application to homescreen
        private void idf_finishButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        // resets application to homescreen
        private void mdf_finishButton_Click(object sender, EventArgs e)
        {
            Reset();
        }


        /// <summary>
        /// constructs the target ip for the mdf 
        /// login to ip through ssh and sends commands
        /// </summary>
        void FinishIDF()
        {
            string ip = "10." + subnet + "." + (idfNum * 8).ToString()+".1";

            using(var client = new SshClient(ip, userLogin, userPassword))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    Console.WriteLine("connected");
                }

                SshCommand command = client.CreateCommand("config t");
                command.Execute();

                command = client.CreateCommand("int eth");
                command.Execute();

                command = client.CreateCommand("no dual");
                command.Execute();

                command = client.CreateCommand("inline power power-by-class 2");
                command.Execute();

                command = client.CreateCommand("vlan "+ 10 + idfNum); // <-- switch to closet
                command.Execute();

                command = client.CreateCommand("tag eth" +idf_switchNum + "/" + idf_cableType + "/" + idf_portNum);
                command.Execute();

                command = client.CreateCommand("vlan 30");
                command.Execute();

                command = client.CreateCommand("tag eth" + idf_switchNum + "/" + idf_cableType + "/" + idf_portNum);
                command.Execute();

                command = client.CreateCommand("vlan 40");
                command.Execute();

                command = client.CreateCommand("no tag eth" + idf_switchNum + "/" + idf_cableType + "/" + idf_portNum);
                command.Execute();

                command = client.CreateCommand("vlan 50");
                command.Execute();

                command = client.CreateCommand("no tag eth" + idf_switchNum + "/" + idf_cableType + "/" + idf_portNum);
                command.Execute();

                command = client.CreateCommand("int eth" + idf_switchNum + "/" + idf_cableType + "/" + idf_portNum);
                command.Execute();

                command = client.CreateCommand("Dual 10");
                command.Execute();

                client.Disconnect();
            }
        }

        /// <summary>
        /// constructs the target ip for the mdf 
        /// login to ip through ssh and sends commands
        /// </summary>
        void FinishMDF()
        {
            //string ip = "10.146.3.39";
            string ip = "10." + subnet + ".0.1";

            using (var client = new SshClient(ip, userLogin, userPassword))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    Console.WriteLine("connected");
                }

                SshCommand command = client.CreateCommand("config t");
                command.Execute();

                command = client.CreateCommand("int eth");
                command.Execute();

                command = client.CreateCommand("no dual");
                command.Execute();

                command = client.CreateCommand("inline power power-by-class 2");
                command.Execute();

                command = client.CreateCommand("vlan " + 10);
                command.Execute();

                command = client.CreateCommand("tag eth" + slotNum + "/" + portNum);
                command.Execute();

                command = client.CreateCommand("vlan 30");
                command.Execute();

                command = client.CreateCommand("tag eth" + slotNum + "/" + portNum);
                command.Execute();

                command = client.CreateCommand("vlan 40");
                command.Execute();

                command = client.CreateCommand("no tag eth" + slotNum + "/" + portNum);
                command.Execute();

                command = client.CreateCommand("vlan 50");
                command.Execute();

                command = client.CreateCommand("no tag eth" + slotNum + "/" + portNum);
                command.Execute();

                command = client.CreateCommand("int eth" + slotNum + "/" + portNum);
                command.Execute();

                command = client.CreateCommand("Dual 10");
                command.Execute();

                client.Disconnect();
            }
        }

        // resets all values and updates labels
        void Reset()
        {
            idf_switchNum = 0;
            idf_cableType = 1;
            idf_portNum = 0;
            slotNum = 0;
            portNum = 0;
            idfNum = 0;
            subnet = 0; 

            UpdateLabels();
            UpdateIDFLables();
            SecondScreenPanel.Hide();
            panel1.Hide();
            panel2.Hide();
            PhoneButton.Show();
            WirelessAPButton.Show(); 

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // the exit version
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
            
        }

        // increases idf number by 1
        private void button1_Click_1(object sender, EventArgs e)
        {
            idfNum++;
            UpdateIDFLables();
        }


        // decreases idf number by 1
        private void button2_Click(object sender, EventArgs e)
        {
            idfNum--;
            if(idfNum < 0)
            {
                idfNum = 0; 
            }
            UpdateIDFLables();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // decreases subnet by 1
        private void button3_Click(object sender, EventArgs e)
        {
            // decrease
            subnet--;
            UpdateLabel8();
        }

        // increases subnet by 1
        private void button4_Click(object sender, EventArgs e)
        {
            // increase
            subnet++;
            UpdateLabel8(); 
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }


        // updates subnetting label every button 3 and 4 click 
        void UpdateLabel8()
        {
            string ip = "10." + subnet.ToString() + ".xx.xx";
            label8.Text = ip; 
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        
    }
}
