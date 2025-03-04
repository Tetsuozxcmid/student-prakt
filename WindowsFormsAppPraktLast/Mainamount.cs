using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsAppPraktLast
{
    public partial class Mainamount : Form
    {
        public Mainamount()
        {
            InitializeComponent();
        }
        int n;

        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox1.Text = "";
            textBox4.Text = "";
            
            textBox1.Focus();
        }

        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.VS.Tables["ОсновноеСредство"].Rows[n]["ИнвентарыйНомер"].ToString();
            textBox2.Text = Form1.VS.Tables["ОсновноеСредство"].Rows[n]["Название"].ToString();
            textBox3.Text = Form1.VS.Tables["ОсновноеСредство"].Rows[n]["Тип"].ToString();
            textBox4.Text = Form1.VS.Tables["ОсновноеСредство"].Rows[n]["Стоимость"].ToString();
        }

        private void Mainamount_Load(object sender, EventArgs e)
        {
            if (Form1.VS.Tables["ОсновноеСредство"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n < Form1.VS.Tables["ОсновноеСредство"].Rows.Count) n++;
            if (Form1.VS.Tables["ОсновноеСредство"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            n = Form1.VS.Tables["ОсновноеСредство"].Rows.Count;
            FieldsForm_Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n > 0)
            {
                n--; FieldsForm_Fill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.VS.Tables["ОсновноеСредство"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;
            if (n < Form1.VS.Tables["ОсновноеСредство"].Rows.Count)
            {
                sql = "UPDATE mainamount SET Название='" + textBox2.Text + "', Тип='" + textBox3.Text + "', Стоимость='" + textBox4.Text + "' WHERE Код = " + textBox1.Text;


                if (!Form1.Modification_Execute(sql))
                    return;
                Form1.VS.Tables["ОсновноеСредство"].Rows[n].ItemArray = new object[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text };


            }
            else
            {
                sql = "INSERT INTO mainamount ( Название, Тип, Стоимость) " +
                "VALUES ( '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";

                if (!Form1.Modification_Execute(sql))
                    return;
                textBox1.Enabled = false;


                Form1.VS.Tables["ОсновноеСредство"].Rows.Add(new object[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text});
            }
        }
    }
}
