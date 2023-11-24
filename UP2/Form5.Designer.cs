namespace UP2
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idкнигиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.названиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.первыйавторDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.издательствоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.местоизданияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.годизданияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествостраницDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ценаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.кодтемыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.книгиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.malinaDataSet = new UP2.MalinaDataSet();
            this.книгиTableAdapter = new UP2.MalinaDataSetTableAdapters.КнигиTableAdapter();
            this.malinaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.malinaDataSet1 = new UP2.MalinaDataSet1();
            this.тематическиекаталогиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.тематические_каталогиTableAdapter = new UP2.MalinaDataSet1TableAdapters.Тематические_каталогиTableAdapter();
            this.книгиBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.книгиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.malinaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.malinaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.malinaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.тематическиекаталогиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.книгиBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(23, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 68);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить в корзину";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Выберите жанр",
            "Повесть",
            "Роман",
            "Стихи"});
            this.comboBox1.Location = new System.Drawing.Point(45, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 27);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Выберите жанр";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(521, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 26);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idкнигиDataGridViewTextBoxColumn,
            this.названиеDataGridViewTextBoxColumn,
            this.первыйавторDataGridViewTextBoxColumn,
            this.издательствоDataGridViewTextBoxColumn,
            this.местоизданияDataGridViewTextBoxColumn,
            this.годизданияDataGridViewTextBoxColumn,
            this.количествостраницDataGridViewTextBoxColumn,
            this.ценаDataGridViewTextBoxColumn,
            this.кодтемыDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.книгиBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(23, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(734, 273);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idкнигиDataGridViewTextBoxColumn
            // 
            this.idкнигиDataGridViewTextBoxColumn.DataPropertyName = "id_книги";
            this.idкнигиDataGridViewTextBoxColumn.HeaderText = "id_книги";
            this.idкнигиDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idкнигиDataGridViewTextBoxColumn.Name = "idкнигиDataGridViewTextBoxColumn";
            this.idкнигиDataGridViewTextBoxColumn.Width = 125;
            // 
            // названиеDataGridViewTextBoxColumn
            // 
            this.названиеDataGridViewTextBoxColumn.DataPropertyName = "Название";
            this.названиеDataGridViewTextBoxColumn.HeaderText = "Название";
            this.названиеDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.названиеDataGridViewTextBoxColumn.Name = "названиеDataGridViewTextBoxColumn";
            this.названиеDataGridViewTextBoxColumn.Width = 125;
            // 
            // первыйавторDataGridViewTextBoxColumn
            // 
            this.первыйавторDataGridViewTextBoxColumn.DataPropertyName = "Первый_автор";
            this.первыйавторDataGridViewTextBoxColumn.HeaderText = "Первый_автор";
            this.первыйавторDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.первыйавторDataGridViewTextBoxColumn.Name = "первыйавторDataGridViewTextBoxColumn";
            this.первыйавторDataGridViewTextBoxColumn.Width = 125;
            // 
            // издательствоDataGridViewTextBoxColumn
            // 
            this.издательствоDataGridViewTextBoxColumn.DataPropertyName = "Издательство";
            this.издательствоDataGridViewTextBoxColumn.HeaderText = "Издательство";
            this.издательствоDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.издательствоDataGridViewTextBoxColumn.Name = "издательствоDataGridViewTextBoxColumn";
            this.издательствоDataGridViewTextBoxColumn.Width = 125;
            // 
            // местоизданияDataGridViewTextBoxColumn
            // 
            this.местоизданияDataGridViewTextBoxColumn.DataPropertyName = "Место_издания";
            this.местоизданияDataGridViewTextBoxColumn.HeaderText = "Место_издания";
            this.местоизданияDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.местоизданияDataGridViewTextBoxColumn.Name = "местоизданияDataGridViewTextBoxColumn";
            this.местоизданияDataGridViewTextBoxColumn.Width = 125;
            // 
            // годизданияDataGridViewTextBoxColumn
            // 
            this.годизданияDataGridViewTextBoxColumn.DataPropertyName = "Год_издания";
            this.годизданияDataGridViewTextBoxColumn.HeaderText = "Год_издания";
            this.годизданияDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.годизданияDataGridViewTextBoxColumn.Name = "годизданияDataGridViewTextBoxColumn";
            this.годизданияDataGridViewTextBoxColumn.Width = 125;
            // 
            // количествостраницDataGridViewTextBoxColumn
            // 
            this.количествостраницDataGridViewTextBoxColumn.DataPropertyName = "Количество_страниц";
            this.количествостраницDataGridViewTextBoxColumn.HeaderText = "Количество_страниц";
            this.количествостраницDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.количествостраницDataGridViewTextBoxColumn.Name = "количествостраницDataGridViewTextBoxColumn";
            this.количествостраницDataGridViewTextBoxColumn.Width = 125;
            // 
            // ценаDataGridViewTextBoxColumn
            // 
            this.ценаDataGridViewTextBoxColumn.DataPropertyName = "Цена";
            this.ценаDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.ценаDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ценаDataGridViewTextBoxColumn.Name = "ценаDataGridViewTextBoxColumn";
            this.ценаDataGridViewTextBoxColumn.Width = 125;
            // 
            // кодтемыDataGridViewTextBoxColumn
            // 
            this.кодтемыDataGridViewTextBoxColumn.DataPropertyName = "Код_темы";
            this.кодтемыDataGridViewTextBoxColumn.HeaderText = "Код_темы";
            this.кодтемыDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.кодтемыDataGridViewTextBoxColumn.Name = "кодтемыDataGridViewTextBoxColumn";
            this.кодтемыDataGridViewTextBoxColumn.Width = 125;
            // 
            // книгиBindingSource
            // 
            this.книгиBindingSource.DataMember = "Книги";
            this.книгиBindingSource.DataSource = this.malinaDataSet;
            // 
            // malinaDataSet
            // 
            this.malinaDataSet.DataSetName = "MalinaDataSet";
            this.malinaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // книгиTableAdapter
            // 
            this.книгиTableAdapter.ClearBeforeFill = true;
            // 
            // malinaDataSetBindingSource
            // 
            this.malinaDataSetBindingSource.DataSource = this.malinaDataSet;
            this.malinaDataSetBindingSource.Position = 0;
            // 
            // malinaDataSet1
            // 
            this.malinaDataSet1.DataSetName = "MalinaDataSet1";
            this.malinaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // тематическиекаталогиBindingSource
            // 
            this.тематическиекаталогиBindingSource.DataMember = "Тематические_каталоги";
            this.тематическиекаталогиBindingSource.DataSource = this.malinaDataSet1;
            // 
            // тематические_каталогиTableAdapter
            // 
            this.тематические_каталогиTableAdapter.ClearBeforeFill = true;
            // 
            // книгиBindingSource1
            // 
            this.книгиBindingSource1.DataMember = "Книги";
            this.книгиBindingSource1.DataSource = this.malinaDataSetBindingSource;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(325, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Поиск по названию:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button2.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(9, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(290, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "Вернуться на главнуюю";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button3.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(486, 386);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 41);
            this.button3.TabIndex = 6;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button4.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button4.Location = new System.Drawing.Point(631, 386);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 41);
            this.button4.TabIndex = 7;
            this.button4.Text = "Удалить";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form5";
            this.Text = "Тематический каталог";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.книгиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.malinaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.malinaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.malinaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.тематическиекаталогиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.книгиBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MalinaDataSet malinaDataSet;
        private System.Windows.Forms.BindingSource книгиBindingSource;
        private MalinaDataSetTableAdapters.КнигиTableAdapter книгиTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idкнигиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn названиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn первыйавторDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn издательствоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn местоизданияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn годизданияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествостраницDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ценаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодтемыDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource malinaDataSetBindingSource;
        private MalinaDataSet1 malinaDataSet1;
        private System.Windows.Forms.BindingSource тематическиекаталогиBindingSource;
        private MalinaDataSet1TableAdapters.Тематические_каталогиTableAdapter тематические_каталогиTableAdapter;
        private System.Windows.Forms.BindingSource книгиBindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}