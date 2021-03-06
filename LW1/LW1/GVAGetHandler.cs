using System.Web;

namespace LW1
{
    public class GVAGetHandler : IHttpHandler
    {
        private static string ParmAName = "ParmA";
        private static string ParmBName = "ParmB";

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string paramA = context.Request.QueryString[ParmAName];
            string paramB = context.Request.QueryString[ParmBName];
            HttpResponse response = context.Response;
            if(string.IsNullOrEmpty(paramA) || string.IsNullOrEmpty(paramB))
            {
                response.Write("ParmA and/or ParmB is null or empty");
            }
            else
            {
                response.Write($"GET-GVA:ParmA = {paramA},ParmB = {paramB}");
            }
            
        }
    }
}
