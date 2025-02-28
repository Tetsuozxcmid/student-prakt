namespace WindowsFormsAppPraktLast
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.обьектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предприятиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подразделениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.основноеСредствоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дефектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменаПароляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обьектыToolStripMenuItem,
            this.операцииToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.сервисныеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // обьектыToolStripMenuItem
            // 
            this.обьектыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.предприятиеToolStripMenuItem,
            this.подразделениеToolStripMenuItem,
            this.основноеСредствоToolStripMenuItem,
            this.дефектToolStripMenuItem});
            this.обьектыToolStripMenuItem.Name = "обьектыToolStripMenuItem";
            this.обьектыToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.обьектыToolStripMenuItem.Text = "Обьекты";
            // 
            // предприятиеToolStripMenuItem
            // 
            this.предприятиеToolStripMenuItem.Name = "предприятиеToolStripMenuItem";
            this.предприятиеToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.предприятиеToolStripMenuItem.Text = "Предприятие";
            this.предприятиеToolStripMenuItem.Click += new System.EventHandler(this.предприятиеToolStripMenuItem_Click);
            // 
            // подразделениеToolStripMenuItem
            // 
            this.подразделениеToolStripMenuItem.Name = "подразделениеToolStripMenuItem";
            this.подразделениеToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.подразделениеToolStripMenuItem.Text = "Подразделение";
            this.подразделениеToolStripMenuItem.Click += new System.EventHandler(this.подразделениеToolStripMenuItem_Click);
            // 
            // основноеСредствоToolStripMenuItem
            // 
            this.основноеСредствоToolStripMenuItem.Name = "основноеСредствоToolStripMenuItem";
            this.основноеСредствоToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.основноеСредствоToolStripMenuItem.Text = "Основное средство";
            this.основноеСредствоToolStripMenuItem.Click += new System.EventHandler(this.основноеСредствоToolStripMenuItem_Click);
            // 
            // дефектToolStripMenuItem
            // 
            this.дефектToolStripMenuItem.Name = "дефектToolStripMenuItem";
            this.дефектToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.дефектToolStripMenuItem.Text = "Дефект";
            this.дефектToolStripMenuItem.Click += new System.EventHandler(this.дефектToolStripMenuItem_Click);
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // сервисныеToolStripMenuItem
            // 
            this.сервисныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.сменаПароляToolStripMenuItem});
            this.сервисныеToolStripMenuItem.Name = "сервисныеToolStripMenuItem";
            this.сервисныеToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.сервисныеToolStripMenuItem.Text = "Сервисные функции";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.оПрограммеToolStripMenuItem.Text = "о программе";
            // 
            // сменаПароляToolStripMenuItem
            // 
            this.сменаПароляToolStripMenuItem.Name = "сменаПароляToolStripMenuItem";
            this.сменаПароляToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сменаПароляToolStripMenuItem.Text = "смена пароля";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem обьектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предприятиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подразделениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem основноеСредствоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дефектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сервисныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменаПароляToolStripMenuItem;
    }
}

