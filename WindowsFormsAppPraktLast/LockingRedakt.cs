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
    public partial class LockingRedakt : Form
    {
        public LockingRedakt()
        {
            InitializeComponent();
        }
        int n;
        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox1.Focus();
        }

        private void FieldsForm_Fill()
        {

            comboBox1.Text = Form1.VS.Tables["Закрепления"].Rows[n]["ИнвентНомер"].ToString();
            comboBox2.Text = Form1.VS.Tables["Закрепления"].Rows[n]["КодПодраздела"].ToString();

            textBox1.Enabled = false;
        }
        private void LockingRedakt_Load(object sender, EventArgs e)
        {
            string sql;
            

            sql = "SELECT Номер,Дата,СрокЗакрепления,ИнвентНомер,КодПодраздела FROM locking";
            textBox1.Text = Form1.VS.Tables["Закрепления"].Rows[Locking.n]["Номер"].ToString();
            dateTimePicker1.Text = Form1.VS.Tables["Закрепления"].Rows[n]["Дата"].ToString();
            dateTimePicker2.Text = Form1.VS.Tables["Закрепления"].Rows[n]["СрокЗакрепления"].ToString();

            Form1.VS.Tables["ОсновноеСредство"].DefaultView.Sort = "ИнвентарыйНомер";
            comboBox1.DataSource = Form1.VS.Tables["ОсновноеСредство"].DefaultView;
            comboBox1.DisplayMember = "Название";
            comboBox1.ValueMember = "ИнвентарыйНомер";

            Form1.VS.Tables["Подразделение"].DefaultView.Sort = "Код";
            comboBox2.DataSource = Form1.VS.Tables["Подразделение"].DefaultView;
            comboBox2.DisplayMember = "Название";
            comboBox2.ValueMember = "Код";


            Form1.Table_Fill("Закрепления", sql);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "UPDATE locking SET " +
"Дата='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', " +
"СрокЗакрепления='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', " +
"ИнвентНомер=" + comboBox1.SelectedValue + ", " +
"КодПодраздела=" + comboBox2.SelectedValue + " " +
"WHERE Номер='" + textBox1.Text + "'";



            if (!Form1.Modification_Execute(sql))
                return;
            Form1.VS.Tables["Закрепления"].Rows[n].ItemArray = new object[] { textBox1.Text, dateTimePicker1.Text, dateTimePicker2.Text, comboBox1.SelectedValue,comboBox1.Text, comboBox2.SelectedValue,comboBox2.Text };

        }
    }
}
