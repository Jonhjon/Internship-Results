using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Namotion.Reflection;


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("/Insert")]
        [Produces("application/json")]
        public ClJson.result Insert([FromBody] Cls_NEW.Rootobject ins_objs)
        {
            string? db = _configuration.GetValue<string>("ConnectionString:DB_ADM");
            ClJson.result result = new ClJson.result();
            string sql = "";
            DataTable dt = new DataTable();
            if (ins_objs == null)
            {
                result.status = "fail";
                result.message = "Input object is null";
                return result;
            }
            try
            {
                if (db == null)
                {
                    throw new InvalidOperationException("Connection string is null");
                }

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(db)
                {
                    TrustServerCertificate = true // 新增這行以信任伺服器憑證
                };
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();
                    sql = "select max(id) from [DB_ADM].[dbo].[RestBPTbl]";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        dt.Reset();
                        dt.Load(cmd.ExecuteReader());

                        int index = dt.Rows[0][0] != DBNull.Value ? int.Parse(dt.Rows[0][0].ToString()) : 0;

                        sql = "INSERT INTO [DB_ADM].[dbo].[RestBPTbl] ( [op_id] , [patient_id] ,[sys],[dia],[map],[spo2],[pulse],[temp],[rr],[pain],[data_time],[status])" +
                                                                   "VALUES( @op_Id , @patient_id , @sys , @dia , @map, @spo2, @pulse, @temp, @rr, @pain, @data_time, '')";
                        cmd.CommandText = sql;

                        foreach (var ins_obj in ins_objs.Property1)
                        {
                            if (ins_obj != null && ins_obj.Value != null && ins_obj.Value.Length > 0)
                            {
                                cmd.Parameters.Add("@op_Id", SqlDbType.Char).Value = ins_obj.StaffNumber.Trim();
                                cmd.Parameters.Add("@patient_id", SqlDbType.Char).Value = ins_obj.ChartNo.Trim();
                                cmd.Parameters.Add("@sys", SqlDbType.Char).Value = ins_obj.Value[0].Systolic.value.Trim();
                                cmd.Parameters.Add("@dia", SqlDbType.Char).Value = ins_obj.Value[0].Diastolic.value.Trim();
                                cmd.Parameters.Add("@map", SqlDbType.Char).Value = ins_obj.Value[0].Mean.value.Trim();
                                cmd.Parameters.Add("@spo2", SqlDbType.Char).Value = ins_obj.Value[0].SpO2.value.Trim();
                                cmd.Parameters.Add("@pulse", SqlDbType.Char).Value = ins_obj.Value[0].HR.value.Trim();
                                cmd.Parameters.Add("@temp", SqlDbType.Char).Value = ins_obj.Value[0].Spot_Temp.value.Trim();
                                cmd.Parameters.Add("@rr", SqlDbType.Char).Value = ins_obj.Value[0].Resp.value.Trim();
                                cmd.Parameters.Add("@pain", SqlDbType.Char).Value = ins_obj.Value[0].Pain.value.Trim();
                                cmd.Parameters.Add("@data_time", SqlDbType.Char).Value = ins_obj.TurningDateTime.Trim();

                                cmd.ExecuteNonQuery();

                                sql = "select max(id) from [DB_ADM].[dbo].[RestBPTbl]";

                                cmd.CommandText = sql;

                                dt.Reset();
                                dt.Load(cmd.ExecuteReader());
                                int index2 = dt.Rows[0][0] != DBNull.Value ? int.Parse(dt.Rows[0][0].ToString()) : 0;

                                if (index2 > index)
                                {
                                    result.index = index2;
                                    result.status = "success";
                                    result.message = "Insert success";
                                }
                                else
                                {
                                    result.status = "fail";
                                    result.message = "Insert fail";
                                }
                            }
                            else
                            {
                                result.status = "fail";
                                result.message = "沒有物件";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                result.status = "fail";
                result.message = ex.Message.ToString();
            }
            return result;
        }
    }
}

