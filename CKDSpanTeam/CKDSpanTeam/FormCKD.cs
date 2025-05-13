using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;
using Application = System.Windows.Forms.Application;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;

namespace CKDSpanTeam
{
    public partial class FormCKD : Form
    {
        public FormCKD()
        {
            InitializeComponent();
        }
        string userkind = "";//營養師 D ，護理師 C
        private void FormCKD_Load(object sender, EventArgs e)
        {
            btnIdSelect_Click(e, e);
            FormMain frmmain = new FormMain();
            if (Program.sUserType == "DOC")
            {
                this.Text = this.Text + "___登入者：" + frmmain.ArasName +"_醫師";
                btnDocSure.Visible = true;
            }
            else
            {
                this.Text = this.Text + "___登入者：" + frmmain.ArasName+ "_專師,營養師";
            }
        }
        public void btnIdSelect_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Class1.ConnectionOPDString))
            {
                if (Program.sFrom =="OPD")
                {   //門診
                    string sSQL = @" Select * from DB_OPD..OpdCKDManageTbl a (nolock)
                                    left join DB_GEN.dbo.GenUserProfile1 b (nolock) on a.chUserID = b.chUserID
                                    left join DB_GEN.dbo.GenDoctorTbl c (nolock) on a.chDocNo = c.chDocNo
                                    Where chSeeDate ='" + Program.sSeeDate + "' and chPNC = '" + Program.sPNC + "' and chRoom ='" + Program.sRoom + "' and intRegNo = '" + Program.intRegNo + "' " +
                                    "Order by intSeqNo Desc";
                    using (SqlCommand cmd = new SqlCommand(sSQL, conn))
                    {
                        conn.Open();
                        dt.Clear();
                        dt.Load(cmd.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dgvDate.Rows.Add();
                                dgvDate.Rows[i].Cells["chSeeDate"].Value = dt.Rows[i]["chSeeDate"].ToString().Trim();
                                dgvDate.Rows[i].Cells["chPNC"].Value = dt.Rows[i]["chPNC"].ToString().Trim();
                                dgvDate.Rows[i].Cells["chRoom"].Value = dt.Rows[i]["chRoom"].ToString().Trim();
                                dgvDate.Rows[i].Cells["intRegNo"].Value = dt.Rows[i]["intRegNo"].ToString().Trim();
                                dgvDate.Rows[i].Cells["intSeqNo"].Value = dt.Rows[i]["intSeqNo"].ToString().Trim();
                                dgvDate.Rows[i].Cells["Reply"].Value = dt.Rows[i]["chUserName"].ToString().Trim();
                                dgvDate.Rows[i].Cells["chDocName"].Value = dt.Rows[i]["chDocName"].ToString().Trim();
                            }
                        }
                    }
                }
                else
                {   //住院
                    using (SqlConnection connADM = new SqlConnection())
                    {
                        string sSQLADM = @"Select * from DB_OPD..OpdCKDManageTbl a (nolock)
                                        left join DB_GEN.dbo.GenUserProfile1 b (nolock) on a.chUserID = b.chUserID
                                        left join DB_GEN.dbo.GenDoctorTbl c (nolock) on a.chDocNo = c.chDocNo
                                        Where chOCaseNo ='" + Program.sOCaseNo + "'  " +
                                        "Order by intSeqNo Desc";
                        using (SqlCommand cmd = new SqlCommand(sSQLADM, conn))
                        {
                            conn.Open();
                            dt.Clear();
                            dt.Load(cmd.ExecuteReader());
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    dgvDate.Rows.Add();
                                    dgvDate.Rows[i].Cells["chSeeDate"].Value = dt.Rows[i]["chSeeDate"].ToString().Trim();
                                    dgvDate.Rows[i].Cells["intSeqNo"].Value = dt.Rows[i]["intSeqNo"].ToString().Trim();
                                    dgvDate.Rows[i].Cells["Reply"].Value = dt.Rows[i]["chUserName"].ToString().Trim();
                                    dgvDate.Rows[i].Cells["Reply"].Value = dt.Rows[i]["chUserName"].ToString().Trim();
                                    dgvDate.Rows[i].Cells["chDocName"].Value = dt.Rows[i]["chDocName"].ToString().Trim();
                                }
                            }
                        }
                    }
                }
                
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtMsg.Text.ToString().Trim() =="")
            {
                MessageBox.Show("請輸入內容!!!");
                return;
            }
            if (chkTeacher.Checked == false && chkNutritionist.Checked == false)
            {
                MessageBox.Show("請選擇身分!!!");
                return;
            }
            using (SqlConnection conn = new SqlConnection(Class1.ConnectionOPDString))
            {
                DataTable dt = new DataTable();
                FormMain frmMain = new FormMain();
                string sMsg = "";
                string sSQL = "";
                int iMaxSeqNo = 0;
                if (Program.sFrom == "OPD")
                {   //門診
                    sSQL = @" Select MAX(intSeqNo)+1 AS intSeqNo from DB_OPD..OpdCKDManageTbl (nolock)
                            Where chSeeDate ='" + Program.sSeeDate + "' and chPNC = '" + Program.sPNC + "' and chRoom ='" + Program.sRoom + "' and intRegNo = '" + Program.intRegNo + "' ";
                    using (SqlCommand cmd = new SqlCommand(sSQL, conn))
                    {
                        conn.Open();
                        dt.Clear();
                        dt.Load(cmd.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["intSeqNo"].ToString().Trim() == "")
                            {
                                //sMsg = txtMsgView.Text + (DateTime.Now) + "  " + frmMain.ArasName.ToString().Trim();
                                sMsg = (DateTime.Now) + "  " + frmMain.ArasName.ToString().Trim() + "\r\n" + txtMsg.Text.ToString().Trim();
                            }
                            else
                            {
                                iMaxSeqNo = Int16.Parse(dt.Rows[0]["intSeqNo"].ToString().Trim());
                                //sMsg = txtMsgView.Text + "\r\n" + (DateTime.Now) + "  " + frmMain.ArasName.ToString().Trim() + "\r\n";
                                sMsg = (DateTime.Now) + "  " + frmMain.ArasName.ToString().Trim() + "\r\n" + txtMsg.Text.ToString().Trim();
                            }
                            sSQL = @"INSERT INTO [DB_OPD].[dbo].[OpdCKDManageTbl]
                                    ([chSeeDate],[chPNC],[chRoom],[intRegNo]
                                    ,[intSeqNo],[chMRNo],[chMsg],[chSetFlg]
                                    ,[chUserID],[chModDTM],[chOCaseNo],[chEducation]
                                    ,[chHeight],[chWeight],[chBP1],[chBP2])
                                    VALUES
                                    ('" + Program.sSeeDate.ToString().Trim() + "','" + Program.sPNC.ToString().Trim() + "','" + Program.sRoom.ToString().Trim() + "','" + Program.intRegNo.ToString().Trim() + "'" +
                                       ",'"+ iMaxSeqNo + "','" + txtMRNo.Text.ToString().Trim() + "','" + sMsg + "','N'" +
                                       ",'" + frmMain.ArasID.ToString().Trim() + "','" + frmMain.GetDate11(DateTime.Now) + "','OPD','"+userkind+"'" +
                                       ",'" + txtHeight.Text.ToString().Trim() + "','"+txtWeight.Text.ToString().Trim()+"','"+txtBP1.Text.ToString().Trim()+"','"+txtBP2.Text.ToString().Trim()+"')";//新增chEducation的欄位
                            cmd.CommandText = sSQL;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("回覆完成");
                            this.Close();
                        }
                    }
                }
                else
                {   //住院
                    sSQL = @" Select MAX(intSeqNo)+1 AS intSeqNo from DB_OPD..OpdCKDManageTbl (nolock)
                            Where chOCaseNo = '" + Program.sOCaseNo + "' ";
                    using (SqlCommand cmd = new SqlCommand(sSQL, conn))
                    {
                        conn.Open();
                        dt.Clear();
                        dt.Load(cmd.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["intSeqNo"].ToString().Trim() == "")
                            {
                                //sMsg = txtMsgView.Text + (DateTime.Now) + "  " + frmMain.ArasName.ToString().Trim();
                                sMsg = (DateTime.Now) + "  " + frmMain.ArasName.ToString().Trim() + "\r\n" + txtMsg.Text.ToString().Trim();
                            }
                            else
                            {
                                iMaxSeqNo = Int16.Parse(dt.Rows[0]["intSeqNo"].ToString().Trim());
                                //sMsg = txtMsgView.Text + "\r\n" + (DateTime.Now) + "  " + frmMain.ArasName.ToString().Trim() + "\r\n";
                                sMsg = (DateTime.Now) + "  " + frmMain.ArasName.ToString().Trim() + "\r\n" + txtMsg.Text.ToString().Trim();
                            }
                            sSQL = @"INSERT INTO [DB_OPD].[dbo].[OpdCKDManageTbl]
                                    ([chSeeDate],[chPNC],[chRoom],[intRegNo]
                                    ,[intSeqNo],[chMRNo],[chMsg],[chSetFlg]
                                    ,[chUserID],[chModDTM],[chOCaseNo])
                                    VALUES
                                    ('" + Program.sSeeDate.ToString().Trim() + "','" + Program.sPNC.ToString().Trim() + "','" + Program.sRoom.ToString().Trim() + "','" + Program.intRegNo.ToString().Trim() + "'" +
                                       ",'"+ iMaxSeqNo + "','" + txtMRNo.Text.ToString().Trim() + "','" + sMsg + "','N'" +
                                       ",'" + frmMain.ArasID.ToString().Trim() + "','" + frmMain.GetDate11(DateTime.Now) + "','"+Program.sOCaseNo.ToString().Trim()+"')";
                            cmd.CommandText = sSQL;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("回覆完成");
                            this.Close();
                        }
                    }
                }
                
            }
        }

        private void dgvDate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sSQL ;
            using (SqlConnection conn = new SqlConnection(Class1.ConnectionOPDString))
            {
                DataTable dt = new DataTable();
                if (Program.sFrom == "OPD")
                {
                     sSQL = @" Select TOP 1 * from DB_OPD..OpdCKDManageTbl (nolock)
                                Where chSeeDate ='" + dgvDate.Rows[e.RowIndex].Cells["chSeeDate"].Value.ToString() + "' and chPNC = '" + dgvDate.Rows[e.RowIndex].Cells["chPNC"].Value.ToString() + "'" +
                                " and chRoom ='" + dgvDate.Rows[e.RowIndex].Cells["chRoom"].Value.ToString() + "' and intRegNo = '" + dgvDate.Rows[e.RowIndex].Cells["intRegNo"].Value.ToString() + "' " +
                                "and intSeqNo = '" + dgvDate.Rows[e.RowIndex].Cells["intSeqNo"].Value.ToString() + "' Order by intSeqNo Desc";
                }
                else
                {
                     sSQL = @" Select TOP 1 * from DB_OPD..OpdCKDManageTbl (nolock)
                                Where chSeeDate ='" + dgvDate.Rows[e.RowIndex].Cells["chSeeDate"].Value.ToString() + "' " +
                                "and chOCaseNo = '" + dgvDate.Rows[e.RowIndex].Cells["chAd1OCaseNo"].Value.ToString() +"' " +
                                "and intSeqNo = '" + dgvDate.Rows[e.RowIndex].Cells["intSeqNo"].Value.ToString() + "' ";
                }
                
                using (SqlCommand cmd = new SqlCommand(sSQL, conn))
                {
                    conn.Open();
                    dt.Clear();
                    dt.Load(cmd.ExecuteReader());
                    if (dt.Rows.Count > 0)
                    {
                        txtMsgView.Text = dt.Rows[0]["chMsg"].ToString().Trim() + "\r\n" + dt.Rows[0]["chDocResPond"].ToString().Trim();
                        if (Program.sFrom == "OPD")
                        {
                            Program.sSeeDate = dgvDate.Rows[e.RowIndex].Cells["chSeeDate"].Value.ToString();
                            Program.sPNC = dgvDate.Rows[e.RowIndex].Cells["chPNC"].Value.ToString();
                            Program.sRoom = dgvDate.Rows[e.RowIndex].Cells["chRoom"].Value.ToString();
                            Program.intRegNo = Int16.Parse(dgvDate.Rows[e.RowIndex].Cells["intRegNo"].Value.ToString());
                            Program.intSeqNo = Int16.Parse(dgvDate.Rows[e.RowIndex].Cells["intSeqNo"].Value.ToString());
                        }
                        else
                        {
                            Program.sSeeDate = dgvDate.Rows[e.RowIndex].Cells["chSeeDate"].Value.ToString();
                            Program.sOCaseNo = dgvDate.Rows[e.RowIndex].Cells["chAd1OCaseNo"].Value.ToString();
                            Program.intSeqNo = Int16.Parse(dgvDate.Rows[e.RowIndex].Cells["intSeqNo"].Value.ToString());
                        }
                        txtHeight.Text = dt.Rows[0]["chHeight"].ToString().Trim();
                        txtWeight.Text = dt.Rows[0]["chWeight"].ToString().Trim();
                        txtBP1.Text = dt.Rows[0]["chBP1"].ToString().Trim();
                        txtBP2.Text = dt.Rows[0]["chBP2"].ToString().Trim();
                    }
                }
            }
        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sSQL;
            DataTable dt = new DataTable();
            FormMain frmMain = new FormMain();

            if (txtMsg.Text.ToString().Trim() == "")
            {
                MessageBox.Show("請輸入內容!!!");
                return;
            }
            if (chkTeacher.Checked == false && chkNutritionist.Checked == false)
            {
                MessageBox.Show("請選擇身分!!!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(Class1.ConnectionOPDString))
            {
                if (Program.sFrom == "OPD")
                {   //門診
                    sSQL = @"Select * from DB_OPD..OpdCKDManageTbl (nolock)
                            Where chSeeDate ='" + Program.sSeeDate + "' and chPNC = '" + Program.sPNC + "' and chRoom ='" + Program.sRoom + "' " +
                            "and intRegNo = '" + Program.intRegNo + "' and intSeqNo = '" + Program.intSeqNo + "' ";
                }
                else
                {   //住院
                    sSQL = @" Select * from DB_OPD..OpdCKDManageTbl (nolock)
                            Where chOCaseNo = '" + Program.sOCaseNo + "' and intSeqNo = '"+ Program.intSeqNo + "' ";
                }
                using (SqlCommand cmd = new SqlCommand(sSQL,conn))
                {
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                    if (dt.Rows.Count > 0)
                    {
                        if (Program.sFrom == "OPD")
                        {
                            sSQL = @" Update  DB_OPD..OpdCKDManageTbl  set chMsg = '" + (DateTime.Now) + frmMain.ArasName.ToString().Trim() + "\r\n"  + txtMsg.Text.ToString().Trim() + "' " + ", chEducation = '" +userkind.Trim()+"' "+
                                " ,chHeight = '"+txtHeight.Text.ToString().Trim()+"',chWeight = '"+txtWeight.Text.ToString().Trim()+"',chBP1 = '"+txtBP1.Text.ToString().Trim()+"',chBP2 = '"+txtBP2.Text.ToString().Trim()+"' " +
                                " Where chSeeDate ='" + Program.sSeeDate + "' and chPNC = '" + Program.sPNC + "' and chRoom ='" + Program.sRoom + "'" +
                                " and intRegNo = '" + Program.intRegNo + "' and intSeqNo = '" + Program.intSeqNo + "' ";
                        }
                        else
                        {
                            sSQL = @" Update  DB_OPD..OpdCKDManageTbl  set chMsg = '" + (DateTime.Now) + "  " + frmMain.ArasName.ToString().Trim() + "\r\n" + txtMsg.Text.ToString().Trim() + "' " + ", chEducation = '" + userkind.Trim() + "' " +
                                ",chHeight = '" + txtHeight.Text.ToString().Trim() + "',chWeight = '" + txtWeight.Text.ToString().Trim() + "',chBP1 = '" + txtBP1.Text.ToString().Trim() + "',chBP2 = '" + txtBP2.Text.ToString().Trim() + "' " +
                                " where chOCaseNo = '" + Program.sOCaseNo + "'  and intSeqNo = '" + Program.intSeqNo + "' ";
                        }
                        cmd.CommandText = sSQL;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("修改完成");
                        Close();
                    }
                }
            }
        }

        private void btnDocSure_Click(object sender, EventArgs e)
        {
            string sSQL;
            DataTable dt = new DataTable();
            FormMain frmMain = new FormMain();
            using (SqlConnection conn = new SqlConnection (Class1.ConnectionOPDString))
            {
                if (Program.sFrom == "OPD")
                {   //門診
                    sSQL = @"Select * from DB_OPD..OpdCKDManageTbl (nolock)
                            Where chSeeDate ='" + Program.sSeeDate + "' and chPNC = '" + Program.sPNC + "' and chRoom ='" + Program.sRoom + "' " +
                            "and intRegNo = '" + Program.intRegNo + "' and intSeqNo = '" + Program.intSeqNo + "' ";
                }
                else
                {   //住院
                    sSQL = @" Select * from DB_OPD..OpdCKDManageTbl (nolock)
                            Where chOCaseNo = '" + Program.sOCaseNo + "' and intSeqNo = '" + Program.intSeqNo + "' ";
                }
                using (SqlCommand cmd = new SqlCommand(sSQL,conn))
                {
                    dt.Reset();
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                    if (dt.Rows.Count > 0)
                    {
                        if (Program.sFrom == "OPD")
                        {
                            sSQL = @" Update  DB_OPD..OpdCKDManageTbl  set chDocResPond = '" + (DateTime.Now) +"  "+ frmMain.ArasName.ToString().Trim() + "\r\n" + txtMsg.Text.ToString().Trim() + "'" +
                                ",chDocNo = '" +frmMain.ArasID + "' " +
                                "Where chSeeDate ='" + Program.sSeeDate + "' and chPNC = '" + Program.sPNC + "' and chRoom ='" + Program.sRoom + "'" +
                                " and intRegNo = '" + Program.intRegNo + "' and intSeqNo = '" + Program.intSeqNo + "' ";
                        }
                        else
                        {
                            sSQL = @" Update  DB_OPD..OpdCKDManageTbl  set chDocResPond = '" + (DateTime.Now) + "  " + frmMain.ArasName.ToString().Trim() + "\r\n" + txtMsg.Text.ToString().Trim() + "'" +
                                ",chDocNo = '" + frmMain.ArasID + "'  " +
                                "where chOCaseNo = '" + Program.sOCaseNo + "'  and intSeqNo = '" + Program.intSeqNo + "' ";
                        }
                        cmd.CommandText = sSQL;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("回覆完成");
                        Close();
                    }
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            userkind = "C";
            chkTeacher.Checked = true;
            // MessageBox.Show(userkind);
            FormChoose frmChoose = new FormChoose();
            frmChoose.ShowDialog();
            if (txtMsg.Text.ToString().Trim() != "")
            {
                txtMsg.Text = txtMsg.Text + "\r\n" + Program.sChooes.ToString().Trim();
            }
            else
            {
                txtMsg.Text = Program.sChooes.ToString().Trim();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userkind = "D";
            chkNutritionist.Checked = true;
            // MessageBox.Show(userkind);
            FormNutrition formNutrition = new FormNutrition();
            formNutrition.ShowDialog();
            if (txtMsg.Text.ToString().Trim() != "")
            {
                txtMsg.Text = txtMsg.Text + "\r\n" + Program.sChooes.ToString().Trim();
            }
            else
            {
                txtMsg.Text = Program.sChooes.ToString().Trim();
            }
        }

        private void chkTeacher_CheckedChanged(object sender, EventArgs e)
        {
            //營養師 D ，護理師 C
            userkind = "C";
            if (chkTeacher.Checked  == true)
            {
                chkNutritionist.Checked = false;
            }
        }

        private void chkNutritionist_CheckedChanged(object sender, EventArgs e)
        {
            //營養師 D ，護理師 C
            userkind = "D";
            if (chkNutritionist.Checked == true)
            {
                chkTeacher.Checked = false;
            }
        }

    }
}
