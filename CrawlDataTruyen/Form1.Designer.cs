
namespace CrawlDataTruyen
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txbLinkTruyen = new System.Windows.Forms.TextBox();
            this.numStart = new System.Windows.Forms.NumericUpDown();
            this.btnCrawl = new System.Windows.Forms.Button();
            this.rtxbPreview = new System.Windows.Forms.RichTextBox();
            this.txbTitleChap = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.numWK = new System.Windows.Forms.NumericUpDown();
            this.numEND = new System.Windows.Forms.NumericUpDown();
            this.numIDTruyen = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTrangTruyen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbSaveDatabase = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numTimeCrawl = new System.Windows.Forms.NumericUpDown();
            this.lbCurrentTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIDTruyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeCrawl)).BeginInit();
            this.SuspendLayout();
            // 
            // txbLinkTruyen
            // 
            this.txbLinkTruyen.Location = new System.Drawing.Point(98, 6);
            this.txbLinkTruyen.Margin = new System.Windows.Forms.Padding(4);
            this.txbLinkTruyen.Name = "txbLinkTruyen";
            this.txbLinkTruyen.Size = new System.Drawing.Size(325, 27);
            this.txbLinkTruyen.TabIndex = 0;
            this.txbLinkTruyen.TextChanged += new System.EventHandler(this.txbLinkTruyen_TextChanged);
            // 
            // numStart
            // 
            this.numStart.Location = new System.Drawing.Point(501, 6);
            this.numStart.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStart.Name = "numStart";
            this.numStart.Size = new System.Drawing.Size(67, 27);
            this.numStart.TabIndex = 1;
            this.numStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStart.ValueChanged += new System.EventHandler(this.numStart_ValueChanged);
            // 
            // btnCrawl
            // 
            this.btnCrawl.BackColor = System.Drawing.Color.Green;
            this.btnCrawl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrawl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrawl.Location = new System.Drawing.Point(574, 6);
            this.btnCrawl.Name = "btnCrawl";
            this.btnCrawl.Size = new System.Drawing.Size(59, 27);
            this.btnCrawl.TabIndex = 8;
            this.btnCrawl.Text = "Crawl";
            this.btnCrawl.UseVisualStyleBackColor = false;
            this.btnCrawl.Click += new System.EventHandler(this.btnCrawl_Click);
            // 
            // rtxbPreview
            // 
            this.rtxbPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtxbPreview.Location = new System.Drawing.Point(0, 135);
            this.rtxbPreview.Name = "rtxbPreview";
            this.rtxbPreview.ReadOnly = true;
            this.rtxbPreview.Size = new System.Drawing.Size(635, 519);
            this.rtxbPreview.TabIndex = 12;
            this.rtxbPreview.Text = "";
            this.rtxbPreview.TextChanged += new System.EventHandler(this.rtxbPreview_TextChanged);
            // 
            // txbTitleChap
            // 
            this.txbTitleChap.Location = new System.Drawing.Point(2, 102);
            this.txbTitleChap.Name = "txbTitleChap";
            this.txbTitleChap.ReadOnly = true;
            this.txbTitleChap.Size = new System.Drawing.Size(630, 27);
            this.txbTitleChap.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(574, 39);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(59, 27);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // numWK
            // 
            this.numWK.Location = new System.Drawing.Point(209, 71);
            this.numWK.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numWK.Name = "numWK";
            this.numWK.ReadOnly = true;
            this.numWK.Size = new System.Drawing.Size(75, 27);
            this.numWK.TabIndex = 6;
            // 
            // numEND
            // 
            this.numEND.Location = new System.Drawing.Point(501, 39);
            this.numEND.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numEND.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEND.Name = "numEND";
            this.numEND.Size = new System.Drawing.Size(67, 27);
            this.numEND.TabIndex = 2;
            this.numEND.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numIDTruyen
            // 
            this.numIDTruyen.Location = new System.Drawing.Point(368, 38);
            this.numIDTruyen.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numIDTruyen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numIDTruyen.Name = "numIDTruyen";
            this.numIDTruyen.Size = new System.Drawing.Size(55, 27);
            this.numIDTruyen.TabIndex = 4;
            this.numIDTruyen.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Link truyện:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Trang truyện:";
            // 
            // cmbTrangTruyen
            // 
            this.cmbTrangTruyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangTruyen.FormattingEnabled = true;
            this.cmbTrangTruyen.Items.AddRange(new object[] {
            "https://truyenfull.vn/",
            "https://metruyenchu.com/",
            "https://truyenyy.vip/",
            "https://vtruyen.com/",
            "http://tangkinhcac.atwebpages.com/"});
            this.cmbTrangTruyen.Location = new System.Drawing.Point(98, 38);
            this.cmbTrangTruyen.Name = "cmbTrangTruyen";
            this.cmbTrangTruyen.Size = new System.Drawing.Size(180, 27);
            this.cmbTrangTruyen.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "ID truyện:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bắt đầu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kết thúc";
            // 
            // ckbSaveDatabase
            // 
            this.ckbSaveDatabase.AutoSize = true;
            this.ckbSaveDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckbSaveDatabase.Location = new System.Drawing.Point(3, 73);
            this.ckbSaveDatabase.Name = "ckbSaveDatabase";
            this.ckbSaveDatabase.Size = new System.Drawing.Size(128, 23);
            this.ckbSaveDatabase.TabIndex = 5;
            this.ckbSaveDatabase.Text = "Lưu vào CSDL";
            this.ckbSaveDatabase.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Aqua;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(574, 70);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(59, 27);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số chữ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "Time crawl:";
            // 
            // numTimeCrawl
            // 
            this.numTimeCrawl.Location = new System.Drawing.Point(395, 71);
            this.numTimeCrawl.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numTimeCrawl.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numTimeCrawl.Name = "numTimeCrawl";
            this.numTimeCrawl.Size = new System.Drawing.Size(75, 27);
            this.numTimeCrawl.TabIndex = 7;
            this.numTimeCrawl.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lbCurrentTime
            // 
            this.lbCurrentTime.ForeColor = System.Drawing.Color.Blue;
            this.lbCurrentTime.Location = new System.Drawing.Point(476, 74);
            this.lbCurrentTime.Name = "lbCurrentTime";
            this.lbCurrentTime.Size = new System.Drawing.Size(92, 23);
            this.lbCurrentTime.TabIndex = 12;
            this.lbCurrentTime.Text = "00:00:00";
            this.lbCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 654);
            this.Controls.Add(this.lbCurrentTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ckbSaveDatabase);
            this.Controls.Add(this.cmbTrangTruyen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numTimeCrawl);
            this.Controls.Add(this.numWK);
            this.Controls.Add(this.txbTitleChap);
            this.Controls.Add(this.rtxbPreview);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnCrawl);
            this.Controls.Add(this.numIDTruyen);
            this.Controls.Add(this.numEND);
            this.Controls.Add(this.numStart);
            this.Controls.Add(this.txbLinkTruyen);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crawl Truyện";
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIDTruyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeCrawl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbLinkTruyen;
        private System.Windows.Forms.NumericUpDown numStart;
        private System.Windows.Forms.Button btnCrawl;
        private System.Windows.Forms.RichTextBox rtxbPreview;
        private System.Windows.Forms.TextBox txbTitleChap;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown numWK;
        private System.Windows.Forms.NumericUpDown numEND;
        private System.Windows.Forms.NumericUpDown numIDTruyen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTrangTruyen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckbSaveDatabase;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numTimeCrawl;
        private System.Windows.Forms.Label lbCurrentTime;
    }
}

