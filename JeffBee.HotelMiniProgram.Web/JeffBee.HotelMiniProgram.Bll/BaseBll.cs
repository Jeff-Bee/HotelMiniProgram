using JeffBee.HotelMiniProgram.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DapperExtensions;
using JeffBee.HotelMiniProgram.Global;

namespace JeffBee.HotelMiniProgram.Bll
{
    public class BaseBll<T>  where T : class
    {
        protected static readonly BaseDal<T> baseDal = new BaseDal<T>(ConnectionString);

        //public static string ConnectionString { get; set; }
        protected static string ConnectionString { get { return ApplicationParms.ConnectionString; } }
        public static bool Insert(T model)
        {
            return  baseDal.Insert(model);
        }
        public static int InsertWithReturnId(T model)
        {
            return baseDal.InsertWithReturnId(model, ConnectionString);
        }
        public static bool Update(T model)
        {
            return baseDal.Update(model);
        }
       
        public static T GetModel(PredicateGroup pdg)
        {
            return baseDal.GetModel(pdg);
        }
        public virtual T GetModel(string sqlString, out string errMsg)
        {
            return baseDal.GetModel(sqlString, out errMsg);
        }
        public static IList<T> GetList()
        {
            return baseDal.GetList();
        }

        public static bool ExecuteSql(string Sql) {
            return baseDal.Execute(Sql);
        }
    }
}
