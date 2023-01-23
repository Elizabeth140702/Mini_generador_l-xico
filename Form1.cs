using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mini_generador_léxico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable tabla = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = tabla.DefaultView;
        }
        public void agrega()
        {
            tabla.Rows.Add();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int d = 0;
            int c = 0;
            int a = 0;
            int b = 0;
            char[] textBox1 = textBox.Text.ToCharArray();
            string token = "";
            while (d < textBox1.Length)
            {
                agrega();
                if (textBox1[d] == ' ')
                    d += 1;
                if (char.IsLetter(textBox1[d]))
            {
                c = d;
                token = token + textBox1[d];
                d += 1;
                //MessageBox.Show("funciiona");
            }
                if (d < textBox1.Length)
                {

                    while (char.IsDigit(textBox1[d]) || textBox1[d] == '.')
                    {
                        if (textBox1[d] == '.' || char.IsDigit(textBox1[d]))
                        {
                            token = token + textBox1[d];
                            d += 1;
                            if (d == textBox1.Length)
                                break;
                        }
                    }

                }
                if (d < textBox1.Length)
            {
                while (char.IsLetter(textBox1[d]))
                {
                    token = token + textBox1[d];
                    d += 1;
                    
                    if (d == textBox1.Length)
                        break;
                }
            }
            
            dataGridView1.Rows[a].Cells[0].Value = token;
            a++;
            token = "";
                for (b = 0; b < dataGridView1.Rows.Count - 1; b++)
                {
                    string resto = Convert.ToString(dataGridView1.Rows[b].Cells[0].Value);
                    if (dataGridView1.Rows[b].Cells[0].Value != null)
                    {
                        if (dataGridView1.Rows[b].Cells[1].Value == null)
                        {
                            bool real_entero = resto.Contains ( ".");//si tiene un punto, es verdadero y sería un num real
                            
                            if (real_entero == true)
                            {
                                dataGridView1.Rows[b].Cells[1].Value = "2";
                                dataGridView1.Rows[b].Cells[2].Value = "Real";
                            }
                            else if (real_entero == false)
                            {
                                dataGridView1.Rows[b].Cells[1].Value = "0";
                                dataGridView1.Rows[b].Cells[2].Value = "Identificador de variable";
                            }
                        }
                    }
                }

            }
        }
    }
}
                

       

    