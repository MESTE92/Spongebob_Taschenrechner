using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace try_catch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private string zeichenkette = "";


        private string zahl;
        private string aktuelle_zahl="";
        private string operation;

        public static double ergebnis;
        private double letztes_ergebnis;

        public static string fehlermeldung;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gib_zahl_ein(string ziffer)
        {
            if (textBox_zeichen.Text == ergebnis.ToString())
            {
               zeichenkette ="";
                textBox_zeichen.Text = zeichenkette;
                    
            }


            zahl = ziffer;
            aktuelle_zahl += ziffer;
            zeichenkette += zahl;
            textBox_zeichen.Text = zeichenkette;
            button_ist_gleich.Focus();
            
        }

        private void rechenoperator_eingeben(string rechenoperator)
        {
            if (zeichenkette != null)
            {
                operation = rechenoperator;
                zeichenkette += rechenoperator;
                textBox_zeichen.Text = zeichenkette;
                button_ist_gleich.Focus();
            }
        }

        #region Zahlen_Buttons
        private void button_0_Click(object sender, EventArgs e)
        {
            gib_zahl_ein("0");
        }       
        private void button_1_Click(object sender, EventArgs e)
        {
            gib_zahl_ein("1");
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            gib_zahl_ein("2");
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            gib_zahl_ein("3");
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            gib_zahl_ein("4");
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            gib_zahl_ein("5");
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            gib_zahl_ein("6");
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            gib_zahl_ein("7");
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            gib_zahl_ein("8");
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            gib_zahl_ein("9");
        }
        #endregion

        #region Rechenoperationen
        private void button_plus_Click(object sender, EventArgs e)
        {
            rechenoperator_eingeben("+");
        }
        private void button_minus_Click(object sender, EventArgs e)
        {
            rechenoperator_eingeben("-");
        }
        private void button_mal_Click(object sender, EventArgs e)
        {
            rechenoperator_eingeben("*");
        }
        private void button_geteilt_Click(object sender, EventArgs e)
        {
            rechenoperator_eingeben("/");
        }
        #endregion


        private void button_komma_Click(object sender, EventArgs e)
        {
            if (aktuelle_zahl.Contains(",") == false)
            {
                if (aktuelle_zahl == "") // sollte keine zahl dastehen dann setze null automatisch
                {
                    
                    aktuelle_zahl = "0,";
                    zeichenkette += "0,";
                }
                else
                {
                    aktuelle_zahl += ",";
                    zeichenkette += ",";
                }

                textBox_zeichen.Text = zeichenkette;
            }
        }

        private void button_ist_gleich_Click(object sender, EventArgs e)
        {
            try
            {
                var table = new DataTable();

                string konvertierung = zeichenkette.Replace(',', '.');

                var value = table.Compute(konvertierung, "");

                //ergebnis = Convert.ToDouble(value);
                ergebnis = Convert.ToDouble(value, System.Globalization.CultureInfo.InvariantCulture);
                letztes_ergebnis = ergebnis;

                textBox_zeichen.Text = ergebnis.ToString();
                textBox_zeichen.SelectionStart = textBox_zeichen.Text.Length; // <- hier!
                textBox_zeichen.SelectionLength = 0;

                // Damit weitergerechnet werden kann
                zeichenkette = letztes_ergebnis.ToString();
                aktuelle_zahl = letztes_ergebnis.ToString();
            }
            catch(SyntaxErrorException)
            {
                
                fehlermeldung = "Syntaxfehler, ungülitger Rechenausdruck !";
                Form2 Fehlermeldung = new Form2(fehlermeldung);
                Fehlermeldung.Show();
                zeichenkette = "";
                textBox_zeichen.Text = zeichenkette;
           
            }
            catch (InvalidCastException)
            {

                fehlermeldung = $"{zeichenkette}, ist ein ungülitger Rechenausdruck !";
                Form2 Fehlermeldung = new Form2(fehlermeldung);
                Fehlermeldung.Show();
                zeichenkette = "";
                textBox_zeichen.Text = zeichenkette;

            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_zeichen.Text = "";

            letztes_ergebnis = ergebnis;          

            zeichenkette = "";
            aktuelle_zahl = "";
            operation = "";
            textBox_zeichen.Focus();

        }

        private void button_letztes_ergebnis_Click(object sender, EventArgs e)
        {
            
            zeichenkette = letztes_ergebnis.ToString();

            textBox_zeichen.Text = zeichenkette;
            textBox_zeichen.SelectionStart = textBox_zeichen.Text.Length;
            textBox_zeichen.SelectionLength = 0;
            textBox_zeichen.Focus();


        }

        private void textBox_zeichen_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox box = sender as TextBox;

            
            if (char.IsDigit(e.KeyChar))  // Ziffern und Steuerzeichen (z. B. Backspace) erlauben
            {
                if (textBox_zeichen.Text == ergebnis.ToString())
                {
                    zeichenkette = "";
                    textBox_zeichen.Text = zeichenkette;

                }
                else
                {
                    zeichenkette += e.KeyChar;
                }
                return;
            }
            if (char.IsControl(e.KeyChar))
            { return; }

            
            if (e.KeyChar == ',') // Komma erlauben, aber nur eins pro zahl
            {
                // zeichenkentte auftrennen und anhand des letzten operators trennen
                string[] teile = zeichenkette.Split('+', '-', '*', '/');
                string letzte_Zahl = teile[teile.Length - 1];  // kürzt den string um 1 damit nur die zahl ohne operator bleibt

                // wenn diese Zahl noch kein Komma hat, darf ein Komma in diesen String geschrieben werden
                if (!letzte_Zahl.Contains(","))
                {
                    zeichenkette += ",";
                    return;
                }

                // alle andere blockieren
                e.Handled = true;
                return;
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                if (zeichenkette.Length > 0)
                    zeichenkette = zeichenkette.Substring(0, zeichenkette.Length - 1);
                return;
            }

            // 3️⃣ Rechenoperatoren + - * / erlauben
            if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
            {
                zeichenkette += e.KeyChar;
                return;
            }

            if (e.KeyChar == '=')
            {
                e.Handled = true;
                button_ist_gleich_Click(null, EventArgs.Empty);
                return;
            }
            

            // alles andere blockieren
            e.Handled = true;
        }

        
    }
}
