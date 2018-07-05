using DapperExtensions;
using JeffBee.HotelMiniProgram.Log;
using JeffBee.HotelMiniProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffBee.HotelMiniProgram.Dal
{
    public class HotelInfoDal<T> : BaseDal<T> where T : HotelInfo
    {
        public HotelInfoDal(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// 删除酒店信息
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public bool Delete(int deptId)
        {
            try
            {
                var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };

                var pga = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
                pga.Predicates.Add(Predicates.Field<T>(f => f.Id, Operator.Eq, deptId));
                pgMain.Predicates.Add(pga);

                var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
                pgb.Predicates.Add(Predicates.Field<T>(f => f.Id, Operator.Eq, deptId));
                pgMain.Predicates.Add(pgb);

                return Delete(pgMain);
            }
            catch (Exception ex)
            {
                Logger.LogError4Exception(ex, "AppLogger");
            }
            return false;
        }

        /// <summary>
        /// 获取酒店信息
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public T GetModel(int deptId)
        {
            T model = null;
            try
            {
                PredicateGroup pdg = new PredicateGroup();
                pdg.Predicates = new List<IPredicate>();
                pdg.Predicates.Add(Predicates.Field<T>(a => a.Id, Operator.Eq, deptId));
                model = GetModel(pdg);
            }
            catch (Exception ex)
            {
                Logger.LogError4Exception(ex, "AppLogger");
            }
            return model;
        }

    }
}
