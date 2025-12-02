using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjTcm.classes
{
    public class SessaoHelper
    {
        public static void ProtegerPagina()
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {
                HttpContext.Current.Response.Redirect("MainLogin.aspx");
            }
        }
    }
}