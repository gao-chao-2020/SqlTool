using STWinFormsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            cmb_ConnList.DropDownStyle = ComboBoxStyle.DropDownList;
            dgv_Tables.SelectionChanged += Dgv_Tables_SelectionChanged;
        }

        private void Dgv_Tables_SelectionChanged(object sender, EventArgs e)
        {
            var tableName = this.dgv_Tables.SelectedCells[0].Value.ToString();
            string sql = "select * from "+tableName;
            DataTable dt = FsqlCommon.Fsql.Ado.ExecuteDataTable(sql);
            dgv_tableInfo.DataSource = dt;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            var conn = FsqlCommon.Conns[1];
            FsqlCommon.FsqlBuilder(conn.Name);
            BindConnList();
            BindTables(0);
        }

        private void BindConnList()
        {
            IList<string> list = new List<string>();
            for (int i = 0; i < FsqlCommon.Databases.Count; i++)
            {
                list.Add(FsqlCommon.Databases[i].Name);
            }
            cmb_ConnList.DataSource = list;
        }
        private void BindTables(int index)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("表", typeof(String));
            var tables = FsqlCommon.Databases[index].Tables;
            foreach (var item in tables)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(item.Name);
            }
            dgv_Tables.DataSource = dt;
        }

        private void cmb_ConnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FsqlCommon.FsqlBuilder(cmb_ConnList.Text);
            BindTables(cmb_ConnList.SelectedIndex);
        }
    }
}
