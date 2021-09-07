using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SiPA.Web.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnv;

        public ReportController(
            DataContext context,
            IWebHostEnvironment webHostEnv)
        {
            _context = context;
            _webHostEnv = webHostEnv;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Parishioners()
        {
            var dt = new DataTable();
            dt = GetParishionerInfo();

            int extension = 1;     
            var path = $"{this._webHostEnv.WebRootPath}\\Reports\\Christening.rdlc";
            
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("dsChristening", dt);

            var result = localReport.Execute(RenderType.Pdf, extension);
            return File(result.MainStream, "application/pdf");
        }

        string contr = "Server=(localdb)\\MSSQLLocalDB;Database=SiPA;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DataTable GetParishionerInfo()
        {
            var dt = new DataTable();
            using (SqlConnection con = new SqlConnection(contr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("spChristening", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }               

            return dt;
        }

        public IActionResult FirstCommunion()
        {
            var dt = new DataTable();
            dt = GetFirstCommunionInfo();

            int extension = 1;
            var path = $"{this._webHostEnv.WebRootPath}\\Reports\\FirstCommunion.rdlc";

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("dsFirstCommunion", dt);

            var result = localReport.Execute(RenderType.Pdf, extension);
            return File(result.MainStream, "application/pdf");
        }


        public DataTable GetFirstCommunionInfo()
        {
            var dt = new DataTable();
            using (SqlConnection con = new SqlConnection(contr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("spFirstCommunion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            return dt;
        }

        public IActionResult Confirmation()
        {
            var dt = new DataTable();
            dt = GetConfirmationInfo();

            int extension = 1;
            var path = $"{this._webHostEnv.WebRootPath}\\Reports\\Confirmation.rdlc";

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("dsConfirmation", dt);

            var result = localReport.Execute(RenderType.Pdf, extension);
            return File(result.MainStream, "application/pdf");
        }


        public DataTable GetConfirmationInfo()
        {
            var dt = new DataTable();
            using (SqlConnection con = new SqlConnection(contr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("spConfirmation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            return dt;
        }

        public IActionResult Wedding()
        {
            var dt = new DataTable();
            dt = GetWeddingInfo();

            int extension = 1;
            var path = $"{this._webHostEnv.WebRootPath}\\Reports\\Wedding.rdlc";

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("dsWedding", dt);

            var result = localReport.Execute(RenderType.Pdf, extension);
            return File(result.MainStream, "application/pdf");
        }


        public DataTable GetWeddingInfo()
        {
            var dt = new DataTable();
            using (SqlConnection con = new SqlConnection(contr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("spWedding", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            return dt;
        }

        //public IActionResult Christening()
        //{
        //    var dt = new DataTable();
        //    dt = GetChristeningInfo();

        //    string mimetype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnv.WebRootPath}\\Reports\\Christening.rdlc";

        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("prm", "RDLC Report");
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Christening", dt);
        //     var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public DataTable GetChristeningInfo()
        //{
        //    var dt = new DataTable();
        //    dt.Columns.Add("PlaceofEvent");
        //    dt.Columns.Add("CeremonialCelebrant");
        //    dt.Columns.Add("ChristeningDate");

        //    DataRow row;
        //    for (int i = 101; i <= 107; i++)
        //    {
        //        row = dt.NewRow();
        //        row["PlaceofEvent"] = "Parroquia San Agustin";
        //        row["CeremonialCelebrant"] = "Belisario";
        //        row["ChristeningDate"] = "09/11/1991";

        //        dt.Rows.Add(row);
        //    }

        //    return dt;
        //}
    }
}
