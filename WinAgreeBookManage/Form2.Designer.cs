namespace TEST0205
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtVer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chbTrue = new System.Windows.Forms.CheckBox();
            this.chbFalse = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.DgvForm = new System.Windows.Forms.DataGridView();
            this.chID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chVer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chStat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvForm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 20F);
            this.label1.Location = new System.Drawing.Point(73, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "同意書範本資料建立維護檔";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(211, 117);
            this.txtID.MaxLength = 30;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(133, 22);
            this.txtID.TabIndex = 1;
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(211, 187);
            this.txtName.MaxLength = 150;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(133, 22);
            this.txtName.TabIndex = 2;
            // 
            // txtVer
            // 
            this.txtVer.Location = new System.Drawing.Point(211, 270);
            this.txtVer.MaxLength = 10;
            this.txtVer.Name = "txtVer";
            this.txtVer.Size = new System.Drawing.Size(133, 22);
            this.txtVer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15F);
            this.label2.Location = new System.Drawing.Point(92, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "表單編號";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15F);
            this.label3.Location = new System.Drawing.Point(92, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "表單名稱";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15F);
            this.label4.Location = new System.Drawing.Point(92, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "表單版本";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 15F);
            this.label5.Location = new System.Drawing.Point(92, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "表單狀態";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // chbTrue
            // 
            this.chbTrue.AutoSize = true;
            this.chbTrue.Location = new System.Drawing.Point(211, 354);
            this.chbTrue.Name = "chbTrue";
            this.chbTrue.Size = new System.Drawing.Size(48, 16);
            this.chbTrue.TabIndex = 8;
            this.chbTrue.Text = "啟用";
            this.chbTrue.UseVisualStyleBackColor = true;
            this.chbTrue.CheckedChanged += new System.EventHandler(this.chbTrue_CheckedChanged);
            // 
            // chbFalse
            // 
            this.chbFalse.AutoSize = true;
            this.chbFalse.Location = new System.Drawing.Point(318, 353);
            this.chbFalse.Name = "chbFalse";
            this.chbFalse.Size = new System.Drawing.Size(48, 16);
            this.chbFalse.TabIndex = 9;
            this.chbFalse.Text = "停用";
            this.chbFalse.UseVisualStyleBackColor = true;
            this.chbFalse.CheckedChanged += new System.EventHandler(this.chbFalse_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(121, 407);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(109, 36);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "新增同意書範本";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(274, 407);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 36);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "修改同意書範本";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(429, 407);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 36);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "清空欄位";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // DgvForm
            // 
            this.DgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvForm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chID,
            this.chName,
            this.chVer,
            this.chStat});
            this.DgvForm.Location = new System.Drawing.Point(429, 162);
            this.DgvForm.Name = "DgvForm";
            this.DgvForm.RowTemplate.Height = 24;
            this.DgvForm.Size = new System.Drawing.Size(445, 71);
            this.DgvForm.TabIndex = 13;
            this.DgvForm.Visible = false;
            this.DgvForm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvForm_CellContentClick);
            // 
            // chID
            // 
            this.chID.HeaderText = "表單編號";
            this.chID.Name = "chID";
            // 
            // chName
            // 
            this.chName.HeaderText = "表單名稱";
            this.chName.Name = "chName";
            // 
            // chVer
            // 
            this.chVer.HeaderText = "表單版本";
            this.chVer.Name = "chVer";
            // 
            // chStat
            // 
            this.chStat.HeaderText = "表單狀態";
            this.chStat.Name = "chStat";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 30F);
            this.label6.Location = new System.Drawing.Point(536, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 40);
            this.label6.TabIndex = 14;
            this.label6.Text = "表單內容";
            this.label6.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 574);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DgvForm);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chbFalse);
            this.Controls.Add(this.chbTrue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVer);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "同意書範本資料建議維護";
            ((System.ComponentModel.ISupportInitialize)(this.DgvForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtVer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbTrue;
        private System.Windows.Forms.CheckBox chbFalse;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView DgvForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn chID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn chStat;
        private System.Windows.Forms.Label label6;
    }
}