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
    public partial class DebitingRedakt : Form
    {
        
        public DebitingRedakt()
        {
            InitializeComponent();
        }
        int n;
        private void FieldsForm_Fill()
        {
            textBox1.Enabled = false;
            textBox2.Text = Form1.VS.Tables["Списание"].Rows[n]["Название"].ToString();
            
        }

        private void DebitingRedakt_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT Номер,Название,Дата,КодПодраздела FROM debiting";

            textBox1.Text = Form1.VS.Tables["Списание"].Rows[Debiting.n]["Номер"].ToString();
            textBox2.Text = Form1.VS.Tables["Списание"].Rows[n]["Название"].ToString();

            dateTimePicker1.Text = Form1.VS.Tables["Списание"].Rows[n]["Дата"].ToString();
            Form1.VS.Tables["Подразделение"].DefaultView.Sort = "Код";

            comboBox1.DataSource = Form1.VS.Tables["Подразделение"].DefaultView;
            comboBox1.DisplayMember = "Название";
            comboBox1.ValueMember = "Код";
            Form1.Table_Fill("Списание", sql);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            string sql;

            sql = "UPDATE debiting SET Название='" + textBox2.Text + "', Дата='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', КодПодраздела=" + comboBox1.SelectedValue + " WHERE Номер = " + textBox1.Text;
            MessageBox.Show("SQL (UPDATE): " + sql);
            if (!Form1.Modification_Execute(sql))
                return;
            Form1.VS.Tables["Списание"].Rows[n].ItemArray = new object[] { textBox1.Text, comboBox1.Text, dateTimePicker1.Text, comboBox1.SelectedValue,textBox2.Text};
        }
    }
}
