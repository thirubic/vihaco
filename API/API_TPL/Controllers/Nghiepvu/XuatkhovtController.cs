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
    [RoutePrefix("api/xuatkhovt")]
    public class XuatkhovtController : ApiController
    {
        static String connString = ConfigurationManager.ConnectionStrings["GSkhoConnection"].ToString();
        SQL_DBHELPERs helper = new SQL_DBHELPERs(connString);


        [Route("getbyid"), HttpPost]
        public IHttpActionResult xuatkho_getbyid([FromBody] dynamic obj)
        {
            string query_str = "xuatkho_getbyid";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("IDXUATKHO", obj.IDXUATKHO, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("searchbyHoadon"), HttpPost]
        public IHttpActionResult xuatkho_searchbyHoadon([FromBody] dynamic obj)
        {
            string query_str = "xuatkho_searchbyHoadon";

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
        public IHttpActionResult xuatkho_searchbydate([FromBody] dynamic obj)
        {
            string query_str = "xuatkho_searchbydate";

            object[] aParams = new object[2];
            try
            {
                aParams[0] = helper.BuildParameter("TUNGAY", obj.TUNGAY, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("DENNGAY", obj.DENNGAY, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [Route("xuatkho"), HttpPost]
        public IHttpActionResult xuatkho_insert([FromBody] dynamic obj)
        {
            string query_str = "xuatkho_insert";

            object[] aParams = new object[6];
            try
            {
                aParams[0] = helper.BuildParameter("NGAYXUATKHO", obj.NGAYXUATKHO, System.Data.SqlDbType.NVarChar);
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
        public IHttpActionResult xuatkho_update([FromBody] dynamic obj)
        {
            string query_str = "xuatkho_update";
            //test git
            object[] aParams = new object[7];
            try
            {
                aParams[0] = helper.BuildParameter("IDXUATKHO", obj.IDXUATKHO, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("NGAYXUATKHO", obj.NGAYXUATKHO, System.Data.SqlDbType.NVarChar);
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
        public IHttpActionResult xuatkho_delete([FromBody] dynamic obj)
        {
            string query_str = "xuatkho_delete";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("IDXUATKHO", obj.IDXUATKHO, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("getduongdan"), HttpPost]
        public IHttpActionResult upload_xuatduongdan([FromBody] dynamic obj)
        {
            string query_str = "upload_xuatduongdan";

            object[] aParams = new object[2];
            try
            {
                aParams[0] = helper.BuildParameter("ID_DOITUONG", obj.ID_DOITUONG, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("LOAI", obj.LOAI, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("ton_bymavt"), HttpPost]
        public IHttpActionResult tonkho_getbymavt([FromBody] dynamic obj)
        {
            string query_str = "tonkho_getbymavt";

            object[] aParams = new object[3];
            try
            {
                aParams[0] = helper.BuildParameter("MAKHO", obj.MAKHO, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("MAVT", obj.MAVT, System.Data.SqlDbType.NVarChar);
                aParams[2] = helper.BuildParameter("NGAY", obj.NGAY, System.Data.SqlDbType.NVarChar);

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
