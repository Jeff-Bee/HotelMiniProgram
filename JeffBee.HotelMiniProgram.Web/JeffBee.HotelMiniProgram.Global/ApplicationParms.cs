using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JeffBee.HotelMiniProgram.Global
{
    public class ApplicationParms
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnectionString { get; set; }

        static ApplicationParms()
        {
            //ConnectionString = "Data Source=192.168.16.200;Initial Catalog=电力产品在线管理平台;Persist Security Info=True;User ID=sa;Password=gl328";
        }
    }
}
