namespace WinFormBookClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvBooks = new DataGridView();
            btnRefresh = new Button();
            groupBox1 = new GroupBox();
            btnCreateSubmit = new Button();
            txtCreatePages = new TextBox();
            label3 = new Label();
            txtCreateTitile = new TextBox();
            label2 = new Label();
            txtCreateId = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnUpdateSubmit = new Button();
            txtUpdatePages = new TextBox();
            label4 = new Label();
            txtUpdateTitle = new TextBox();
            label5 = new Label();
            txtUpdateId = new TextBox();
            label6 = new Label();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(18, 52);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.RowTemplate.Height = 29;
            dgvBooks.Size = new Size(552, 348);
            dgvBooks.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(20, 9);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCreateSubmit);
            groupBox1.Controls.Add(txtCreatePages);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCreateTitile);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCreateId);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(597, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(297, 162);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Creating Books";
            // 
            // btnCreateSubmit
            // 
            btnCreateSubmit.Location = new Point(184, 113);
            btnCreateSubmit.Name = "btnCreateSubmit";
            btnCreateSubmit.Size = new Size(94, 29);
            btnCreateSubmit.TabIndex = 6;
            btnCreateSubmit.Text = "Submit";
            btnCreateSubmit.UseVisualStyleBackColor = true;
            // 
            // txtCreatePages
            // 
            txtCreatePages.Location = new Point(61, 113);
            txtCreatePages.Name = "txtCreatePages";
            txtCreatePages.Size = new Size(96, 27);
            txtCreatePages.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 116);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 4;
            label3.Text = "Pages";
            // 
            // txtCreateTitile
            // 
            txtCreateTitile.Location = new Point(61, 69);
            txtCreateTitile.Name = "txtCreateTitile";
            txtCreateTitile.Size = new Size(217, 27);
            txtCreateTitile.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 72);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 2;
            label2.Text = "Title";
            // 
            // txtCreateId
            // 
            txtCreateId.Location = new Point(61, 27);
            txtCreateId.Name = "txtCreateId";
            txtCreateId.Size = new Size(217, 27);
            txtCreateId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 30);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 0;
            label1.Text = "Id";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnUpdateSubmit);
            groupBox2.Controls.Add(txtUpdatePages);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtUpdateTitle);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtUpdateId);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(597, 238);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(297, 162);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Updating Books";
            // 
            // btnUpdateSubmit
            // 
            btnUpdateSubmit.Location = new Point(184, 113);
            btnUpdateSubmit.Name = "btnUpdateSubmit";
            btnUpdateSubmit.Size = new Size(94, 29);
            btnUpdateSubmit.TabIndex = 6;
            btnUpdateSubmit.Text = "Submit";
            btnUpdateSubmit.UseVisualStyleBackColor = true;
            // 
            // txtUpdatePages
            // 
            txtUpdatePages.Location = new Point(61, 113);
            txtUpdatePages.Name = "txtUpdatePages";
            txtUpdatePages.Size = new Size(96, 27);
            txtUpdatePages.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 116);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 4;
            label4.Text = "Pages";
            // 
            // txtUpdateTitle
            // 
            txtUpdateTitle.Location = new Point(61, 69);
            txtUpdateTitle.Name = "txtUpdateTitle";
            txtUpdateTitle.Size = new Size(217, 27);
            txtUpdateTitle.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 72);
            label5.Name = "label5";
            label5.Size = new Size(38, 20);
            label5.TabIndex = 2;
            label5.Text = "Title";
            // 
            // txtUpdateId
            // 
            txtUpdateId.Location = new Point(61, 27);
            txtUpdateId.Name = "txtUpdateId";
            txtUpdateId.ReadOnly = true;
            txtUpdateId.Size = new Size(217, 27);
            txtUpdateId.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 30);
            label6.Name = "label6";
            label6.Size = new Size(22, 20);
            label6.TabIndex = 0;
            label6.Text = "Id";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(476, 406);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 448);
            Controls.Add(btnDelete);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnRefresh);
            Controls.Add(dgvBooks);
            Name = "Form1";
            Text = "Books";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBooks;
        private Button btnRefresh;
        private GroupBox groupBox1;
        private Button btnCreateSubmit;
        private TextBox txtCreatePages;
        private Label label3;
        private TextBox txtCreateTitile;
        private Label label2;
        private TextBox txtCreateId;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnUpdateSubmit;
        private TextBox txtUpdatePages;
        private Label label4;
        private TextBox txtUpdateTitle;
        private Label label5;
        private TextBox txtUpdateId;
        private Label label6;
        private Button btnDelete;
    }
}