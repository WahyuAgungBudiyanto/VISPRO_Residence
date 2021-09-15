using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project__Program_Residence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label_tekskamar.Hide();
            comboBox_nokamar.Hide();

            comboBox_kamar.Items.Add("Queen");
            comboBox_kamar.Items.Add("Ekonomi");
            comboBox_kamar.Items.Add("VIP");
            comboBox_kamar.Items.Add("Sultan");
            dateTimePicker_start.CustomFormat = "MMMM-yyyy";
            dateTimePicker_end.CustomFormat = "MMMM-yyyy";
            dateTimePicker_start.Format = DateTimePickerFormat.Custom;
            dateTimePicker_end.Format = DateTimePickerFormat.Custom;


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox_queen.BorderStyle = BorderStyle.None;
            


            comboBox_nokamar.Items.Clear();
            if (comboBox_kamar.Text == "Queen")
            {
                label_tekskamar.Show();
                comboBox_nokamar.Show();
                string valuekamar = "IDR 200.000/Month";
                label_kamar.Text = valuekamar;
                
                comboBox_nokamar.Items.Add("M1");
                comboBox_nokamar.Items.Add("M2");
                comboBox_nokamar.Items.Add("M3");
                comboBox_nokamar.Items.Add("M4");
                pictureBox_queen.Visible = true;
                pictureBox_ekonomi.Visible = false;
                pictureBox_vip.Visible = false;
                pictureBox_sultan.Visible = false;
                pictureBox_kamardefault.Visible = false;
            }
            if (comboBox_kamar.Text == "Ekonomi")
            {
                label_tekskamar.Show();
                comboBox_nokamar.Show();
                string valuekamar = "IDR 900.000/Month";
                label_kamar.Text = valuekamar;
             
                comboBox_nokamar.Items.Add("E1");
                comboBox_nokamar.Items.Add("E2");
                comboBox_nokamar.Items.Add("E3");
                comboBox_nokamar.Items.Add("E4");
                pictureBox_queen.Visible = false;
                pictureBox_ekonomi.Visible = true;
                pictureBox_vip.Visible = false;
                pictureBox_sultan.Visible = false;
                pictureBox_kamardefault.Visible = false;
            }
            else if (comboBox_kamar.Text == "VIP")
            {
                label_tekskamar.Show();
                comboBox_nokamar.Show();
                string valuekamar = "IDR 1.400.000/Month";
                label_kamar.Text = valuekamar;
               
                comboBox_nokamar.Items.Add("V1");
                comboBox_nokamar.Items.Add("V2");
                comboBox_nokamar.Items.Add("V3");
                comboBox_nokamar.Items.Add("V4");
                pictureBox_queen.Visible = false;
                pictureBox_ekonomi.Visible = false;
                pictureBox_vip.Visible = true;
                pictureBox_sultan.Visible = false;
                pictureBox_kamardefault.Visible = false;
            }
            else if (comboBox_kamar.Text == "Sultan")
            {
                label_tekskamar.Show();
                comboBox_nokamar.Show();
                string valuekamar = "IDR 15.000.000/Month";
                label_kamar.Text = valuekamar;
                
                comboBox_nokamar.Items.Add("S1");
                comboBox_nokamar.Items.Add("S2");
                comboBox_nokamar.Items.Add("S3");
                comboBox_nokamar.Items.Add("S4");
                pictureBox_queen.Visible = false;
                pictureBox_ekonomi.Visible = false;
                pictureBox_vip.Visible = false;
                pictureBox_sultan.Visible = true;
                pictureBox_kamardefault.Visible = false;
            }

            
            

        }

        

        
        
        private void button_addtocart_Click(object sender, EventArgs e)
        {
            DateTime sdate = dateTimePicker_start.Value.Date;
            DateTime edate = dateTimePicker_end.Value.Date;

            

            
            
               if (comboBox_kamar.Text.Trim() == string.Empty || comboBox_nokamar.Text.Trim() == string.Empty || textBox_name.Text.Trim() == string.Empty || textBox_phone.Text.Trim() == string.Empty || textBox_email.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please fill all your details", "Submit Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            else if(sdate.Day == edate.Day)
            {
                MessageBox.Show("Please fill your Check-Out date correctly", "Submit Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }else
            {
                
                string startdate = dateTimePicker_start.Text;
                string enddate = dateTimePicker_end.Text;
                label_checkin.Text = startdate;
                label_checkout.Text = enddate;

                int months = (edate.Year - sdate.Year) * 12 + edate.Month - sdate.Month;
                label_timedate.Text = Convert.ToString(months + " Month");

                int kamar = 0;

                string roomtype = comboBox_kamar.Text;
                label_room.Text = roomtype;

                if (comboBox_kamar.Text == "Queen")
                {
                    kamar += 200000;
                    label_priceroom.Text = Convert.ToString("IDR " + kamar + "/Month");

                    pictureBox_room_display.Image = pictureBox_queen.Image;
                }
                if (comboBox_kamar.Text == "Ekonomi")
                {
                    kamar += 900000;
                    label_priceroom.Text = Convert.ToString("IDR " + kamar + "/Month");


                    pictureBox_room_display.Image = pictureBox_ekonomi.Image;
                }
                else if (comboBox_kamar.Text == "VIP")
                {
                    kamar += 1400000;
                    label_priceroom.Text = Convert.ToString("IDR " + kamar + "/Month");

                    pictureBox_room_display.Image = pictureBox_vip.Image;
                }
                else if (comboBox_kamar.Text == "Sultan")
                {
                    kamar += 15000000;
                    label_priceroom.Text = Convert.ToString("IDR " + kamar + "/Month");


                    pictureBox_room_display.Image = pictureBox_sultan.Image;
                }

                string roomnumber = comboBox_nokamar.Text;
                label_roomnum_display.Text = roomnumber;

                int totaltambahan = 0;
                string add1 = " TV"; string add2 = " AC"; string add3 = " Computer"; string add4 = " Waterheater";
                label_additional.Text = "";

                if (checkBox_tv.Checked == true)
                {
                    totaltambahan += 100000;
                    string simpan = Convert.ToString("+ IDR " + totaltambahan + "/Month");

                    label_add.Text = simpan;
                    label_additional.Text += add1;

                }
                if (checkBox_ac.Checked == true)
                {
                    totaltambahan += 200000;
                    string simpan = Convert.ToString("+ IDR " + totaltambahan + "/Month");

                    label_add.Text = simpan;
                    label_additional.Text += add2;

                }
                if (checkBox_komputer.Checked == true)
                {
                    totaltambahan += 100000;
                    string simpan = Convert.ToString("+ IDR " + totaltambahan + "/Month");

                    label_add.Text = simpan;
                    label_additional.Text += add3;

                }
                if (checkBox_water.Checked == true)
                {
                    totaltambahan += 100000;
                    string simpan = Convert.ToString("+ IDR " + totaltambahan + "/Month");

                    label_add.Text = simpan;
                    label_additional.Text += add4;

                }



                int totalroom = kamar + totaltambahan;

                label_totalroom.Text = Convert.ToString("IDR " + totalroom + " x " + months + " Month");
                int tax = 0;
                int totalall = 0;
                if (totalroom < 1000000)
                {
                    tax = 50000;
                    label_tax.Text = Convert.ToString("IDR " + tax);

                    totalall = totalroom * months + tax;
                    label_totalall.Text = Convert.ToString("IDR " + totalall + "/Month");
                }
                else if (totalroom >= 1000000)
                {
                    tax = 100000;
                    label_tax.Text = Convert.ToString("IDR " + tax);

                    totalall = totalroom * months + tax;
                    label_totalall.Text = Convert.ToString("IDR " + totalall + "/Month");
                }
            }
            

           


            /* DateTime sdate = dateTimePicker_start.Value.Date;
             DateTime edate = dateTimePicker_end.Value.Date;

             TimeSpan checkrange = edate - sdate;

             if (sdate.Day == edate.Day && sdate.Month != edate.Month && Convert.ToInt32(checkrange.Days) >= 31)
             {
                 int months = (edate.Year - sdate.Year) * 12 + edate.Month - sdate.Month;
                 label_timedate.Text = Convert.ToString(months + " Month");
             }
             else if(Convert.ToInt32(checkrange.Days) < 31)
             {
                 MessageBox.Show("Please input your check out date 30 days after check in date!");
                 label_timedate.Text = "...";

             }*/

        }


        private void button_book_Click(object sender, EventArgs e)
        {
            /*if (label_name.Text.Trim() == string.Empty || label_email.Text.Trim() == string.Empty || label_phone.Text.Trim() == string.Empty || label_room.Text.Trim() == string.Empty || label_roomnum_display.Text.Trim() == string.Empty || label_additional.Text.Trim() == string.Empty || label_checkin.Text.Trim() == string.Empty || label_checkout.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please fill all your details", "Submit Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {*/
                string message = "Your cart has been booked!";
                string title = "Success";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            /*}*/
            
            





        }

        

        private void button_clear1_Click(object sender, EventArgs e)
        {
            textBox_name.Clear();
            textBox_email.Clear();
            textBox_phone.Clear();
            label_name.Text = "...";
            label_email.Text = "...";
            label_phone.Text = "...";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label_room.Text = "...";
            label_priceroom.Text = "...";
            label_roomnum_display.Text = "...";
            label_additional.Text = "...";
            label_add.Text = "...";
            label_checkin.Text = "...";
            label_checkout.Text = "...";
            label_timedate.Text = "...";
            label_totalroom.Text = "...";
            label_tax.Text = "...";
            label_totalall.Text = "...";
            pictureBox_room_display.Image = null;
        }














        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label_tax_Click(object sender, EventArgs e)
        {

        }

        private void button_addpersonal_Click(object sender, EventArgs e)
        {
            if(textBox_name.Text.Trim() == string.Empty || textBox_phone.Text.Trim() == string.Empty || textBox_email.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please fill all your details", "Submit Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                string name = textBox_name.Text;
                label_name.Text = name;

                string phone = textBox_phone.Text;
                label_phone.Text = phone;

                string email = textBox_email.Text;
                label_email.Text = email;
            }
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btn_Minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        Point lastPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
