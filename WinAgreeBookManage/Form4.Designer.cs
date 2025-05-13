namespace TEST0205
{
    partial class Form4
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
            this.txtTemplateId = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddControl = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chbTrue = new System.Windows.Forms.CheckBox();
            this.chbFalse = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.Dgvform = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnRefer = new System.Windows.Forms.Button();
            this.DgvRefer = new System.Windows.Forms.DataGridView();
            this.select_refer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgvform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRefer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 20F);
            this.label1.Location = new System.Drawing.Point(73, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "同意書連帶控制項設定檔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15F);
            this.label2.Location = new System.Drawing.Point(77, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "表單編號";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15F);
            this.label3.Location = new System.Drawing.Point(76, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "控制項類型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15F);
            this.label4.Location = new System.Drawing.Point(77, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "控制項名稱";
            // 
            // txtTemplateId
            // 
            this.txtTemplateId.Location = new System.Drawing.Point(220, 110);
            this.txtTemplateId.MaxLength = 15;
            this.txtTemplateId.Name = "txtTemplateId";
            this.txtTemplateId.Size = new System.Drawing.Size(89, 22);
            this.txtTemplateId.TabIndex = 4;
            this.txtTemplateId.Leave += new System.EventHandler(this.txtTemplateId_Leave);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(220, 210);
            this.txtItem.MaxLength = 30;
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(89, 22);
            this.txtItem.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 15F);
            this.label5.Location = new System.Drawing.Point(77, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "啟用狀態";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnAddControl
            // 
            this.btnAddControl.Location = new System.Drawing.Point(78, 371);
            this.btnAddControl.Name = "btnAddControl";
            this.btnAddControl.Size = new System.Drawing.Size(107, 32);
            this.btnAddControl.TabIndex = 9;
            this.btnAddControl.Text = "新增連帶控制項";
            this.btnAddControl.UseVisualStyleBackColor = true;
            this.btnAddControl.Click += new System.EventHandler(this.btnAddControl_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(227, 371);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 32);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "修改連帶控制項";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chbTrue
            // 
            this.chbTrue.AutoSize = true;
            this.chbTrue.Location = new System.Drawing.Point(222, 262);
            this.chbTrue.Name = "chbTrue";
            this.chbTrue.Size = new System.Drawing.Size(48, 16);
            this.chbTrue.TabIndex = 11;
            this.chbTrue.Text = "啟用";
            this.chbTrue.UseVisualStyleBackColor = true;
            this.chbTrue.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chbFalse
            // 
            this.chbFalse.AutoSize = true;
            this.chbFalse.Location = new System.Drawing.Point(287, 262);
            this.chbFalse.Name = "chbFalse";
            this.chbFalse.Size = new System.Drawing.Size(48, 16);
            this.chbFalse.TabIndex = 12;
            this.chbFalse.Text = "停用";
            this.chbFalse.UseVisualStyleBackColor = true;
            this.chbFalse.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(77, 434);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 31);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "清除欄位";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Dgvform
            // 
            this.Dgvform.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgvform.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.No,
            this.Type,
            this.Item,
            this.Stat});
            this.Dgvform.Location = new System.Drawing.Point(371, 95);
            this.Dgvform.Name = "Dgvform";
            this.Dgvform.RowTemplate.Height = 24;
            this.Dgvform.Size = new System.Drawing.Size(553, 235);
            this.Dgvform.TabIndex = 14;
            this.Dgvform.Visible = false;
            this.Dgvform.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgvform_CellContentClick);
            // 
            // Select
            // 
            this.Select.FillWeight = 90F;
            this.Select.HeaderText = "選取";
            this.Select.Name = "Select";
            // 
            // No
            // 
            this.No.HeaderText = "表單編號";
            this.No.Name = "No";
            // 
            // Type
            // 
            this.Type.HeaderText = "控制項類型";
            this.Type.Name = "Type";
            // 
            // Item
            // 
            this.Item.HeaderText = "控制項名稱";
            this.Item.Name = "Item";
            // 
            // Stat
            // 
            this.Stat.HeaderText = "啟用狀態";
            this.Stat.Name = "Stat";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "--Select--",
            "Attr1",
            "Attr2",
            "Attr3",
            "Attr4",
            "Attr5",
            "Attr6",
            "Attr7",
            "Attr8",
            "Attr9",
            "Attr10",
            "Control",
            "Signer"});
            this.cmbType.Location = new System.Drawing.Point(220, 163);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 20);
            this.cmbType.TabIndex = 15;
            // 
            // btnRefer
            // 
            this.btnRefer.Location = new System.Drawing.Point(227, 434);
            this.btnRefer.Name = "btnRefer";
            this.btnRefer.Size = new System.Drawing.Size(118, 31);
            this.btnRefer.TabIndex = 16;
            this.btnRefer.Text = "參考同意書";
            this.btnRefer.UseVisualStyleBackColor = true;
            this.btnRefer.Click += new System.EventHandler(this.btnRefer_Click);
            // 
            // DgvRefer
            // 
            this.DgvRefer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRefer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select_refer,
            this.ID,
            this.Column1});
            this.DgvRefer.Location = new System.Drawing.Point(432, 95);
            this.DgvRefer.Name = "DgvRefer";
            this.DgvRefer.RowTemplate.Height = 24;
            this.DgvRefer.Size = new System.Drawing.Size(431, 235);
            this.DgvRefer.TabIndex = 17;
            this.DgvRefer.Visible = false;
            this.DgvRefer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRefer_CellContentClick);
            // 
            // select_refer
            // 
            this.select_refer.HeaderText = "選取";
            this.select_refer.Name = "select_refer";
            this.select_refer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.select_refer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.select_refer.Width = 60;
            // 
            // ID
            // 
            this.ID.HeaderText = "表單編號";
            this.ID.Name = "ID";
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "表單名稱";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 559);
            this.Controls.Add(this.DgvRefer);
            this.Controls.Add(this.btnRefer);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.Dgvform);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chbFalse);
            this.Controls.Add(this.chbTrue);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddControl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.txtTemplateId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.Text = "同意書連帶控制項設定";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Dgvform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRefer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTemplateId;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddControl;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chbTrue;
        private System.Windows.Forms.CheckBox chbFalse;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView Dgvform;
        private System.Windows.Forms.DataGridViewButtonColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stat;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnRefer;
        private System.Windows.Forms.DataGridView DgvRefer;
        private System.Windows.Forms.DataGridViewButtonColumn select_refer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}