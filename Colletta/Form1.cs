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
        CollettaTotale colletta = new CollettaTotale();
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
            if (listView1.SelectedItems.Count == 1) // controlla se un solo elemento è selezionato
            {
                string key = listView1.SelectedItems[0].Text; // ottiene la chiave dell'elemento selezionato
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    colletta.Raccolta[key] = new Partecipante(textBox1.Text, float.Parse(textBox2.Text)); // aggiorna l'elemento nella raccolta
                    listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text; // aggiorna il nome dell'elemento nella ListView
                    listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text; // aggiorna il valore dell'elemento nella ListView
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    throw new Exception("Compilare tutte le textbox.");
                }
            }
            else
            {
                throw new Exception("Selezionare un elemento da modificare nella ListView.");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verifica che la ListView abbia almeno una colonna
            if (listView1.Columns.Count > 0)
            {
                // Ottieni gli elementi della ListView e ordina la lista per nome
                ListViewItem[] items = new ListViewItem[listView1.Items.Count];
                listView1.Items.CopyTo(items, 0);
                Array.Sort(items, delegate (ListViewItem x, ListViewItem y) { return x.SubItems[0].Text.CompareTo(y.SubItems[0].Text); });

                // Sostituisci gli elementi nella ListView con quelli ordinati
                listView1.BeginUpdate();
                listView1.Items.Clear();
                listView1.Items.AddRange(items);
                listView1.EndUpdate();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            label6.Text = textBox3.Text;
            textBox3.Clear();
        }
    }
}
