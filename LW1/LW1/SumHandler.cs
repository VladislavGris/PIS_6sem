using System;
using System.Web;

namespace LW1
{
    public class SumHandler : IHttpHandler
    {
        private static string ParmAName = "X";
        private static string ParmBName = "Y";

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
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
                response.Write(X+Y);
            }
        }
    }
}
