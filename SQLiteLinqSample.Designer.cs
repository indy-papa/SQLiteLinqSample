namespace SQLiteLinqSample
{
    partial class SampleForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.txtDataId = new System.Windows.Forms.TextBox();
            this.lblDataId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchH_End = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchH_Start = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerchName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbxSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(3, 89);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 25;
            this.dgvList.Size = new System.Drawing.Size(794, 349);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellContentClick);
            // 
            // txtDataId
            // 
            this.txtDataId.Location = new System.Drawing.Point(50, 12);
            this.txtDataId.Name = "txtDataId";
            this.txtDataId.Size = new System.Drawing.Size(34, 23);
            this.txtDataId.TabIndex = 1;
            this.txtDataId.Text = "9999";
            // 
            // lblDataId
            // 
            this.lblDataId.AutoSize = true;
            this.lblDataId.Location = new System.Drawing.Point(3, 15);
            this.lblDataId.Name = "lblDataId";
            this.lblDataId.Size = new System.Drawing.Size(44, 15);
            this.lblDataId.TabIndex = 2;
            this.lblDataId.Text = "データID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "氏名";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 12);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(97, 23);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "あいうえおかきくけこ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "身長";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(253, 12);
            this.txtHeight.MaxLength = 6;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(43, 23);
            this.txtHeight.TabIndex = 5;
            this.txtHeight.Text = "999.99";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(300, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "データ登録";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnClick);
            // 
            // gbxSearch
            // 
            this.gbxSearch.Controls.Add(this.btnSearch);
            this.gbxSearch.Controls.Add(this.txtSearchH_End);
            this.gbxSearch.Controls.Add(this.label3);
            this.gbxSearch.Controls.Add(this.txtSearchH_Start);
            this.gbxSearch.Controls.Add(this.label4);
            this.gbxSearch.Controls.Add(this.txtSerchName);
            this.gbxSearch.Controls.Add(this.label5);
            this.gbxSearch.Location = new System.Drawing.Point(3, 42);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Size = new System.Drawing.Size(793, 43);
            this.gbxSearch.TabIndex = 8;
            this.gbxSearch.TabStop = false;
            this.gbxSearch.Text = "検索";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(282, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "データ検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnClick);
            // 
            // txtSearchH_End
            // 
            this.txtSearchH_End.Location = new System.Drawing.Point(233, 16);
            this.txtSearchH_End.MaxLength = 6;
            this.txtSearchH_End.Name = "txtSearchH_End";
            this.txtSearchH_End.Size = new System.Drawing.Size(43, 23);
            this.txtSearchH_End.TabIndex = 11;
            this.txtSearchH_End.Text = "999.99";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "身長";
            // 
            // txtSearchH_Start
            // 
            this.txtSearchH_Start.Location = new System.Drawing.Point(174, 16);
            this.txtSearchH_Start.MaxLength = 6;
            this.txtSearchH_Start.Name = "txtSearchH_Start";
            this.txtSearchH_Start.Size = new System.Drawing.Size(43, 23);
            this.txtSearchH_Start.TabIndex = 9;
            this.txtSearchH_Start.Text = "999.99";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "氏名";
            // 
            // txtSerchName
            // 
            this.txtSerchName.Location = new System.Drawing.Point(41, 16);
            this.txtSerchName.MaxLength = 20;
            this.txtSerchName.Name = "txtSerchName";
            this.txtSerchName.Size = new System.Drawing.Size(97, 23);
            this.txtSerchName.TabIndex = 7;
            this.txtSerchName.Text = "あいうえおかきくけこ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "～";
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbxSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDataId);
            this.Controls.Add(this.txtDataId);
            this.Controls.Add(this.dgvList);
            this.Name = "SampleForm";
            this.Text = "SQLite Linq Sample";
            this.Load += new System.EventHandler(this.FormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.gbxSearch.ResumeLayout(false);
            this.gbxSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvList;
        private TextBox txtDataId;
        private Label lblDataId;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtHeight;
        private Button btnSave;
        private GroupBox gbxSearch;
        private TextBox txtSearchH_End;
        private Label label3;
        private TextBox txtSearchH_Start;
        private Label label4;
        private TextBox txtSerchName;
        private Label label5;
        private Button btnSearch;
    }
}