namespace CKDSpanTeam
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeeDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPNC = new System.Windows.Forms.ComboBox();
            this.txtMRNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIdSelect = new System.Windows.Forms.Button();
            this.dgvReg = new System.Windows.Forms.DataGridView();
            this.chRemind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intRegNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chMRNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRegFM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheGFR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chHbA1c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chP4301C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chP4302C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch22041E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch22043E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch22043ECnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch22045E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch2204Cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch22045Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCKD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chCKDDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chHE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chHEDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSave = new System.Windows.Forms.DataGridViewButtonColumn();
            this.chPNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chAd1OCaseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.rdoOPD = new System.Windows.Forms.RadioButton();
            this.rdoADM = new System.Windows.Forms.RadioButton();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSaveDgv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSelect.Location = new System.Drawing.Point(565, 9);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(81, 34);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "查詢";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "日期：";
            // 
            // txtSeeDate
            // 
            this.txtSeeDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSeeDate.Location = new System.Drawing.Point(70, 17);
            this.txtSeeDate.MaxLength = 7;
            this.txtSeeDate.Multiline = true;
            this.txtSeeDate.Name = "txtSeeDate";
            this.txtSeeDate.Size = new System.Drawing.Size(95, 20);
            this.txtSeeDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(171, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "時段：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(289, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "診間代號：";
            // 
            // cboPNC
            // 
            this.cboPNC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPNC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboPNC.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboPNC.FormattingEnabled = true;
            this.cboPNC.Items.AddRange(new object[] {
            "",
            "早",
            "中",
            "晚"});
            this.cboPNC.Location = new System.Drawing.Point(231, 16);
            this.cboPNC.Name = "cboPNC";
            this.cboPNC.Size = new System.Drawing.Size(52, 24);
            this.cboPNC.TabIndex = 6;
            // 
            // txtMRNo
            // 
            this.txtMRNo.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMRNo.Location = new System.Drawing.Point(769, 19);
            this.txtMRNo.MaxLength = 10;
            this.txtMRNo.Multiline = true;
            this.txtMRNo.Name = "txtMRNo";
            this.txtMRNo.Size = new System.Drawing.Size(115, 20);
            this.txtMRNo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(652, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "病歷號查詢：";
            // 
            // btnIdSelect
            // 
            this.btnIdSelect.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnIdSelect.Location = new System.Drawing.Point(890, 10);
            this.btnIdSelect.Name = "btnIdSelect";
            this.btnIdSelect.Size = new System.Drawing.Size(81, 34);
            this.btnIdSelect.TabIndex = 9;
            this.btnIdSelect.Text = "查詢";
            this.btnIdSelect.UseVisualStyleBackColor = true;
            this.btnIdSelect.Click += new System.EventHandler(this.btnIdSelect_Click);
            // 
            // dgvReg
            // 
            this.dgvReg.AllowUserToAddRows = false;
            this.dgvReg.AllowUserToDeleteRows = false;
            this.dgvReg.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chRemind,
            this.intRegNo,
            this.chDate,
            this.chMRNo,
            this.chName,
            this.chRoomName,
            this.chRegFM,
            this.cheGFR,
            this.chHbA1c,
            this.chDocName,
            this.chP4301C,
            this.chP4302C,
            this.Day,
            this.ch22041E,
            this.ch22043E,
            this.ch22043ECnt,
            this.ch22045E,
            this.ch2204Cnt,
            this.ch22045Day,
            this.chCKD,
            this.chCKDDate,
            this.chHE,
            this.chHEDate,
            this.dgvSave,
            this.chPNC,
            this.chRoom,
            this.chAd1OCaseNo});
            this.dgvReg.Location = new System.Drawing.Point(11, 69);
            this.dgvReg.Name = "dgvReg";
            this.dgvReg.RowHeadersVisible = false;
            this.dgvReg.RowTemplate.Height = 24;
            this.dgvReg.Size = new System.Drawing.Size(1959, 496);
            this.dgvReg.TabIndex = 11;
            this.dgvReg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReg_CellContentClick);
            this.dgvReg.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReg_CellDoubleClick);
            // 
            // chRemind
            // 
            this.chRemind.HeaderText = "提示";
            this.chRemind.Name = "chRemind";
            this.chRemind.Visible = false;
            // 
            // intRegNo
            // 
            this.intRegNo.HeaderText = "序號";
            this.intRegNo.Name = "intRegNo";
            this.intRegNo.Width = 55;
            // 
            // chDate
            // 
            this.chDate.HeaderText = "日期";
            this.chDate.Name = "chDate";
            this.chDate.Visible = false;
            // 
            // chMRNo
            // 
            this.chMRNo.HeaderText = "病歷號";
            this.chMRNo.Name = "chMRNo";
            // 
            // chName
            // 
            this.chName.HeaderText = "姓名";
            this.chName.Name = "chName";
            // 
            // chRoomName
            // 
            this.chRoomName.HeaderText = "診間";
            this.chRoomName.Name = "chRoomName";
            // 
            // chRegFM
            // 
            this.chRegFM.HeaderText = "初複";
            this.chRegFM.Name = "chRegFM";
            this.chRegFM.Visible = false;
            // 
            // cheGFR
            // 
            this.cheGFR.HeaderText = "eGFR≤15";
            this.cheGFR.Name = "cheGFR";
            // 
            // chHbA1c
            // 
            this.chHbA1c.HeaderText = "HbA1c≥9";
            this.chHbA1c.Name = "chHbA1c";
            // 
            // chDocName
            // 
            this.chDocName.HeaderText = "醫師姓名";
            this.chDocName.Name = "chDocName";
            // 
            // chP4301C
            // 
            this.chP4301C.HeaderText = "P4301C";
            this.chP4301C.Name = "chP4301C";
            this.chP4301C.Visible = false;
            // 
            // chP4302C
            // 
            this.chP4302C.HeaderText = "P4302C";
            this.chP4302C.Name = "chP4302C";
            this.chP4302C.Visible = false;
            // 
            // Day
            // 
            this.Day.HeaderText = "距今";
            this.Day.Name = "Day";
            // 
            // ch22041E
            // 
            this.ch22041E.HeaderText = "22041E";
            this.ch22041E.Name = "ch22041E";
            this.ch22041E.Visible = false;
            // 
            // ch22043E
            // 
            this.ch22043E.HeaderText = "22043E";
            this.ch22043E.Name = "ch22043E";
            this.ch22043E.Visible = false;
            // 
            // ch22043ECnt
            // 
            this.ch22043ECnt.HeaderText = "43E次數";
            this.ch22043ECnt.Name = "ch22043ECnt";
            this.ch22043ECnt.Visible = false;
            // 
            // ch22045E
            // 
            this.ch22045E.HeaderText = "22045E";
            this.ch22045E.Name = "ch22045E";
            this.ch22045E.Visible = false;
            // 
            // ch2204Cnt
            // 
            this.ch2204Cnt.HeaderText = "45E次數";
            this.ch2204Cnt.Name = "ch2204Cnt";
            this.ch2204Cnt.Visible = false;
            // 
            // ch22045Day
            // 
            this.ch22045Day.HeaderText = "距今";
            this.ch22045Day.Name = "ch22045Day";
            this.ch22045Day.Visible = false;
            // 
            // chCKD
            // 
            this.chCKD.HeaderText = "CKD";
            this.chCKD.Name = "chCKD";
            this.chCKD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chCKD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // chCKDDate
            // 
            this.chCKDDate.HeaderText = "CKD日期";
            this.chCKDDate.Name = "chCKDDate";
            // 
            // chHE
            // 
            this.chHE.HeaderText = "營養";
            this.chHE.Name = "chHE";
            this.chHE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chHE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // chHEDate
            // 
            this.chHEDate.HeaderText = "營養日期";
            this.chHEDate.Name = "chHEDate";
            // 
            // dgvSave
            // 
            this.dgvSave.HeaderText = "儲存";
            this.dgvSave.Name = "dgvSave";
            this.dgvSave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvSave.Width = 75;
            // 
            // chPNC
            // 
            this.chPNC.HeaderText = "chPNC";
            this.chPNC.Name = "chPNC";
            this.chPNC.Visible = false;
            // 
            // chRoom
            // 
            this.chRoom.HeaderText = "chRoom";
            this.chRoom.Name = "chRoom";
            this.chRoom.Visible = false;
            // 
            // chAd1OCaseNo
            // 
            this.chAd1OCaseNo.HeaderText = "chAd1OCaseNo";
            this.chAd1OCaseNo.Name = "chAd1OCaseNo";
            this.chAd1OCaseNo.Visible = false;
            // 
            // txtRoom
            // 
            this.txtRoom.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRoom.Location = new System.Drawing.Point(384, 17);
            this.txtRoom.MaxLength = 7;
            this.txtRoom.Multiline = true;
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(175, 20);
            this.txtRoom.TabIndex = 12;
            // 
            // rdoOPD
            // 
            this.rdoOPD.AutoSize = true;
            this.rdoOPD.Checked = true;
            this.rdoOPD.Location = new System.Drawing.Point(459, 43);
            this.rdoOPD.Name = "rdoOPD";
            this.rdoOPD.Size = new System.Drawing.Size(47, 16);
            this.rdoOPD.TabIndex = 13;
            this.rdoOPD.TabStop = true;
            this.rdoOPD.Text = "門診";
            this.rdoOPD.UseVisualStyleBackColor = true;
            this.rdoOPD.CheckedChanged += new System.EventHandler(this.rdoOPD_CheckedChanged);
            // 
            // rdoADM
            // 
            this.rdoADM.AutoSize = true;
            this.rdoADM.Location = new System.Drawing.Point(512, 43);
            this.rdoADM.Name = "rdoADM";
            this.rdoADM.Size = new System.Drawing.Size(47, 16);
            this.rdoADM.TabIndex = 14;
            this.rdoADM.Text = "住院";
            this.rdoADM.UseVisualStyleBackColor = true;
            this.rdoADM.CheckedChanged += new System.EventHandler(this.rdoADM_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExport.Location = new System.Drawing.Point(997, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(81, 34);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "匯出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSaveDgv
            // 
            this.btnSaveDgv.Font = new System.Drawing.Font("新細明體", 20F);
            this.btnSaveDgv.Location = new System.Drawing.Point(512, 573);
            this.btnSaveDgv.Name = "btnSaveDgv";
            this.btnSaveDgv.Size = new System.Drawing.Size(198, 48);
            this.btnSaveDgv.TabIndex = 16;
            this.btnSaveDgv.Text = "儲存表格";
            this.btnSaveDgv.UseVisualStyleBackColor = true;
            this.btnSaveDgv.Click += new System.EventHandler(this.btnSaveDgv_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 633);
            this.Controls.Add(this.btnSaveDgv);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.rdoADM);
            this.Controls.Add(this.rdoOPD);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.dgvReg);
            this.Controls.Add(this.btnIdSelect);
            this.Controls.Add(this.txtMRNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboPNC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSeeDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "腎臟病跨團隊照護系統";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeeDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPNC;
        private System.Windows.Forms.TextBox txtMRNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnIdSelect;
        private System.Windows.Forms.DataGridView dgvReg;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.RadioButton rdoOPD;
        private System.Windows.Forms.RadioButton rdoADM;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSaveDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRemind;
        private System.Windows.Forms.DataGridViewTextBoxColumn intRegNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn chMRNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRoomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRegFM;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheGFR;
        private System.Windows.Forms.DataGridViewTextBoxColumn chHbA1c;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chP4301C;
        private System.Windows.Forms.DataGridViewTextBoxColumn chP4302C;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch22041E;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch22043E;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch22043ECnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch22045E;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch2204Cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch22045Day;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chCKD;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCKDDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chHE;
        private System.Windows.Forms.DataGridViewTextBoxColumn chHEDate;
        private System.Windows.Forms.DataGridViewButtonColumn dgvSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn chPNC;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn chAd1OCaseNo;
    }
}

