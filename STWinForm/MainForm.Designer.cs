
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tableInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_ConnList
            // 
            this.cmb_ConnList.FormattingEnabled = true;
            this.cmb_ConnList.Location = new System.Drawing.Point(12, 41);
            this.cmb_ConnList.Name = "cmb_ConnList";
            this.cmb_ConnList.Size = new System.Drawing.Size(121, 25);
            this.cmb_ConnList.TabIndex = 0;
            this.cmb_ConnList.SelectedIndexChanged += new System.EventHandler(this.cmb_ConnList_SelectedIndexChanged);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(12, 12);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // dgv_Tables
            // 
            this.dgv_Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tables.Location = new System.Drawing.Point(12, 72);
            this.dgv_Tables.Name = "dgv_Tables";
            this.dgv_Tables.RowTemplate.Height = 25;
            this.dgv_Tables.Size = new System.Drawing.Size(211, 366);
            this.dgv_Tables.TabIndex = 2;
            // 
            // dgv_tableInfo
            // 
            this.dgv_tableInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tableInfo.Location = new System.Drawing.Point(229, 72);
            this.dgv_tableInfo.Name = "dgv_tableInfo";
            this.dgv_tableInfo.RowTemplate.Height = 25;
            this.dgv_tableInfo.Size = new System.Drawing.Size(559, 366);
            this.dgv_tableInfo.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_tableInfo);
            this.Controls.Add(this.dgv_Tables);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.cmb_ConnList);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tableInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_ConnList;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.DataGridView dgv_Tables;
        private System.Windows.Forms.DataGridView dgv_tableInfo;
    }
}