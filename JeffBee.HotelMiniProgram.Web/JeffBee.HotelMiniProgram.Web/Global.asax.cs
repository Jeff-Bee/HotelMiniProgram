using JeffBee.HotelMiniProgram.Global;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JeffBee.HotelMiniProgram.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //获取配置文件数据库连接字符串
            //ApplicationParms.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            //获取本项目的db
            ApplicationParms.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source="+AppDomain.CurrentDomain.BaseDirectory+ "/DB/Hotel.accdb;";

        }
    }
}
