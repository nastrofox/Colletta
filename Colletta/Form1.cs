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
        public Form1()
        {
            InitializeComponent();
        }
        public CollettaTotale colletta;
        string[] intes = { "chiave", "Partecipante", "Quota" };
        Partecipante temp;
        private void aggiungi_Click(object sender, EventArgs e)
        {
            temp = new Partecipante(textBox1.Text, float.Parse(textBox2.Text));
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                colletta.Aggiungi(temp);
                ListViewItem riga = new ListViewItem(colletta.Raccolta[colletta.getKey(temp)].ToString().Split(';'));
                listView1.Items.Add(riga);
                label4.Text = "Totale:" + colletta.QuotaTotale.ToString();
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
                throw new Exception("compilare tutte le textbox");

        }

        private void rimuovi_Click(object sender, EventArgs e)
        {
            int selezionato = 0;
            string key;
            if (listView1.SelectedIndices.Count > 0)
                selezionato = listView1.SelectedIndices[0];
            key = listView1.SelectedItems[0].Text;
            temp = colletta.Raccolta[key];
            colletta.Rimuovi(temp);
            listView1.Items.RemoveAt(selezionato);
            label4.Text = "Totale:" + colletta.QuotaTotale.ToString();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selezionato = 0;
            string key;
            temp = new Partecipante(textBox1.Text, float.Parse(textBox2.Text));
            if (listView1.SelectedIndices.Count > 0)
                selezionato = listView1.SelectedIndices[0];
            key = listView1.SelectedItems[0].Text;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                colletta.Modifica(colletta.Raccolta[key], temp);
                listView1.Items.Clear();
                foreach (KeyValuePair<string, Partecipante> kvp in colletta.Raccolta)
                {
                    ListViewItem riga = new ListViewItem(colletta.Raccolta[kvp.Key].ToString().Split(';'));
                    listView1.Items.Add(riga);
                }
                label4.Text = "Totale:" + colletta.QuotaTotale.ToString();
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
                throw new Exception("compilare tutte le textbox");
        }
    }
}
