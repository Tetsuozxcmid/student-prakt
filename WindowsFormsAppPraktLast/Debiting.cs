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
    public partial class Debiting : Form
    {
        
        public Debiting()
        {
            InitializeComponent();
        }
        

        

        private void Debiting_Load(object sender, EventArgs e)
        {
            string sql = "SELECT Номер, debiting.Название, Дата, КодПодраздела, division.\"Название\" " +
              "FROM debiting " +
              "LEFT JOIN division ON debiting.КодПодраздела = division.Код";




            Form1.Table_Fill("Списание", sql);
            dataGridView1.DataSource = Form1.VS.Tables["Списание"];
            dataGridView1.Columns["КодПодраздела"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
        }

        private void Debiting_Activated(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns();
        }
        public static int n = -1;



        private void button1_Click(object sender, EventArgs e)
        {

            n = dataGridView1.Rows.Count;
            int kod;
            if (n > 0)

                kod = Convert.ToInt32(dataGridView1.Rows[n - 1].Cells["Номер"].Value) + 1;
            else kod = 1;

            string sql = "INSERT INTO debiting (Название, Дата, КодПодраздела) VALUES (NULL, '" + DateTime.Now.ToString("yyyy-MM-dd") + "', NULL)";

            Form1.Modification_Execute(sql);

            Form1.VS.Tables["Списание"].Rows.Add(new object[] { kod, null, DateTime.Now.Date, null,null });
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = dataGridView1.Rows[n].Cells[0];


            DebitingRedakt debred = new DebitingRedakt();
            debred.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                n = dataGridView1.SelectedCells[0].RowIndex;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Не указана редактируемая запись таблицы!!!", "Ошибка"); return;
            }
            DebitingRedakt debred = new DebitingRedakt();
            debred.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string msg, sql;
            try
            {
                n = dataGridView1.SelectedCells[0].RowIndex;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Не указана удаляемая запись таблицы"); return;
            }

            msg = "Вы точно хотите удалить закрепление с номером " + dataGridView1.Rows[n].Cells["Номер"].Value + "?";
            string caption = "Удаление закрепления ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(msg, caption, buttons);
            if (result == DialogResult.No) { return; }
            MessageBox.Show(n.ToString());
            sql = "DELETE FROM debiting WHERE Номер = " + dataGridView1.Rows[n].Cells["Номер"].Value;

            Form1.Modification_Execute(sql);

            Form1.VS.Tables["Списание"].Rows.RemoveAt(n);
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
            n = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Division div = new Division();
            div.Show();
        }
    }
}
