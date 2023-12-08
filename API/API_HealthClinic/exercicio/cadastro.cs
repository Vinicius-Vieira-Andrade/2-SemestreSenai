using exercicio.Model;
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
    public partial class cadastro : Form
    {
        
        
        
        public cadastro()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var usuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.Email == textBox2.Text);
            if (usuarioBuscado != null)
            {
                MessageBox.Show("O email ja está em uso");
                return
;            }


            Usuario usuario = new Usuario();
            usuario.Nome = textBox1.Text;
            usuario.Email = textBox2.Text;
            usuario.Telefone = textBox3.Text;
            usuario.Usuario1 = textBox4.Text;

            ctx.Usuario.Add(usuario);
            ctx.SaveChanges();

            MessageBox.Show("Cadastrou meu dog"); ;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void cadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
