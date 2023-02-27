using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colletta
{
    public partial class Form1 : Form
    {
        public string soldi;
        public Form1()
        {
            InitializeComponent();
        }
        public string nome;
        public double importo;
        Dictionary<string, double> colletta = new Dictionary<string, double>();
        private void aggiungi_Click(object sender, EventArgs e)
        {
            soldi = textBox3.Text;
            nome = textBox1.Text;
            importo = double.Parse(textBox2.Text);
            colletta.Add(nome,importo);
            listView1.Items.Add(nome);
            MessageBox.Show("persona aggiunta");
        }

        private void rimuovi_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
