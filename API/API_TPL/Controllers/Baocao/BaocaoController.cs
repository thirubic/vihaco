using API_TPL.DAL;
using Microsoft.AspNet.Identity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;
using System.Web;
using System.Text;
using System.Configuration;
//using Microsoft.Office.Interop.Excel;
//using OfficeOpenXml;
//using Aspose.Cells;

namespace API_TPL.Controllers.Congviec
{
    //[Authorize]
    [RoutePrefix("api/baocao")]
    public class BaocaoController : ApiController
    {
        static String connString = ConfigurationManager.ConnectionStrings["GSkhoConnection"].ToString();
        SQL_DBHELPERs helper = new SQL_DBHELPERs(connString);

        [Route("Tonkho_denngay"), HttpPost]
        public IHttpActionResult Tonkho_denngay([FromBody] dynamic obj)
        {
            string query_str = "BC_Tonkho_denngay";

            object[] aParams = new object[2];
            try
            {
                
                aParams[0] = helper.BuildParameter("Ngay", obj.Ngay, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("MAKHO", obj.MAKHO, System.Data.SqlDbType.NVarChar);
                System.Data.DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [Route("Xuatnhap_tungaydenngay"), HttpPost]
        public IHttpActionResult BC_Xuatnhap_tungaydenngay([FromBody] dynamic obj)
        {
            string query_str = "BC_Tonkho_denngay";

            object[] aParams = new object[3];
            try
            {
                aParams[0] = helper.BuildParameter("tungay", obj.denngay, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("denngay", obj.denngay, System.Data.SqlDbType.NVarChar);
                aParams[2] = helper.BuildParameter("makho", obj.makho, System.Data.SqlDbType.NVarChar);
                System.Data.DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        [Route("Tonghopgiocongtheothang"), HttpPost]
        public IHttpActionResult BC_TonghopgiocongcuaNV([FromBody] dynamic obj)
        {
            string query_str = "BC_TonghopgiocongcuaNV";

            object[] aParams = new object[3];
            try
            {
                aParams[0] = helper.BuildParameter("IDNHANVIEN", obj.IDNHANVIEN, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("THANG", obj.THANG, System.Data.SqlDbType.NVarChar);
                aParams[2] = helper.BuildParameter("NAM", obj.NAM, System.Data.SqlDbType.NVarChar);
                System.Data.DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [Route("chitietgiocongnhanvien"), HttpPost]
        public IHttpActionResult BC_ChitietcongtheothangcuaNV([FromBody] dynamic obj)
        {
            string query_str = "BC_ChitietcongtheothangcuaNV";

            object[] aParams = new object[2];
            try
            {

                aParams[0] = helper.BuildParameter("THANG", obj.THANG, System.Data.SqlDbType.NVarChar);
                aParams[1] = helper.BuildParameter("NAM", obj.NAM, System.Data.SqlDbType.NVarChar);
                System.Data.DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, kq));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        /*
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("baocao_thanhpham_exp"), HttpGet]
        public IHttpActionResult baocao_thanhpham_exp(string ma_xuong)
        {

            string query_str = "baocao_thanhpham";

            object[] aParams = new object[1];
            try
            {
                aParams[0] = helper.BuildParameter("ma_xuong", ma_xuong, System.Data.SqlDbType.NVarChar);

                System.Data.DataTable kq = helper.ExecuteQueryStoreProcedure(query_str, aParams);

                string templateDocument = HttpContext.Current.Server.MapPath("~/Templates/Baocaothanhpham.xlsx");
                MemoryStream output = new MemoryStream();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (FileStream templateDocumentStream = File.OpenRead(templateDocument))
                {
                    using (ExcelPackage package = new ExcelPackage(templateDocumentStream))
                    {
                        ExcelWorksheet sheet = package.Workbook.Worksheets["thongkethanhpham"];

                        int startRow = 4;
                        int rowIndex = startRow;
                        int SL = startRow + kq.Rows.Count + 1;
                        for (int i = 0; i < kq.Rows.Count; i++)
                        {
                            sheet.Cells[rowIndex, 2].Value = (i + 1).ToString();
                            sheet.Cells[rowIndex, 3].Value = kq.Rows[i]["ten_xuong"].ToString();
                            sheet.Cells[rowIndex, 4].Value = kq.Rows[i]["ten_kho"].ToString();
                            sheet.Cells[rowIndex, 5].Value = kq.Rows[i]["ten_vattu"].ToString();
                            sheet.Cells[rowIndex, 6].Value = kq.Rows[i]["soluong"].ToString();
                            sheet.Cells[rowIndex, 7].Value = kq.Rows[i]["donvi_tinh"].ToString();
                            sheet.Cells[rowIndex, 8].Value = kq.Rows[i]["tong_khoiluong"].ToString();
                            rowIndex++;
                        }

                        using (ExcelRange range = sheet.Cells[startRow, 2, rowIndex - 1, 8])
                        {
                            range.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        }
                        package.SaveAs(output);
                    }
                }

                string documentName = string.Format("Baocaothanhpham.{0}", "xlsx");

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

                byte[] m = output.ToArray();
                // Reset Stream Position
                output.Position = 0;
                result.Content = new ByteArrayContent(m);

                // Generic Content Header
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");

                //Set Filename sent to client
                result.Content.Headers.ContentDisposition.FileName = documentName;
                return ResponseMessage(result);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        } */
    }

    public class SubData
    {
        public string MA_DV { get; set; }
        public int LOAI_CV { get; set; }
        public string TUNGAY { get; set; }
        public string DENNGAY { get; set; }
        public int TINHCHAT { get; set; }
    }
}