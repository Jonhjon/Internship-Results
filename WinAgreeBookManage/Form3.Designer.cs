namespace TEST0205
{
    partial class Form3
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrNo = new System.Windows.Forms.TextBox();
            this.txtTamplateId = new System.Windows.Forms.TextBox();
            this.chbTrue = new System.Windows.Forms.CheckBox();
            this.chbFalse = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.Dgvform3 = new System.Windows.Forms.DataGridView();
            this.chOrdNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTemplateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chStat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plform = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgvform3)).BeginInit();
            this.plform.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(80, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "同意書醫令設定";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15F);
            this.label2.Location = new System.Drawing.Point(54, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "醫令代碼";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15F);
            this.label3.Location = new System.Drawing.Point(54, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "表單編號";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15F);
            this.label4.Location = new System.Drawing.Point(54, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "啟用狀態";
            // 
            // txtOrNo
            // 
            this.txtOrNo.Location = new System.Drawing.Point(175, 111);
            this.txtOrNo.MaxLength = 10;
            this.txtOrNo.Name = "txtOrNo";
            this.txtOrNo.Size = new System.Drawing.Size(98, 22);
            this.txtOrNo.TabIndex = 4;
            this.txtOrNo.TextChanged += new System.EventHandler(this.txtOrNo_TextChanged);
            this.txtOrNo.Leave += new System.EventHandler(this.txtOrNo_Leave);
            // 
            // txtTamplateId
            // 
            this.txtTamplateId.Location = new System.Drawing.Point(175, 168);
            this.txtTamplateId.MaxLength = 30;
            this.txtTamplateId.Name = "txtTamplateId";
            this.txtTamplateId.Size = new System.Drawing.Size(98, 22);
            this.txtTamplateId.TabIndex = 5;
            this.txtTamplateId.Leave += new System.EventHandler(this.txtOrNo_Leave);
            // 
            // chbTrue
            // 
            this.chbTrue.AutoSize = true;
            this.chbTrue.Location = new System.Drawing.Point(175, 234);
            this.chbTrue.Name = "chbTrue";
            this.chbTrue.Size = new System.Drawing.Size(48, 16);
            this.chbTrue.TabIndex = 6;
            this.chbTrue.Text = "啟用";
            this.chbTrue.UseVisualStyleBackColor = true;
            this.chbTrue.CheckedChanged += new System.EventHandler(this.chbTrue_CheckedChanged);
            // 
            // chbFalse
            // 
            this.chbFalse.AutoSize = true;
            this.chbFalse.Location = new System.Drawing.Point(259, 234);
            this.chbFalse.Name = "chbFalse";
            this.chbFalse.Size = new System.Drawing.Size(48, 16);
            this.chbFalse.TabIndex = 7;
            this.chbFalse.Text = "停用";
            this.chbFalse.UseVisualStyleBackColor = true;
            this.chbFalse.CheckedChanged += new System.EventHandler(this.chbFalse_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(91, 284);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 34);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "新增醫令同意書";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(259, 284);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(106, 34);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "修改醫令同意書";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(409, 284);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 35);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "清空欄位";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Dgvform3
            // 
            this.Dgvform3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgvform3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chOrdNo,
            this.chTemplateID,
            this.chStat});
            this.Dgvform3.Location = new System.Drawing.Point(12, 61);
            this.Dgvform3.Name = "Dgvform3";
            this.Dgvform3.RowTemplate.Height = 24;
            this.Dgvform3.Size = new System.Drawing.Size(345, 177);
            this.Dgvform3.TabIndex = 11;
            this.Dgvform3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgvform3_CellContentClick);
            // 
            // chOrdNo
            // 
            this.chOrdNo.HeaderText = "醫令代碼";
            this.chOrdNo.Name = "chOrdNo";
            // 
            // chTemplateID
            // 
            this.chTemplateID.HeaderText = "表單編號";
            this.chTemplateID.Name = "chTemplateID";
            // 
            // chStat
            // 
            this.chStat.HeaderText = "啟用狀態";
            this.chStat.Name = "chStat";
            // 
            // plform
            // 
            this.plform.Controls.Add(this.label5);
            this.plform.Controls.Add(this.Dgvform3);
            this.plform.Location = new System.Drawing.Point(380, 12);
            this.plform.Name = "plform";
            this.plform.Size = new System.Drawing.Size(370, 266);
            this.plform.TabIndex = 12;
            this.plform.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 20F);
            this.label5.Location = new System.Drawing.Point(148, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 27);
            this.label5.TabIndex = 12;
            this.label5.Text = "表單";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plform);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chbFalse);
            this.Controls.Add(this.chbTrue);
            this.Controls.Add(this.txtTamplateId);
            this.Controls.Add(this.txtOrNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "同意書醫令設定";
            ((System.ComponentModel.ISupportInitialize)(this.Dgvform3)).EndInit();
            this.plform.ResumeLayout(false);
            this.plform.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrNo;
        private System.Windows.Forms.TextBox txtTamplateId;
        private System.Windows.Forms.CheckBox chbTrue;
        private System.Windows.Forms.CheckBox chbFalse;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView Dgvform3;
        private System.Windows.Forms.DataGridViewTextBoxColumn chOrdNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTemplateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chStat;
        private System.Windows.Forms.Panel plform;
        private System.Windows.Forms.Label label5;
    }
}