using System;
using System.Web;

namespace LW1
{
    public class XMLHandler : IHttpHandler
    {
        private static string pagePath = @"G:\\6_Sem\\PIS\\Labs\\LW1\\LW1\\static\\index.html";
        private static string ParmAName = "X";
        private static string ParmBName = "Y";

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if(context.Request.HttpMethod == "GET")
            {
                string text = System.IO.File.ReadAllText(pagePath);
                context.Response.Write(text);
            }
            else
            {
                string paramA = context.Request[ParmAName];
                string paramB = context.Request[ParmBName];
                float X, Y;
                HttpResponse response = context.Response;
                if (!float.TryParse(paramA, out X) || !float.TryParse(paramB, out Y))
                {
                    response.Write("X and/or Y is not a number");
                }
                else
                {
                    response.Write(X * Y);
                }
            }
        }
    }
}
