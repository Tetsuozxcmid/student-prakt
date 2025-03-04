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
    public partial class Locking : Form
    {
        public Locking()
        {
            InitializeComponent();
        }


        private void Locking_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT Номер, Дата, СрокЗакрепления, ИнвентНомер, ma.Название, d.Название, КодПодраздела " +
      "FROM locking l " +
      "JOIN division d ON l.КодПодраздела = d.Код " +
      "JOIN mainamount ma ON l.ИнвентНомер = ma.ИнвентарыйНомер";

            Form1.Table_Fill("Закрепления", sql);
            dataGridView1.DataSource = Form1.VS.Tables["Закрепления"];
            dataGridView1.Columns["КодПодраздела"].Visible = false;
            dataGridView1.Columns["ИнвентНомер"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
        }

        private void Locking_Activated(object sender, EventArgs e)
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

           string sql = "INSERT INTO locking (Номер, Дата, СрокЗакрепления, ИнвентНомер, КодПодраздела) " +
          "VALUES (" + kod + ", '" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "', NULL, NULL)";

            Form1.Modification_Execute(sql);

            Form1.VS.Tables["Закрепления"].Rows.Add(new object[] { kod, DateTime.Now.Date, null, null, null,null,0 });
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];

            LockingRedakt red = new LockingRedakt();
            red.Show();
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
            LockingRedakt red = new LockingRedakt();
            red.Show();
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
                MessageBox.Show("Не указана удаляемая запись таблицы");return;
            }

            msg = "Вы точно хотите удалить закрепление с номером " + dataGridView1.Rows[n].Cells["Номер"].Value + "?";
            string caption = "Удаление закрепления ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(msg, caption, buttons);
            if(result == DialogResult.No) { return; }
            MessageBox.Show(n.ToString());
            sql = "DELETE FROM locking WHERE Номер = " + dataGridView1.Rows[n].Cells["Номер"].Value;

            Form1.Modification_Execute(sql);

            Form1.VS.Tables["Закрепления"].Rows.RemoveAt(n);
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
            n = -1;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mainamount mn = new Mainamount();
            mn.Show();
        }
    }
}
