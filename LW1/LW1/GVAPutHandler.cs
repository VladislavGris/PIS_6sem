using System;
using System.Web;

namespace LW1
{
    public class GVAPutHandler : IHttpHandler
    {
        private static string ParmAName = "ParmA";
        private static string ParmBName = "ParmB";

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string parmA = context.Request[ParmAName];
            string parmB = context.Request[ParmBName];
            HttpResponse response = context.Response;
            if (string.IsNullOrEmpty(parmA) || string.IsNullOrEmpty(parmB))
            {
                response.Write("ParmA and/or ParmB is null or empty");
            }
            else
            {
                response.Write($"PUT-GVA:ParmA = {parmA},ParmB = {parmB}");
            }
        }
    }
}
