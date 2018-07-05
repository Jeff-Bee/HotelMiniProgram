using JeffBee.HotelMiniProgram.Dal;
using JeffBee.HotelMiniProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffBee.HotelMiniProgram.Bll
{
    public class HotelInfoBll<T>:BaseBll<HotelInfo>
    {

        protected static readonly HotelInfoDal<HotelInfo> ThisDal = new HotelInfoDal<HotelInfo>(ConnectionString);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static bool InsertScore(HotelInfo model)
        {
            return ThisDal.Insert(model);
        }
        
       
    }
}
