using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicioTelegrama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textoTelegrama;
            char tipoTelegrama = 'o'; // Corrección 1: por defecto es ordinario ('o')
            int numPalabras = 0;
            double coste;

            // Leo el telegrama
            textoTelegrama = txtTelegrama.Text;

            // Telegrama urgente?
            if (cbUrgente.Checked)
                tipoTelegrama = 'u';

            // Corrección 2: Contar palabras reales, no caracteres
            char[] separadores = new char[] { ' ', '\r', '\n' };
            string[] palabras = textoTelegrama.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
            numPalabras = palabras.Length;

            // Si el telegrama es ordinario
            if (tipoTelegrama == 'o')
            {
                if (numPalabras <= 10)
                    coste = 2.5; // Corrección 3: tarifa base ordinaria 2.5
                else
                    coste = 2.5 + 0.5 * (numPalabras - 10);
            }
            else
            {
                // Si el telegrama es urgente
                if (tipoTelegrama == 'u')
                {
                    if (numPalabras <= 10)
                        coste = 5;
                    else
                        coste = 5 + 0.75 * (numPalabras - 10);
                }
                else
                    coste = 0;
            }

            txtPrecio.Text = coste.ToString() + " euros";
        }
    }
}