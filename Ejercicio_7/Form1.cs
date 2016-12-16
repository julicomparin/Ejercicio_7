using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_7
{
    public partial class Form1 : Form
    {
        FachadaEncriptadores iFachada = new FachadaEncriptadores();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string mResultado = iFachada.EncriptarMediante(comboBox1.Text, textBox1.Text);
           MessageBox.Show(mResultado);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mResultado = iFachada.DesencriptarMediante(comboBox1.Text, textBox1.Text);
            MessageBox.Show(mResultado);

        }
    }
}
