namespace CKDSpanTeam
{
    partial class FormCKD
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
            this.txtMRNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDocSure = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.dgvDate = new System.Windows.Forms.DataGridView();
            this.chSeeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intRegNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intSeqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chAd1OCaseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSure = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMsgView = new System.Windows.Forms.TextBox();
            this.btnIdSelect = new System.Windows.Forms.Button();
            this.chkTeacher = new System.Windows.Forms.CheckBox();
            this.chkNutritionist = new System.Windows.Forms.CheckBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBP1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBP2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDate)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMRNo
            // 
            this.txtMRNo.Enabled = false;
            this.txtMRNo.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMRNo.Location = new System.Drawing.Point(89, 18);
            this.txtMRNo.MaxLength = 10;
            this.txtMRNo.Multiline = true;
            this.txtMRNo.Name = "txtMRNo";
            this.txtMRNo.Size = new System.Drawing.Size(115, 20);
            this.txtMRNo.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(8, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "病歷號：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnDocSure);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnChoose);
            this.panel1.Controls.Add(this.dgvDate);
            this.panel1.Controls.Add(this.btnSure);
            this.panel1.Controls.Add(this.txtMsg);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMsgView);
            this.panel1.Location = new System.Drawing.Point(8, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 563);
            this.panel1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(687, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 34);
            this.button1.TabIndex = 22;
            this.button1.Text = "B營養";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDocSure
            // 
            this.btnDocSure.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDocSure.Location = new System.Drawing.Point(495, 404);
            this.btnDocSure.Name = "btnDocSure";
            this.btnDocSure.Size = new System.Drawing.Size(71, 66);
            this.btnDocSure.TabIndex = 21;
            this.btnDocSure.Text = "醫師回覆";
            this.btnDocSure.UseVisualStyleBackColor = true;
            this.btnDocSure.Visible = false;
            this.btnDocSure.Click += new System.EventHandler(this.btnDocSure_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnUpdate.Location = new System.Drawing.Point(495, 473);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(71, 66);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(572, 505);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(235, 34);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "離        開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnChoose.Location = new System.Drawing.Point(572, 465);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(116, 34);
            this.btnChoose.TabIndex = 18;
            this.btnChoose.Text = "A護理";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // dgvDate
            // 
            this.dgvDate.AllowUserToAddRows = false;
            this.dgvDate.AllowUserToDeleteRows = false;
            this.dgvDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chSeeDate,
            this.Reply,
            this.chDocName,
            this.chPNC,
            this.chRoom,
            this.intRegNo,
            this.intSeqNo,
            this.chAd1OCaseNo});
            this.dgvDate.Location = new System.Drawing.Point(572, 32);
            this.dgvDate.Name = "dgvDate";
            this.dgvDate.ReadOnly = true;
            this.dgvDate.RowHeadersVisible = false;
            this.dgvDate.RowTemplate.Height = 24;
            this.dgvDate.Size = new System.Drawing.Size(235, 422);
            this.dgvDate.TabIndex = 16;
            this.dgvDate.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDate_CellDoubleClick);
            // 
            // chSeeDate
            // 
            this.chSeeDate.HeaderText = "歷年紀錄";
            this.chSeeDate.Name = "chSeeDate";
            this.chSeeDate.ReadOnly = true;
            this.chSeeDate.Width = 80;
            // 
            // Reply
            // 
            this.Reply.HeaderText = "回覆人";
            this.Reply.Name = "Reply";
            this.Reply.ReadOnly = true;
            this.Reply.Width = 70;
            // 
            // chDocName
            // 
            this.chDocName.HeaderText = "回復醫師";
            this.chDocName.Name = "chDocName";
            this.chDocName.ReadOnly = true;
            this.chDocName.Width = 80;
            // 
            // chPNC
            // 
            this.chPNC.HeaderText = "chPNC";
            this.chPNC.Name = "chPNC";
            this.chPNC.ReadOnly = true;
            this.chPNC.Visible = false;
            // 
            // chRoom
            // 
            this.chRoom.HeaderText = "chRoom";
            this.chRoom.Name = "chRoom";
            this.chRoom.ReadOnly = true;
            this.chRoom.Visible = false;
            // 
            // intRegNo
            // 
            this.intRegNo.HeaderText = "intRegNo";
            this.intRegNo.Name = "intRegNo";
            this.intRegNo.ReadOnly = true;
            this.intRegNo.Visible = false;
            // 
            // intSeqNo
            // 
            this.intSeqNo.HeaderText = "版本";
            this.intSeqNo.Name = "intSeqNo";
            this.intSeqNo.ReadOnly = true;
            this.intSeqNo.Visible = false;
            this.intSeqNo.Width = 60;
            // 
            // chAd1OCaseNo
            // 
            this.chAd1OCaseNo.HeaderText = "chAd1OCaseNo";
            this.chAd1OCaseNo.Name = "chAd1OCaseNo";
            this.chAd1OCaseNo.ReadOnly = true;
            this.chAd1OCaseNo.Visible = false;
            // 
            // btnSure
            // 
            this.btnSure.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSure.Location = new System.Drawing.Point(495, 404);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(71, 66);
            this.btnSure.TabIndex = 17;
            this.btnSure.Text = "回覆";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMsg.Location = new System.Drawing.Point(16, 404);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(473, 135);
            this.txtMsg.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "CKD";
            // 
            // txtMsgView
            // 
            this.txtMsgView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMsgView.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMsgView.Location = new System.Drawing.Point(16, 32);
            this.txtMsgView.Multiline = true;
            this.txtMsgView.Name = "txtMsgView";
            this.txtMsgView.ReadOnly = true;
            this.txtMsgView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgView.Size = new System.Drawing.Size(550, 366);
            this.txtMsgView.TabIndex = 14;
            // 
            // btnIdSelect
            // 
            this.btnIdSelect.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnIdSelect.Location = new System.Drawing.Point(753, 3);
            this.btnIdSelect.Name = "btnIdSelect";
            this.btnIdSelect.Size = new System.Drawing.Size(81, 34);
            this.btnIdSelect.TabIndex = 12;
            this.btnIdSelect.Text = "查詢";
            this.btnIdSelect.UseVisualStyleBackColor = true;
            this.btnIdSelect.Visible = false;
            this.btnIdSelect.Click += new System.EventHandler(this.btnIdSelect_Click);
            // 
            // chkTeacher
            // 
            this.chkTeacher.AutoSize = true;
            this.chkTeacher.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkTeacher.Location = new System.Drawing.Point(658, 45);
            this.chkTeacher.Name = "chkTeacher";
            this.chkTeacher.Size = new System.Drawing.Size(85, 23);
            this.chkTeacher.TabIndex = 16;
            this.chkTeacher.Text = "衛教師";
            this.chkTeacher.UseVisualStyleBackColor = true;
            this.chkTeacher.CheckedChanged += new System.EventHandler(this.chkTeacher_CheckedChanged);
            // 
            // chkNutritionist
            // 
            this.chkNutritionist.AutoSize = true;
            this.chkNutritionist.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkNutritionist.Location = new System.Drawing.Point(749, 45);
            this.chkNutritionist.Name = "chkNutritionist";
            this.chkNutritionist.Size = new System.Drawing.Size(85, 23);
            this.chkNutritionist.TabIndex = 17;
            this.chkNutritionist.Text = "營養師";
            this.chkNutritionist.UseVisualStyleBackColor = true;
            this.chkNutritionist.CheckedChanged += new System.EventHandler(this.chkNutritionist_CheckedChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtHeight.Location = new System.Drawing.Point(291, 18);
            this.txtHeight.MaxLength = 10;
            this.txtHeight.Multiline = true;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(115, 20);
            this.txtHeight.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(229, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "身高：";
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtWeight.Location = new System.Drawing.Point(291, 44);
            this.txtWeight.MaxLength = 10;
            this.txtWeight.Multiline = true;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(115, 20);
            this.txtWeight.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(229, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "體重：";
            // 
            // txtBP1
            // 
            this.txtBP1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBP1.Location = new System.Drawing.Point(488, 18);
            this.txtBP1.MaxLength = 10;
            this.txtBP1.Multiline = true;
            this.txtBP1.Name = "txtBP1";
            this.txtBP1.Size = new System.Drawing.Size(115, 20);
            this.txtBP1.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(412, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "收縮壓：";
            // 
            // txtBP2
            // 
            this.txtBP2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBP2.Location = new System.Drawing.Point(488, 42);
            this.txtBP2.MaxLength = 10;
            this.txtBP2.Multiline = true;
            this.txtBP2.Name = "txtBP2";
            this.txtBP2.Size = new System.Drawing.Size(115, 20);
            this.txtBP2.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(412, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 24;
            this.label6.Text = "舒張壓：";
            // 
            // FormCKD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 650);
            this.Controls.Add(this.txtBP2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBP1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkNutritionist);
            this.Controls.Add(this.chkTeacher);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnIdSelect);
            this.Controls.Add(this.txtMRNo);
            this.Controls.Add(this.label4);
            this.Name = "FormCKD";
            this.Text = "腎臟病跨團隊照護系統";
            this.Load += new System.EventHandler(this.FormCKD_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtMRNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSure;
        public  System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMsgView;
        private System.Windows.Forms.Button btnIdSelect;
        private System.Windows.Forms.DataGridView dgvDate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDocSure;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSeeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reply;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chPNC;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn intRegNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn intSeqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chAd1OCaseNo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkTeacher;
        private System.Windows.Forms.CheckBox chkNutritionist;
        public System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtBP1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtBP2;
        private System.Windows.Forms.Label label6;
    }
}