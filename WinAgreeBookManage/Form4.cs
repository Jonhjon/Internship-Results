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
using Microsoft.VisualBasic;
using WinAgreeBookManage.Properties;


namespace TEST0205
{

    public partial class Form4 : Form
    {
        // Update the declaration of E3ConnString to correctly reference the static field in Class1.  
        public string E3ConnString = Class1.E3ConnString;
        private bool IDCheck = false;
        public Form4()
        {
            InitializeComponent();
            cmbType.Text = "--Select--";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTrue.Checked)
            {
                chbFalse.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFalse.Checked)
            {
                chbTrue.Checked = false;
            }
        }

        private DataTable TxtIdCheck()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(E3ConnString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from ThinkTemplateTbl WHERE chTemplateID = @ID", connection))
                {
                    try
                    {
                        adapter.SelectCommand.Parameters.Add("@ID", SqlDbType.Char).Value = txtTemplateId.Text.Trim();
                        adapter.Fill(ds, "ThinkTemplateTbl");

                        adapter.SelectCommand.CommandText = "SELECT * from [ThinkTemplateControlTbl] WHERE chTemplateID = @ID";
                        adapter.Fill(ds, "[ThinkTemplateControlTbl]");

                        Dgvform.Rows.Clear();
                        dt = ds.Tables["ThinkTemplateTbl"];
                        if (dt.Rows.Count > 0)
                        {
                            dt = ds.Tables["[ThinkTemplateControlTbl]"];
                            foreach (DataRow dataRow in dt.Rows)
                            {
                                Dgvform.Rows.Add("選取", dataRow["chTemplateID"], dataRow["chType"], dataRow["chItem"], dataRow["chStat"]);
                            }
                            if (txtTemplateId.Text == "")
                            {
                                Dgvform.Visible = false;
                            }
                            Dgvform.Visible = true;
                            IDCheck = true;
                            return dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            return dt;
        }
        private void txtTemplateId_Leave(object sender, EventArgs e)
        {
           DgvRefer.Visible =  false;
            if (TxtIdCheck() == null) {
                MessageBox.Show("查無範例\n");
                //btnClear_Click(sender, e);
                txtTemplateId.Text = "";
                txtTemplateId.Focus();
                Dgvform.Visible = false;
            }
            //return dt;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
            this.Dispose();
            this.Close();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtItem.Text = "";
            cmbType.SelectedItem = "--Select--";
            txtTemplateId.Text = "";
            chbTrue.Checked = false;
            chbFalse.Checked = false;
            Dgvform.Rows.Clear();
            Dgvform.Visible = false;
            DgvRefer.Visible = false;
            txtTemplateId.Focus();
        }

        private void btnAddControl_Click(object sender, EventArgs e)
        {
            if ((txtTemplateId.Text == "" || txtItem.Text == "" || cmbType.SelectedItem.ToString() == "--Select--") || (chbFalse.Checked == false && chbTrue.Checked == false))
            {
                MessageBox.Show("資料無填寫完整\n");
                btnClear_Click(sender, e);
                return;
            }
            try
            {
                if (!IDCheck)
                {
                    MessageBox.Show("沒有此表單\n");
                    return;
                }
                using (SqlConnection conn = new SqlConnection(E3ConnString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter("Select * from [ThinkTemplateControlTbl] where [chTemplateID] = @Id AND [chType] = @Type AND [chItem] = @Item", conn))
                    {
                        adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Char).Value = txtTemplateId.Text.Trim();
                        adapter.SelectCommand.Parameters.Add("@Type", SqlDbType.Char).Value = cmbType.SelectedItem.ToString().Trim();
                        adapter.SelectCommand.Parameters.Add("@Item", SqlDbType.Char).Value = txtItem.Text.Trim();
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("已有此項目\n");
                            btnClear_Click(sender, e);
                            return;
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr["chTemplateID"] = txtTemplateId.Text.Trim();
                            dr["chType"] = cmbType.SelectedItem.ToString();
                            dr["chItem"] = txtItem.Text.Trim();
                            dr["chStat"] = chbTrue.Checked ? "1" : "0";

                            dt.Rows.Add(dr);
                            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                            adapter.Update(dt);

                            //string sqlstr = "chTemplateID = '" + txtTemplateId.Text.Trim() + "' AND chType = '" + txtType.Text.Trim() + "' AND chItem = '" + txtItem.Text.Trim() + "'";
                            string sqlstr = "chTemplateID = '" + txtTemplateId.Text.Trim() + "'";
                            //dt.Select(sqlstr);

                            using (SqlDataAdapter da2 = new SqlDataAdapter("Select * from [ThinkTemplateControlTbl] where [chTemplateID] = @Id", conn))
                            {
                                da2.SelectCommand.Parameters.Add("@Id", SqlDbType.Char).Value = txtTemplateId.Text.Trim();
                                da2.Fill(dt);
                                DataRow[] rows = dt.Select();
                                if (rows.Length >= 1)
                                {
                                    Dgvform.Rows.Clear();
                                    foreach (DataRow dataRow in rows)
                                    {
                                        Dgvform.Rows.Add("選取", dataRow["chTemplateID"], dataRow["chType"], dataRow["chItem"], dataRow["chStat"]);
                                    }
                                    Dgvform.Visible = true;
                                    txtItem.Text = "";
                                    cmbType.Text = "--Select--";
                                    chbFalse.Checked = false;
                                    chbTrue.Checked = false;
                                    MessageBox.Show("新增成功");
                                    //return;
                                }
                                else
                                {
                                    MessageBox.Show("新增失敗");
                                }
                                return;
                            }
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
            if (!IDCheck || ((txtTemplateId.Text == "" || txtItem.Text == "" || cmbType.SelectedItem.ToString() == "") && (chbFalse.Checked == false && chbTrue.Checked == false)))
            {
                MessageBox.Show("無此範本或是資料無填寫完整\n");
                btnClear_Click(sender, e);
                return;
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(E3ConnString))
                    {
                        connection.Open();
                        string sqlstr = "Update [ThinkTemplateControlTbl] set chStat = @Stat Where chTemplateID = @ID AND chType = @Type AND chItem = @Item";
                        using (SqlCommand cmd = new SqlCommand(sqlstr, connection))
                        {
                            cmd.Parameters.Add("@Stat", SqlDbType.Char).Value = chbTrue.Checked ? "1" : "0";
                            cmd.Parameters.Add("@ID", SqlDbType.Char).Value = txtTemplateId.Text.Trim();
                            cmd.Parameters.Add("@Type", SqlDbType.Char).Value = cmbType.SelectedItem.ToString();
                            cmd.Parameters.Add("@Item", SqlDbType.Char).Value = txtItem.Text.Trim();
                            int  check = cmd.ExecuteNonQuery();
                            //connection.Close();
                            if(check == 1)
                                MessageBox.Show("更新成功");
                            else
                                MessageBox.Show("更新失敗");
                            //btnClear_Click(sender, e);
                            txtItem.Text = "";
                            cmbType.Text = "--Select--";
                            chbFalse.Checked = false;
                            chbTrue.Checked = false;
                        }

                        sqlstr = "Select * from [ThinkTemplateControlTbl] Where chTemplateID = @ID";
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlstr, connection))
                        {
                            adapter.SelectCommand.Parameters.Add("@ID", SqlDbType.Char).Value = txtTemplateId.Text.Trim();
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            Dgvform.Rows.Clear();
                            foreach (DataRow dataRow in dt.Rows)
                            {
                                Dgvform.Rows.Add("選取", dataRow["chTemplateID"], dataRow["chType"], dataRow["chItem"], dataRow["chStat"]);
                            }
                            Dgvform.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Dgvform_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgvform.Columns[e.ColumnIndex].Name == "Select" && e.RowIndex < Dgvform.Rows.Count - 1)
            {
                txtTemplateId.Text = Dgvform.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbType.Text = "--Select--";
                foreach (var item in cmbType.Items)
                {
                    if (Dgvform.Rows[e.RowIndex].Cells[2].Value.ToString() == item.ToString())
                    {
                        cmbType.SelectedItem = Dgvform.Rows[e.RowIndex].Cells[2].Value.ToString();
                        break;
                    }
                }

                txtItem.Text = Dgvform.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (Dgvform.Rows[e.RowIndex].Cells[4].Value.ToString() == "1")
                {
                    chbTrue.Checked = true;
                    chbFalse.Checked = false;
                }
                else
                {
                    chbTrue.Checked = false;
                    chbFalse.Checked = true;
                }
            }
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(E3ConnString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter("Select * from ThinkTemplateTbl where chTemplateID LIKE "+"'%"+txtTemplateId.Text.Trim()+"'", connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        DgvRefer.Rows.Clear();
                        foreach (DataRow dataRow in dt.Rows)
                        {
                            DgvRefer.Rows.Add("選取", dataRow["chTemplateID"], dataRow["chTemplateName"]);
                        }
                    }
                }
                DgvRefer.Visible = true;
                Dgvform.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DgvRefer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Dgvform.Visible = false;

            if (DgvRefer.Columns[e.ColumnIndex].Name == "select_refer" && e.RowIndex <= DgvRefer.Rows.Count - 1)
            {
                try
                {
                    string str = Interaction.InputBox("請輸入還未有控制項的表單編號", "輸入", "", -1, -1);

                    using (SqlConnection conn = new SqlConnection(E3ConnString))
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter("select * from ThinkTemplateTbl", conn))
                        {
                            DataTable dt_Control = new DataTable();
                            DataTable dt_template = new DataTable();
                            DataSet ds = new DataSet();
                            da.Fill(ds, "ThinkTemplateTbl");

                            da.SelectCommand = new SqlCommand("select * from ThinkTemplateControlTbl", conn);
                            da.Fill(ds, "ThinkTemplateControlTbl");

                            if (ds.Tables.Contains("ThinkTemplateTbl"))
                            {
                                dt_template = ds.Tables["ThinkTemplateTbl"];
                                DataRow[] Rows = dt_template.Select("[chTemplateID] = '" + str + "'");
                                if (Rows.Length == 0)
                                {
                                    MessageBox.Show("此編號還未在同意書範本資料庫中登記\n");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("ThinkTemplateTbl 表不存在\n");
                                return;
                            }
                            //DialogResult result;
                            if (ds.Tables.Contains("ThinkTemplateControlTbl"))
                            {
                                dt_Control = ds.Tables["ThinkTemplateControlTbl"];
                                DataRow[] Rows = dt_Control.Select("chTemplateID = '" + str + "'");
                                if (Rows.Length != 0)
                                {
                                    //MessageBox.Show("此編號已經有控制項了，\n請使用 修改控制項\r\n或是 新增控制項\n");
                                    //btnClear_Click(sender, e);
                                    //Dgvform.Rows.Clear();
                                    //foreach (DataRow dataRow in Rows)
                                    //{
                                    //    Dgvform.Rows.Add("選取", dataRow["chTemplateID"], dataRow["chType"], dataRow["chItem"], dataRow["chStat"]);
                                    //}
                                    //Dgvform.Visible = true;
                                    //return;

                                    DialogResult result = MessageBox.Show("此編號已經有控制項了，\n是否要覆蓋控制項", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (result == DialogResult.Yes)
                                    {
                                        SqlCommand com = new SqlCommand("DELETE FROM ThinkTemplateControlTbl WHERE chTemplateID = @ID",conn);
                                        com.Parameters.Add("@ID",SqlDbType.Char).Value = str;
                                        com.ExecuteNonQuery();
                                    }
                                    else if(result ==DialogResult.No)
                                    {
                                        return;
                                    }
                                }
                            }

                            DataRow[] select_rows = dt_Control.Select("chTemplateID = '" + DgvRefer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                            foreach (DataRow dataRow in select_rows)
                            {
                                DataRow Insertrow = dt_Control.NewRow();
                                Insertrow["chTemplateID"] = str;
                                Insertrow["chType"] = dataRow["chType"];
                                Insertrow["chItem"] = dataRow["chItem"];
                                Insertrow["chStat"] = dataRow["chStat"];
                                dt_Control.Rows.Add(Insertrow);
                            }
                          
                            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
                            da.Update(dt_Control);

                            txtTemplateId.Text = str;

                            if (TxtIdCheck() == null)
                            {
                                MessageBox.Show("新增失敗\n");
                                return;
                            }
                            else
                            {
                                DgvRefer.Visible = false;
                                MessageBox.Show("新增成功\n");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    
    }
}
