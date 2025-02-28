using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPraktLast
{
    public partial class Company : Form
    {
        public Company()
        {
            InitializeComponent();
        }
        int n;

        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox1.Focus();
        }

        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.VS.Tables["Компания"].Rows[n]["Код"].ToString();
            textBox2.Text = Form1.VS.Tables["Компания"].Rows[n]["Название"].ToString();
            textBox3.Text = Form1.VS.Tables["Компания"].Rows[n]["Краткоеназвание"].ToString();
            textBox4.Text = Form1.VS.Tables["Компания"].Rows[n]["Руководитель"].ToString();
            textBox5.Text = Form1.VS.Tables["Компания"].Rows[n]["ГлавныйБухгалтер"].ToString();
            textBox6.Text = Form1.VS.Tables["Компания"].Rows[n]["ГлавныйИнженер"].ToString();
            textBox7.Text = Form1.VS.Tables["Компания"].Rows[n]["ГлавныйЭлектрик"].ToString();
            textBox8.Text = Form1.VS.Tables["Компания"].Rows[n]["ГлавныйМеханик"].ToString();
            
        }

        private void Company_Load(object sender, EventArgs e)
        {
            if (Form1.VS.Tables["Компания"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n < Form1.VS.Tables["Компания"].Rows.Count) n++;
            if (Form1.VS.Tables["Компания"].Rows.Count > n)
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
            n = Form1.VS.Tables["Компания"].Rows.Count;
            FieldsForm_Clear();
        }

        private void button3_Click(object sender,EventArgs e)
        {
            if (n > 0)
            {
                n--; FieldsForm_Fill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.VS.Tables["Компания"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;
            if (n < Form1.VS.Tables["Компания"].Rows.Count)
            {
                sql = "UPDATE company SET Название='" + textBox2.Text + "',Краткоеназвание='" + textBox3.Text + "',Руководитель='" + textBox4.Text + "',ГлавныйБухгалтер='" + textBox5.Text + "',ГлавныйИнженер='" + textBox6.Text + "',ГлавныйЭлектрик='" + textBox7.Text + "',ГлавныйМеханик='" + textBox8.Text;

                if (!Form1.Modification_Execute(sql))
                    return;
                Form1.VS.Tables["Компания"].Rows[n].ItemArray = new object[] {textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox6.Text,textBox7.Text,textBox8.Text };


            }
            else
            {
                sql = "INSERT INTO company ( Название, Краткоеназвание, Руководитель, ГлавныйБухгалтер, ГлавныйИнженер, ГлавныйЭлектрик, ГлавныйМеханик) " +
                "VALUES ( '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "')";

                if (!Form1.Modification_Execute(sql))
                    return;
                textBox1.Enabled = false;
                

                Form1.VS.Tables["Компания"].Rows.Add(new object[] {textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox6.Text,textBox7.Text,textBox8.Text });
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из компании компанию с кодом" + textBox1.Text + "?";
            string caption = "Удаление...";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult rezult = MessageBox.Show(message, caption, buttons);
            if (rezult == DialogResult.No) { return; }


            string sql = "DELETE FROM company WHERE Код = " + textBox1.Text;

            if (!Form1.Modification_Execute(sql)) return;
            try
            {
                Form1.VS.Tables["Компания"].Rows.RemoveAt(n);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Удаление не было выполнени из за несуществущего указания");
                return;
            }
            if (Form1.VS.Tables["Компания"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }
        }
    }
}
