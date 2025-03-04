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
    public partial class DebitingAmount : Form
    {
        public DebitingAmount()
        {
            InitializeComponent();
        }

        private void DebitingAmount_Load(object sender, EventArgs e)
        {

            string sql = "SELECT " +
             "    d.Название AS НазваниеСписания, " +
             "    d.Дата AS ДатаСписания, " +
             "    ma.Название AS НазваниеСредства, " +
             "    da.НомерСписания AS Номер " + 
             "FROM " +
             "    debitingamount da " +
             "LEFT JOIN " +
             "    debiting d ON da.НомерСписания = d.Номер " +
             "LEFT JOIN " +
             "    mainamount ma ON da.ИнвентарныйНомер = ma.ИнвентарыйНомер;";
            Form1.Table_Fill("Списания", sql);

            dataGridView1.DataSource = Form1.VS.Tables["Списания"];
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AutoResizeColumns();
            dataGridView1.Enabled = false;

            

            for (int i = 0; i < Form1.VS.Tables["Списания"].Rows.Count; i++)
            {
                if (comboBox1.Items.IndexOf(Form1.VS.Tables["Списания"].Rows[i]["НазваниеСписания"]) < 0)
                    comboBox1.Items.Add(Form1.VS.Tables["Списания"].Rows[i]["НазваниеСписания"]);
            }
            comboBox1.Sorted = true;
            for (int i = 0; i < Form1.VS.Tables["Списания"].Rows.Count;i++)
            {
                if (comboBox2.Items.IndexOf(Form1.VS.Tables["Списания"].Rows[i]["ДатаСписания"]) < 0)
                    comboBox2.Items.Add(Form1.VS.Tables["Списания"].Rows[i]["ДатаСписания"]);
            }
            comboBox2.Sorted = true;
            for (int i = 0; i < Form1.VS.Tables["Списания"].Rows.Count; i++)
            {
                if (comboBox3.Items.IndexOf(Form1.VS.Tables["Списания"].Rows[i]["НазваниеСредства"]) < 0)
                    comboBox3.Items.Add(Form1.VS.Tables["Списания"].Rows[i]["НазваниеСредства"]);
            }
            comboBox2.Sorted = true;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            Form1.VS.Tables["Списания"].DefaultView.RowFilter = "[Номер]<>0";
            dataGridView1.CurrentCell = null;
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            Form1.VS.Tables["Списания"].DefaultView.RowFilter = "[ИнвентарыйНомер]<>0";
            dataGridView1.CurrentCell = null;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Form1.VS.Tables["Списания"].DefaultView.RowFilter = $"[НазваниеСредства] = '{comboBox1.Text}'";
            dataGridView1.CurrentCell = null;
        }
    }
}
