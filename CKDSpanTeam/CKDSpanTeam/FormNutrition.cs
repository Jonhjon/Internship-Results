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

namespace CKDSpanTeam
{
    public partial class FormNutrition : Form
    {
        public FormNutrition()
        {
            InitializeComponent();
        }


        private void FormNutrition_Load(object sender, EventArgs e)
        {
            txtEnergy.Text = "";
            txtProtein.Text = "";
            Program.sChooes = "";
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                string OutString = "";
                if (txtEnergy.Text != "")
                {
                    Program.sChooes = Program.sChooes + txtEnergy.Tag.ToString().Trim() + "-" + txtEnergy.Text.ToString().Trim() + " Kcal/day" + "\r\n";
                }
                if (txtProtein.Text != "")
                {
                    Program.sChooes = Program.sChooes + txtProtein.Tag.ToString().Trim() + "-" + txtProtein.Text.ToString().Trim() + " G/Day" + "\r\n";
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
                                    Program.sChooes = Program.sChooes + ck.Tag.ToString().Trim().Substring(0, ck.Tag.ToString().IndexOf("-")) + "-" + ck.Text.ToString().Trim() + "\r\n";
                                    OutString = OutString + ck.Tag.ToString().Trim().Substring(ck.Tag.ToString().IndexOf("-") + 1) + ",";
                                }
                            }
                        }

                    }
                }

                //飲食計畫
                foreach (Control cl in this.Controls)//迴圈Form上的控制元件
                {
                    if (cl is GroupBox)//看看是不是GroupBox
                    {
                        GroupBox GB = cl as GroupBox;//將找到的control轉化成GroupBox
                        foreach (Control ctl in GB.Controls)//迴圈GroupBox上的控制元件
                        {
                            if (ctl is ComboBox)//看看是不是ComboBox
                            {
                                ComboBox cbo = ctl as ComboBox;//將找到的control轉化成ComboBox
                                if (cbo.SelectedIndex != -1)//判斷是否有選
                                {
                                    Program.sChooes = Program.sChooes + cbo.Tag.ToString().Trim() + "-" + cbo.Text.ToString().Trim() + "\r\n";
                                }
                            }
                        }

                    }
                }

                DataTable dt = new DataTable();
                FormMain frmMain = new FormMain();
                using (SqlConnection con = new SqlConnection(Class1.ConnectionOPDString))
                {
                    string sSQL = @"select* from OpdRegDiagnosisTbl a(nolock) left join DB_GEN..GenDoctorTbl b (nolock) on a.chDocNo = b.chDocNo
                    Where chDate ='" + Program.sSeeDate + "' and chPNC = '" + Program.sPNC + "' " +
                   "and chRoom ='" + Program.sRoom + "' and intRegNo = '" + Program.intRegNo + "' ";
                    using (SqlCommand cmd = new SqlCommand(sSQL, con))
                    {
                        dt.Reset();
                        con.Open();
                        dt.Load(cmd.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            //OutString_1 = 表單號,病歷號,日期,D,醫師ID,醫師姓名
                            string OutString_1 = "E6N1622218," + dt.Rows[0]["chMRNo"].ToString().Trim().ToString() + "," + dt.Rows[0]["chDate"].ToString().Trim().ToString() + ",D,"
                                + frmMain.ArasID + "," + frmMain.ArasName + "," + dt.Rows[0]["chDocName"].ToString().Trim() + "";
                            //Program.sSeeDate
                            //File.Copy(@"\\HISSVR\TCHEXE$\EXE\CallCloudThink.exe", @"C:\tch\exe\CallCloudThink.exe", true);
                            //Process.Start("C:\\tch\\exe\\CallCloudThink.exe", OutString_1 + "," + OutString.Substring(OutString.ToString().Length - 1));
                        }
                    }
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
