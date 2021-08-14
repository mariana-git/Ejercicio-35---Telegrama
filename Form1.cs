using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Telegrama
{
    /*Ejercicio 35: Dado un texto de un telegrama que termina en punto:
        a) Contar la cantidad de palabras que posean más de 10 letras
        b) Informar la cantidad de veces que aparece cada vocal
        c) Informar el porcentaje de espacios en blanco.
        Nota: Las palabras están separadas por un espacio en blanco.*/
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rtbTexto.Focus();
            AcceptButton = btnAnalizar;
        }

        private void BtnAnalizar_Click(object sender, EventArgs e)
        {
            string texto = rtbTexto.Text;
            double porcEspacios;
            
            //escribo las expresiones regulares
            string palDiezLetras = @"\b(\w{10,})\b";
            string vocalA = @"([aAáÁàÀäÄ])";
            string vocalE = @"([eEéÉèÈëË])";
            string vocalI = @"([iIíÍìÌïÏ])";
            string vocalO = @"([oOóÓöÖòÒ])";
            string vocalU = @"([uUúÚùÙüÜ])";
            string espacios = @"(\s)";
            string noespacios = @"\S";

            //instancio la clase que creé
            //var cant = new UsandoRegex();
            
            //instancio los objetos en esa clase a la vez que agrego al listbox el resultado 
            lbxAnalisis.Items.Add($"Se encontraron {Resultado(palDiezLetras,texto)} palabras de DIEZ o más letras.");
            lbxAnalisis.Items.Add($"Se encontraron {Resultado(vocalA, texto)} vocales A.");
            lbxAnalisis.Items.Add($"Se encontraron {Resultado(vocalE, texto)} vocales E.");
            lbxAnalisis.Items.Add($"Se encontraron {Resultado(vocalI, texto)} vocales I.");
            lbxAnalisis.Items.Add($"Se encontraron {Resultado(vocalO, texto)} vocales O.");
            lbxAnalisis.Items.Add($"Se encontraron {Resultado(vocalU, texto)} vocales U.");
        
            //calculo porcentaje de espacios
            porcEspacios = (Resultado(espacios, texto) * 100) / (Resultado(espacios, texto) + Resultado(noespacios, texto));
            lbxAnalisis.Items.Add($"El {porcEspacios} % del texto son ESPACIOS.");

            btnAnalizar.Enabled = false;
        }
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            rtbTexto.Clear();
            lbxAnalisis.Items.Clear();
            btnAnalizar.Enabled = true;
            rtbTexto.Focus();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        double Resultado(String expresion, string texto)
        {
            Regex regex = new Regex(expresion);
            MatchCollection matches = regex.Matches(texto);
            double cadena = matches.Count;
            return cadena;
        }
    }
}
