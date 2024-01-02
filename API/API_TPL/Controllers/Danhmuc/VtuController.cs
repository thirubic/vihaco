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

namespace API_TPL.Controllers.Danhmuc
{
    [RoutePrefix("api/vattu")]
    public class VtuController : ApiController
    {
        static String connString = ConfigurationManager.ConnectionStrings["GSkhoConnection"].ToString();
        SQL_DBHELPERs helper = new SQL_DBHELPERs(connString);       
        
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("getall"), HttpGet]
        public IHttpActionResult getAll()
        {
            string query_str = "vattu_getall";

            object[] aParams = new object[0];
            try
            {
                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [Route("capnhat"), HttpPost]
        public IHttpActionResult DM_GIAVATTU([FromBody] dynamic obj)
        {
            string query_str = "vattu_insert";

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
        public IHttpActionResult vattu_update([FromBody] dynamic obj)
        {
            string query_str = "vattu_update";

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
        public IHttpActionResult vattu_delete([FromBody] dynamic obj)
        {
            string query_str = "vattu_delete";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("MAVT", obj.MAVT, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("getbyma"), HttpPost]
        public IHttpActionResult vattu_getbyma([FromBody] dynamic obj)
        {
            string query_str = "vattu_getbyma";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("MAVT", obj.MAVT, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("getbykho"), HttpPost]
        public IHttpActionResult vattu_getkho([FromBody] dynamic obj)
        {
            string query_str = "vattu_getkho";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("MAKHO", obj.MAKHO, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [Route("getbynhomvt"), HttpPost]
        public IHttpActionResult vattu_getbynhomvt([FromBody] dynamic obj)
        {
            string query_str = "vattu_getbynhomvt";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("IDNHOMVT", obj.IDNHOMVT, System.Data.SqlDbType.NVarChar);

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
