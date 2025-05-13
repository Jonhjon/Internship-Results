using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAgreeBookManage.Properties;

namespace TEST0205
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string E3ConnString = Class1.E3ConnString;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private DataTable ID_Check(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(E3ConnString))
                {
                    connection.Open();
                    if (connection.State != ConnectionState.Open) { MessageBox.Show("資料庫連線失敗"); return dt; }
                    SqlCommand cmd = new SqlCommand("SELECT * from ThinkTemplateTbl WHERE chTemplateID = @ID", connection);
                    cmd.Parameters.Add("@ID", SqlDbType.Char).Value = txtID.Text.Trim();
                    dt.Reset();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dt;
            }
        }
        private void txtID_Leave(object sender, EventArgs e)
        {
            DataTable dt =  ID_Check(txtID.Text.Trim());
            if (dt.Rows.Count == 0) { return; }
            txtName.Text = dt.Rows[0]["chTemplateName"].ToString().Trim();
            txtVer.Text = dt.Rows[0]["chTemplateVer"].ToString().Trim();
            if (dt.Rows[0]["chStat"].ToString().Trim() == "1")
            {
                chbTrue.Checked = true;
            }
            else if (dt.Rows[0]["chStat"].ToString().Trim() == "0")
            {
                chbFalse.Checked = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ID_Check(txtID.Text.Trim())==null) { 
                MessageBox.Show("範本已存在\n");
                txtID.Text = "";
                txtName.Text = "";
                txtVer.Text = "";
                chbTrue.Checked = false;
                chbFalse.Checked = false;
                txtID.Focus();
                return; 
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(E3ConnString))
                {
                    string strSql = "Select * from ThinkTemplateTbl Where 1=2";
                    using (SqlDataAdapter dtAdpt = new SqlDataAdapter(strSql, connection))
                    {
                        DataTable dt = new DataTable();
                        dtAdpt.Fill(dt);
                        DataRow dataRow = dt.NewRow();

                        dataRow["chTemplateID"] = txtID.Text.Trim();
                        dataRow["chTemplateName"] = txtName.Text.Trim();
                        dataRow["chTemplateVer"] = txtVer.Text.Trim();
                        if (chbTrue.Checked == true)
                        {
                            dataRow["chStat"] = "1";
                        }
                        else if (chbFalse.Checked == true)
                        {
                            dataRow["chStat"] = "0";
                        }

                        dt.Rows.Add(dataRow);
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dtAdpt);
                        dtAdpt.Update(dt);


                        DataRow[] Row = dt.Select("chTemplateID = '" + txtID.Text.Trim()+"'");
                        DgvForm.Rows.Add(Row[0]["chTemplateID"], Row[0]["chTemplateName"], Row[0]["chTemplateVer"], Row[0]["chStat"]);
                        DgvForm.Visible = true;
                        label6.Visible = true;
                        // DgvForm.
                        if (Row.Length ==1)
                        {
                            MessageBox.Show("建立成功\n");
                        }
                        else
                        {
                            MessageBox.Show("新增錯誤\n");

                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(ID_Check(txtID.Text.Trim()) == null){
                MessageBox.Show("查無此範本\n");
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(E3ConnString))
                {
                    string Id = txtID.Text.Trim();
                    string Name = txtName.Text.Trim();
                    string Ver = txtVer.Text.Trim();
                    connection.Open();
                    string strSql = "UPDATE ThinkTemplateTbl SET chTemplateName = @Name , chTemplateVer = @Ver , chStat = @Stat WHERE chTemplateID = @ID";
                    using (SqlCommand cmd = new SqlCommand(strSql, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", Id);

                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Ver", Ver);
                        if (chbTrue.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Stat", SqlDbType.Char).Value = chbTrue.Checked ? "1" : "0";
                        }
                        else if (chbFalse.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Stat", SqlDbType.Char).Value = chbFalse.Checked ? "0" : "1";
                        }
                        cmd.ExecuteNonQuery();
                    }
                    DgvForm.Rows.Clear();
                    strSql = "Select * from ThinkTemplateTbl Where chTemplateID = @ID";
                    using (SqlDataAdapter dtAdpt = new SqlDataAdapter(strSql, connection))
                    {
                        DataTable dt = new DataTable();
                        dtAdpt.SelectCommand.Parameters.Add("@ID", SqlDbType.Char).Value = txtID.Text.Trim();
                        dtAdpt.Fill(dt);
                        DataRow dataRow = dt.Rows[0];
                        DgvForm.Rows.Add(dataRow["chTemplateID"], dataRow["chTemplateName"], dataRow["chTemplateVer"], dataRow["chStat"]);
                        DgvForm.Visible = true;
                        label6.Visible = true;
                        //MessageBox.Show("更新成功\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtVer.Text = "";
            chbTrue.Checked = false;
            chbFalse.Checked = false;
            DgvForm.Rows.Clear();
            DgvForm.Visible = false;
            label6.Visible = false;
        }

        private void chbTrue_CheckedChanged(object sender, EventArgs e)
        {
            if(chbTrue.Checked)
            {
                chbFalse.Checked = false;
            }
        }

        private void chbFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFalse.Checked)
            {
                chbTrue.Checked = false;
            }
        }

        private void DgvForm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
