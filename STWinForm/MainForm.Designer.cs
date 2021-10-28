
namespace STWinForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmb_ConnList = new System.Windows.Forms.ComboBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.dgv_Tables = new System.Windows.Forms.DataGridView();
            this.dgv_tableInfo = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_ShowMsg = new System.Windows.Forms.Label();
            this.btn_RunSql = new System.Windows.Forms.Button();
            this.txt_TopCount = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_ShowSql = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tableInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_ConnList
            // 
            this.cmb_ConnList.FormattingEnabled = true;
            this.cmb_ConnList.Location = new System.Drawing.Point(108, 4);
            this.cmb_ConnList.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ConnList.Name = "cmb_ConnList";
            this.cmb_ConnList.Size = new System.Drawing.Size(154, 28);
            this.cmb_ConnList.TabIndex = 0;
            this.cmb_ConnList.SelectedIndexChanged += new System.EventHandler(this.cmb_ConnList_SelectedIndexChanged);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(4, 4);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(96, 27);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // dgv_Tables
            // 
            this.dgv_Tables.AllowUserToAddRows = false;
            this.dgv_Tables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Tables.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tables.ColumnHeadersVisible = false;
            this.dgv_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Tables.Location = new System.Drawing.Point(0, 0);
            this.dgv_Tables.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Tables.MultiSelect = false;
            this.dgv_Tables.Name = "dgv_Tables";
            this.dgv_Tables.RowHeadersVisible = false;
            this.dgv_Tables.RowHeadersWidth = 51;
            this.dgv_Tables.RowTemplate.Height = 25;
            this.dgv_Tables.Size = new System.Drawing.Size(248, 484);
            this.dgv_Tables.TabIndex = 2;
            // 
            // dgv_tableInfo
            // 
            this.dgv_tableInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_tableInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tableInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_tableInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_tableInfo.Location = new System.Drawing.Point(0, 0);
            this.dgv_tableInfo.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_tableInfo.Name = "dgv_tableInfo";
            this.dgv_tableInfo.RowHeadersWidth = 51;
            this.dgv_tableInfo.RowTemplate.Height = 25;
            this.dgv_tableInfo.Size = new System.Drawing.Size(762, 412);
            this.dgv_tableInfo.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lab_ShowMsg);
            this.panel1.Controls.Add(this.btn_RunSql);
            this.panel1.Controls.Add(this.txt_TopCount);
            this.panel1.Controls.Add(this.cmb_ConnList);
            this.panel1.Controls.Add(this.btn_Connect);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 42);
            this.panel1.TabIndex = 4;
            // 
            // lab_ShowMsg
            // 
            this.lab_ShowMsg.AutoSize = true;
            this.lab_ShowMsg.Location = new System.Drawing.Point(407, 7);
            this.lab_ShowMsg.Name = "lab_ShowMsg";
            this.lab_ShowMsg.Size = new System.Drawing.Size(0, 20);
            this.lab_ShowMsg.TabIndex = 4;
            // 
            // btn_RunSql
            // 
            this.btn_RunSql.Location = new System.Drawing.Point(346, 4);
            this.btn_RunSql.Name = "btn_RunSql";
            this.btn_RunSql.Size = new System.Drawing.Size(55, 29);
            this.btn_RunSql.TabIndex = 3;
            this.btn_RunSql.Text = "run";
            this.btn_RunSql.UseVisualStyleBackColor = true;
            this.btn_RunSql.Click += new System.EventHandler(this.btn_RunSql_Click);
            this.btn_RunSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_RunSql_KeyDown);
            // 
            // txt_TopCount
            // 
            this.txt_TopCount.Location = new System.Drawing.Point(270, 4);
            this.txt_TopCount.Name = "txt_TopCount";
            this.txt_TopCount.Size = new System.Drawing.Size(70, 27);
            this.txt_TopCount.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.dgv_Tables);
            this.panel2.Location = new System.Drawing.Point(12, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 484);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dgv_tableInfo);
            this.panel3.Location = new System.Drawing.Point(267, 132);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(762, 412);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.txt_ShowSql);
            this.panel4.Location = new System.Drawing.Point(268, 61);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(761, 64);
            this.panel4.TabIndex = 7;
            // 
            // txt_ShowSql
            // 
            this.txt_ShowSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ShowSql.Location = new System.Drawing.Point(4, 4);
            this.txt_ShowSql.Multiline = true;
            this.txt_ShowSql.Name = "txt_ShowSql";
            this.txt_ShowSql.Size = new System.Drawing.Size(754, 57);
            this.txt_ShowSql.TabIndex = 0;
            this.txt_ShowSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ShowSql_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 556);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tableInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_ConnList;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.DataGridView dgv_Tables;
        private System.Windows.Forms.DataGridView dgv_tableInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_TopCount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txt_ShowSql;
        private System.Windows.Forms.Button btn_RunSql;
        private System.Windows.Forms.Label lab_ShowMsg;
    }
}