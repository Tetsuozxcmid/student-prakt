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
    public partial class Division : Form
    {
        public Division()
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
            comboBox1.Text = "";
            comboBox1.Focus();
        }

        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.VS.Tables["Подразделение"].Rows[n]["Код"].ToString();
            textBox2.Text = Form1.VS.Tables["Подразделение"].Rows[n]["Название"].ToString();
            textBox3.Text = Form1.VS.Tables["Подразделение"].Rows[n]["Краткоеназвание"].ToString();
            textBox4.Text = Form1.VS.Tables["Подразделение"].Rows[n]["Руководитель"].ToString();
            textBox5.Text = Form1.VS.Tables["Подразделение"].Rows[n]["МатериальноОтветственный"].ToString();
            comboBox1.SelectedValue = Form1.VS.Tables["Подразделение"].Rows[n]["КодПредприятия"].ToString();
            
            
        }

        private void Division_Load(object sender, EventArgs e)
        {
            
            Form1.VS.Tables["Компания"].DefaultView.Sort = "Название";
            comboBox1.DataSource = Form1.VS.Tables["Компания"].DefaultView;

            
            comboBox1.DisplayMember = "Название";
            comboBox1.ValueMember = "Код";

            
            if (Form1.VS.Tables["Подразделение"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
            textBox1.Enabled = true;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            
                if (n < Form1.VS.Tables["Подразделение"].Rows.Count) n++;
                if (Form1.VS.Tables["Подразделение"].Rows.Count > n)
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
            n = Form1.VS.Tables["Подразделение"].Rows.Count;
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
            if (Form1.VS.Tables["Подразделение"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            string kodPredpr = comboBox1.SelectedValue.ToString();

            string sql;
            if (n < Form1.VS.Tables["Подразделение"].Rows.Count)
            {
                
                sql = "UPDATE division SET Название='" + textBox2.Text + "', КраткоеНазвание='" + textBox3.Text + "', Руководитель='" + textBox4.Text + "', МатериальноОтветственный='" + textBox5.Text + "', КодПредприятия=" + kodPredpr + " WHERE Код=" + textBox1.Text;

                MessageBox.Show("SQL (UPDATE): " + sql);

                if (!Form1.Modification_Execute(sql))
                    return;

                Form1.VS.Tables["Подразделение"].Rows[n].ItemArray = new object[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, kodPredpr };
            }
            else
            {
                
                sql = "INSERT INTO division (Название, КраткоеНазвание, Руководитель, МатериальноОтветственный, КодПредприятия) " +
                       "VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', " + kodPredpr + ")";

                MessageBox.Show("SQL (INSERT): " + sql);

                if (!Form1.Modification_Execute(sql))
                    return;

                textBox1.Enabled = false;

                
                Form1.VS.Tables["division"].Rows.Add(new object[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, kodPredpr });
            }
        }






        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить подразделение с кодом " + textBox1.Text + "?";
            string caption = "Удаление...";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }

            
            string sql = "DELETE FROM division WHERE Код='" + textBox1.Text + "'";

            if (!Form1.Modification_Execute(sql)) return;

            try
            {
                Form1.VS.Tables["Подразделение"].Rows.RemoveAt(n);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Удаление не было выполнено из-за несуществующего указания");
                return;
            }

            if (Form1.VS.Tables["Подразделение"].Rows.Count > n)
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
