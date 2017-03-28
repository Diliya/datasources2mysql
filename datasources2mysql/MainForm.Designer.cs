namespace datasources2mysql
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnOpenPath = new System.Windows.Forms.Button();
            this.lbStatusRep = new System.Windows.Forms.Label();
            this.btnStartEx = new System.Windows.Forms.Button();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateStop = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSources = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRenew = new System.Windows.Forms.Button();
            this.cmbContract = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择数据源路径：";
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPath.Location = new System.Drawing.Point(202, 24);
            this.txtPath.Margin = new System.Windows.Forms.Padding(5);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(323, 26);
            this.txtPath.TabIndex = 1;
            // 
            // btnOpenPath
            // 
            this.btnOpenPath.Location = new System.Drawing.Point(531, 22);
            this.btnOpenPath.Name = "btnOpenPath";
            this.btnOpenPath.Size = new System.Drawing.Size(37, 29);
            this.btnOpenPath.TabIndex = 2;
            this.btnOpenPath.Text = "...";
            this.btnOpenPath.UseVisualStyleBackColor = true;
            this.btnOpenPath.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbStatusRep
            // 
            this.lbStatusRep.AutoSize = true;
            this.lbStatusRep.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStatusRep.Location = new System.Drawing.Point(13, 76);
            this.lbStatusRep.Name = "lbStatusRep";
            this.lbStatusRep.Size = new System.Drawing.Size(152, 16);
            this.lbStatusRep.TabIndex = 3;
            this.lbStatusRep.Text = "请先选择一个数据源";
            // 
            // btnStartEx
            // 
            this.btnStartEx.Location = new System.Drawing.Point(493, 162);
            this.btnStartEx.Name = "btnStartEx";
            this.btnStartEx.Size = new System.Drawing.Size(75, 73);
            this.btnStartEx.TabIndex = 4;
            this.btnStartEx.Text = "开始转换";
            this.btnStartEx.UseVisualStyleBackColor = true;
            this.btnStartEx.Click += new System.EventHandler(this.btnStartEx_Click);
            // 
            // dateStart
            // 
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStart.Location = new System.Drawing.Point(93, 162);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(200, 21);
            this.dateStart.TabIndex = 5;
            // 
            // dateStop
            // 
            this.dateStop.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStop.Location = new System.Drawing.Point(93, 219);
            this.dateStop.Name = "dateStop";
            this.dateStop.Size = new System.Drawing.Size(200, 21);
            this.dateStop.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "起始日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "结束日期";
            // 
            // cmbSources
            // 
            this.cmbSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSources.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSources.FormattingEnabled = true;
            this.cmbSources.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbSources.Location = new System.Drawing.Point(447, 72);
            this.cmbSources.Name = "cmbSources";
            this.cmbSources.Size = new System.Drawing.Size(121, 20);
            this.cmbSources.TabIndex = 10;
            this.cmbSources.Visible = false;
            this.cmbSources.SelectedValueChanged += new System.EventHandler(this.cmbSources_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "已选择数据源：";
            // 
            // btnRenew
            // 
            this.btnRenew.Location = new System.Drawing.Point(16, 367);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(75, 23);
            this.btnRenew.TabIndex = 12;
            this.btnRenew.Text = "重置";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // cmbContract
            // 
            this.cmbContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbContract.FormattingEnabled = true;
            this.cmbContract.Location = new System.Drawing.Point(447, 121);
            this.cmbContract.Name = "cmbContract";
            this.cmbContract.Size = new System.Drawing.Size(121, 20);
            this.cmbContract.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "已选择合约：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 402);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbContract);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSources);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateStop);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.btnStartEx);
            this.Controls.Add(this.lbStatusRep);
            this.Controls.Add(this.btnOpenPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "数据转换";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnOpenPath;
        private System.Windows.Forms.Label lbStatusRep;
        private System.Windows.Forms.Button btnStartEx;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSources;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.ComboBox cmbContract;
        private System.Windows.Forms.Label label5;

    }
}

