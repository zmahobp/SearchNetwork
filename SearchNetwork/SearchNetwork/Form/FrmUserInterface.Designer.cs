
namespace SearchNetwork
{
    partial class FrmUserInterface
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.tbxParameter = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.tbxGroup = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lvResults = new System.Windows.Forms.ListView();
            this.ipAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.macAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.connected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(224, 50);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(88, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Group ( optional )";
            // 
            // tbxParameter
            // 
            this.tbxParameter.Location = new System.Drawing.Point(25, 67);
            this.tbxParameter.Name = "tbxParameter";
            this.tbxParameter.Size = new System.Drawing.Size(160, 20);
            this.tbxParameter.TabIndex = 1;
            this.tbxParameter.TextChanged += new System.EventHandler(this.tBx2_TextChanged);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(22, 50);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(137, 13);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Parameter name ( required )";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.lblWarning);
            this.groupBox1.Controls.Add(this.tbxGroup);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lbl3);
            this.groupBox1.Controls.Add(this.lbl2);
            this.groupBox1.Controls.Add(this.tbxParameter);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Location = new System.Drawing.Point(50, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 105);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devices";
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Location = new System.Drawing.Point(411, 50);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(0, 13);
            this.lblWarning.TabIndex = 5;
            // 
            // tbxGroup
            // 
            this.tbxGroup.Location = new System.Drawing.Point(227, 67);
            this.tbxGroup.Name = "tbxGroup";
            this.tbxGroup.Size = new System.Drawing.Size(151, 20);
            this.tbxGroup.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(414, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(22, 27);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(84, 13);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "Search devices:";
            // 
            // lvResults
            // 
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ipAddress,
            this.macAddress,
            this.connected,
            this.value});
            this.lvResults.HideSelection = false;
            this.lvResults.Location = new System.Drawing.Point(50, 159);
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(688, 411);
            this.lvResults.TabIndex = 5;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            // 
            // ipAddress
            // 
            this.ipAddress.Tag = "1";
            this.ipAddress.Text = "IP adress";
            this.ipAddress.Width = 167;
            // 
            // macAddress
            // 
            this.macAddress.Tag = "1";
            this.macAddress.Text = "MAC address";
            this.macAddress.Width = 177;
            // 
            // connected
            // 
            this.connected.Tag = "1";
            this.connected.Text = "Connected";
            this.connected.Width = 179;
            // 
            // value
            // 
            this.value.Text = "Value";
            this.value.Width = 92;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.LawnGreen;
            this.progressBar.Location = new System.Drawing.Point(50, 135);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(688, 18);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 6;
            this.progressBar.Value = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(512, 64);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FrmUserInterface
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 630);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lvResults);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmUserInterface";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.FrmUserInterface_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox tbxParameter;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.TextBox tbxGroup;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.ColumnHeader ipAddress;
        private System.Windows.Forms.ColumnHeader macAddress;
        private System.Windows.Forms.ColumnHeader connected;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnClear;
    }
}

