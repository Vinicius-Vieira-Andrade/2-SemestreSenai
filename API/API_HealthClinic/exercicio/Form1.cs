using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exercicio
{

    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
            label4.Visible = false;
        }
    
        

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
  
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new cadastro().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsKeyLocked(Keys.CapsLock))
            {
                label4.Visible=true;
            }
            else
            {
                label4.Visible=false;
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            
           
        }
    }

}
