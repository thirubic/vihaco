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

namespace API_TPL.Controllers.Chamcong
{

    [RoutePrefix("api/chamcong")]
    public class ChamcongController : ApiController
    {
        static String connString = ConfigurationManager.ConnectionStrings["GSkhoConnection"].ToString();
        SQL_DBHELPERs helper = new SQL_DBHELPERs(connString);
        [Route("capnhat"), HttpPost]
        public IHttpActionResult chamcong_insert([FromBody] dynamic obj)
        {
            string query_str = "chamcong_insert";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("data", obj.data, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));

            }
        }
        [Route("update"), HttpPost]
        public IHttpActionResult chamcong_update([FromBody] dynamic obj)
        {
            string query_str = "chamcong_update";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("data", obj.data, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));

            }
        }
        [Route("xoa"), HttpPost]
        public IHttpActionResult chamcong_delete([FromBody] dynamic obj)
        {
            string query_str = "chamcong_delete";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("IDCONG", obj.IDCONG, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("listbydate"), HttpPost]
        public IHttpActionResult chamcong_laytheongay([FromBody] dynamic obj)
        {
            string query_str = "chamcong_laytheongay";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("NGAY", obj.NGAY, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("listbynv"), HttpPost]
        public IHttpActionResult chamcong_laytheonhanvien([FromBody] dynamic obj)
        {
            string query_str = "chamcong_laytheonhanvien";

            object[] aParams = new object[3];
            try
            {
                aParams[0] = helper.BuildParameter("ID_NHANVIEN", obj.ID_NHANVIEN, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("THANG", obj.THANG, System.Data.SqlDbType.NVarChar);
                aParams[2] = helper.BuildParameter("NAM", obj.NAM, System.Data.SqlDbType.NVarChar);
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
