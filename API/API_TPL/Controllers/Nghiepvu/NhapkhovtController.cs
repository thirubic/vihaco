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

namespace API_TPL.Controllers.Nghiepvu
{
    [RoutePrefix("api/nhapkhovt")]
    public class NhapkhovtController : ApiController
    {
        static String connString = ConfigurationManager.ConnectionStrings["GSkhoConnection"].ToString();
        SQL_DBHELPERs helper = new SQL_DBHELPERs(connString);
       
        [Route("nhapkho"), HttpPost]
        public IHttpActionResult nhapkho_insert([FromBody] dynamic obj)
        {
            string query_str = "nhapkho_insert";

            object[] aParams = new object[6];
            try
            {
                aParams[0] = helper.BuildParameter("NGAYNHAPKHO", obj.NGAYNHAPKHO, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("SOHOADON", obj.SOHOADON, System.Data.SqlDbType.NVarChar);
                aParams[2] = helper.BuildParameter("MAKHO", obj.MAKHO, System.Data.SqlDbType.NVarChar);
                aParams[3] = helper.BuildParameter("IDANH", obj.IDANH, System.Data.SqlDbType.NVarChar);
                aParams[4] = helper.BuildParameter("GHICHU", obj.GHICHU, System.Data.SqlDbType.NVarChar);
                aParams[5] = helper.BuildParameter("data", obj.data, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("update"), HttpPost]
        public IHttpActionResult nhapkho_update([FromBody] dynamic obj)
        {
            string query_str = "nhapkho_update";

            object[] aParams = new object[7];
            try
            {
                aParams[0] = helper.BuildParameter("IDNHAPKHO", obj.IDNHAPKHO, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("NGAYNHAPKHO", obj.NGAYNHAPKHO, System.Data.SqlDbType.NVarChar);
                aParams[2] = helper.BuildParameter("SOHOADON", obj.SOHOADON, System.Data.SqlDbType.NVarChar);
                aParams[3] = helper.BuildParameter("MAKHO", obj.MAKHO, System.Data.SqlDbType.NVarChar);
                aParams[4] = helper.BuildParameter("IDANH", obj.IDANH, System.Data.SqlDbType.NVarChar);
                aParams[5] = helper.BuildParameter("GHICHU", obj.GHICHU, System.Data.SqlDbType.NVarChar);
                aParams[6] = helper.BuildParameter("data", obj.data, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("xoa"), HttpPost]
        public IHttpActionResult nhapkho_delete([FromBody] dynamic obj)
        {
            string query_str = "nhapkho_delete";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("IDNHAPKHO", obj.IDNHAPKHO, System.Data.SqlDbType.NVarChar);

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
