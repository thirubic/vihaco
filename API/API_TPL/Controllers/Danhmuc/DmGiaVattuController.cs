﻿using API_TPL.DAL;
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
    //[Authorize]
    [RoutePrefix("api/gia_vattu")]
    public class DmGiaVattuController : ApiController
    {
        static String connString = ConfigurationManager.ConnectionStrings["GSkhoConnection"].ToString();
        SQL_DBHELPERs helper = new SQL_DBHELPERs(connString);

        ///<summary>
        ///<b>Mục đích:</b>Lấy danh sách phân xưởng. <br />
        ///<b>Tham số URI:</b> Không có. <br />
        ///<b>Trả về:</b> Datatable <br />
        ///</summary>
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("getall"), HttpGet]
        public IHttpActionResult getAll()
        {
            string query_str = "dm_giavattu_getall";

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
            string query_str = "dm_giavattu_insert";

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
        public IHttpActionResult DM_GIAVATTU_XOA([FromBody] dynamic obj)
        {
            string query_str = "dm_giavattu_delete";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("ma_vattu", obj.ma_vattu, System.Data.SqlDbType.NVarChar);

                DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("getbyma"), HttpPost]
        public IHttpActionResult DM_GIAVATTU_BYID([FromBody] dynamic obj)
        {
            string query_str = "dm_giavattu_getbyma";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("ma_vattu", obj.ma_vattu, System.Data.SqlDbType.NVarChar);

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
