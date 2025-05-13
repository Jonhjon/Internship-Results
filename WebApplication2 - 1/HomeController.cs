using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;
using static WebApplication2.Models.ClsJson;
using System.Xml;
//using SqlConnection = System.Data.SqlClient.SqlConnection;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public result Insert(ElectricPlasmaPot ins_obj)
        {
            //ClsJson.UserProfile Rtn_Dtl = new ClsJson.UserProfile();
            string db = _configuration.GetValue<string>("ConnectionString:DB_GEN");
            result result = new result();
            try
            {
                string sqlstr = "";
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();
                    sqlstr = "SELECT max([intSeq]) FROM [dbo].[ExmCSRPlasmaPotDataTbl]";
                    using (SqlCommand cmd = new SqlCommand(sqlstr, conn))
                    {
                        dt.Reset();
                        dt.Load(cmd.ExecuteReader());
                    }

                    int intSeq_1 = int.Parse(dt.Rows[0][0].ToString());

                    sqlstr = "INSERT INTO [dbo].[ExmCSRPlasmaPotDataTbl]([chDTM_C],[chCycleNo],[chBI_BatchNo],[chCycleDTM_S],[chDTM_Add],[chDate],[chResult_Content_1]" +
                        ",[chResult_DTM_1],[chBatchNo],[chResult_Content_2],[chCycleDTM_E])" +
                        "VALUES(@chDTM_C,@chCycleNo,@chBI_BatchNo,@chCycleDTM_S,@chDTM_Add,@chDate,@chResult_Content_1,@chResult_DTM_1,@chBatchNo,@chResult_Content_2,@chCycleDTM_E)";
                    using (SqlCommand cmd = new SqlCommand(sqlstr, conn))
                    {
                        cmd.Parameters.Add("@chDTM_C", SqlDbType.VarChar).Value = ins_obj.chDTM_C;
                        cmd.Parameters.Add("@chCycleNo", SqlDbType.VarChar).Value = ins_obj.chCycleNo;
                        cmd.Parameters.Add("@chBI_BatchNo", SqlDbType.VarChar).Value = ins_obj.chBI_BatchNo;
                        cmd.Parameters.Add("@chCycleDTM_S", SqlDbType.VarChar).Value = ins_obj.chCycleDTM_S;
                        cmd.Parameters.Add("@chDTM_Add", SqlDbType.VarChar).Value = ins_obj.chDTM_Add;
                        cmd.Parameters.Add("@chDate", SqlDbType.VarChar).Value = ins_obj.chDate;
                        cmd.Parameters.Add("@chResult_Content_1", SqlDbType.VarChar).Value = ins_obj.chResult_Content_1;
                        cmd.Parameters.Add("@chResult_DTM_1", SqlDbType.VarChar).Value = ins_obj.chResult_DTM_1;
                        cmd.Parameters.Add("@chBatchNo", SqlDbType.VarChar).Value = ins_obj.chBatchNo;
                        cmd.Parameters.Add("@chResult_Content_2", SqlDbType.VarChar).Value = ins_obj.chResult_Content_2;
                        cmd.Parameters.Add("@chCycleDTM_E", SqlDbType.VarChar).Value = ins_obj.chCycleDTM_E;

                        cmd.ExecuteNonQuery();
                    }


                    using (SqlCommand cmd = new SqlCommand("SELECT max([intSeq]) FROM [dbo].[ExmCSRPlasmaPotDataTbl]", conn))
                    {
                        //cmd.Parameters.Add("@chDTM_C", SqlDbType.VarChar).Value = ins_obj.chDTM_C;
                        dt.Reset();
                        dt.Load(cmd.ExecuteReader());
                        int intSeq_2 = int.Parse(dt.Rows[0][0].ToString());
                        if (intSeq_2 > intSeq_1)
                        {
                            result.IsSuccess = true;
                            result.message = "Data Inserted Successfully";
                        }
                        else
                        {
                            result.IsSuccess = false;
                            result.message = "Data Inserted Failed";
                        }
                    }
                    
                }
            }
            catch (System.Exception ex)
            {
                result.IsSuccess = false;
                result.message = $"Code Erro!\n{ex.ToString()}";
            }
            return result;
        }

        [HttpGet]
        [Route("/TestConnection")]
        public IActionResult TestConnection()
        {
            string db = _configuration.GetValue<string>("ConnectionString:DB_GEN");
            try
            {
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();
                    return Ok("Connection successful");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection failed: {ex.Message}");
            }
        }
    }
}
