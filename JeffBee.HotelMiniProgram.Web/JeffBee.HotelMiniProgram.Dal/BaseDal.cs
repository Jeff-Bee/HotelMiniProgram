using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using DapperExtensions;
using JeffBee.HotelMiniProgram.Log;
using JeffBee.HotelMiniProgram.Global;
using System.Data;
using System.Data.OleDb;

namespace JeffBee.HotelMiniProgram.Dal
{
    public class BaseDal<T> where T : class
    {
        public BaseDal()
        {
        }
        public BaseDal(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
        public virtual bool Insert(T model)
        {
            return SqlHelper.Insert<T>(model, ConnectionString);
        }
        public virtual bool Insert(List<T> listModel)
        {
            foreach (var model in listModel)
            {
                if (!Insert(model))
                {
                    return false;
                }
            }
            return true;
        }
        public virtual bool Insert(T model, string connectionString)
        {
            return SqlHelper.Insert<T>(model, connectionString);
        }
        public int InsertWithReturnId(T model)
        {
            return InsertWithReturnId(model, ConnectionString);
        }
        public int InsertWithReturnId(T model, string connectionString)
        {
            return SqlHelper.InsertWithReturnId<T>(model, connectionString);
        }
        public virtual bool Update(T model)
        {
            return SqlHelper.Update<T>(model, ConnectionString);
        }
        public virtual bool Update(T model, string connectionString)
        {
            return SqlHelper.Update<T>(model, connectionString);
        }
        public bool Delete(PredicateGroup predicate)
        {
            return SqlHelper.Delete<T>(predicate, ConnectionString);
        }
        public bool Delete(PredicateGroup predicate, string connectionString)
        {
            return SqlHelper.Delete<T>(predicate, connectionString);
        }
        public IList<T> GetList()
        {
            return GetListWithConnectionString(ConnectionString);
        }
        public IList<T> GetList(string sql)
        {
            return SqlHelper.GetList<T>(sql, ConnectionString);
        }
        public IList<T> GetList(string sql, string connectionString)
        {
            return SqlHelper.GetList<T>(sql, connectionString);
        }
        public IList<T> GetListWithConnectionString(string connectionString)
        {
            return SqlHelper.GetList<T>(connectionString);
        }
        public IList<T> GetList(PredicateGroup pdg)
        {
            return GetList(pdg, ConnectionString);
        }
        public IList<T> GetList(PredicateGroup pdg, string connectionString)
        {
            try
            {
                return SqlHelper.GetList<T>(pdg, connectionString);
            }
            catch (Exception ex)
            {
                Logger.LogError4Exception(ex, "AppLogger");
            }
            return new List<T>();
        }
        public IList<T> GetList(string storedProcedure, dynamic param = null)
        {
            return GetList(storedProcedure, ConnectionString, param);
        }
        public IList<T> GetList(string storedProcedure, string connectionString, dynamic param = null)
        {
            try
            {
                return SqlHelper.QuerySp<T>(storedProcedure, param, null, null, true, null, connectionString);
            }
            catch (Exception ex)
            {
                Logger.LogError4Exception(ex, "AppLogger");
            }
            return new List<T>();
        }
        public T GetModel(PredicateGroup pdg)
        {
            return GetModel(pdg, ConnectionString);
        }
        public T GetModel(PredicateGroup pdg, string connectionString)
        {
            T model = null;
            try
            {
                model = SqlHelper.Find<T>(pdg, connectionString);
            }
            catch (Exception ex)
            {
                Logger.LogError4Exception(ex, "AppLogger");
            }
            return model;
        }
        public virtual T GetModel(PredicateGroup pdg, string connectionString, out string errMsg)
        {
            errMsg = string.Empty;
            try
            {
                return SqlHelper.GetModel<T>(pdg, connectionString);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                Logger.LogError(string.Format("BaseDal::GetModel() Error:{0},connectionString:{1}"
                    , errMsg, connectionString), "AppLogger");
                Logger.LogError4Exception(ex, "AppLogger");
            }
            return null;
        }

        public virtual T GetModel(string sqlString, out string errMsg)
        {
            return GetModel(sqlString, ConnectionString, out errMsg);
        }
        public virtual T GetModel(string sqlString, string connectionString, out string errMsg)
        {
            T ret = null;
            errMsg = string.Empty;
            try
            {
                var reader = SqlHelper.GetReader(connectionString, sqlString);
                while (reader.Read())
                {
                    ret = GetInstance(ref reader);
                    break;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                Logger.LogError(string.Format("BaseDal::GetModel()执行SQL语句失败：{0}", sqlString), "AppLogger");
                Logger.LogError4Exception(ex, "AppLogger");
            }
            return ret;
        }
        public float? ExecuteScalar2Float(string sql)
        {
            float? ret = null;

            try
            {
                ret = SqlHelper.ExecuteScalar2Float(sql, ConnectionString);
            }
            catch (Exception ex)
            {
                Logger.LogError4Exception(ex, "AppLogger");
            }
            return ret;
        }
        public int ExecuteScalar2Int(string sql)
        {
            return ExecuteScalar2Int(sql, ConnectionString);
        }
        public int ExecuteScalar2Int(string sql, string connectionString)
        {
            int? ret = null;

            try
            {
                ret = SqlHelper.ExecuteScalar2Int(sql, connectionString);
            }
            catch (Exception ex)
            {
                Logger.LogError4Exception(ex, "AppLogger");
            }
            if (ret.HasValue)
            {
                return ret.Value;
            }
            else
            {
                return 0;
            }
        }
        public bool Execute(string sql)
        {
            return Execute(sql, ConnectionString);
        }
        public bool Execute(string sql, string connectionString)
        {
            try
            {
                return SqlHelper.Execute(sql, connectionString);
            }
            catch (Exception ex)
            {
                Logger.LogError4Exception(ex, "AppLogger");
            }
            return false;
        }
        public bool Execute(string storedProcedure, dynamic param = null)
        {
            return SqlHelper.Execute(storedProcedure, param, null, null, ConnectionString);
        }
        protected virtual T GetInstance(ref OleDbDataReader rdr)
        {
            T _t = Activator.CreateInstance<T>();
            try
            {
                PropertyInfo[] propertyInfos = _t.GetType().GetProperties();

                foreach (var property in propertyInfos)
                {
                    string name = string.Empty;
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        if (property.Name.ToUpper() == rdr.GetName(i).ToUpper())
                        {
                            name = rdr.GetName(i);
                            break;
                        }
                    }
                    if (!string.IsNullOrEmpty(name))
                    {
                        object _value = rdr[name];
                        if (_value != null && _value != DBNull.Value)
                        {
                            if (property.PropertyType.Name == "Single")
                                property.SetValue(_t, Convert.ToSingle(_value), null);
                            else if (property.PropertyType.Name == "Date")
                            {
                                property.SetValue(_t, Convert.ToDateTime(_value), null);
                            }
                            else
                                property.SetValue(_t, _value, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError4Exception(ex, "AppLogger");
            }


            //RichModelLazyLoader(ref _t);

            return _t;
        }

        public DataTable ExecuteDataTable(string sql)
        {
            return SqlHelper.ExecuteDataTable(sql, ConnectionString);
        }
    }
}
