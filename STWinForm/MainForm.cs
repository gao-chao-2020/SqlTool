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
            txt_TopCount.Text = 100.ToString();

            dgv_Tables.SelectionChanged += Dgv_Tables_SelectionChanged;
            dgv_tableInfo.CellValueChanged += Dgv_tableInfo_CellValueChanged;
            dgv_tableInfo.DataSourceChanged += Dgv_tableInfo_DataSourceChanged;
        }

        private void Dgv_tableInfo_DataSourceChanged(object sender, EventArgs e)
        {
            lab_ShowMsg.Text = "";
        }
        private void Dgv_tableInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lab_ShowMsg.Text = "";
                var columnName = dgv_tableInfo.Columns[dgv_tableInfo.CurrentCell.ColumnIndex].Name;
                var columnNewVal = dgv_tableInfo.CurrentCell.Value.ToString();
                var idName = FsqlCommon.Databases[cmb_ConnList.SelectedIndex].Tables.Where(p => p.Schema.ToLower() + "." + p.Name.ToLower() == FsqlCommon.TableName.ToLower()).FirstOrDefault().Primarys[0].Name;
                var id = dgv_tableInfo.Rows[dgv_tableInfo.CurrentCell.RowIndex].Cells[idName].Value.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    var sql = "update " + FsqlCommon.TableName + " set " + columnName + "=" + "'" + columnNewVal + "' where " + idName + "='" + id + "'";
                    lab_ShowMsg.Text = sql;
                    int rel = FsqlCommon.Fsql.Ado.ExecuteNonQuery(sql);
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                lab_ShowMsg.Text = ex.Message;
            }
        }

        private string GetTableBySql(string sql)
        {
            var sqlArr = new List<string>(sql.ToLower().Split(" "));
            var tableName = sqlArr[sqlArr.IndexOf("from") + 1];
            return tableName;
        }

        private void Dgv_Tables_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgv_Tables.SelectedCells.Count > 0 && !string.IsNullOrEmpty(this.dgv_Tables.SelectedCells[0].Value.ToString()))
            {
                var tableName = this.dgv_Tables.SelectedCells[0].Value.ToString();
                string sql = "select top " + txt_TopCount.Text + " * from " + tableName;
                txt_ShowSql.Text = sql;
                FsqlCommon.TableName = GetTableBySql(sql);
                DataTable dt = FsqlCommon.Fsql.Ado.ExecuteDataTable(sql);
                dgv_tableInfo.DataSource = dt;
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            var conn = FsqlCommon.Conns[1];
            try
            {
                FsqlCommon.FsqlBuilder(conn.Name);
                BindConnList();
                BindTables(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                dt.Rows.Add(item.Schema + "." + item.Name);
            }
            dgv_Tables.DataSource = dt;
        }

        private void cmb_ConnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FsqlCommon.FsqlBuilder(cmb_ConnList.Text);
            BindTables(cmb_ConnList.SelectedIndex);
        }

        private void btn_RunSql_Click(object sender, EventArgs e)
        {
            RunSql();
        }

        private void RunSql()
        {
            string sql = txt_ShowSql.Text;
            if (!string.IsNullOrEmpty(sql))
            {
                try
                {
                    FsqlCommon.TableName = GetTableBySql(sql);
                    lab_ShowMsg.Text = "";
                    DataTable dt = FsqlCommon.Fsql.Ado.ExecuteDataTable(sql);
                    dgv_tableInfo.DataSource = dt;
                }
                catch (Exception ex)
                {
                    lab_ShowMsg.Text = ex.Message;
                }
            }
        }

        private void btn_RunSql_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_ShowSql_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RunSql();
            }

        }
    }
}
