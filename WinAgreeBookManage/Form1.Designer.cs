namespace TEST0205
{
    partial class Form1
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
            this.btn_API = new System.Windows.Forms.Button();
            this.txtIDNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBirth = new System.Windows.Forms.Label();
            this.btnNoSign = new System.Windows.Forms.Button();
            this.btnIsSign = new System.Windows.Forms.Button();
            this.btnGetCard = new System.Windows.Forms.Button();
            this.btnSearchForm = new System.Windows.Forms.Button();
            this.DgvForm = new System.Windows.Forms.DataGridView();
            this.chMrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTemplateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.表單名稱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chJobID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.是否簽署 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPDFToEMR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txttemplateId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblAdress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtSDate = new System.Windows.Forms.TextBox();
            this.txtEDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvForm)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_API
            // 
            this.btn_API.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_API.Location = new System.Drawing.Point(644, 190);
            this.btn_API.Name = "btn_API";
            this.btn_API.Size = new System.Drawing.Size(119, 39);
            this.btn_API.TabIndex = 0;
            this.btn_API.Text = "取得基本資料";
            this.btn_API.UseVisualStyleBackColor = true;
            this.btn_API.Click += new System.EventHandler(this.btn_API_Click);
            // 
            // txtIDNo
            // 
            this.txtIDNo.Location = new System.Drawing.Point(215, 132);
            this.txtIDNo.Name = "txtIDNo";
            this.txtIDNo.Size = new System.Drawing.Size(100, 22);
            this.txtIDNo.TabIndex = 1;
            this.txtIDNo.Leave += new System.EventHandler(this.txtIDNo_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(74, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "同意書簽署管理系統";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15F);
            this.label2.Location = new System.Drawing.Point(135, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "病人ID ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("新細明體", 15F);
            this.lblName.Location = new System.Drawing.Point(799, 126);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(99, 20);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "病人姓名 :";
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBirth.Location = new System.Drawing.Point(988, 126);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(104, 20);
            this.lblBirth.TabIndex = 5;
            this.lblBirth.Text = "病人生日 : ";
            this.lblBirth.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnNoSign
            // 
            this.btnNoSign.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNoSign.Location = new System.Drawing.Point(466, 263);
            this.btnNoSign.Name = "btnNoSign";
            this.btnNoSign.Size = new System.Drawing.Size(144, 40);
            this.btnNoSign.TabIndex = 6;
            this.btnNoSign.Text = "查閱未簽署表單";
            this.btnNoSign.UseVisualStyleBackColor = true;
            this.btnNoSign.Click += new System.EventHandler(this.btnNoSign_Click);
            // 
            // btnIsSign
            // 
            this.btnIsSign.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnIsSign.Location = new System.Drawing.Point(644, 263);
            this.btnIsSign.Name = "btnIsSign";
            this.btnIsSign.Size = new System.Drawing.Size(119, 40);
            this.btnIsSign.TabIndex = 7;
            this.btnIsSign.Text = "查閱已簽署的表單";
            this.btnIsSign.UseVisualStyleBackColor = true;
            this.btnIsSign.Click += new System.EventHandler(this.btnIsSign_Click);
            // 
            // btnGetCard
            // 
            this.btnGetCard.Location = new System.Drawing.Point(644, 121);
            this.btnGetCard.Name = "btnGetCard";
            this.btnGetCard.Size = new System.Drawing.Size(119, 40);
            this.btnGetCard.TabIndex = 8;
            this.btnGetCard.Text = "讀取健保卡";
            this.btnGetCard.UseVisualStyleBackColor = true;
            this.btnGetCard.Click += new System.EventHandler(this.btnGetCard_Click);
            // 
            // btnSearchForm
            // 
            this.btnSearchForm.Location = new System.Drawing.Point(466, 121);
            this.btnSearchForm.Name = "btnSearchForm";
            this.btnSearchForm.Size = new System.Drawing.Size(144, 40);
            this.btnSearchForm.TabIndex = 9;
            this.btnSearchForm.Text = "搜尋表單並帶入基本資料";
            this.btnSearchForm.UseVisualStyleBackColor = true;
            this.btnSearchForm.Click += new System.EventHandler(this.btnSearchForm_Click);
            // 
            // DgvForm
            // 
            this.DgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvForm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chMrNo,
            this.chTemplateID,
            this.表單名稱,
            this.chJobID,
            this.chDocID,
            this.是否簽署,
            this.chPDFToEMR,
            this.chCDate,
            this.Search});
            this.DgvForm.Location = new System.Drawing.Point(29, 328);
            this.DgvForm.Name = "DgvForm";
            this.DgvForm.RowTemplate.Height = 24;
            this.DgvForm.Size = new System.Drawing.Size(795, 212);
            this.DgvForm.TabIndex = 10;
            this.DgvForm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvForm_CellContentClick);
            // 
            // chMrNo
            // 
            this.chMrNo.HeaderText = "案件編號";
            this.chMrNo.Name = "chMrNo";
            // 
            // chTemplateID
            // 
            this.chTemplateID.HeaderText = "表單編號";
            this.chTemplateID.Name = "chTemplateID";
            // 
            // 表單名稱
            // 
            this.表單名稱.HeaderText = "表單名稱";
            this.表單名稱.Name = "表單名稱";
            this.表單名稱.Width = 200;
            // 
            // chJobID
            // 
            this.chJobID.HeaderText = "chJobID";
            this.chJobID.Name = "chJobID";
            this.chJobID.Visible = false;
            this.chJobID.Width = 150;
            // 
            // chDocID
            // 
            this.chDocID.HeaderText = "chDocID";
            this.chDocID.Name = "chDocID";
            this.chDocID.Visible = false;
            this.chDocID.Width = 250;
            // 
            // 是否簽署
            // 
            this.是否簽署.HeaderText = "chIfComplete";
            this.是否簽署.Name = "是否簽署";
            // 
            // chPDFToEMR
            // 
            this.chPDFToEMR.HeaderText = "chPDFToEMR";
            this.chPDFToEMR.Name = "chPDFToEMR";
            this.chPDFToEMR.Visible = false;
            // 
            // chCDate
            // 
            this.chCDate.HeaderText = "chCDate";
            this.chCDate.Name = "chCDate";
            // 
            // Search
            // 
            this.Search.HeaderText = "調閱";
            this.Search.Name = "Search";
            // 
            // txttemplateId
            // 
            this.txttemplateId.Location = new System.Drawing.Point(215, 191);
            this.txttemplateId.Name = "txttemplateId";
            this.txttemplateId.Size = new System.Drawing.Size(100, 22);
            this.txttemplateId.TabIndex = 11;
            this.txttemplateId.Leave += new System.EventHandler(this.templateId_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15F);
            this.label3.Location = new System.Drawing.Point(73, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "輸入表單編號";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(466, 188);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(144, 41);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "清除欄位";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblAdress
            // 
            this.lblAdress.AutoSize = true;
            this.lblAdress.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAdress.Location = new System.Drawing.Point(799, 180);
            this.lblAdress.Name = "lblAdress";
            this.lblAdress.Size = new System.Drawing.Size(104, 20);
            this.lblAdress.TabIndex = 14;
            this.lblAdress.Text = "病人地址 : ";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPhone.Location = new System.Drawing.Point(801, 226);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(104, 20);
            this.lblPhone.TabIndex = 15;
            this.lblPhone.Text = "病人電話 : ";
            this.lblPhone.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtSDate
            // 
            this.txtSDate.Location = new System.Drawing.Point(229, 242);
            this.txtSDate.Name = "txtSDate";
            this.txtSDate.Size = new System.Drawing.Size(86, 22);
            this.txtSDate.TabIndex = 16;
            // 
            // txtEDate
            // 
            this.txtEDate.Location = new System.Drawing.Point(346, 242);
            this.txtEDate.Name = "txtEDate";
            this.txtEDate.Size = new System.Drawing.Size(86, 22);
            this.txtEDate.TabIndex = 19;
            this.txtEDate.TextChanged += new System.EventHandler(this.txtEDate_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 15F);
            this.label6.Location = new System.Drawing.Point(2, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "表單日期(YYY/MM/DD) :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15F);
            this.label4.Location = new System.Drawing.Point(321, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "~";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 659);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEDate);
            this.Controls.Add(this.txtSDate);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblAdress);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttemplateId);
            this.Controls.Add(this.DgvForm);
            this.Controls.Add(this.btnSearchForm);
            this.Controls.Add(this.btnGetCard);
            this.Controls.Add(this.btnIsSign);
            this.Controls.Add(this.btnNoSign);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIDNo);
            this.Controls.Add(this.btn_API);
            this.Name = "Form1";
            this.Text = "同意書管理";
            ((System.ComponentModel.ISupportInitialize)(this.DgvForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_API;
        private System.Windows.Forms.TextBox txtIDNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.Button btnNoSign;
        private System.Windows.Forms.Button btnIsSign;
        private System.Windows.Forms.Button btnGetCard;
        private System.Windows.Forms.Button btnSearchForm;
        private System.Windows.Forms.DataGridView DgvForm;
        private System.Windows.Forms.TextBox txttemplateId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblAdress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtSDate;
        private System.Windows.Forms.TextBox txtEDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn chMrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTemplateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 表單名稱;
        private System.Windows.Forms.DataGridViewTextBoxColumn chJobID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 是否簽署;
        private System.Windows.Forms.DataGridViewTextBoxColumn chPDFToEMR;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCDate;
        private System.Windows.Forms.DataGridViewButtonColumn Search;
    }
}

