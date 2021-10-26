using ISTService;
using STService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace STConsole
{
    class Program
    {
        public static IFreeSql fsql { get; private set; }
        static void Main(string[] args)
        {
            string cmd = "";
            List<string> cmds = new List<string> { "select", "update", "delete", "insert", "selectnew" };
            List<string> cmdsF = new List<string>();
            List<string> cmdsH = new List<string>();
            int cmdsHI = 0;
            int cmdsFI = 0;
            Console.WriteLine("Hello World!");

            fsql = new FreeSql.FreeSqlBuilder()
                            .UseConnectionString(FreeSql.DataType.SqlServer, @"Data Source=192.168.2.27;Initial Catalog=STDB;User ID=sa;Password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                            .Build();
            var t1 = fsql.DbFirst.GetDatabases();
            var t2 = fsql.DbFirst.GetTablesByDatabase("STDB");
            var t3 = fsql.DbFirst.GetTableByName("t1");
            cmds.AddRange(t2.Select(p => p.Name).ToList());
            t2.ForEach(p => cmds.AddRange(p.Columns.Select(p => p.Name).ToList()));
            cmds = cmds.Distinct().ToList();
            SelectService selectService = new SelectService(fsql);


            while (true)
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    var r = Console.ReadKey(true);
                    if (r.KeyChar == '\b' && cmd.Length == 0)
                    {
                        continue;
                    }
                    switch (r.Key)
                    {
                        case ConsoleKey.Tab:
                            if (cmdsF.Count == 0)
                            {
                                foreach (var c in cmds)
                                {
                                    if (c.StartsWith(cmd.Split(" ").Last()))
                                    {
                                        cmdsF.Add(c);
                                    }
                                }
                            }
                            else
                            {
                                if (cmdsF.Count == cmdsFI)
                                {
                                    cmdsFI = 0;
                                }
                            }
                            if (cmdsF.Count > 0)
                            {
                                cmd = cmd.Substring(0, cmd.Length - cmd.Split(" ").Last().Length) + cmdsF[cmdsFI];
                            }
                            cmdsFI++;
                            ClearCurrentConsoleLine();
                            Console.Write(cmd);
                            break;
                        case ConsoleKey.Enter:
                            cmdsFI = 0;
                            cmdsF = new List<string>();
                            Console.WriteLine();
                            break;
                        case ConsoleKey.Backspace:
                            cmdsFI = 0;
                            cmdsF = new List<string>();
                            cmd = cmd.Substring(0, cmd.Length - 1);
                            Console.Write("\b \b");
                            break;
                        case ConsoleKey.UpArrow:
                            cmdsFI = 0;
                            cmdsF = new List<string>();
                            if (cmdsHI > 0)
                            {
                                cmdsHI--;
                            }
                            cmd = cmdsH[cmdsHI]; 
                            ClearCurrentConsoleLine();
                            Console.Write(cmd);
                            break;
                        case ConsoleKey.DownArrow:
                            cmdsFI = 0;
                            cmdsF = new List<string>();
                            if (cmdsHI < cmdsH.Count)
                            {
                                cmdsHI++;
                            }
                            cmd = cmdsH[cmdsHI]; 
                            ClearCurrentConsoleLine();
                            Console.Write(cmd);
                            break;
                        default:
                            cmdsFI = 0;
                            cmdsF = new List<string>();
                            cmd += r.KeyChar.ToString();
                            Console.Write(r.KeyChar.ToString());
                            break;
                    }
                    if (r.Key == ConsoleKey.Enter)
                    {
                        cmdsH.Add(cmd);
                        cmdsHI = cmdsH.Count;
                        break;
                    }
                }


                //var str = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                var arr = cmd.Split(" ");
                cmd = "";
                try
                {
                    switch (arr[0].ToLower())
                    {
                        case "select":
                            var t4 = selectService.SelectTable(arr);
                            PrintTable(t4);
                            break;
                        case "insert":
                            var t5 = selectService.InsertTable(arr);
                            Console.WriteLine(t5);
                            break;
                        case "delete":
                            var t6 = selectService.DeleteTable(arr);
                            Console.WriteLine(t6);
                            break;
                        case "update":
                            var t7 = selectService.UpdateTable(arr);
                            Console.WriteLine(t7);
                            break;
                        default:
                            Console.WriteLine("无效命令");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        /// <summary>
        /// Print a DataTable on to the console
        /// </summary>
        /// <param name="table">the table to be printed</param>
        public static void PrintTable(DataTable table)
        {
            // print head
            PrintLine(12 * table.Columns.Count);
            foreach (DataColumn col in table.Columns)
            {
                Console.Write(string.Format("{0,12}", col.Caption));
            }
            Console.Write("\n");
            PrintLine(12 * table.Columns.Count);

            // print rows
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    Console.Write(string.Format("{0,12}", table.Rows[i][j].ToString()));
                }
                Console.Write("\n");
            }
            PrintLine(12 * table.Columns.Count, "-");
        }

        /// <summary>
        /// Print a line with specific char on to the console
        /// </summary>
        /// <param name="length">count of the char to be printed</param>
        /// <param name="lineChar">the char to be printed, default is "="</param>
        private static void PrintLine(int length, string lineChar = "=")
        {
            string line = string.Empty;
            for (int i = 0; i < length; i++)
            {
                line += lineChar;
            }
            Console.WriteLine(line);
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
