using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;

namespace CKDSpanTeam
{
    public partial class FormChoose : Form
    {
        public FormChoose()
        {
            InitializeComponent();
        }

        private void FormChoose_Load(object sender, EventArgs e)
        {
             Program.sChooes="";
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
            string OutString = "";
            Boolean bRB = false;
            if (cboNutrition.SelectedIndex == 11 && txtOther.Text.ToString().Trim() == "")
            {
                MessageBox.Show("請填寫其他欄位");
                return;
            }

            if (cboNutrition.SelectedIndex != 0 && cboNutrition.SelectedIndex != -1 )
            {
                foreach (Control cl in groupBox7.Controls)//迴圈groupBox上的控制元件
                {
                    if (cl is RadioButton)//看看是不是RadioButton
                    {
                        RadioButton rb = cl as RadioButton;//將找到的control轉化成RadioButton
                        if (rb.Checked)//判斷是否選中
                        {
                            bRB = true;
                            Program.sChooes = Program.sChooes + cboNutrition.Text + "-" + rb.Text + "\r\n";
                        }
                    }
                }
                if (!bRB && cboNutrition.SelectedIndex !=11)
                {
                    MessageBox.Show("請選擇右方條件");
                    return;
                }
            }
            

            foreach (Control cl in this.Controls)//迴圈Form上的控制元件
            {
                if (cl is GroupBox)//看看是不是GroupBox
                {
                    GroupBox GB = cl as GroupBox;//將找到的control轉化成GroupBox
                    foreach (Control ctl in GB.Controls)//迴圈GroupBox上的控制元件
                    {
                        if (ctl is CheckBox)//看看是不是checkbox
                        {
                            CheckBox ck = ctl as CheckBox;//將找到的control轉化成CheckBox
                            if (ck.Checked)//判斷是否選中
                            {
                                if (ck.Text.ToString().Contains("Elary") ==true || ck.Text.ToString().Contains("Pre") == true)
                                {
                                    Program.sChooes = Program.sChooes + ck.Text + "\r\n";
                                }
                                else
                                {
                                    OutString = OutString + ck.Tag.ToString().Trim() + ",";
                                    Program.sChooes = Program.sChooes + ck.Text.Substring(3) + "\r\n";
                                }
                            }
                        }
                    }
                }
            }

            if (cboNutrition.SelectedIndex ==11)
            {
                Program.sChooes = Program.sChooes + txtOther.Text + "\r\n";
            }

            DataTable dt = new DataTable();
            FormMain frmMain = new FormMain();
            string OutString2 = "";
            string OutString3 = "";
            using (SqlConnection con = new SqlConnection(Class1.ConnectionOPDString))
            {
                string sSQL = @"select * from OpdRegDiagnosisTbl a(nolock) left join DB_GEN..GenDoctorTbl b (nolock) on a.chDocNo = b.chDocNo
                Where chDate ='" + Program.sSeeDate + "' and chPNC = '" + Program.sPNC + "' " +
                "and chRoom ='" + Program.sRoom + "' and intRegNo = '" + Program.intRegNo + "' ";
                using (SqlCommand cmd = new SqlCommand(sSQL,con))
                {
                    dt.Reset();
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    if (dt.Rows.Count > 0)
                    {
                        sSQL = @" select top 1 chPhysNo,chPhysResult,chEntryDate from OpdSoapNrsTbl where  chMRNo = '" + Program.sMRNo.ToString().Trim() + @"' and chPhysNo = '01' 
                                union 
                                select top 1 chPhysNo,chPhysResult,chEntryDate from OpdSoapNrsTbl where  chMRNo = '" + Program.sMRNo.ToString().Trim() + @"' and chPhysNo = '04' 
                                union 
                                select top 1 chPhysNo,chPhysResult,chEntryDate from OpdSoapNrsTbl where  chMRNo = '" + Program.sMRNo.ToString().Trim() + @"' and chPhysNo = '05' order by chEntryDate ";
                        cmd.CommandText = sSQL;
                        DataTable dt2 = new DataTable();
                        dt2.Reset();
                        dt2.Load(cmd.ExecuteReader());
                        if (dt2.Rows.Count >0)
                        {
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                if (dt2.Rows[i]["chPhysNo"].ToString().Trim()=="01")
                                {
                                    //OutString2 = "*血壓:"+ dt2.Rows[i]["chPhysResult"].ToString().Trim() + ",";
                                    OutString2 = OutString2 + "*血壓:" +  Strings.StrConv(dt2.Rows[i]["chPhysResult"].ToString().Trim(), VbStrConv.Narrow, 0) + ",";
                                }
                                else if (dt2.Rows[i]["chPhysNo"].ToString().Trim() == "04")
                                {
                                    OutString2 = OutString2 +"*身高:"+ dt2.Rows[i]["chPhysResult"].ToString().Trim() + ",";
                                }
                                else if (dt2.Rows[i]["chPhysNo"].ToString().Trim() == "05")
                                {
                                    OutString2 = OutString2 +"*體重:"+ dt2.Rows[i]["chPhysResult"].ToString().Trim() + ",";
                                }
                            }
                        }
                        //1.eGFR  2.//CRE  3.//BUN
                        sSQL = @" select top 1 ISNULL(chVal,'') as eGFR,(
                                select top 1 ISNULL(chVal,'') as chVal from AdmResultRPTbl  
                                where  chRcpDTM >= dbo.GetChnDate7Add(-90, dbo.GetDateToDate7(GetDate()))
                                and chMRNo = '" + Program.sMRNo.ToString().Trim() + @"' and  chOrdNo = 'L0109' and chHead ='CRE' and chVal <> ''  and chSpeci = 'Blood' order by chRcpDTM desc
                                ) AS CRE,
                                (
                                select top 1 ISNULL(chVal,'') as chVal from AdmResultRPTbl  
                                where  chRcpDTM >= dbo.GetChnDate7Add(-90, dbo.GetDateToDate7(GetDate()))
                                and chMRNo = '" + Program.sMRNo.ToString().Trim() + @"' and  chOrdNo = 'L0107' and chHead = 'BUN' and chVal <> ''  order by chRcpDTM desc 
                                ) AS BUN,
                                chRcpDTM
                                from AdmResultRPTbl  
                                where  chRcpDTM >= dbo.GetChnDate7Add(-90, dbo.GetDateToDate7(GetDate()))
                                and chMRNo = '" + Program.sMRNo.ToString().Trim() + @"' and  chOrdNo = 'L0109' and chHead ='eGFR' and chVal <> '' 
                                order by chRcpDTM desc ";
                        cmd.CommandText = sSQL;
                        con.Close();
                        con.ConnectionString = Class1.ConnectionADMString;
                        con.Open();
                        DataTable dt3 = new DataTable();
                        dt3.Reset();
                        dt3.Load(cmd.ExecuteReader());
                        if (dt3.Rows.Count > 0)
                        {
                            OutString3 = OutString3 + "*GFR:" + dt3.Rows[0]["eGFR"].ToString().Trim() + ",";
                           
                            OutString3 = OutString3 + "*Cr:" + dt3.Rows[0]["CRE"].ToString().Trim() + ",";
                            
                            OutString3 = OutString3 + "*BUN:" + dt3.Rows[0]["BUN"].ToString().Trim() + ",";
                        }

                        if (OutString.ToString().Trim()!="")
                        {
                            OutString = OutString.Substring(0, OutString.Length - 1);
                        }
                        if (OutString2.ToString().Trim() != "")
                        {
                            OutString2 = OutString2.Substring(0, OutString2.Length - 1);
                        }
                        if (OutString3.ToString().Trim() != "")                        {
                            OutString3 = OutString3.Substring(0, OutString3.Length - 1);
                        }

                        //OutString_1 = 表單號,病歷號,日期,D,醫師ID,醫師姓名
                        //string OutString_1 = "E6N1622219," + dt.Rows[0]["chMRNo"].ToString().Trim().ToString() +","+ dt.Rows[0]["chDate"].ToString().Trim().ToString()+",D,"
                        //    + frmMain.ArasID + "," + frmMain.ArasName + "," + dt.Rows[0]["chDocName"].ToString().Trim();
                        ////Program.sSeeDate
                        //File.Copy(@"\\HISSVR\TCHEXE$\EXE\CallCloudThink.exe", @"C:\tch\exe\CallCloudThink.exe", true);
                        //Process.Start("C:\\tch\\exe\\CallCloudThink.exe", OutString_1 + "," + OutString + "," + OutString2 + "," + OutString3);
                        
                        }
                }
            }
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNutrition.SelectedIndex == -1 || cboNutrition.SelectedIndex == 0)
            {
                txtOther.Enabled = false;
                txtOther.Text = "";
                foreach (Control cl in groupBox7.Controls)
                {
                    if (cl is RadioButton)
                    {
                        RadioButton rb = cl as RadioButton;
                        rb.Enabled = false;
                        rb.Checked = false;
                    }
                }
                return;
            }
            if (cboNutrition.SelectedIndex != 11)
            {
                txtOther.Enabled = false;
                txtOther.Text = "";
                foreach (Control cl in groupBox7.Controls)
                {
                    if (cl is RadioButton)
                    {
                        RadioButton rb = cl as RadioButton;
                        rb.Enabled = true;
                    }
                }
            }
            else
            {
                txtOther.Enabled = true;
                foreach (Control cl in groupBox7.Controls)
                {
                    if (cl is RadioButton)
                    {
                        RadioButton rb = cl as RadioButton;
                        rb.Enabled = false;
                        rb.Checked = false;
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
