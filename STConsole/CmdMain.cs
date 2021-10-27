using ISTService;
using STService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STConsole
{
    public static class CmdMain
    {
        public static IFreeSql fsql { get; set; }
        public static void GetCMDInfo()
        {
            fsql = new FreeSql.FreeSqlBuilder()
                            .UseConnectionString(FreeSql.DataType.SqlServer, @"Data Source=192.168.2.27;Initial Catalog=STDB;User ID=sa;Password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                            .Build();
            var t1 = fsql.DbFirst.GetDatabases();
            var t2 = fsql.DbFirst.GetTablesByDatabase("STDB");
            var t3 = fsql.DbFirst.GetTableByName("t1");
            CmdTool.cmdsSet.AddRange(t2.Select(p => p.Name).ToList());
            t2.ForEach(p => CmdTool.cmdsSet.AddRange(p.Columns.Select(p => p.Name).ToList()));
            CmdTool.cmdsSet = CmdTool.cmdsSet.Distinct().ToList();

            string cmd = "";
            List<string> cmdsTab = new List<string>();
            List<string> cmdsHis = new List<string>();
            int cmdsTabI = 0;
            int cmdsHisI = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                var r = Console.ReadKey(true);
                //if (r.KeyChar == '\b' && cmd.Length == 0)
                //{
                //    continue;
                //}
                switch (r.Key)
                {
                    #region 输入
                    case ConsoleKey.D0:
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                    case ConsoleKey.D5:
                    case ConsoleKey.D6:
                    case ConsoleKey.D7:
                    case ConsoleKey.D8:
                    case ConsoleKey.D9:
                    case ConsoleKey.A:
                    case ConsoleKey.B:
                    case ConsoleKey.C:
                    case ConsoleKey.D:
                    case ConsoleKey.E:
                    case ConsoleKey.F:
                    case ConsoleKey.G:
                    case ConsoleKey.H:
                    case ConsoleKey.I:
                    case ConsoleKey.J:
                    case ConsoleKey.K:
                    case ConsoleKey.L:
                    case ConsoleKey.M:
                    case ConsoleKey.N:
                    case ConsoleKey.O:
                    case ConsoleKey.P:
                    case ConsoleKey.Q:
                    case ConsoleKey.R:
                    case ConsoleKey.S:
                    case ConsoleKey.T:
                    case ConsoleKey.U:
                    case ConsoleKey.V:
                    case ConsoleKey.W:
                    case ConsoleKey.X:
                    case ConsoleKey.Y:
                    case ConsoleKey.Z:
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.Multiply:
                    case ConsoleKey.Add:
                    case ConsoleKey.Separator:
                    case ConsoleKey.Subtract:
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Decimal:
                    case ConsoleKey.Divide:
                    case ConsoleKey.OemPlus:
                    case ConsoleKey.OemComma:
                    case ConsoleKey.OemMinus:
                    case ConsoleKey.OemPeriod:
                        cmdsTabI = 0;
                        cmdsTab = new List<string>();
                        cmd += r.KeyChar.ToString();
                        Console.Write(r.KeyChar.ToString());
                        break;
                    #endregion
                    #region 功能
                    case ConsoleKey.Backspace:
                        cmdsTabI = 0;
                        cmdsTab = new List<string>();
                        if (cmd.Length > 0)
                        {
                            cmd = cmd[0..^1];
                            Console.Write("\b \b");
                        }
                        break;
                    case ConsoleKey.Tab:
                        if (cmdsTab.Count == 0)
                        {
                            foreach (var c in CmdTool.cmdsSet)
                            {
                                if (c.StartsWith(cmd.Split(" ").Last()))
                                {
                                    cmdsTab.Add(c);
                                }
                            }
                        }
                        else
                        {
                            cmdsTabI++;
                            if (cmdsTab.Count <= cmdsTabI)
                            {
                                cmdsTabI = 0;
                            }
                        }
                        if (cmdsTab.Count > 0)
                        {
                            cmd = cmd.Substring(0, cmd.Length - cmd.Split(" ").Last().Length) + cmdsTab[cmdsTabI];
                        }
                        CmdTool.ClearCurrentConsoleLine();
                        Console.Write(cmd);
                        break;
                    case ConsoleKey.UpArrow:
                        cmdsTabI = 0;
                        cmdsTab = new List<string>();
                        if (cmdsHis.Count > 0)
                        {
                            cmdsTabI = 0;
                            cmdsTab = new List<string>();
                            if (cmdsHisI > 0)
                            {
                                cmdsHisI--;
                            }
                            cmd = cmdsHis[cmdsHisI];
                            CmdTool.ClearCurrentConsoleLine();
                            Console.Write(cmd);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        cmdsTabI = 0;
                        cmdsTab = new List<string>();
                        if (cmdsHis.Count > 0)
                        {
                            cmdsTabI = 0;
                            cmdsTab = new List<string>();
                            if (cmdsHisI < cmdsHis.Count - 1)
                            {
                                cmdsHisI++;
                            }
                            cmd = cmdsHis[cmdsHisI];
                            CmdTool.ClearCurrentConsoleLine();
                            Console.Write(cmd);
                        }
                        break;
                    case ConsoleKey.Enter:
                        cmdsTabI = 0;
                        cmdsTab = new List<string>();
                        cmdsHis.Add(cmd);
                        cmdsHisI = cmdsHis.Count;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Running...");
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            RunCMD(cmd);
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(ex.Message);
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("End");
                        cmd = "";
                        break;
                    case ConsoleKey.Clear:
                    case ConsoleKey.Pause:
                    case ConsoleKey.Escape:
                    case ConsoleKey.PageUp:
                    case ConsoleKey.PageDown:
                    case ConsoleKey.End:
                    case ConsoleKey.Home:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.Select:
                    case ConsoleKey.Print:
                    case ConsoleKey.Execute:
                    case ConsoleKey.PrintScreen:
                    case ConsoleKey.Insert:
                    case ConsoleKey.Delete:
                    case ConsoleKey.Help:
                    case ConsoleKey.LeftWindows:
                    case ConsoleKey.RightWindows:
                    case ConsoleKey.Applications:
                    case ConsoleKey.Sleep:
                    case ConsoleKey.F1:
                    case ConsoleKey.F2:
                    case ConsoleKey.F3:
                    case ConsoleKey.F4:
                    case ConsoleKey.F5:
                    case ConsoleKey.F6:
                    case ConsoleKey.F7:
                    case ConsoleKey.F8:
                    case ConsoleKey.F9:
                    case ConsoleKey.F10:
                    case ConsoleKey.F11:
                    case ConsoleKey.F12:
                    case ConsoleKey.F13:
                    case ConsoleKey.F14:
                    case ConsoleKey.F15:
                    case ConsoleKey.F16:
                    case ConsoleKey.F17:
                    case ConsoleKey.F18:
                    case ConsoleKey.F19:
                    case ConsoleKey.F20:
                    case ConsoleKey.F21:
                    case ConsoleKey.F22:
                    case ConsoleKey.F23:
                    case ConsoleKey.F24:
                    case ConsoleKey.BrowserBack:
                    case ConsoleKey.BrowserForward:
                    case ConsoleKey.BrowserRefresh:
                    case ConsoleKey.BrowserStop:
                    case ConsoleKey.BrowserSearch:
                    case ConsoleKey.BrowserFavorites:
                    case ConsoleKey.BrowserHome:
                    case ConsoleKey.VolumeMute:
                    case ConsoleKey.VolumeDown:
                    case ConsoleKey.VolumeUp:
                    case ConsoleKey.MediaNext:
                    case ConsoleKey.MediaPrevious:
                    case ConsoleKey.MediaStop:
                    case ConsoleKey.MediaPlay:
                    case ConsoleKey.LaunchMail:
                    case ConsoleKey.LaunchMediaSelect:
                    case ConsoleKey.LaunchApp1:
                    case ConsoleKey.LaunchApp2:
                    case ConsoleKey.Oem1:
                    case ConsoleKey.Oem2:
                    case ConsoleKey.Oem3:
                    case ConsoleKey.Oem4:
                    case ConsoleKey.Oem5:
                    case ConsoleKey.Oem6:
                    case ConsoleKey.Oem7:
                    case ConsoleKey.Oem8:
                    case ConsoleKey.Oem102:
                    case ConsoleKey.Process:
                    case ConsoleKey.Packet:
                    case ConsoleKey.Attention:
                    case ConsoleKey.CrSel:
                    case ConsoleKey.ExSel:
                    case ConsoleKey.EraseEndOfFile:
                    case ConsoleKey.Play:
                    case ConsoleKey.Zoom:
                    case ConsoleKey.NoName:
                    case ConsoleKey.Pa1:
                    case ConsoleKey.OemClear:
                    #endregion
                    default:
                        break;
                }
            }
        }

        private static void RunCMD(string cmd)
        {
            SelectService selectService = new SelectService(fsql);
            var arr = cmd.Split(" ");
            switch (arr.First().ToLower())
            {
                case "select":
                    var t4 = selectService.SelectTable(arr);
                    CmdTool.PrintTable(t4);
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("无效命令");
                    break;
            }
        }

    }
}
