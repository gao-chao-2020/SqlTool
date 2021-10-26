using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STConsole
{
    public static class CmdTool
    {
        public static List<string> cmdsSet = new List<string> { "select", "update", "delete", "insert", "selectnew" };
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

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
    }
}
