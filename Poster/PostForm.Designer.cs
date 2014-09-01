namespace Achievo.Poster
{
    partial class PostForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbHosts = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnDeleteHistory = new System.Windows.Forms.Button();
            this.txtSaveAs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveHistory = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbURL = new System.Windows.Forms.ComboBox();
            this.txtRequestUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPut = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkReplaceHeader = new System.Windows.Forms.CheckBox();
            this.txtRequestHeader = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRequestBody = new System.Windows.Forms.RichTextBox();
            this.groupResponse = new System.Windows.Forms.GroupBox();
            this.txtResponse = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Thread = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Elapsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtResponseHeader = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHttpExecution = new System.Windows.Forms.TabPage();
            this.tabHeaderSetting = new System.Windows.Forms.TabPage();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbHostsTab2 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAccessKey = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEnvironment = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAgency = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGenerateToken = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtResponseToken = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRequestUrlForGettingToken = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRequestBodyForGettingToken = new System.Windows.Forms.TextBox();
            this.txtAppSecret = new System.Windows.Forms.TextBox();
            this.txtAppID = new System.Windows.Forms.TextBox();
            this.txtContentType = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabHost = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAllHosts = new System.Windows.Forms.TextBox();
            this.btnHostSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupResponse.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabHttpExecution.SuspendLayout();
            this.tabHeaderSetting.SuspendLayout();
            this.tabHost.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbHosts);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbURL);
            this.groupBox1.Controls.Add(this.txtRequestUrl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(845, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // cmbHosts
            // 
            this.cmbHosts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHosts.FormattingEnabled = true;
            this.cmbHosts.Items.AddRange(new object[] {
            "None",
            "Dev(apps-apis.dev.accela.com)",
            "Stage(apis.dev.accela.com)",
            "Prod(apis.accela.com)"});
            this.cmbHosts.Location = new System.Drawing.Point(73, 23);
            this.cmbHosts.Name = "cmbHosts";
            this.cmbHosts.Size = new System.Drawing.Size(121, 21);
            this.cmbHosts.TabIndex = 8;
            this.cmbHosts.SelectedIndexChanged += new System.EventHandler(this.cmbHosts_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnDeleteHistory);
            this.groupBox6.Controls.Add(this.txtSaveAs);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.btnSaveHistory);
            this.groupBox6.Location = new System.Drawing.Point(384, 86);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(458, 54);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Request Save";
            // 
            // btnDeleteHistory
            // 
            this.btnDeleteHistory.Location = new System.Drawing.Point(405, 21);
            this.btnDeleteHistory.Name = "btnDeleteHistory";
            this.btnDeleteHistory.Size = new System.Drawing.Size(47, 23);
            this.btnDeleteHistory.TabIndex = 5;
            this.btnDeleteHistory.Text = "Delete";
            this.btnDeleteHistory.UseVisualStyleBackColor = true;
            this.btnDeleteHistory.Click += new System.EventHandler(this.btnDeleteHistory_Click);
            // 
            // txtSaveAs
            // 
            this.txtSaveAs.Location = new System.Drawing.Point(40, 24);
            this.txtSaveAs.Name = "txtSaveAs";
            this.txtSaveAs.Size = new System.Drawing.Size(307, 20);
            this.txtSaveAs.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name:";
            // 
            // btnSaveHistory
            // 
            this.btnSaveHistory.Location = new System.Drawing.Point(353, 21);
            this.btnSaveHistory.Name = "btnSaveHistory";
            this.btnSaveHistory.Size = new System.Drawing.Size(46, 23);
            this.btnSaveHistory.TabIndex = 2;
            this.btnSaveHistory.Text = "Save";
            this.btnSaveHistory.UseVisualStyleBackColor = true;
            this.btnSaveHistory.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(79, 59);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Concurrent:";
            // 
            // cmbURL
            // 
            this.cmbURL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbURL.FormattingEnabled = true;
            this.cmbURL.Location = new System.Drawing.Point(192, 56);
            this.cmbURL.Name = "cmbURL";
            this.cmbURL.Size = new System.Drawing.Size(650, 21);
            this.cmbURL.TabIndex = 2;
            this.cmbURL.SelectedIndexChanged += new System.EventHandler(this.cmbURL_SelectedIndexChanged);
            // 
            // txtRequestUrl
            // 
            this.txtRequestUrl.Location = new System.Drawing.Point(195, 23);
            this.txtRequestUrl.Name = "txtRequestUrl";
            this.txtRequestUrl.Size = new System.Drawing.Size(647, 20);
            this.txtRequestUrl.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Favorites:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnPut);
            this.groupBox2.Controls.Add(this.btnPost);
            this.groupBox2.Controls.Add(this.btnGet);
            this.groupBox2.Location = new System.Drawing.Point(9, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HTTP Verb";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(268, 22);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPut
            // 
            this.btnPut.Location = new System.Drawing.Point(183, 22);
            this.btnPut.Name = "btnPut";
            this.btnPut.Size = new System.Drawing.Size(75, 23);
            this.btnPut.TabIndex = 5;
            this.btnPut.Text = "Put";
            this.btnPut.UseVisualStyleBackColor = true;
            this.btnPut.Click += new System.EventHandler(this.btnPut_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(98, 22);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 1;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(13, 22);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 0;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Request URL:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkReplaceHeader);
            this.groupBox3.Controls.Add(this.txtRequestHeader);
            this.groupBox3.Location = new System.Drawing.Point(3, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 177);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Request Header";
            // 
            // chkReplaceHeader
            // 
            this.chkReplaceHeader.AutoSize = true;
            this.chkReplaceHeader.Checked = true;
            this.chkReplaceHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReplaceHeader.Location = new System.Drawing.Point(12, 16);
            this.chkReplaceHeader.Name = "chkReplaceHeader";
            this.chkReplaceHeader.Size = new System.Drawing.Size(250, 17);
            this.chkReplaceHeader.TabIndex = 1;
            this.chkReplaceHeader.Text = "Replace header with shared http header setting";
            this.chkReplaceHeader.UseVisualStyleBackColor = true;
            // 
            // txtRequestHeader
            // 
            this.txtRequestHeader.Location = new System.Drawing.Point(8, 39);
            this.txtRequestHeader.Name = "txtRequestHeader";
            this.txtRequestHeader.Size = new System.Drawing.Size(362, 129);
            this.txtRequestHeader.TabIndex = 0;
            this.txtRequestHeader.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtRequestBody);
            this.groupBox4.Location = new System.Drawing.Point(387, 155);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(460, 177);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Request Body";
            // 
            // txtRequestBody
            // 
            this.txtRequestBody.Location = new System.Drawing.Point(6, 19);
            this.txtRequestBody.Name = "txtRequestBody";
            this.txtRequestBody.Size = new System.Drawing.Size(448, 149);
            this.txtRequestBody.TabIndex = 1;
            this.txtRequestBody.Text = "";
            // 
            // groupResponse
            // 
            this.groupResponse.Controls.Add(this.txtResponse);
            this.groupResponse.Location = new System.Drawing.Point(3, 459);
            this.groupResponse.Name = "groupResponse";
            this.groupResponse.Size = new System.Drawing.Size(666, 342);
            this.groupResponse.TabIndex = 5;
            this.groupResponse.TabStop = false;
            this.groupResponse.Text = "Response Body";
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(3, 19);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(662, 288);
            this.txtResponse.TabIndex = 2;
            this.txtResponse.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listView1);
            this.groupBox5.Location = new System.Drawing.Point(675, 332);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(170, 469);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Concurrent";
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Thread,
            this.Elapsed});
            this.listView1.Location = new System.Drawing.Point(6, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(158, 444);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Thread
            // 
            this.Thread.Text = "Thread";
            // 
            // Elapsed
            // 
            this.Elapsed.Text = "Elapsed(ms)";
            this.Elapsed.Width = 90;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtResponseHeader);
            this.groupBox7.Location = new System.Drawing.Point(3, 332);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(665, 121);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Response Http Header";
            // 
            // txtResponseHeader
            // 
            this.txtResponseHeader.Location = new System.Drawing.Point(6, 18);
            this.txtResponseHeader.Multiline = true;
            this.txtResponseHeader.Name = "txtResponseHeader";
            this.txtResponseHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponseHeader.Size = new System.Drawing.Size(651, 92);
            this.txtResponseHeader.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHttpExecution);
            this.tabControl1.Controls.Add(this.tabHeaderSetting);
            this.tabControl1.Controls.Add(this.tabHost);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(879, 798);
            this.tabControl1.TabIndex = 8;
            // 
            // tabHttpExecution
            // 
            this.tabHttpExecution.Controls.Add(this.groupBox1);
            this.tabHttpExecution.Controls.Add(this.groupResponse);
            this.tabHttpExecution.Controls.Add(this.groupBox3);
            this.tabHttpExecution.Controls.Add(this.groupBox7);
            this.tabHttpExecution.Controls.Add(this.groupBox4);
            this.tabHttpExecution.Controls.Add(this.groupBox5);
            this.tabHttpExecution.Location = new System.Drawing.Point(4, 22);
            this.tabHttpExecution.Name = "tabHttpExecution";
            this.tabHttpExecution.Padding = new System.Windows.Forms.Padding(3);
            this.tabHttpExecution.Size = new System.Drawing.Size(871, 772);
            this.tabHttpExecution.TabIndex = 0;
            this.tabHttpExecution.Text = "Http Execution";
            this.tabHttpExecution.UseVisualStyleBackColor = true;
            // 
            // tabHeaderSetting
            // 
            this.tabHeaderSetting.Controls.Add(this.btnSaveSettings);
            this.tabHeaderSetting.Controls.Add(this.label26);
            this.tabHeaderSetting.Controls.Add(this.label25);
            this.tabHeaderSetting.Controls.Add(this.label24);
            this.tabHeaderSetting.Controls.Add(this.label23);
            this.tabHeaderSetting.Controls.Add(this.label22);
            this.tabHeaderSetting.Controls.Add(this.label21);
            this.tabHeaderSetting.Controls.Add(this.label20);
            this.tabHeaderSetting.Controls.Add(this.label19);
            this.tabHeaderSetting.Controls.Add(this.label18);
            this.tabHeaderSetting.Controls.Add(this.cmbHostsTab2);
            this.tabHeaderSetting.Controls.Add(this.label16);
            this.tabHeaderSetting.Controls.Add(this.txtAccessKey);
            this.tabHeaderSetting.Controls.Add(this.label15);
            this.tabHeaderSetting.Controls.Add(this.txtEnvironment);
            this.tabHeaderSetting.Controls.Add(this.label14);
            this.tabHeaderSetting.Controls.Add(this.txtAgency);
            this.tabHeaderSetting.Controls.Add(this.label13);
            this.tabHeaderSetting.Controls.Add(this.btnGenerateToken);
            this.tabHeaderSetting.Controls.Add(this.label12);
            this.tabHeaderSetting.Controls.Add(this.txtResponseToken);
            this.tabHeaderSetting.Controls.Add(this.label11);
            this.tabHeaderSetting.Controls.Add(this.txtRequestUrlForGettingToken);
            this.tabHeaderSetting.Controls.Add(this.label10);
            this.tabHeaderSetting.Controls.Add(this.label9);
            this.tabHeaderSetting.Controls.Add(this.txtRequestBodyForGettingToken);
            this.tabHeaderSetting.Controls.Add(this.txtAppSecret);
            this.tabHeaderSetting.Controls.Add(this.txtAppID);
            this.tabHeaderSetting.Controls.Add(this.txtContentType);
            this.tabHeaderSetting.Controls.Add(this.label8);
            this.tabHeaderSetting.Controls.Add(this.label7);
            this.tabHeaderSetting.Controls.Add(this.label6);
            this.tabHeaderSetting.Controls.Add(this.label5);
            this.tabHeaderSetting.Location = new System.Drawing.Point(4, 22);
            this.tabHeaderSetting.Name = "tabHeaderSetting";
            this.tabHeaderSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabHeaderSetting.Size = new System.Drawing.Size(871, 772);
            this.tabHeaderSetting.TabIndex = 1;
            this.tabHeaderSetting.Text = "Shared Http Header Setting";
            this.tabHeaderSetting.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(138, 467);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaveSettings.Size = new System.Drawing.Size(233, 23);
            this.btnSaveSettings.TabIndex = 33;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(681, 325);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(11, 13);
            this.label26.TabIndex = 32;
            this.label26.Text = "*";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(681, 276);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(11, 13);
            this.label25.TabIndex = 31;
            this.label25.Text = "*";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(681, 81);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(11, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(681, 176);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 13);
            this.label23.TabIndex = 29;
            this.label23.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(681, 143);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 13);
            this.label22.TabIndex = 28;
            this.label22.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(681, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 13);
            this.label21.TabIndex = 27;
            this.label21.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(681, 114);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 13);
            this.label20.TabIndex = 26;
            this.label20.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(755, 212);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 13);
            this.label19.TabIndex = 25;
            this.label19.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(681, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "*";
            // 
            // cmbHostsTab2
            // 
            this.cmbHostsTab2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHostsTab2.FormattingEnabled = true;
            this.cmbHostsTab2.Location = new System.Drawing.Point(138, 14);
            this.cmbHostsTab2.Name = "cmbHostsTab2";
            this.cmbHostsTab2.Size = new System.Drawing.Size(537, 21);
            this.cmbHostsTab2.TabIndex = 23;
            this.cmbHostsTab2.SelectedIndexChanged += new System.EventHandler(this.cmbHostsTab2_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Host:";
            // 
            // txtAccessKey
            // 
            this.txtAccessKey.Location = new System.Drawing.Point(185, 209);
            this.txtAccessKey.Name = "txtAccessKey";
            this.txtAccessKey.Size = new System.Drawing.Size(564, 20);
            this.txtAccessKey.TabIndex = 21;
            this.txtAccessKey.Text = "dhHeALUHMuBK+kC5lQktCwJINpSpLGIbsm96LFJ5GVOJErOH/TIRVQO+jh/SaNlMZ/noLpf4Zdd1d3Ts/" +
    "muWCQ==";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 214);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(156, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "x-accela-subsystem-accesskey:";
            // 
            // txtEnvironment
            // 
            this.txtEnvironment.Location = new System.Drawing.Point(138, 169);
            this.txtEnvironment.Name = "txtEnvironment";
            this.txtEnvironment.Size = new System.Drawing.Size(537, 20);
            this.txtEnvironment.TabIndex = 19;
            this.txtEnvironment.Text = "PROD";
            this.txtEnvironment.TextChanged += new System.EventHandler(this.txtEnvironment_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 174);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "x-accela-environment:";
            // 
            // txtAgency
            // 
            this.txtAgency.Location = new System.Drawing.Point(138, 136);
            this.txtAgency.Name = "txtAgency";
            this.txtAgency.Size = new System.Drawing.Size(537, 20);
            this.txtAgency.TabIndex = 17;
            this.txtAgency.Text = "BPTDEV-ENG";
            this.txtAgency.TextChanged += new System.EventHandler(this.txtAgency_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "x-accela-agency:";
            // 
            // btnGenerateToken
            // 
            this.btnGenerateToken.Location = new System.Drawing.Point(429, 468);
            this.btnGenerateToken.Name = "btnGenerateToken";
            this.btnGenerateToken.Size = new System.Drawing.Size(246, 23);
            this.btnGenerateToken.TabIndex = 15;
            this.btnGenerateToken.Text = "Generate  and Save Access Token";
            this.btnGenerateToken.UseVisualStyleBackColor = true;
            this.btnGenerateToken.Click += new System.EventHandler(this.btnGenerateToken_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 510);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Access Token:";
            // 
            // txtResponseToken
            // 
            this.txtResponseToken.Location = new System.Drawing.Point(138, 507);
            this.txtResponseToken.Multiline = true;
            this.txtResponseToken.Name = "txtResponseToken";
            this.txtResponseToken.Size = new System.Drawing.Size(537, 253);
            this.txtResponseToken.TabIndex = 13;
            this.txtResponseToken.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResponseToken_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Request Body:";
            // 
            // txtRequestUrlForGettingToken
            // 
            this.txtRequestUrlForGettingToken.Location = new System.Drawing.Point(138, 273);
            this.txtRequestUrlForGettingToken.Name = "txtRequestUrlForGettingToken";
            this.txtRequestUrlForGettingToken.Size = new System.Drawing.Size(537, 20);
            this.txtRequestUrlForGettingToken.TabIndex = 11;
            this.txtRequestUrlForGettingToken.Text = "https://apps-apis.dev.accela.com/oauth2/token";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 276);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Request Url:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(216, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Request Body for Getting an Access Token:";
            // 
            // txtRequestBodyForGettingToken
            // 
            this.txtRequestBodyForGettingToken.Location = new System.Drawing.Point(138, 322);
            this.txtRequestBodyForGettingToken.Multiline = true;
            this.txtRequestBodyForGettingToken.Name = "txtRequestBodyForGettingToken";
            this.txtRequestBodyForGettingToken.Size = new System.Drawing.Size(537, 139);
            this.txtRequestBodyForGettingToken.TabIndex = 8;
            this.txtRequestBodyForGettingToken.Text = resources.GetString("txtRequestBodyForGettingToken.Text");
            this.txtRequestBodyForGettingToken.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRequestBodyForGettingToken_KeyDown);
            // 
            // txtAppSecret
            // 
            this.txtAppSecret.Location = new System.Drawing.Point(138, 107);
            this.txtAppSecret.Name = "txtAppSecret";
            this.txtAppSecret.Size = new System.Drawing.Size(537, 20);
            this.txtAppSecret.TabIndex = 7;
            this.txtAppSecret.Text = "f5a0b0c9b9824dd9ac95677494006913";
            this.txtAppSecret.TextChanged += new System.EventHandler(this.txtAppSecret_TextChanged);
            // 
            // txtAppID
            // 
            this.txtAppID.Location = new System.Drawing.Point(138, 74);
            this.txtAppID.Name = "txtAppID";
            this.txtAppID.Size = new System.Drawing.Size(537, 20);
            this.txtAppID.TabIndex = 5;
            this.txtAppID.Text = "634787061125751953";
            this.txtAppID.TextChanged += new System.EventHandler(this.txtAppID_TextChanged);
            // 
            // txtContentType
            // 
            this.txtContentType.Location = new System.Drawing.Point(138, 42);
            this.txtContentType.Name = "txtContentType";
            this.txtContentType.Size = new System.Drawing.Size(537, 20);
            this.txtContentType.TabIndex = 4;
            this.txtContentType.Text = "application/json";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "x-accela-appsecret:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "x-accela-appid:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Content-Type:";
            // 
            // tabHost
            // 
            this.tabHost.Controls.Add(this.label17);
            this.tabHost.Controls.Add(this.txtAllHosts);
            this.tabHost.Controls.Add(this.btnHostSave);
            this.tabHost.Location = new System.Drawing.Point(4, 22);
            this.tabHost.Name = "tabHost";
            this.tabHost.Size = new System.Drawing.Size(871, 772);
            this.tabHost.TabIndex = 2;
            this.tabHost.Text = "Host Configuration";
            this.tabHost.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(28, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(215, 39);
            this.label17.TabIndex = 3;
            this.label17.Text = "e.g:\r\nlocalhost http://localhost\r\napps-apis https://apps-apis.dev.accela.com\r\n";
            // 
            // txtAllHosts
            // 
            this.txtAllHosts.Location = new System.Drawing.Point(31, 101);
            this.txtAllHosts.Multiline = true;
            this.txtAllHosts.Name = "txtAllHosts";
            this.txtAllHosts.Size = new System.Drawing.Size(809, 201);
            this.txtAllHosts.TabIndex = 2;
            this.txtAllHosts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAllHosts_KeyDown);
            // 
            // btnHostSave
            // 
            this.btnHostSave.Location = new System.Drawing.Point(325, 326);
            this.btnHostSave.Name = "btnHostSave";
            this.btnHostSave.Size = new System.Drawing.Size(136, 23);
            this.btnHostSave.TabIndex = 1;
            this.btnHostSave.Text = "Save";
            this.btnHostSave.UseVisualStyleBackColor = true;
            this.btnHostSave.Click += new System.EventHandler(this.btnHostSave_Click);
            // 
            // PostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 810);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Http Poster";
            this.Load += new System.EventHandler(this.PostForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupResponse.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabHttpExecution.ResumeLayout(false);
            this.tabHeaderSetting.ResumeLayout(false);
            this.tabHeaderSetting.PerformLayout();
            this.tabHost.ResumeLayout(false);
            this.tabHost.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtRequestHeader;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox txtRequestBody;
        private System.Windows.Forms.GroupBox groupResponse;
        private System.Windows.Forms.RichTextBox txtResponse;
        private System.Windows.Forms.ComboBox cmbURL;
        private System.Windows.Forms.TextBox txtSaveAs;
        private System.Windows.Forms.Button btnSaveHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRequestUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Thread;
        private System.Windows.Forms.ColumnHeader Elapsed;
        private System.Windows.Forms.Button btnPut;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDeleteHistory;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtResponseHeader;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHttpExecution;
        private System.Windows.Forms.TabPage tabHeaderSetting;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtResponseToken;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRequestUrlForGettingToken;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRequestBodyForGettingToken;
        private System.Windows.Forms.TextBox txtAppSecret;
        private System.Windows.Forms.TextBox txtAppID;
        private System.Windows.Forms.TextBox txtContentType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerateToken;
        private System.Windows.Forms.CheckBox chkReplaceHeader;
        private System.Windows.Forms.TextBox txtEnvironment;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAgency;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAccessKey;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbHosts;
        private System.Windows.Forms.ComboBox cmbHostsTab2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tabHost;
        private System.Windows.Forms.Button btnHostSave;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtAllHosts;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}

