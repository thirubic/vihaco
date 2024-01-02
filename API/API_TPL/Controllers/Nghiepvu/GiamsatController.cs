using API_TPL.DAL;
using Microsoft.AspNet.Identity;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
//using Telegram.Bot;
//using Telegram.Bot.Types.Enums;
//using Telegram.Bot.Types.ReplyMarkups;
using System.Threading;
using System.Threading.Tasks;

namespace API_TPL.Controllers.Danhmuc
{
    //[Authorize]
    [RoutePrefix("api/giamsat")]
    public class GiamsatController : ApiController
    {
        static String connString = ConfigurationManager.ConnectionStrings["GSkhoConnection"].ToString();
        SQL_DBHELPERs helper = new SQL_DBHELPERs(connString);
        //TelegramBotClient botClient;
      
        [Route("getbytrangthai"), HttpPost]
        public IHttpActionResult DANHACH_LUONG_BYTRANGTHAI ([FromBody] dynamic obj)
        {
            string query_str = "hoso_luongphan_getbytrangthai";

            object[] aParams = new object[2];
            try
            {
                aParams[0] = helper.BuildParameter("ma_duong", obj.ma_duong, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("trangthai", obj.trangthai, System.Data.SqlDbType.Int);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
       
    }
}
