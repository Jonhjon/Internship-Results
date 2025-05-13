using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAgreeBookManage.Properties;

namespace TEST0205
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string E3ConnString = Class1.E3ConnString;

        private DataTable ID_Check()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(E3ConnString))
                {
                    connection.Open();
                    if (connection.State != ConnectionState.Open) { MessageBox.Show("資料庫連線失敗"); return dt; }
                    SqlCommand cmd = new SqlCommand("SELECT * from [ThinkOrdFormTbl] WHERE [chOrdNo] = @ID OR chTemplateID = @Template", connection);
                    cmd.Parameters.Add("@ID", SqlDbType.Char).Value = txtOrNo.Text.Trim();
                    cmd.Parameters.Add("@Template", SqlDbType.Char).Value = txtTamplateId.Text.Trim();
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
        private void txtOrNo_Leave(object sender, EventArgs e)
        {
            DataTable dt = ID_Check();
            if (dt.Rows.Count > 0)
            {
                txtTamplateId.Text = dt.Rows[0]["chTemplateID"].ToString().Trim();
                txtOrNo.Text = dt.Rows[0]["chOrdNo"].ToString().Trim();
                if (dt.Rows[0]["chStat"].ToString().Trim() == "1")
                {
                    chbTrue.Checked = true;
                }
                else if (dt.Rows[0]["chStat"].ToString().Trim() == "0")
                {
                    chbFalse.Checked = true;
                }
                Dgvform3.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    Dgvform3.Rows.Add(dr["chOrdNo"].ToString().Trim(), dr["chTemplateID"].ToString().Trim(), dr["chStat"].ToString().Trim());
                }
                plform.Visible = true;
                return;
            }
            return;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = ID_Check();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("表單編號已存在");
                txtOrNo.Text = "";
                txtTamplateId.Text = "";
                chbTrue.Checked = false;
                chbFalse.Checked = false;
                plform.Visible = false;
                txtOrNo.Focus();
                return;
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(E3ConnString))
                    {
                        connection.Open();
                        if (connection.State != ConnectionState.Open) { MessageBox.Show("資料庫連線失敗"); return; }
                        using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from [ThinkOrdFormTbl] WHERE 1=2", connection))
                        {
                            adapter.Fill(dt);
                            DataRow dr = dt.NewRow();
                            dr["chOrdNo"] = txtOrNo.Text.Trim();
                            dr["chTemplateID"] = txtTamplateId.Text.Trim();
                            if (chbTrue.Checked == true)
                            {
                                dr["chStat"] = "1";
                            }
                            else if (chbFalse.Checked == true)
                            {
                                dr["chStat"] = "0";
                            }

                            dt.Rows.Add(dr);
                            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                            adapter.Update(dt);

                            string sqlstr = "chOrdNo = '" + txtOrNo.Text.Trim() + "'";

                            DataRow[] row = dt.Select(sqlstr);
                            if (dt.Rows.Count == 1)
                            {
                                Dgvform3.Rows.Add(row[0]["chOrdNo"].ToString().Trim(), row[0]["chTemplateID"].ToString().Trim(), row[0]["chStat"].ToString().Trim());
                                plform.Visible = true;
                                MessageBox.Show("新增成功");
                            }
                            else
                            {
                                MessageBox.Show("新增失敗");

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOrNo.Text = "";
            txtTamplateId.Text = "";
            chbTrue.Checked = false;
            chbFalse.Checked = false;
            plform.Visible = false;
            Dgvform3.Rows.Clear();
            txtOrNo.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ID_Check() == null)
            {
                MessageBox.Show("無此範本\n"); return;
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(E3ConnString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Update [ThinkOrdFormTbl] set chStat = @Stat Where chOrdNo = @No AND chTemplateID = @ID", conn);
                        cmd.Parameters.AddWithValue("@Stat", SqlDbType.VarChar).Value = chbTrue.Checked ? "1" : "0";
                        cmd.Parameters.AddWithValue("@No", SqlDbType.VarChar).Value = txtOrNo.Text.Trim();
                        cmd.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = txtTamplateId.Text.Trim();

                        cmd.ExecuteNonQuery();

                        Dgvform3.Rows.Clear();

                        string strSql = "Select * from ThinkOrdFormTbl Where chTemplateID = @ID AND chOrdNo = @No";
                        using (SqlDataAdapter dtAdpt = new SqlDataAdapter(strSql, conn))
                        {
                            DataTable dt = new DataTable();
                            dtAdpt.SelectCommand.Parameters.Add("@ID", SqlDbType.Char).Value = txtTamplateId.Text.Trim();
                            dtAdpt.SelectCommand.Parameters.Add("@No", SqlDbType.Char).Value = txtOrNo.Text.Trim();
                            dtAdpt.Fill(dt);
                            DataRow dataRow = dt.Rows[0];
                            Dgvform3.Rows.Add(dataRow["chOrdNo"], dataRow["chTemplateID"], dataRow["chStat"]);
                            plform.Visible = true;
                            MessageBox.Show("更新成功\n");
                            //Dgvform3.Visible = true;
                            // Dgvform3.Visible = true;
                            //MessageBox.Show("更新成功\n");
                        }
                        //txtOrNo.Focus() ;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
        }
        private void chbTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTrue.Checked)
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

        private void Dgvform3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgvform3.Columns[e.ColumnIndex].Name == "chOrdNo" && e.RowIndex < Dgvform3.RowCount)
            {
                txtOrNo.Text = Dgvform3.Rows[e.RowIndex].Cells["chOrdNo"].Value.ToString();
                txtTamplateId.Text = Dgvform3.Rows[e.RowIndex].Cells["chTemplateID"].Value.ToString();
                if (Dgvform3.Rows[e.RowIndex].Cells["chStat"].Value.ToString() == "1")
                {
                    chbTrue.Checked = true;
                }
                else if (Dgvform3.Rows[e.RowIndex].Cells["chStat"].Value.ToString() == "0")
                {
                    chbFalse.Checked = true;
                }
                plform.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtOrNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
