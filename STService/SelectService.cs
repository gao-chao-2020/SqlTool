using ISTService;
using System;
using System.Collections.Generic;
using System.Data;

namespace STService
{
    public class SelectService : ISelectService
    {

        public IFreeSql fsql { get; set; }

        public SelectService(IFreeSql _fsql)
        {
            fsql = _fsql;
        }
        public DataTable SelectTable(string[] arr)
        {
            var t = "";
            string w = "";
            if (arr.Length == 2)
            {
                t = arr[1];
            }
            else if (arr.Length >= 3)
            {
                t = arr[1];
                if (arr.Length == 3 && int.TryParse(arr[2], out int relId))
                {
                    w = fsql.DbFirst.GetTableByName(t).Primarys[0].Name + "=" + relId;
                }
                else if (arr.Length == 3 && Guid.TryParse(arr[2], out Guid relGuid))
                {
                    w = fsql.DbFirst.GetTableByName(t).Primarys[0].Name + "='" + relGuid + "'";
                }
                else
                {
                    w = string.Join(" ", arr);
                    w = w.Substring(arr[0].Length + arr[1].Length + 1);
                }
            }
            else
            {
                throw new Exception("参数错误");
            }
            string sql = "select * from " + t + (!string.IsNullOrEmpty(w) ? (" where " + w) : "");
            DataTable dt = new DataTable();
            try
            {
                dt = fsql.Ado.ExecuteDataTable(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(sql + "\r\n" + ex.Message);
            }
            return dt;
        }
        public int InsertTable(string[] arr)
        {
            var t = "";
            var v = "";
            if (arr.Length == 3)
            {
                t = arr[1];
                v = arr[2];
            }
            else
            {
                throw new Exception("参数错误");
            }
            var arrs = v.Split(",");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var item in arrs)
            {
                var ar = item.Split("=");
                dic.Add(ar[0], "'" + ar[1] + "'");
            }

            string sql = "INSERT INTO " + t + " (" + string.Join(",", dic.Keys) + ") VALUES (" + string.Join(",", dic.Values) + ")";
            int rel = 0;
            try
            {
                rel = fsql.Ado.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(sql + "\r\n" + ex.Message);
            }
            return rel;
        }
        public int DeleteTable(string[] arr)
        {
            var t = "";
            var id = "";

            if (arr.Length == 3)
            {
                t = arr[1];
                id = arr[2];
            }
            else
            {
                throw new Exception("参数错误");
            }
            string sql = "delete from " + t + " where id = '" + id + "'";
            int rel = 0;
            try
            {
                rel = fsql.Ado.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(sql + "\r\n" + ex.Message);
            }
            return rel;
        }
        public int UpdateTable(string[] arr)
        {
            var t = "";
            var id = "";
            var v = "";
            if (arr.Length == 4)
            {
                t = arr[1];
                id = arr[2];
                v = arr[3];
            }
            else
            {
                throw new Exception("参数错误");
            }
            var arrs = v.Split(",");
            List<string> list = new List<string>();
            foreach (var item in arrs)
            {
                var ar = item.Split("=");
                list.Add(ar[0] + "='" + ar[1] + "'");
            }
            string sql = "update " + t + " set " + string.Join(",", list) + " where id = '" + id + "'";
            int rel = 0;
            try
            {
                rel = fsql.Ado.ExecuteNonQuery("update " + t + " set " + string.Join(",", list) + " where id = '" + id + "'");
            }
            catch (Exception ex)
            {
                throw new Exception(sql + "\r\n" + ex.Message);
            }
            return rel;
        }
    }
}
