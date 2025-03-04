using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsAppPraktLast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static NpgsqlConnection connection = new NpgsqlConnection("Server=Server;User Id=User Id;Password=password;Database=database;");
        public static DataSet VS = new DataSet();
        public static void Table_Fill(string name,string sql)
        {
            if (VS.Tables[name] != null)
                VS.Tables[name].Clear();
            NpgsqlDataAdapter dat;
            dat = new NpgsqlDataAdapter(sql,connection);
            dat.Fill(VS, name);
            connection.Close();
        }

        public static bool Modification_Execute(string sql)
        {
            NpgsqlCommand com;
            com = new NpgsqlCommand(sql,connection);
            connection.Open();
            try
            {
                com.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Обновление базы не выполнено. Ошибка: " + ex.Message);
                MessageBox.Show("Обновление базы не выполнено из за не указания данных");
                connection.Close();
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Обновление базы не было из за попытки добавления удаления данных");
                connection.Close(); return false;
            }
            connection.Close(); return false;
            
        }
        
        private void предприятиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company company = new Company();
            company.Show();
        }

        private void подразделениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Division division  = new Division();
            division.Show();
        }

        private void основноеСредствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mainamount mainamount = new Mainamount();
            mainamount.Show();
        }

        private void дефектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Defect defect = new Defect();
            defect.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql;

            sql = "SELECT company.Код,company.Название,company.Краткоеназвание,company.Руководитель,company.ГлавныйБухгалтер,company.ГлавныйИнженер,company.ГлавныйЭлектрик,company.ГлавныйМеханик FROM company ORDER BY company.Код";
            Table_Fill("Компания", sql);

            sql = "SELECT division.Код,division.Название,division.КраткоеНазвание,division.Руководитель,division.МатериальноОтветственный,division.КодПредприятия FROM division ORDER BY division.Код";
            Table_Fill("Подразделение", sql);

            sql = "SELECT mainamount.ИнвентарыйНомер,mainamount.Название,mainamount.Тип,mainamount.Стоимость FROM mainamount ORDER BY mainamount.ИнвентарыйНомер";
            Table_Fill("ОсновноеСредство",sql);

            sql = " SELECT defect.Код,defect.Название FROM defect ORDER BY defect.Код";
            Table_Fill("Дефект", sql);
        }

        


        private void закреплениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locking locking = new Locking();
            locking.Show();
        }

        private void списаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debiting deb = new Debiting();
            deb.Show();
        }

        private void списанияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebitingAmount debam = new DebitingAmount();    
            debam.Show();
        }
    }
}
