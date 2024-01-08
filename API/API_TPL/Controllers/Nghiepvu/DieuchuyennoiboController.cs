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
    [RoutePrefix("api/dieuchuyennoibo")]
    public class DieuchuyennoiboController : ApiController
    {
        static String connString = ConfigurationManager.ConnectionStrings["GSkhoConnection"].ToString();
        SQL_DBHELPERs helper = new SQL_DBHELPERs(connString);


        [Route("getbyid"), HttpPost]
        public IHttpActionResult dieuchuyen_getbyID([FromBody] dynamic obj)
        {
            string query_str = "dieuchuyen_getbyID";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("ID_DEN", obj.ID_DEN, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("searchbyHoadon"), HttpPost]
        public IHttpActionResult dieuchuyen_getbyHoadon([FromBody] dynamic obj)
        {
            string query_str = "dieuchuyen_getbyHoadon";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("SOHOADON", obj.SOHOADON, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("searchbydate"), HttpPost]
        public IHttpActionResult dieuchuyen_searchbydate([FromBody] dynamic obj)
        {
            string query_str = "dieuchuyen_searchbydate";

            object[] aParams = new object[2];
            try
            {
                aParams[0] = helper.BuildParameter("tungay", obj.tungay, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("denngay", obj.denngay, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("dieuchuyen"), HttpPost]
        public IHttpActionResult Dieuchuyen_noibo([FromBody] dynamic obj)
        {
            string query_str = "Dieuchuyen_noibo";

            object[] aParams = new object[8];
            try
            {
                aParams[0] = helper.BuildParameter("NGAY", obj.NGAY, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("SOHOADON_DI", obj.SOHOADON_DI, System.Data.SqlDbType.NVarChar);
                aParams[2] = helper.BuildParameter("SOHOADON_DEN", obj.SOHOADON_DEN, System.Data.SqlDbType.NVarChar);
                aParams[3] = helper.BuildParameter("MAKHO_DI", obj.MAKHO_DI, System.Data.SqlDbType.NVarChar);
                aParams[4] = helper.BuildParameter("MAKHO_DEN", obj.MAKHO_DEN, System.Data.SqlDbType.NVarChar);
                aParams[5] = helper.BuildParameter("IDANH", obj.IDANH, System.Data.SqlDbType.NVarChar);
                aParams[6] = helper.BuildParameter("GHICHU", obj.GHICHU, System.Data.SqlDbType.NVarChar);
                aParams[7] = helper.BuildParameter("data", obj.data, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("update"), HttpPost]
        public IHttpActionResult Dieuchuyen_update([FromBody] dynamic obj)
        {
            string query_str = "Dieuchuyen_update";

            object[] aParams = new object[9];
            try
            {
                aParams[0] = helper.BuildParameter("ID_DEN", obj.ID_DEN, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("NGAY", obj.NGAY, System.Data.SqlDbType.NVarChar);
                aParams[2] = helper.BuildParameter("SOHOADON_DI", obj.SOHOADON_DI, System.Data.SqlDbType.NVarChar);
                aParams[3] = helper.BuildParameter("SOHOADON_DEN", obj.SOHOADON_DEN, System.Data.SqlDbType.NVarChar);
                aParams[4] = helper.BuildParameter("MAKHO_DI", obj.MAKHO_DI, System.Data.SqlDbType.NVarChar);
                aParams[5] = helper.BuildParameter("MAKHO_DEN", obj.MAKHO_DEN, System.Data.SqlDbType.NVarChar);
                aParams[6] = helper.BuildParameter("IDANH", obj.IDANH, System.Data.SqlDbType.NVarChar);
                aParams[7] = helper.BuildParameter("GHICHU", obj.GHICHU, System.Data.SqlDbType.NVarChar);
                aParams[8] = helper.BuildParameter("data", obj.data, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("xoa"), HttpPost]
        public IHttpActionResult Dieuchuyen_delete([FromBody] dynamic obj)
        {
            string query_str = "Dieuchuyen_delete";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("ID_DEN", obj.ID_DEN, System.Data.SqlDbType.NVarChar);

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
