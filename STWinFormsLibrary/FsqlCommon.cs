using FreeSql.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STWinFormsLibrary
{
    public static class FsqlCommon
    {
        public static IFreeSql Fsql;
        public static List<DataBase> Databases;
        public static void FsqlBuilder(string connName)
        {
            string connStr = FsqlCommon.Conns[connName].ToString();
            Fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, connStr)
            .Build();
            var dataBases = Fsql.DbFirst.GetDatabases();
            Databases = new List<DataBase>();
            DataBase dataBase = new DataBase();
            foreach (var item in dataBases)
            {
                var tables = Fsql.DbFirst.GetTablesByDatabase(item);
                dataBase = new DataBase()
                {
                    Name = item,
                    Tables = tables
                };
                Databases.Add(dataBase);
            }
        }
        private static ConnectionStringSettingsCollection conns;

        public static ConnectionStringSettingsCollection Conns
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings;
            }
            set => conns = value;
        }
    }
    public class DataBase
    {
        public string Name { get; set; }
        public List<DbTableInfo> Tables { get; set; }
    }
}
