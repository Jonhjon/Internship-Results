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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Office.Interop.Excel;


namespace CKDSpanTeam
{
    public partial class FormMain : Form
    {
        public string[] Array;
        string Aras;
        public string ArasID;
        public string ArasName;

        public FormMain()
        {
            InitializeComponent();
            Array = Environment.GetCommandLineArgs();
            if (Array.Length <= 1)
            {
                MessageBox.Show("請用醫療系統開啟");
                System.Environment.Exit(System.Environment.ExitCode);
                return;
            }
            Aras = Array[1].ToString();
            if (Aras.Length < 12)
            {
                using (SqlConnection conn = new SqlConnection(Class1.ConnectionOPDString))
                {
                    string sSQL = @" select * from DB_GEN.dbo.GenDoctorTbl (nolock)
                                        where chDocNo = '" + Aras.Substring(0, 5).ToString().Trim() + "' and chQuitDate  = '' ";
                    using (SqlCommand cmd = new SqlCommand(sSQL, conn))
                    {
                        conn.Open();
                        DataTable dt = new DataTable();
                        dt.Reset();
                        dt.Load(cmd.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            if (Aras.Substring(0, 5).ToString().Trim() == "43148" || Aras.Substring(0, 5).ToString().Trim() == "43181" || Aras.Substring(0, 5).ToString().Trim() == "43179")
                            {
                                ArasID = Aras.Substring(0, 5).Trim();
                                ArasName = dt.Rows[0]["chDocName"].ToString().Trim();
                                Program.sUserType = "User";
                                return;
                            }
                            ArasID = dt.Rows[0]["chDocNo"].ToString().Trim();
                            ArasName = dt.Rows[0]["chDocName"].ToString().Trim();
                            Program.sUserType = "DOC";
                        }
                        else
                        {
                            MessageBox.Show("請通知資訊室!!! #18236 恆毅");
                            System.Environment.Exit(System.Environment.ExitCode);
                            return;
                        }
                    }
                }

            }

            if (Aras.Length >= 12)
            {
                ArasID = Aras.Substring(0, 10).Trim();
                ArasName = Aras.Substring(10).Trim();
                Program.sUserType = "User";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSeeDate.Text = GetDate7(DateTime.Now);
            cboPNC.SelectedIndex = 1;
            if (Program.sUserType == "User")
            {
                this.Text = this.Text + "___登入者：" + ArasName + "_專師,營養師";
            }
            else
            {
                this.Text = this.Text + "___登入者：" + ArasName + "_醫師";
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sStr;
            int l = 0;
            try
            {
                DataTable dt = new DataTable();
                DateTime dateTime = DateTime.Now;
                using (SqlConnection con = new SqlConnection(Class1.ConnectionOPDString))
                {
                    if (rdoOPD.Checked)
                    {   //門診
                        Program.sFrom = "OPD";
                        //string sSQL = @" Select --* --g.intRegNo, a.chMRNo, a.chDate, c.chName, d.chDocName, a.chRegFM, a.chRoom, b.chRoomName, a.chIsCKD, a.chIsHE, a.chCKD, a.chHE 
                        //        from OpdRegDiagnosisTbl a (nolock)                                
                        //        left join OpdRegRoomTbl b (nolock) on a.chDate = b.chDate and a.chPNC = b.chPNC and a.chRoom = b.chRoom
                        //        left join OpdMRBasicTbl c (nolock) on a.chMRNo = c.chMRNo
                        //        left join DB_GEN.dbo.GenDoctorTbl d (nolock) on a.chDocNo = d.chDocNo
                        //        left join OpdMREmailTbl e (nolock) on a.chMRNo = e.chMRNo 
                        //        inner join DB_WEB.dbo.Ckdbasic_New f (nolock) on a.chMRNo = f.chMRNo and chEdate = ''  
                        //        left join DB_OPD..OpdCKDManageTbl g (nolock) on a.chMRNo = g.chMRNo 
                        //        Where a.chDate = '" + txtSeeDate.Text.ToString().Trim() + "' and a.chPNC = '" + cboPNC.SelectedIndex.ToString().Trim() + "' and chIfWithdraw <> '1' " +
                        //        " "; //and (chIsKD = 'Y' or chSWKNo = 'KD')

//                        string sSQL = @"SELECT *
//                                FROM OpdRegDiagnosisTbl a (nolock)
//                                LEFT JOIN OpdRegRoomTbl b (nolock) ON a.chDate = b.chDate AND a.chPNC = b.chPNC AND a.chRoom = b.chRoom
//                                LEFT JOIN OpdMRBasicTbl c (nolock) ON a.chMRNo = c.chMRNo
//                                LEFT JOIN DB_GEN.dbo.GenDoctorTbl d (nolock) ON a.chDocNo = d.chDocNo
//                                LEFT JOIN OpdMREmailTbl e (nolock) ON a.chMRNo = e.chMRNo
//                                INNER JOIN DB_WEB.dbo.Ckdbasic_New f (nolock) ON a.chMRNo = f.chMRNo AND f.chEdate = ''
//                                LEFT JOIN [dbo].[OpdEducationTbl] g (nolock) ON a.chMRNo = g.chMRNo and g.chSeeDate = a.chDate and g.chPNC = a.chPNC and g.chRoom = a.chRoom and g.intRegNo = a.intRegNo
//                                left join OpdCKDManageTbl h (nolock) on a.chMRNo = h.chMRNo and h.chSeeDate = a.chDate and h.chPNC = a.chPNC and h.chRoom = a.chRoom and h.intRegNo = a.intRegNo
//                                Where a.chDate = '" + txtSeeDate.Text.ToString().Trim() + "' and a.chPNC = '" + cboPNC.SelectedIndex.ToString().Trim() + "' and chIfWithdraw <> '1' " +
//                                " ";
                        string sSQL = @"SELECT *
                                FROM OpdRegDiagnosisTbl a (nolock)
                                LEFT JOIN OpdRegRoomTbl b (nolock) ON a.chDate = b.chDate AND a.chPNC = b.chPNC AND a.chRoom = b.chRoom
                                LEFT JOIN OpdMRBasicTbl c (nolock) ON a.chMRNo = c.chMRNo
                                LEFT JOIN DB_GEN.dbo.GenDoctorTbl d (nolock) ON a.chDocNo = d.chDocNo
                                LEFT JOIN OpdMREmailTbl e (nolock) ON a.chMRNo = e.chMRNo
                                INNER JOIN DB_WEB.dbo.Ckdbasic_New f (nolock) ON a.chMRNo = f.chMRNo AND f.chEdate = ''
                                LEFT JOIN [dbo].[OpdEducationTbl] g (nolock) ON a.chMRNo = g.chMRNo and g.chSeeDate = a.chDate and g.chPNC = a.chPNC and g.chRoom = a.chRoom and g.intRegNo = a.intRegNo
                                OUTER APPLY 
                                    (SELECT TOP 1 chModDTM As chModDTM_C FROM OpdCKDManageTbl (nolock) 
                                     WHERE a.chMRNo = chMRNo 
                                     AND chSeeDate = a.chDate 
                                     AND chPNC = a.chPNC 
                                     AND chRoom = a.chRoom 
                                     AND intRegNo = a.intRegNo 
                                     And chEducation ='C'
                                     ORDER BY chModDTM DESC) h1
                                OUTER APPLY 
                                    (SELECT TOP 1 chModDTM As chModDTM_D FROM OpdCKDManageTbl (nolock) 
                                     WHERE a.chMRNo = chMRNo 
                                     AND chSeeDate < a.chDate 
                                     AND chPNC = a.chPNC 
                                     AND chRoom = a.chRoom 
                                     AND intRegNo = a.intRegNo 
                                     And chEducation ='D'
                                     ORDER BY chModDTM DESC) h2
                                Where a.chDate like '" + txtSeeDate.Text.ToString().Trim() + "%' and a.chPNC = '" + cboPNC.SelectedIndex.ToString().Trim() + "' and chIfWithdraw <> '1' " +" ";
                        if (txtRoom.Text.ToString().Trim() != "")
                        {
                            sSQL = sSQL + "And a.chRoom ='" + txtRoom.Text.ToString().Trim() + "' ";
                        }
                        else
                        {
                            sSQL = sSQL + "And a.chRoom in('2201','2202') ";
                        }
                        sSQL = sSQL + " Order by a.chRoom asc ,a.intRegNo asc ";

                        using (SqlCommand cmd = new SqlCommand(sSQL, con))
                        {
                            con.Open();
                            dt.Reset();
                            dt.Load(cmd.ExecuteReader());
                            dgvReg.Rows.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    sStr = GetRemind(dt.Rows[i]["chMRNo"].ToString().Trim()).ToString();
                                    if (sStr.Contains("KD") == true)
                                    {
                                        dgvReg.Rows.Add();
                                        dgvReg.Rows[l].Cells["intRegNo"].Value = dt.Rows[i]["intRegNo"].ToString().Trim();
                                        dgvReg.Rows[l].Cells["chMRNo"].Value = dt.Rows[i]["chMRNo"].ToString().Trim();
                                        dgvReg.Rows[l].Cells["chDate"].Value = dt.Rows[i]["chDate"].ToString().Trim();
                                        dgvReg.Rows[l].Cells["chName"].Value = dt.Rows[i]["chName"].ToString().Trim();
                                        dgvReg.Rows[l].Cells["chDocName"].Value = dt.Rows[i]["chDocName"].ToString().Trim();
                                        if (dt.Rows[l]["chRegFM"].ToString().Trim() == "2")
                                        {
                                            dgvReg.Rows[l].Cells["chRegFM"].Value = "複診";
                                        }
                                        else
                                        {
                                            dgvReg.Rows[l].Cells["chRegFM"].Value = "初診";
                                        }
                                        dgvReg.Rows[l].Cells["chRoom"].Value = dt.Rows[i]["chRoom"].ToString().Trim();
                                        dgvReg.Rows[l].Cells["chPNC"].Value = dt.Rows[i]["chPNC"].ToString().Trim();
                                        dgvReg.Rows[l].Cells["chRemind"].Value = GetRemind(dt.Rows[i]["chMRNo"].ToString().Trim());
                                        dgvReg.Rows[l].Cells["chRoomName"].Value = dt.Rows[i]["chRoomName"].ToString().Trim();
                                        dgvReg.Rows[l].Cells["cheGFR"].Value = GeteGFR(dt.Rows[i]["chMRNo"].ToString().Trim(), dt.Rows[i]["chDate"].ToString().Trim());
                                        dgvReg.Rows[l].Cells["chHbA1c"].Value = GeteHbA1c(dt.Rows[i]["chMRNo"].ToString().Trim(), dt.Rows[i]["chDate"].ToString().Trim());
                                        
                                        //dgvReg.Rows[l].Cells["chIsCKD"].Value = dt.Rows[i]["chIsCKD"].ToString().Trim();
                                        //dgvReg.Rows[l].Cells["chIsHE"].Value = dt.Rows[i]["chIsHE"].ToString().Trim();
                                        
                                        //if (dt.Rows[i]["chHE"].ToString().Trim() == "Y")
                                        //{
                                        //    dgvReg.Rows[l].Cells["chHE"].Value = true;
                                        //}
                                        //if (dt.Rows[i]["chCKD"].ToString().Trim() == "Y")
                                        //{
                                        //    dgvReg.Rows[l].Cells["chCKD"].Value = true;
                                        //}
                                        dgvReg.Rows[l].Cells["chCKDDate"].Value = dt.Rows[i]["chModDTM_C"].ToString().Trim();
                                        dgvReg.Rows[l].Cells["chHEDate"].Value = dt.Rows[i]["chModDTM_D"].ToString().Trim();
                                        
                                        string sP4301C = "", sP4302C = "";
                                        string days = Calculate_Number_Days(con, dt.Rows[i]["chMRNo"].ToString().Trim(), ref sP4301C, ref sP4302C, dt.Rows[i]["chDate"].ToString().Trim());
                                        
                                        dgvReg.Rows[l].Cells["Day"].Value = days;//CKD欄位自動勾選判斷
                                        if (days != "")
                                        {
                                            string[] split_days = days.Split('_');
                                            string Medical_Order = split_days[0];
                                            int Medical_Order_day = 0;
                                            if (split_days[1].Contains('('))
                                            {
                                                string[] parts = split_days[1].Split('(');
                                                Medical_Order_day = int.Parse(parts[0]);
                                                string part3 = parts[1].TrimEnd(')');
                                            }
                                            else
                                            {
                                                Medical_Order_day = int.Parse(split_days[1]);
                                            }
                                            //string[] combinedArray = new string[] { part1, part2, part3 };
                                            if ((Medical_Order == "P4301C" && Medical_Order_day >= 77) || (Medical_Order == "P4302C" && Medical_Order_day >= 161) ||
                                                (Medical_Order == "22041E" && Medical_Order_day >= 77) || (Medical_Order == "22043E" && Medical_Order_day >= 77) || (Medical_Order == "22045E" && Medical_Order_day >= 77))
                                            {
                                                dgvReg.Rows[l].Cells["chCKD"].Value = true;
                                            }
                                        }

                                        //if(dt.Rows[i]["chModDTM_D"].ToString().Trim() != null && int.Parse(dt.Rows[i]["chModDTM"].ToString().Trim()) >154)
                                        //{
                                        //    dgvReg.Rows[l].Cells["chHE"].Value = true;
                                        //}
                                        string DTM_D = dt.Rows[i]["chModDTM_D"].ToString().Trim();//營養欄位自動勾選判斷
                                        //string DTM_D = "11308081658";
                                        if (DTM_D != "") // 確認是否有最近一次的看診
                                        {
                                            int year = int.Parse(DTM_D.Substring(0, 3)) + 1911; // 民國年轉西元年
                                            int month = int.Parse(DTM_D.Substring(3, 2));
                                            int day = int.Parse(DTM_D.Substring(5, 2));
                                            //int hour = int.Parse(DTM_D.Substring(7, 2));
                                            //int minute = int.Parse(DTM_D.Substring(9, 2));

                                            DateTime parsedDateTime = new DateTime(year, month, day);

                                            TimeSpan difference = dateTime - parsedDateTime;

                                            if (difference.Days > 154)
                                            {
                                                dgvReg.Rows[l].Cells["chHE"].Value = true;
                                            }
                                        }

                                        //dgvReg.Rows[l].Cells["Day"].Value = Calculate_Number_Days(con, dt.Rows[i]["chMRNo"].ToString().Trim(),ref sP4301C,ref sP4302C);
                                        //dgvReg.Rows[l].Cells["chP4301C"].Value = sP4301C;
                                        //dgvReg.Rows[l].Cells["chP4302C"].Value = sP4302C;
                                        dgvReg.Rows[l].Cells["dgvSave"].Value = "儲存";
                                        Application.DoEvents();
                                        l++;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {   //住院
                        Program.sFrom = "ADM";
                        DataTable dtADM = new DataTable();
                        using (SqlConnection conADM = new SqlConnection(Class1.ConnectionADMString))
                        {
                            string sSQLADM = @" Select * from DB_ADM..vw_BasicDisch a (nolock) 
                                                left join HLOPDSQL.DB_OPD.dbo.OpdMREmailTbl b (nolock) on a.chAd1MrNo = b.chMRNo
                                                where chAd1OldDate = '" + txtSeeDate.Text.ToString().Trim() + "' and chIsKD = 'Y'   ";
                            using (SqlCommand cmdADM = new SqlCommand(sSQLADM, conADM))
                            {
                                conADM.Open();
                                dtADM.Reset();
                                dtADM.Load(cmdADM.ExecuteReader());
                                dgvReg.Rows.Clear();
                                if (dtADM.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtADM.Rows.Count; i++)
                                    {
                                        dgvReg.Rows.Add();
                                        dgvReg.Rows[i].Cells["chMRNo"].Value = dtADM.Rows[i]["chAd1MrNo"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["chDate"].Value = dtADM.Rows[i]["chAd1OldDate"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["chName"].Value = dtADM.Rows[i]["chAd1PSName"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["chDocName"].Value = dtADM.Rows[i]["chAd1DrName1"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["chRoomName"].Value = dtADM.Rows[i]["chAd1BLoc"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["chAd1OCaseNo"].Value = dtADM.Rows[i]["chAd1OCaseNo"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["intRegNo"].Value = i.ToString();
                                        dgvReg.Rows[i].Cells["chRemind"].Value = GetRemind(dtADM.Rows[i]["chAd1MrNo"].ToString().Trim());
                                        //Application.DoEvents();
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private string GeteGFR( string chMRNo,string sDate)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            try
            {
                using (SqlConnection conADM = new SqlConnection(Class1.ConnectionADMString))
                {
                    conADM.Open();
                    strSQL = " select top 1 ";
                    strSQL = strSQL + " Case when b.chVal <> '' Then b.chVal ";
                    strSQL = strSQL + " else b.chCommt end chRpt, ";
                    strSQL = strSQL + " * from AdmRqtrcpLWTbl a (nolock) ";
                    strSQL = strSQL + " inner join AdmResultRPTbl b (nolock) ";
                    strSQL = strSQL + " on a.chGReqNo = b.chGReqNo and a.chReqNo = b.chReqNo ";
                    strSQL = strSQL + " where a.chRcpDTM >= dbo.GetDate7(DATEADD(d,-90, dbo.GetChnDate7ToDate('" + sDate.ToString().Trim() + "'))) " + " + '0000'"; //-@SDate  --11碼    民國7+時分4 "
                    strSQL = strSQL + " and a.chRcpDTM <= '" + sDate.ToString().Trim() + "9999'";//--@EDate    --11碼    民國7+時分4 "
                    strSQL = strSQL + " and a.chMRNo = '" + chMRNo.Trim() + "'";//@MRNo
                    strSQL = strSQL + " and a.chStat in('60','70') ";
                    strSQL = strSQL + " and b.chStat in('60','70') ";
                    strSQL = strSQL + " and  a.chOrdNo = 'L0109' and chItemSeq ='02' ";
                    strSQL = strSQL + " and a.chSpeci = 'Blood' ";
                    strSQL = strSQL + " order by chRptDTM desc";
                    SqlCommand scmd = new SqlCommand(strSQL, conADM);
                    dt.Reset();
                    dt.Load(scmd.ExecuteReader());

                    if (dt.Rows.Count > 0)
                    {
                        if  (Convert.ToDouble(dt.Rows[0]["chRpt"].ToString().Trim()) <= 15)
	                    {
                            return dt.Rows[0]["chRpt"].ToString().Trim();
	                    }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return  "";
                    }


                    conADM.Close();
                }
            }
            catch (Exception)
            {

                return "";
            }
        }
        private string GeteHbA1c(string chMRNo, string sDate)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            try
            {
                using (SqlConnection conADM = new SqlConnection(Class1.ConnectionADMString))
                {
                    conADM.Open();
                    strSQL = " select top 1 ";
                    strSQL = strSQL + " Case when b.chVal <> '' Then b.chVal ";
                    strSQL = strSQL + " else b.chCommt end chRpt, ";
                    strSQL = strSQL + " * from AdmRqtrcpLWTbl a (nolock) ";
                    strSQL = strSQL + " inner join AdmResultRPTbl b (nolock) ";
                    strSQL = strSQL + " on a.chGReqNo = b.chGReqNo and a.chReqNo = b.chReqNo ";
                    strSQL = strSQL + " where a.chRcpDTM >= dbo.GetDate7(DATEADD(d,-90, dbo.GetChnDate7ToDate('" + sDate.ToString().Trim() + "'))) " + " + '0000'"; //-@SDate  --11碼    民國7+時分4 "
                    strSQL = strSQL + " and a.chRcpDTM <= '" + sDate.ToString().Trim() + "9999'";//--@EDate    --11碼    民國7+時分4 "
                    strSQL = strSQL + " and a.chMRNo = '" + chMRNo.Trim() + "'";//@MRNo
                    strSQL = strSQL + " and a.chStat in('60','70') ";
                    strSQL = strSQL + " and b.chStat in('60','70') ";
                    strSQL = strSQL + " and  a.chOrdNo = 'L0131' and chItemSeq ='01' ";
                    strSQL = strSQL + " and a.chSpeci = 'Blood' ";
                    strSQL = strSQL + " order by chRptDTM desc";
                    SqlCommand scmd = new SqlCommand(strSQL, conADM);
                    dt.Reset();
                    dt.Load(scmd.ExecuteReader());

                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToDouble(dt.Rows[0]["chRpt"].ToString().Trim()) >= 9)
                        {
                            return dt.Rows[0]["chRpt"].ToString().Trim();
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }


                    conADM.Close();
                }
            }
            catch (Exception)
            {

                return "";
            }
        }
        private string Calculate_Number_Days(SqlConnection con, string chMRNo, ref string P4301C, ref string P4302C, string sDate)//計算天數
        {
            //string sql1 = "select top 1 chSeeDate " +//計算天數
            //              "from OpdQuoteOrderTbl q " +
            //              //"left join OpdRegDiagnosisTbl a on q.chMRNo = a.chMRNo " +
            //              "where q.chMRNo= '"+chMRNo+"' and chOrderPriceNo='P4301C' and chDCFlg = 'N' and rlDose>0 order by chSeeDate desc";
            string sRtn = "";
            string sql1 = "select top 1 chSeeDate,chOrderPriceNo " +//計算天數
              "from OpdQuoteOrderTbl q " +
                //"left join OpdRegDiagnosisTbl a on q.chMRNo = a.chMRNo " +
              "where q.chMRNo= '" + chMRNo + "' and chOrderPriceNo in('P4301C','P4302C','22041E','22043E','22045E') and chDCFlg = 'N' and rlDose>0 order by chSeeDate desc";
            using (SqlCommand cmd1 = new SqlCommand(sql1, con))
            {
                DataTable dt = new DataTable();
                dt.Load(cmd1.ExecuteReader());
                if (dt.Rows.Count > 0)
                {
                    string day1 = "";
                    Boolean blCnt = false;
                    day1 = dt.Rows[0]["chSeeDate"].ToString().Trim();
                    sRtn = dt.Rows[0]["chOrderPriceNo"].ToString().Trim() + "_" + days(day1, txtSeeDate.Text.Trim()).ToString().ToString();

                    switch (dt.Rows[0]["chOrderPriceNo"].ToString().Trim())
                    {
                        case "22043E":
                        case "22045E":
                            blCnt = true;
                            break;
                        default:
                            break;
                    }
                    if (blCnt)
                    {
                        if (dt.Rows[0]["chOrderPriceNo"].ToString().Trim() == "22043E")
                        {
                            sql1 = "select top 1 chSeeDate,chOrderPriceNo " +//計算天數
                                 "from OpdQuoteOrderTbl q " +
                                //"left join OpdRegDiagnosisTbl a on q.chMRNo = a.chMRNo " +
                                 "where q.chMRNo= '" + chMRNo + "' and chOrderPriceNo in('22045E') and chDCFlg = 'N' and rlDose>0 order by chSeeDate desc";
                            DataTable dt1 = new DataTable();
                            dt1.Reset();
                            cmd1.CommandText = sql1;
                            dt1.Load(cmd1.ExecuteReader());
                            if (dt1.Rows.Count > 0)
                            {
                                sDate = dt1.Rows[0]["chSeeDate"].ToString().Trim();
                            }
                            else
                            {
                                sql1 = "select top 1 chSeeDate,chOrderPriceNo " +//計算天數
                                     "from OpdQuoteOrderTbl q " +
                                    //"left join OpdRegDiagnosisTbl a on q.chMRNo = a.chMRNo " +
                                     "where q.chMRNo= '" + chMRNo + "' and chOrderPriceNo in('22041E') and chDCFlg = 'N' and rlDose>0 order by chSeeDate desc";
                                dt1.Reset();
                                cmd1.CommandText = sql1;
                                dt1.Load(cmd1.ExecuteReader());
                                if (dt1.Rows.Count > 0)
                                {
                                    sDate = dt1.Rows[0]["chSeeDate"].ToString().Trim();
                                }
                            } 
                        }



                        sql1 = "select COUNT(*) As Cnt from OpdQuoteOrderTbl(Nolock) ";
                        sql1 = sql1 + " where chMRNo = '" + chMRNo + "'";
                        if (dt.Rows[0]["chOrderPriceNo"].ToString().Trim() == "22043E")
                        {
                            sql1 = sql1 + " and chSeeDate >= '" + sDate.ToString().Trim() + "'  and chSeeDate <= dbo.GetDate7(DATEADD(d,+365, dbo.GetChnDate7ToDate('" + sDate.ToString().Trim() + "')))";
                        }
                        sql1 = sql1 + " and chOrderPriceNo='" +  dt.Rows[0]["chOrderPriceNo"].ToString().Trim() + "' and chDCFlg = 'N' and rlDose>0";
                        dt.Reset();
                        cmd1.CommandText = sql1;
                        dt.Load(cmd1.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            sRtn = sRtn + "(" + dt.Rows[0]["Cnt"].ToString().Trim() + ")";
                        }

                    }
                    return sRtn;
                }
                else
                {
                    return "";
                }
                
            }

            //using (SqlCommand cmd1 = new SqlCommand(sql1, con))
            //{
            //    string day1= "", day2="";
            //    DataTable dt1 = new DataTable();
            //    dt1.Reset();
            //    dt1.Load(cmd1.ExecuteReader());
            //    if (dt1.Rows.Count > 0)
            //    {
            //        day1 = dt1.Rows[0]["chSeeDate"].ToString().Trim();
            //        P4301C = day1;
            //    }
            //    else
            //    {
            //        day1 = null;
            //    }
                    
            //    string sql2 = "select top 1 chSeeDate " +
            //                   "from OpdQuoteOrderTbl q " +
            //                  // "left join OpdRegDiagnosisTbl a on q.chMRNo = a.chMRNo " +
            //                   "where q.chMRNo= '"+chMRNo+"' and chOrderPriceNo='P4302C' and chDCFlg = 'N' and rlDose>0 order by chSeeDate desc";

            //    using (SqlCommand cmd2 = new SqlCommand(sql2, con))
            //    {
            //        //DataTable dt2 = new DataTable();
            //        dt1.Reset();
            //        dt1.Load(cmd2.ExecuteReader());
            //        if (dt1.Rows.Count > 0)
            //        {
            //            day2 = dt1.Rows[0]["chSeeDate"].ToString().Trim();
            //            P4302C = day2;
            //        }
            //        else
            //        {
            //            day2 = null;
            //        }
            //        if (day1!=null && day2 !=null)
            //        {
            //            if (int.Parse(day1) >= int.Parse(day2))
            //            {
            //                return "P4301C_" + days(day1, txtSeeDate.Text.Trim()).ToString();
            //                //return days(day1, txtSeeDate.Text.Trim()).ToString();
            //            }
            //            else
            //            {
            //                return "P4302C_" +  days(day2, txtSeeDate.Text.Trim()).ToString();
            //                //return days(day2, txtSeeDate.Text.Trim()).ToString();
            //            }
            //        }
            //        else
            //        {
            //            if(day1 != null)
            //            {
            //                return "P4301C_" + days(day1, txtSeeDate.Text.Trim()).ToString();
            //                //return days(day1, txtSeeDate.Text.Trim()).ToString();
            //            }else if(day2 != null)
            //            {
            //                return "P4302C_" + days(day2, txtSeeDate.Text.Trim()).ToString();
            //                //return days(day2, txtSeeDate.Text.Trim()).ToString();
            //            }
            //            else
            //            {
            //                return "暫無檢查";
            //            }
            //        }
                   
            //    }
            //}
        }
        private int days(string day1,string day2)
        {
            try
            {
                //int result_day = 0;
                // 將民國年轉換為西元年
                DateTime startDateTime = ConvertToGregorianDate(day1);
                DateTime endDateTime = ConvertToGregorianDate(day2);

                // 計算天數差異
                TimeSpan result_day = endDateTime - startDateTime;

                return result_day.Days;
            }
            catch (Exception)
            {

                return 0;
            }

        }
        private DateTime ConvertToGregorianDate(string taiwanDate)
        {
            // 解析民國年、月、日
            int year = int.Parse(taiwanDate.Substring(0, 3)) + 1911;
            int month = int.Parse(taiwanDate.Substring(3, 2));
            int day = int.Parse(taiwanDate.Substring(5, 2));

            // 建立西元日期
            return new DateTime(year, month, day);
        }
        private void btnIdSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMRNo.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("請輸入病歷號!!!");
                    return;
                }
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(Class1.ConnectionOPDString))
                {
                    if (rdoOPD.Checked)
                    {   //門診
                        Program.sFrom = "OPD";
                        string sSQL = @" Select * from OpdRegDiagnosisTbl a (nolock) 
                                left join OpdRegRoomTbl b (nolock) on a.chDate = b.chDate and a.chPNC = b.chPNC and a.chRoom = b.chRoom
                                left join OpdMRBasicTbl c (nolock) on a.chMRNo = c.chMRNo
                                left join DB_GEN.dbo.GenDoctorTbl d (nolock) on a.chDocNo = d.chDocNo
                                left join OpdMREmailTbl e (nolock) on a.chMRNo = e.chMRNo
                                LEFT JOIN [dbo].[OpdEducationTbl] g (nolock) ON a.chMRNo = g.chMRNo and g.chSeeDate = a.chDate and g.chPNC = a.chPNC and g.chRoom = a.chRoom and g.intRegNo = a.intRegNo
                                left join OpdCKDManageTbl h (nolock) on a.chMRNo = h.chMRNo and h.chSeeDate = a.chDate and h.chPNC = a.chPNC and h.chRoom = a.chRoom and h.intRegNo = a.intRegNo
                                Where a.chPNC = '" + cboPNC.SelectedIndex.ToString().Trim() + "' and chIfWithdraw <> '1' and (chIsKD = 'Y' or chSWKNo = 'KD') ";

                        if (txtRoom.Text.ToString().Trim() != "")
                        {
                            sSQL = sSQL + "And a.chRoom ='" + txtRoom.Text.ToString().Trim() + "' ";
                        }
                        else
                        {
                            sSQL = sSQL + "And a.chRoom in('2201','2202') ";
                        }
                        sSQL = sSQL + "And a.chMRNo = '" + txtMRNo.Text.ToString().Trim() + "' ";
                        using (SqlCommand cmd = new SqlCommand(sSQL, con))
                        {
                            con.Open();
                            dt.Reset();
                            dt.Load(cmd.ExecuteReader());
                            dgvReg.Rows.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    dgvReg.Rows.Add();
                                    dgvReg.Rows[i].Cells["intRegNo"].Value = dt.Rows[i]["intRegNo"].ToString().Trim();
                                    dgvReg.Rows[i].Cells["chMRNo"].Value = dt.Rows[i]["chMRNo"].ToString().Trim();
                                    dgvReg.Rows[i].Cells["chDate"].Value = dt.Rows[i]["chDate"].ToString().Trim();
                                    dgvReg.Rows[i].Cells["chName"].Value = dt.Rows[i]["chName"].ToString().Trim();
                                    dgvReg.Rows[i].Cells["chDocName"].Value = dt.Rows[i]["chDocName"].ToString().Trim();
                                    if (dt.Rows[i]["chRegFM"].ToString().Trim() == "2")
                                    {
                                        dgvReg.Rows[i].Cells["chRegFM"].Value = "複診";
                                    }
                                    else
                                    {
                                        dgvReg.Rows[i].Cells["chRegFM"].Value = "初診";
                                    }
                                    dgvReg.Rows[i].Cells["chRoom"].Value = dt.Rows[i]["chRoom"].ToString().Trim();
                                    dgvReg.Rows[i].Cells["chPNC"].Value = dt.Rows[i]["chPNC"].ToString().Trim();
                                    dgvReg.Rows[i].Cells["chRemind"].Value = GetRemind(dt.Rows[i]["chMRNo"].ToString().Trim());
                                    dgvReg.Rows[i].Cells["chRoomName"].Value = dt.Rows[i]["chRoomName"].ToString().Trim();
                                    dgvReg.Rows[i].Cells["cheGFR"].Value = dt.Rows[i]["chRoomName"].ToString().Trim();
                                    dgvReg.Rows[i].Cells["chHbA1c"].Value = dt.Rows[i]["chRoomName"].ToString().Trim();

                                    //dgvReg.Rows[i].Cells["chIsCKD"].Value = dt.Rows[i]["chIsCKD"].ToString().Trim();
                                    //dgvReg.Rows[i].Cells["chIsHE"].Value = dt.Rows[i]["chIsHE"].ToString().Trim();

                                    if (dt.Rows[i]["chCKD"].ToString().Trim() == "Y")
                                    {
                                        dgvReg.Rows[i].Cells["chCKD"].Value = true;
                                    }
                                    if (dt.Rows[i]["chHE"].ToString().Trim() == "Y")
                                    {
                                        dgvReg.Rows[i].Cells["chHE"].Value = true;
                                    }

                                    if (dt.Rows[i]["chEducation"].ToString().Trim() == "C")
                                    {
                                        dgvReg.Rows[i].Cells["chHEDate"].Value = dt.Rows[i]["chModDTM"].ToString().Trim();
                                    }
                                    else if (dt.Rows[i]["chEducation"].ToString().Trim() == "D")
                                    {
                                        dgvReg.Rows[i].Cells["chCKDDate"].Value = dt.Rows[i]["chModDTM"].ToString().Trim();
                                    }
                                    else
                                    {
                                        dgvReg.Rows[i].Cells["chHEDate"].Value = "";
                                    }

                                    string sP4301C = "", sP4302C = "";
                                    dgvReg.Rows[i].Cells["Day"].Value = Calculate_Number_Days(con, dt.Rows[i]["chMRNo"].ToString().Trim(), ref sP4301C, ref sP4302C, dt.Rows[i]["chDate"].ToString().Trim());
                                    dgvReg.Rows[i].Cells["chP4301C"].Value = sP4301C;
                                    dgvReg.Rows[i].Cells["chP4302C"].Value = sP4302C;
                                    dgvReg.Rows[i].Cells["dgvSave"].Value = "儲存";
                                    //Application.DoEvents();
                                }
                            }
                            else
                            {
                                MessageBox.Show("查無此人!!!");
                            }
                        }
                    }
                    else
                    {   //住院
                        Program.sFrom = "ADM";
                        DataTable dtADM = new DataTable();
                        using (SqlConnection conADM = new SqlConnection(Class1.ConnectionADMString))
                        {
                            string sSQLADM = @" Select * from DB_ADM..vw_BasicDisch a (nolock) 
                                                left join HLOPDSQL.DB_OPD.dbo.OpdMREmailTbl b (nolock) on a.chAd1MrNo = b.chMRNo
                                                where chIsKD = 'Y'  ";
                            sSQLADM = sSQLADM + " and a.chAd1MrNo =  '" + txtMRNo.Text.ToString().Trim() + "' ";
                            using (SqlCommand cmdADM = new SqlCommand(sSQLADM, conADM))
                            {
                                conADM.Open();
                                dtADM.Reset();
                                dtADM.Load(cmdADM.ExecuteReader());
                                dgvReg.Rows.Clear();
                                if (dtADM.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtADM.Rows.Count; i++)
                                    {
                                        dgvReg.Rows.Add();
                                        dgvReg.Rows[i].Cells["chMRNo"].Value = dtADM.Rows[i]["chAd1MrNo"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["chDate"].Value = dtADM.Rows[i]["chAd1OldDate"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["chName"].Value = dtADM.Rows[i]["chAd1PSName"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["chDocName"].Value = dtADM.Rows[i]["chAd1DrName1"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["chRoomName"].Value = dtADM.Rows[i]["chAd1BLoc"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["chAd1OCaseNo"].Value = dtADM.Rows[i]["chAd1OCaseNo"].ToString().Trim();
                                        dgvReg.Rows[i].Cells["intRegNo"].Value = i.ToString();
                                        dgvReg.Rows[i].Cells["chRemind"].Value = GetRemind(dtADM.Rows[i]["chAd1MrNo"].ToString().Trim());
                                        //Application.DoEvents();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("查無此人!!!");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void dgvReg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormCKD frmCKD = new FormCKD();
            if (Program.sFrom == "OPD")
            {   //門診
                frmCKD.txtMRNo.Text = dgvReg.Rows[e.RowIndex].Cells["chMRNo"].Value.ToString().Trim();
                Program.sSeeDate = dgvReg.Rows[e.RowIndex].Cells["chDate"].Value.ToString().Trim();
                Program.sRoom = dgvReg.Rows[e.RowIndex].Cells["chRoom"].Value.ToString().Trim();
                Program.sPNC = dgvReg.Rows[e.RowIndex].Cells["chPNC"].Value.ToString().Trim();
                Program.sMRNo = dgvReg.Rows[e.RowIndex].Cells["chMRNo"].Value.ToString().Trim();
                Program.intRegNo = Int16.Parse(dgvReg.Rows[e.RowIndex].Cells["intRegNo"].Value.ToString().Trim());
            }
            else//住院
            {
                frmCKD.txtMRNo.Text = dgvReg.Rows[e.RowIndex].Cells["chMRNo"].Value.ToString().Trim();
                Program.sOCaseNo = dgvReg.Rows[e.RowIndex].Cells["chAd1OCaseNo"].Value.ToString().Trim();
                Program.sSeeDate = dgvReg.Rows[e.RowIndex].Cells["chDate"].Value.ToString().Trim();
            }

            frmCKD.ShowDialog();
        }
        public string GetRemind(string MRNo)//抓取病人收案提示
        {
            Boolean bKD = false;
            try
            {
                string RemindMsg = "";
                using (SqlConnection conn = new SqlConnection(Class1.ConnectionOPDString))
                {
                    DataTable dt = new DataTable();//糖
                    string sSQL = @" Select top 1 * from OpdTestDoDMTbl (nolock) where chMRNo = '" + MRNo.ToString().Trim() + "' order by chSeeDate desc ";
                    using (SqlCommand cmd = new SqlCommand(sSQL, conn))
                    {
                        conn.Open();
                        dt.Reset();
                        dt.Load(cmd.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            RemindMsg = RemindMsg + "糖";
                        }
                        //KD
                        sSQL = @" Select * from OpdMREmailTbl where chMRNo = '" + MRNo.ToString().Trim() + "' and chIsKD = 'Y' ";
                        cmd.CommandText = sSQL;
                        dt.Reset();
                        dt.Load(cmd.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            bKD = true;
                            RemindMsg = RemindMsg + "KD";
                        }
                        //KD2
                        if (bKD == false)
                        {
                            sSQL = @"select * from OpdMRBasicTbl where chMRNo = '" + MRNo.ToString().Trim() + "' and chSWKNo ='KD'  ";
                            cmd.CommandText = sSQL;
                            dt.Reset();
                            dt.Load(cmd.ExecuteReader());
                            if (dt.Rows.Count > 0)
                            {
                                bKD = true;
                                RemindMsg = RemindMsg + "KD";
                            }
                        }
                        //KD3
                        if (bKD == false)
                        {
                            sSQL = @"select* from DB_WEB.dbo.Ckdbasic_New(Nolock) where chMRNo = '" + MRNo.ToString().Trim() + "'and chEdate = ''  ";
                            cmd.CommandText = sSQL;
                            dt.Reset();
                            dt.Load(cmd.ExecuteReader());
                            if (dt.Rows.Count > 0)
                            {
                                bKD = true;
                                RemindMsg = RemindMsg + "KD";
                            }
                        }
                        //COPD
                        sSQL = @" Select * from OpdCOPDCtlTbl  (nolock)where chMRNo='" + MRNo.ToString().Trim() + "'  ";
                        cmd.CommandText = sSQL;
                        dt.Reset();
                        dt.Load(cmd.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            RemindMsg = RemindMsg + "COPD";
                        }
                        //肝炎
                        sSQL = @" Select chMRNo,chSWKNo from OpdMRBasicTbl (nolock) where chMRNo='" + MRNo.ToString().Trim() + "'  ";
                        cmd.CommandText = sSQL;
                        dt.Reset();
                        dt.Load(cmd.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["chSWKNo"].ToString().Trim() == "LD")
                            {
                                RemindMsg = RemindMsg + "肝炎";
                            }
                        }
                        //CAD
                        conn.Close();
                        conn.ConnectionString = Class1.ConnectionADMString;
                        sSQL = @" Select top 1 chMRNo from  DB_ADM.dbo.AdmCADMTbl (NOLOCK) 
                            Where chMRNo = '" + MRNo.ToString().Trim() + "' and  chType in('收案中') and isnull(chCloseDate,'') = ''  ";
                        cmd.CommandText = sSQL;
                        conn.Open();
                        dt.Reset();
                        dt.Load(cmd.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            RemindMsg = RemindMsg + "肝炎";
                        }

                        //心衰
                        sSQL = @" SELECT * FROM DB_ADM.dbo.AdmCHFMangeTbl (nolock) WHERE chMRNo = '" + MRNo.ToString().Trim() + "' AND chOpenDate >= '-1' AND chType = '收案'  ";
                        cmd.CommandText = sSQL;
                        dt.Reset();
                        dt.Load(cmd.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            RemindMsg = RemindMsg + "心衰";
                        }
                    }

                }
                return RemindMsg;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return "";
            }
        }
        public string GetDate11(DateTime dTime)//抓取當下時間.明國年月日
        {
            string Time;
            TaiwanCalendar twC = new TaiwanCalendar();
            Time = twC.GetYear(dTime) + dTime.ToString("MMddHHmm");
            return Time;
        }
        public string GetDate7(DateTime dTime)//抓取當下時間.明國年月日
        {
            string Time;
            TaiwanCalendar twC = new TaiwanCalendar();
            Time = twC.GetYear(dTime) + dTime.ToString("MMdd");
            return Time;
        }
        public static string GetTime()//抓取當下時分秒
        {
            try
            {
                DateTime Date = DateTime.Now;
                string Time = Date.ToString("HHmmss");
                return Time;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string GetDate()//抓取當下時間.西元年月日
        {
            try
            {
                DateTime Date = DateTime.Now;
                string Today = Date.ToString("yyyyMMdd");
                return Today;
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormChoose frmCKD = new FormChoose();
            frmCKD.ShowDialog();
        }

        private void rdoOPD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOPD.Checked == true)
            {
                Program.sFrom = "OPD";
            }
        }

        private void rdoADM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoADM.Checked == true)
            {
                Program.sFrom = "ADM";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Application.DoEvents();


                //引用Excel Application類別
                Microsoft.Office.Interop.Excel._Application myExcel = null;
                //引用活頁簿類別
                _Workbook myBook = null;
                //引用工作表類別
                _Worksheet mySheet = null;
                //引用Range類別
                Cursor = Cursors.WaitCursor;
                int xlsRow = 1; //excel列址
                                //prgb_1.Value = 0; double prcbPercent; int j = 1; // 進度條

                excel.Application.Workbooks.Add(true); //引用excel工作簿
                myBook = excel.Workbooks[1];
                mySheet = myBook.Worksheets[1];
                mySheet.Name = "CKD資料";
                mySheet.Activate();
                //——-標題———————-
                if (excel == null)
                {
                    MessageBox.Show("!無法建立新excel檔!");
                    return;
                }
                mySheet.Cells[xlsRow, 1] = "";
                excel.Cells.NumberFormat = "@";
                // ————————————- 讀取DataGridView資料轉入excel檔

                //——-各欄名稱——————

                for (int i = 0; i < dgvReg.Columns.Count; i++)
                {
                    if (dgvReg.Columns[i].Visible && !(dgvReg.Columns[i] is  DataGridViewButtonColumn))
                    {
                        mySheet.Cells[xlsRow, i + 1] = dgvReg.Columns[i].HeaderText;
                    }
                  
                }
                Microsoft.Office.Interop.Excel.Range rowrange = mySheet.Range[excel.Cells[xlsRow, 1], mySheet.Cells[xlsRow, dgvReg.Columns.Count]];
                rowrange.Interior.Color = ColorTranslator.ToOle(Color.LightCoral);
                //——內容———————–
                xlsRow++;
                foreach (DataGridViewRow row in dgvReg.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (!(dgvReg.Columns[i] is DataGridViewButtonColumn))//dgvReg.Columns[i].Visible &&
                        {
                            mySheet.Cells[xlsRow, i + 1] = row.Cells[i].Value;
                        }
                        
                    }
                    xlsRow++;
                }
                Microsoft.Office.Interop.Excel.Range rowrange1 = mySheet.Range[mySheet.Cells[1, 1], mySheet.Cells[xlsRow - 1, dgvReg.Columns.Count]];
                rowrange1.Borders.LineStyle = 1;
                //—–結尾————————

                Cursor = Cursors.Default;


                MessageBox.Show("資料轉至excel作業完成");
                excel.Visible = true;

                mySheet = myBook.Worksheets[1];
                mySheet.Activate();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void DataGridView2Excel(Microsoft.Office.Interop.Excel.Worksheet Sheet)
        {
            // 下面方法二選一使用
            // 利用 DataGridView 
            for (int i = 0; i < dgvReg.Rows.Count; i++)
            {
                for (int j = 0; j < dgvReg.Columns.Count; j++)
                {
                    string value = dgvReg[j, i].Value.ToString();
                    Sheet.Cells[i + 1, j + 1] = value;
                }
            }
        }

        private void btnSaveDgv_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (dgvReg.Rows.Count == 0)
            {
                MessageBox.Show("無資料不可做儲存!!!\n");
                return;
            }
            try
            {
                using (SqlConnection con = new SqlConnection(Class1.ConnectionOPDString))
                {
                    con.Open();
                    for (int i = 0; i < dgvReg.Rows.Count; i++)
                    {
                        sql = "select * from [dbo].[OpdEducationTbl] " +
                            "where [chSeeDate] = @date and [chPNC] = @PNC and [chRoom] = @Room and [intRegNo] = @RegNo and [chMRNo] = @MRNo";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            // 清除參數，避免重複新增
                            cmd.Parameters.Clear();

                            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = dgvReg.Rows[i].Cells["chDate"].Value.ToString().Trim();
                            cmd.Parameters.Add("@PNC", SqlDbType.VarChar).Value = dgvReg.Rows[i].Cells["chPNC"].Value.ToString().Trim();
                            cmd.Parameters.Add("@Room", SqlDbType.VarChar).Value = dgvReg.Rows[i].Cells["chRoom"].Value.ToString().Trim();
                            cmd.Parameters.Add("@RegNo", SqlDbType.Int).Value = dgvReg.Rows[i].Cells["intRegNo"].Value.ToString().Trim();
                            cmd.Parameters.Add("@MRNo", SqlDbType.VarChar).Value = dgvReg.Rows[i].Cells["chMRNo"].Value.ToString().Trim();
                            
                            DataTable dt = new DataTable();
                            dt.Load(cmd.ExecuteReader());
                            if (dt.Rows.Count > 0)
                            {
                                sql = "Update [dbo].[OpdEducationTbl] set chCKD =@CKD , chHE = @HE" +
                                    " where [chSeeDate] = @date and [chPNC] = @PNC and [chRoom] = @Room and [intRegNo] = @RegNo and [chMRNo] = @MRNo";

                                cmd.CommandText = sql;

                                if (dgvReg.Rows[i].Cells["chCKD"].Value != null && (bool)dgvReg.Rows[i].Cells["chCKD"].Value == true)
                                {
                                    cmd.Parameters.Add("@CKD", SqlDbType.VarChar).Value = "Y";
                                }
                                else
                                {
                                    cmd.Parameters.Add("@CKD", SqlDbType.VarChar).Value = "N";
                                }
                                if (dgvReg.Rows[i].Cells["chHE"].Value != null && (bool)dgvReg.Rows[i].Cells["chHE"].Value == true)
                                {
                                    cmd.Parameters.Add("@HE", SqlDbType.VarChar).Value = "Y";
                                }
                                else
                                {
                                    cmd.Parameters.Add("@HE", SqlDbType.VarChar).Value = "N";
                                }
                                
                                //if (cmd.ExecuteNonQuery() > 0)
                                //{
                                //    MessageBox.Show("更新成功");
                                //}
                                //else
                                //{
                                //    MessageBox.Show("更新 失敗");
                                //}
                            }
                            else
                            {
                                sql = "INSERT INTO [dbo].[OpdEducationTbl]([chSeeDate],[chPNC],[chRoom],[intRegNo],[chMRNo],[chCKD],[chHE])" +
                                                                 "VALUES( @date, @PNC,@Room, @RegNo,@MRNo,@CKD,@HE)";

                                if (dgvReg.Rows[i].Cells["chCKD"].Value != null && (bool)dgvReg.Rows[i].Cells["chCKD"].Value == true)
                                {
                                    cmd.Parameters.Add("@CKD", SqlDbType.VarChar).Value = "Y";
                                }
                                else
                                {
                                    cmd.Parameters.Add("@CKD", SqlDbType.VarChar).Value = "N";
                                }
                                if (dgvReg.Rows[i].Cells["chHE"].Value != null && (bool)dgvReg.Rows[i].Cells["chHE"].Value == true)
                                {
                                    cmd.Parameters.Add("@HE", SqlDbType.VarChar).Value = "Y";
                                }
                                else
                                {
                                    cmd.Parameters.Add("@HE", SqlDbType.VarChar).Value = "N";
                                }
                                cmd.CommandText = sql;

                               
                                //if (cmd.ExecuteNonQuery() > 0)
                                //{
                                //    MessageBox.Show("新增成功");
                                //}
                                //else
                                //{
                                //    MessageBox.Show("新增失敗");
                                //}

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失敗：" + ex.Message);
            }
        }

        private void dgvReg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql= "";
            if (dgvReg.Columns[e.ColumnIndex].Name == "dgvSave" && e.RowIndex <= dgvReg.Rows.Count - 1)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(Class1.ConnectionOPDString))
                    {
                        sql = "select * from [dbo].[OpdEducationTbl] " +
                            "where [chSeeDate] = @date and [chPNC] = @PNC and [chRoom] = @Room and [intRegNo] = @RegNo and [chMRNo] = @MRNo";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = dgvReg.Rows[e.RowIndex].Cells["chDate"].Value.ToString().Trim();
                            cmd.Parameters.Add("@PNC", SqlDbType.VarChar).Value = dgvReg.Rows[e.RowIndex].Cells["chPNC"].Value.ToString().Trim();
                            cmd.Parameters.Add("@Room", SqlDbType.VarChar).Value = dgvReg.Rows[e.RowIndex].Cells["chRoom"].Value.ToString().Trim();
                            cmd.Parameters.Add("@RegNo", SqlDbType.Int).Value = dgvReg.Rows[e.RowIndex].Cells["intRegNo"].Value.ToString().Trim();
                            cmd.Parameters.Add("@MRNo", SqlDbType.VarChar).Value = dgvReg.Rows[e.RowIndex].Cells["chMRNo"].Value.ToString().Trim();
                            con.Open();
                            DataTable dt = new DataTable();
                            dt.Load(cmd.ExecuteReader());
                            if(dt.Rows.Count > 0)
                            {
                                sql = "Update [dbo].[OpdEducationTbl] set chCKD =@CKD , chHE = @HE" +
                                    " where [chSeeDate] = @date and [chPNC] = @PNC and [chRoom] = @Room and [intRegNo] = @RegNo and [chMRNo] = @MRNo";

                                cmd.CommandText = sql;

                                if (dgvReg.Rows[e.RowIndex].Cells["chCKD"].Value != null && (bool)dgvReg.Rows[e.RowIndex].Cells["chCKD"].Value == true)
                                    cmd.Parameters.Add("@CKD", SqlDbType.VarChar).Value = "Y";
                                else
                                    cmd.Parameters.Add("@CKD", SqlDbType.VarChar).Value = "N";

                                if (dgvReg.Rows[e.RowIndex].Cells["chHE"].Value != null && (bool)dgvReg.Rows[e.RowIndex].Cells["chHE"].Value == true)
                                    cmd.Parameters.Add("@HE", SqlDbType.VarChar).Value = "Y";
                                else
                                    cmd.Parameters.Add("@HE", SqlDbType.VarChar).Value = "N";

                                int  i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    MessageBox.Show("更新成功");
                                }
                                else
                                {
                                    MessageBox.Show("更新 失敗");
                                }
                            }
                            else
                            {
                                sql = "INSERT INTO [dbo].[OpdEducationTbl]([chSeeDate],[chPNC],[chRoom],[intRegNo],[chMRNo],[chCKD],[chHE])" +
                                                                 "VALUES( @date, @PNC,@Room, @RegNo,@MRNo,@CKD,@HE)";

                                if(dgvReg.Rows[e.RowIndex].Cells["chCKD"].Value != null && (bool)dgvReg.Rows[e.RowIndex].Cells["chCKD"].Value == true)
                                    cmd.Parameters.Add("@CKD", SqlDbType.VarChar).Value = "Y";
                                else
                                    cmd.Parameters.Add("@CKD", SqlDbType.VarChar).Value = "N";

                                if (dgvReg.Rows[e.RowIndex].Cells["chHE"].Value != null && (bool)dgvReg.Rows[e.RowIndex].Cells["chHE"].Value == true)
                                    cmd.Parameters.Add("@HE", SqlDbType.VarChar).Value = "Y";
                                else
                                    cmd.Parameters.Add("@HE", SqlDbType.VarChar).Value = "N";
                                cmd.CommandText = sql;

                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    MessageBox.Show("新增成功");
                                }
                                else
                                {
                                    MessageBox.Show("新增失敗");
                                }

                            }

                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("更新失敗：" + ex.Message);
                }
            }
        }
    }
}
