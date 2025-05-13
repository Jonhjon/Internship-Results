using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using static System.Net.WebRequestMethods;
using WinAgreeBookManage.Properties;

namespace TEST0205
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DateTime dateTime = DateTime.Now;
            int year = dateTime.Year - 1911;
            int month = dateTime.Month;
            int day = dateTime.Day;
            txtSDate.Text = $"{(year):000}{month - 1:00}{day:00}";
            txtEDate.Text = $"{year:000}{month:00}{day:00}";
        }
        public string E3ConnString = Class1.E3ConnString;

        private void btn_API_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDNo.Text.Trim()!="")
                {
                    ins_Basic ins_obj = new ins_Basic();

                    ins_obj.mrNo = txtIDNo.Text.Trim();
                    ins_obj.birthday = "";
                    string param = JsonConvert.SerializeObject(ins_obj);
                    Rtn_Basic rtn_obj = new Rtn_Basic();
                    rtn_obj = JsonConvert.DeserializeObject<Rtn_Basic>(PostWebAPI("http://10.2.2.84:8080/personal/details", param));

                    if (rtn_obj.statusCode == "1000")
                    {
                        string sMsg = "";

                        sMsg = sMsg + "身分證號：" + rtn_obj.result.mrNo + "\r\n";
                        sMsg = sMsg + "生日：" + rtn_obj.result.birthday + "\r\n";
                        sMsg = sMsg + "地址：" + rtn_obj.result.address + "\r\n";
                        sMsg = sMsg + "電話：" + rtn_obj.result.phone + "\r\n";

                        lblName.Text = "病人姓名 :" + rtn_obj.result.name;
                        lblBirth.Text = "病人生日 :" + rtn_obj.result.birthday;
                        lblAdress.Text = "病人地址 : " + rtn_obj.result.address;
                        lblPhone.Text = "病人電話 : " + rtn_obj.result.phone;
                        //txttemplateId.Focus();
                        //MessageBox.Show(sMsg);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("失敗Error Code：" + rtn_obj.statusCode);
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("請輸入病歷號");
                    txtIDNo.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("btn_API_Click" + ex.Message);
            }

        }

        public string PostWebAPI(string URL, string param)
        {
            try
            {
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                //指定傳輸層安全性協定為TLS 1.2 
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //因為網站註冊的SSl憑證是(cdc.gov.tw)與使用的網址(https://203.65.72.65)不一樣，會有憑證不符合的問題，這段code是為了解決這個問題
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                Task<HttpResponseMessage> response = new HttpClient().PostAsync(URL, contentPost);

                return response.Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PostWebAPI" + ex.Message);
                return "error";

            }

        }
        public class ins_Basic
        {
            public string mrNo { get; set; }
            public string birthday { get; set; }
        }

        public class Rtn_Basic
        {
            public string statusCode { get; set; }
            public Rtn_Basic_Result result { get; set; }
        }

        public class Rtn_Basic_Result
        {
            public string name { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public int tirace { get; set; }
            public string mrNo { get; set; }
            public string birthday { get; set; }
        }

        public void GetCardInfo()
        {
            try
            {
                string cReader;
                //string StrRtn = " ";
                //picNoChk.Visible = false;
                txtIDNo.Text = "";
                //picYesChk.Visible = false;
                //lblPreChk.Text = "插卡後報到";
                //尋找本機讀卡機設備
                using (var oReaders = PCSC.ContextFactory.Instance.Establish(PCSC.SCardScope.User))
                {
                    cReader = oReaders.GetReaders().FirstOrDefault();
                }
                //string strName = "";
                //string strMRNo = "";
                //string strBirthday = "";
                //string strGender = "";
                using (var oContext = PCSC.ContextFactory.Instance.Establish(PCSC.SCardScope.User))
                using (var oReader = new PCSC.Iso7816.IsoReader(
                  context: oContext,
                  readerName: cReader,
                  mode: PCSC.SCardShareMode.Shared,
                  protocol: PCSC.SCardProtocol.Any
                ))
                {
                    //lblPreChk.Text = "正在讀取健保卡！";
                    Application.DoEvents();
                    Thread.Sleep(200);
                    //初始化健保卡
                    var oAdpuInit = new PCSC.Iso7816.CommandApdu(PCSC.Iso7816.IsoCase.Case4Short, oReader.ActiveProtocol)
                    {
                        CLA = 0x00,
                        INS = 0xA4,
                        P1 = 0x04,
                        P2 = 0x00,
                        Data = new byte[] { 0xD1, 0x58, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x11 }
                    };
                    //取得初始化健保卡回應
                    var oAdpuInitResponse = oReader.Transmit(oAdpuInit);
                    //讀取健保顯性資訊
                    var oAdpuProfile = new PCSC.Iso7816.CommandApdu(PCSC.Iso7816.IsoCase.Case4Short, oReader.ActiveProtocol)
                    {
                        CLA = 0x00,
                        INS = 0xCA,
                        P1 = 0x11,
                        P2 = 0x00,
                        Data = new byte[] { 0x00, 0x00 }
                    };
                    //取得讀取健保卡顯性資訊回應
                    var oAdpuProfileResponse = oReader.Transmit(oAdpuProfile);
                    //檢查回應是否正確（144；00）
                    //如果有回應且具備資料的話，就將其輸出到畫面上
                    if (oAdpuProfileResponse.HasData)
                    { //播放提示音
                      //Console.Beep();
                      //位元組資料
                        byte[] aryData = oAdpuProfileResponse.GetData();
                        //文字編碼解碼器
                        var oUTF8 = System.Text.Encoding.UTF8;
                        var oBIG5 = System.Text.Encoding.GetEncoding("big5");
                        //建立使用者匿名物件
                        var oUser = new
                        {
                            cName = oBIG5.GetString(aryData.Skip(12).Take(20).ToArray()),
                            cID = oUTF8.GetString(aryData.Skip(32).Take(10).ToArray()),
                            cBirthday = oUTF8.GetString(aryData.Skip(42).Take(7).ToArray()),
                            cGender = oUTF8.GetString(aryData.Skip(49).Take(1).ToArray()) == "M" ? "男" : "女",
                        };
                        //strName = oUser.cName;
                        //strMRNo = oUser.cID;
                        //strBirthday = oUser.cBirthday;
                        //strGender = oUser.cGender;

                        lblName.Text = "病人姓名：" + oUser.cName;
                        lblBirth.Text = "病人生日 : "+oUser.cBirthday;
                        //if (strMRNo == lblLastID.Text)
                        //{

                        //    lblPreChk.Text = "該卡已重複插入，請拔出健保卡！";
                        //    Application.DoEvents();
                        //    Thread.Sleep(200);
                        //    return;//若當前健保卡身份證字號與上一張健保卡身份證字號相同，則不做資料庫寫入
                        //}
                        //lblCardName.Text = strName;
                        //lblCardBirthDay.Text = strBirthday;
                        //lblSex.Text = strGender;
                        //lblLastID.Text = strMRNo;
                        //lblCardIDNo.Text = strMRNo;
                        txtIDNo.Text = oUser.cID;
                        txtIDNo_Leave(null, null);
                        //lblPreChk.Text = "請拔出健保卡！";
                        Application.DoEvents();
                        Thread.Sleep(200);
                        return;
                    }
                }
            }
            catch
            {
                txtIDNo.Focus();
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
       
        private void btnGetCard_Click(object sender, EventArgs e)
        {
            GetCardInfo();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void templateId_Leave(object sender, EventArgs e)
        {
            if (txttemplateId.Text.Trim() == "") { MessageBox.Show("表單編號輸入不得為空"); return; }
            try
            {
                using (SqlConnection conn = new SqlConnection(E3ConnString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT chMrNo ,a.chTemplateID ,b.chTemplateName,chJobID , chDocID , chIfComplete,chPDFToEMR  ,[chCDate]" +
                        "FROM [DB_THINK].[dbo].[ThinkCreateJobReturnTbl] a inner join [DB_THINK].[dbo].ThinkTemplateTbl b  on a.chTemplateID = b.chTemplateID " +
                        "where chSeeDate >= @StartDate and chSeeDate <=@EndState  and chResult ='true'", conn))
                    {
                        da.SelectCommand.Parameters.Add("@ID", SqlDbType.Char).Value = txttemplateId.Text.Trim();
                        da.SelectCommand.Parameters.Add("@StartDate", SqlDbType.Char).Value = txtSDate.Text.Trim();
                        da.SelectCommand.Parameters.Add("@EndState", SqlDbType.Char).Value = txtEDate.Text.Trim();
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        //"chTemplateID LIKE '%" + txttemplateId.Text.Trim() + "%'";
                        DataRow[] row = dt.Select("chTemplateID LIKE '%" + txttemplateId.Text.Trim() + "%' and" + "[chMrNo] = '"+txtIDNo.Text.Trim()+"'");
                        DgvForm.Rows.Clear();
                        foreach (var item in row)
                        {
                            DgvForm.Rows.Add(item["chMrNo"], item["chTemplateID"], item["chTemplateName"], item["chJobID"], item["chDocID"], item["chIfComplete"], item["chPDFToEMR"], item["chCDate"], "調閱");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtIDNo_Leave(object sender, EventArgs e)
        {
        //    if (txtIDNo.Text.Trim() == "") { MessageBox.Show("病人ID輸入不得為空"); return; }
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(E3ConnString))
        //        {
        //            using (SqlDataAdapter da = new SqlDataAdapter("SELECT chMrNo ,a.chTemplateID ,b.chTemplateName,chJobID , chDocID , chIfComplete,chPDFToEMR  " +
        //                "FROM [DB_THINK].[dbo].[ThinkCreateJobReturnTbl] a inner join [DB_THINK].[dbo].ThinkTemplateTbl b  on a.chTemplateID = b.chTemplateID " +
        //                "where chSeeDate >= @StartDate and chSeeDate <=@EndState and chResult ='true' ", conn))
        //            {
        //                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Char).Value = txtIDNo.Text.Trim();
        //                da.SelectCommand.Parameters.Add("@StartDate", SqlDbType.Char).Value = txtSDate.Text.Trim();
        //                da.SelectCommand.Parameters.Add("@EndState", SqlDbType.Char).Value = txtEDate.Text.Trim();
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                //"chTemplateID LIKE '%" + txttemplateId.Text.Trim() + "%' and " +
        //                string select =  "[chMrNo] = '" + txtIDNo.Text.Trim() + "'";
        //                DataRow[] row = dt.Select(select);
        //                DgvForm.Rows.Clear();
        //                foreach (var item in row)
        //                {
        //                    DgvForm.Rows.Add(item["chMrNo"], item["chTemplateID"], item["chTemplateName"], item["chJobID"]  ,item["chDocID"], item["chIfComplete"], item["chPDFToEMR"], "調閱");
        //                }
                        btn_API_Click(sender, e);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        }

        private void btnNoSign_Click(object sender, EventArgs e)
        {
            if (txtIDNo.Text.Trim() == "" && txttemplateId.Text.Trim() == "")
            {
                MessageBox.Show("病人ID跟表單編號至少要輸入一個\n");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(E3ConnString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT chMrNo ,a.chTemplateID ,b.chTemplateName,chJobID , chDocID , chIfComplete,chPDFToEMR  ,[chCDate]" +
                        "FROM [DB_THINK].[dbo].[ThinkCreateJobReturnTbl] a inner join [DB_THINK].[dbo].ThinkTemplateTbl b  on a.chTemplateID = b.chTemplateID " +
                        "where chSeeDate >= @StartDate and chSeeDate <=@EndState  and chResult ='true' and chMrNo = @ID and a.chTemplateID LIKE '%' + @template + '%'", conn))
                    {
                        da.SelectCommand.Parameters.Add("@ID", SqlDbType.Char).Value = txtIDNo.Text.Trim();
                        da.SelectCommand.Parameters.Add("@template",SqlDbType.Char).Value = txttemplateId.Text.Trim();
                        da.SelectCommand.Parameters.Add("@StartDate",SqlDbType.Char).Value = txtSDate.Text.Trim();
                        da.SelectCommand.Parameters.Add("@EndState",SqlDbType.Char).Value = txtEDate.Text.Trim();
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        //"chTemplateID LIKE '%" + txttemplateId.Text.Trim() + "%'";
                        DataRow[] row = dt.Select("chIfComplete is NULL ");
                        DgvForm.Rows.Clear();
                        foreach (var item in row)
                        {
                            DgvForm.Rows.Add(item["chMrNo"], item["chTemplateID"], item["chTemplateName"], item["chJobID"], item["chDocID"], item["chIfComplete"], item["chPDFToEMR"], item["chCDate"] ,"調閱");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnIsSign_Click(object sender, EventArgs e)
        {
            if (txtIDNo.Text.Trim() == "" && txttemplateId.Text.Trim() == "")
            {
                MessageBox.Show("病人ID跟表單編號至少要輸入一個\n");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(E3ConnString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT chMrNo ,a.chTemplateID ,b.chTemplateName,chJobID , chDocID , chIfComplete,chPDFToEMR ,[chCDate] " +
                        "FROM [DB_THINK].[dbo].[ThinkCreateJobReturnTbl] a inner join [DB_THINK].[dbo].ThinkTemplateTbl b  on a.chTemplateID = b.chTemplateID " +
                        "where chSeeDate >= @StartDate and chSeeDate <=@EndState  and chResult ='true' and chMrNo = @ID and a.chTemplateID LIKE '%' + @template + '%'", conn))
                    {
                        da.SelectCommand.Parameters.Add("@ID", SqlDbType.Char).Value = txtIDNo.Text.Trim();
                        da.SelectCommand.Parameters.Add("@template", SqlDbType.Char).Value = txttemplateId.Text.Trim();
                        da.SelectCommand.Parameters.Add("@StartDate", SqlDbType.Char).Value = txtSDate.Text.Trim();
                        da.SelectCommand.Parameters.Add("@EndState", SqlDbType.Char).Value = txtEDate.Text.Trim();
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DataRow[] row = dt.Select("chIfComplete = 'Y' ");
                        DgvForm.Rows.Clear();
                        foreach (var item in row)
                        {
                            DgvForm.Rows.Add(item["chMrNo"], item["chTemplateID"], item["chTemplateName"], item["chJobID"], item["chDocID"], item["chIfComplete"], item["chPDFToEMR"], item["chCDate"] ,"調閱");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIDNo.Text = "";
            txttemplateId.Text = "";
            DgvForm.Rows.Clear();
            lblName.Text = "病人姓名 :";
            lblBirth.Text = "病人生日 :";
            lblAdress.Text = "病人地址 :";
            lblPhone.Text = "病人電話 :";
            txtEDate.Text = "";
            txtSDate.Text = "";
        }

        private void DgvForm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= DgvForm.Rows.Count -1  && DgvForm.Columns[e.ColumnIndex].Name == "Search") {
                MessageBox.Show("表單點擊錯誤\n"); return; 
            }
            else
            {
                //本機端路徑
                string p_2 = @"C:\tch\exe\ThinkCloud\ThinkCloud.exe";
                //傳入參數
                string @chCDate = DgvForm.Rows[e.RowIndex].Cells[7].Value.ToString();
                string OutString = txtIDNo.Text.Trim() + ",,,,,,,," + txttemplateId.Text.Trim() + "@"+@chCDate + "," + "GetSignDocUrl";
                //範例：
                //string OutString = "U120460957,,,,,,,,E7C1252007@1130923110010573,GetSignDocUrl";
                //這裡不用比對這隻EXE版本 已經放在登入 或著重開機時會自動更新
                Process.Start(p_2, OutString);//執行
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void txtEDate_TextChanged(object sender, EventArgs e)
        {

        }
        private bool CompareFile(string sPath1, string sPath2)
        {
            if (!System.IO.File.Exists(sPath1) || !System.IO.File.Exists(sPath2))
            {
                return false;
            }
            if (!(System.IO.File.GetLastWriteTime(sPath1) == System.IO.File.GetLastWriteTime(sPath2)))
            {
                return false;
            }
            return true;
        }
        private void btnSearchForm_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            int year = dateTime.Year - 1911;
            int month = dateTime.Month;
            int day = dateTime.Day;
            //主機端路經
            string p_1 = @"\\hissvr\tchexe$\exe\AdmORSchPk.exe";
            //本機端路徑
            string p_2 = @"C:\tch\exe\AdmORSchPk.exe";
            //傳入參數
            string OutString = txttemplateId.Text + "," + txtIDNo.Text + "," + $"{(year):000}{month:00}{day:00}" + "," + "AD" + "," + "TEST";

            if (!CompareFile(p_1, p_2)) //如果不相同更新
            {
                //System.IO.File.Copy(p_1, p_2, true);//Copy過去 如已存在，覆蓋
            }
            try {
                Process.Start(p_2, OutString);//執行
            }catch(Exception ex)
            {
                MessageBox.Show("無法啟動應用程式: " + ex.Message);
            }
        }
    }
}
