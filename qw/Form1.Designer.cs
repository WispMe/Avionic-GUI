namespace qw
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.openGLControl1 = new SharpGL.OpenGLControl();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.freezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unfreezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wireframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.solidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lighterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gmap = new GMap.NET.WindowsForms.GMapControl();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.altimeterInstrumentControl1 = new qw.AltimeterInstrumentControl();
			this.turnCoordinatorInstrumentControl1 = new qw.TurnCoordinatorInstrumentControl();
			this.attitudeIndicatorInstrumentControl1 = new qw.AttitudeIndicatorInstrumentControl();
			this.airSpeedIndicatorInstrumentControl1 = new qw.AirSpeedIndicatorInstrumentControl();
			this.headingIndicatorInstrumentControl1 = new qw.HeadingIndicatorInstrumentControl();
			this.verticalSpeedIndicatorInstrumentControl1 = new qw.VerticalSpeedIndicatorInstrumentControl();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(12, 43);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(90, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "57600",
            "115200"});
			this.comboBox2.Location = new System.Drawing.Point(108, 43);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(60, 21);
			this.comboBox2.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(197, 41);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(278, 41);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Disconnect";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(197, 90);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(156, 23);
			this.button4.TabIndex = 5;
			this.button4.Text = "Send \"2\"";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(12, 90);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(156, 23);
			this.button5.TabIndex = 6;
			this.button5.Text = "Send \"1\"";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Serial Port";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(105, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Baud Rate";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 134);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(90, 20);
			this.textBox1.TabIndex = 9;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(12, 176);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(90, 20);
			this.textBox2.TabIndex = 10;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(12, 256);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(90, 20);
			this.textBox3.TabIndex = 11;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(12, 216);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(90, 20);
			this.textBox4.TabIndex = 12;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(12, 298);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(90, 20);
			this.textBox5.TabIndex = 13;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(12, 341);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(90, 20);
			this.textBox6.TabIndex = 14;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(12, 383);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(90, 20);
			this.textBox7.TabIndex = 15;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(12, 421);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(434, 115);
			this.richTextBox1.TabIndex = 16;
			this.richTextBox1.Text = "";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// zedGraphControl1
			// 
			this.zedGraphControl1.Location = new System.Drawing.Point(108, 134);
			this.zedGraphControl1.Name = "zedGraphControl1";
			this.zedGraphControl1.ScrollGrace = 0D;
			this.zedGraphControl1.ScrollMaxX = 0D;
			this.zedGraphControl1.ScrollMaxY = 0D;
			this.zedGraphControl1.ScrollMaxY2 = 0D;
			this.zedGraphControl1.ScrollMinX = 0D;
			this.zedGraphControl1.ScrollMinY = 0D;
			this.zedGraphControl1.ScrollMinY2 = 0D;
			this.zedGraphControl1.Size = new System.Drawing.Size(338, 269);
			this.zedGraphControl1.TabIndex = 17;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.openGLControl1);
			this.panel1.Location = new System.Drawing.Point(464, 136);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(398, 267);
			this.panel1.TabIndex = 21;
			// 
			// openGLControl1
			// 
			this.openGLControl1.BackColor = System.Drawing.SystemColors.Control;
			this.openGLControl1.BitDepth = 24;
			this.openGLControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.openGLControl1.DrawFPS = true;
			this.openGLControl1.FrameRate = 28;
			this.openGLControl1.Location = new System.Drawing.Point(0, 0);
			this.openGLControl1.Name = "openGLControl1";
			this.openGLControl1.RenderContextType = SharpGL.RenderContextType.NativeWindow;
			this.openGLControl1.Size = new System.Drawing.Size(398, 267);
			this.openGLControl1.TabIndex = 2;
			this.openGLControl1.OpenGLDraw += new System.Windows.Forms.PaintEventHandler(this.openGLControl1_OpenGLDraw);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.renderToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1246, 24);
			this.menuStrip1.TabIndex = 22;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importPolygonToolStripMenuItem,
            this.importTextureToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.freezeToolStripMenuItem,
            this.unfreezeToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// importPolygonToolStripMenuItem
			// 
			this.importPolygonToolStripMenuItem.Name = "importPolygonToolStripMenuItem";
			this.importPolygonToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.importPolygonToolStripMenuItem.Text = "Import Polygon";
			this.importPolygonToolStripMenuItem.Click += new System.EventHandler(this.importPolygonToolStripMenuItem_Click);
			// 
			// importTextureToolStripMenuItem
			// 
			this.importTextureToolStripMenuItem.Name = "importTextureToolStripMenuItem";
			this.importTextureToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.importTextureToolStripMenuItem.Text = "Import Texture";
			this.importTextureToolStripMenuItem.Click += new System.EventHandler(this.importTextureToolStripMenuItem_Click);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// freezeToolStripMenuItem
			// 
			this.freezeToolStripMenuItem.Name = "freezeToolStripMenuItem";
			this.freezeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.freezeToolStripMenuItem.Text = "Freeze";
			this.freezeToolStripMenuItem.Click += new System.EventHandler(this.freezeToolStripMenuItem_Click);
			// 
			// unfreezeToolStripMenuItem
			// 
			this.unfreezeToolStripMenuItem.Name = "unfreezeToolStripMenuItem";
			this.unfreezeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.unfreezeToolStripMenuItem.Text = "Unfreeze";
			this.unfreezeToolStripMenuItem.Click += new System.EventHandler(this.unfreezeToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// renderToolStripMenuItem
			// 
			this.renderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wireframeToolStripMenuItem,
            this.solidToolStripMenuItem,
            this.lighterToolStripMenuItem});
			this.renderToolStripMenuItem.Name = "renderToolStripMenuItem";
			this.renderToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.renderToolStripMenuItem.Text = "Render";
			// 
			// wireframeToolStripMenuItem
			// 
			this.wireframeToolStripMenuItem.Name = "wireframeToolStripMenuItem";
			this.wireframeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.wireframeToolStripMenuItem.Text = "Wireframe";
			this.wireframeToolStripMenuItem.Click += new System.EventHandler(this.wireframeToolStripMenuItem_Click);
			// 
			// solidToolStripMenuItem
			// 
			this.solidToolStripMenuItem.Name = "solidToolStripMenuItem";
			this.solidToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.solidToolStripMenuItem.Text = "Solid";
			this.solidToolStripMenuItem.Click += new System.EventHandler(this.solidToolStripMenuItem_Click);
			// 
			// lighterToolStripMenuItem
			// 
			this.lighterToolStripMenuItem.Name = "lighterToolStripMenuItem";
			this.lighterToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.lighterToolStripMenuItem.Text = "Lighter";
			// 
			// gmap
			// 
			this.gmap.Bearing = 0F;
			this.gmap.CanDragMap = true;
			this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
			this.gmap.GrayScaleMode = false;
			this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			this.gmap.LevelsKeepInMemmory = 5;
			this.gmap.Location = new System.Drawing.Point(882, 136);
			this.gmap.MarkersEnabled = true;
			this.gmap.MaxZoom = 2;
			this.gmap.MinZoom = 2;
			this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			this.gmap.Name = "gmap";
			this.gmap.NegativeMode = false;
			this.gmap.PolygonsEnabled = true;
			this.gmap.RetryLoadTile = 0;
			this.gmap.RoutesEnabled = true;
			this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
			this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
			this.gmap.ShowTileGridLines = false;
			this.gmap.Size = new System.Drawing.Size(352, 267);
			this.gmap.TabIndex = 23;
			this.gmap.Zoom = 0D;
			this.gmap.Load += new System.EventHandler(this.Form1_Load);
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(372, 43);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(121, 21);
			this.comboBox3.TabIndex = 24;
			this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(524, 44);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(206, 20);
			this.textBox8.TabIndex = 25;
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(524, 73);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(100, 20);
			this.textBox9.TabIndex = 26;
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(630, 73);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(100, 20);
			this.textBox10.TabIndex = 27;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(418, 70);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 28;
			this.button3.Text = "Fetching";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(882, 140);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 29;
			this.label3.Text = "label3";
			// 
			// altimeterInstrumentControl1
			// 
			this.altimeterInstrumentControl1.Location = new System.Drawing.Point(1078, 44);
			this.altimeterInstrumentControl1.Name = "altimeterInstrumentControl1";
			this.altimeterInstrumentControl1.Size = new System.Drawing.Size(75, 73);
			this.altimeterInstrumentControl1.TabIndex = 20;
			this.altimeterInstrumentControl1.Text = "altimeterInstrumentControl1";
			// 
			// turnCoordinatorInstrumentControl1
			// 
			this.turnCoordinatorInstrumentControl1.Location = new System.Drawing.Point(1159, 43);
			this.turnCoordinatorInstrumentControl1.Name = "turnCoordinatorInstrumentControl1";
			this.turnCoordinatorInstrumentControl1.Size = new System.Drawing.Size(75, 73);
			this.turnCoordinatorInstrumentControl1.TabIndex = 19;
			this.turnCoordinatorInstrumentControl1.Text = "turnCoordinatorInstrumentControl1";
			// 
			// attitudeIndicatorInstrumentControl1
			// 
			this.attitudeIndicatorInstrumentControl1.Location = new System.Drawing.Point(997, 43);
			this.attitudeIndicatorInstrumentControl1.Name = "attitudeIndicatorInstrumentControl1";
			this.attitudeIndicatorInstrumentControl1.Size = new System.Drawing.Size(75, 73);
			this.attitudeIndicatorInstrumentControl1.TabIndex = 18;
			this.attitudeIndicatorInstrumentControl1.Text = "attitudeIndicatorInstrumentControl1";
			// 
			// airSpeedIndicatorInstrumentControl1
			// 
			this.airSpeedIndicatorInstrumentControl1.Location = new System.Drawing.Point(916, 43);
			this.airSpeedIndicatorInstrumentControl1.Name = "airSpeedIndicatorInstrumentControl1";
			this.airSpeedIndicatorInstrumentControl1.Size = new System.Drawing.Size(75, 73);
			this.airSpeedIndicatorInstrumentControl1.TabIndex = 30;
			this.airSpeedIndicatorInstrumentControl1.Text = "airSpeedIndicatorInstrumentControl1";
			// 
			// headingIndicatorInstrumentControl1
			// 
			this.headingIndicatorInstrumentControl1.Location = new System.Drawing.Point(835, 43);
			this.headingIndicatorInstrumentControl1.Name = "headingIndicatorInstrumentControl1";
			this.headingIndicatorInstrumentControl1.Size = new System.Drawing.Size(75, 73);
			this.headingIndicatorInstrumentControl1.TabIndex = 31;
			this.headingIndicatorInstrumentControl1.Text = "headingIndicatorInstrumentControl1";
			// 
			// verticalSpeedIndicatorInstrumentControl1
			// 
			this.verticalSpeedIndicatorInstrumentControl1.Location = new System.Drawing.Point(754, 44);
			this.verticalSpeedIndicatorInstrumentControl1.Name = "verticalSpeedIndicatorInstrumentControl1";
			this.verticalSpeedIndicatorInstrumentControl1.Size = new System.Drawing.Size(75, 72);
			this.verticalSpeedIndicatorInstrumentControl1.TabIndex = 32;
			this.verticalSpeedIndicatorInstrumentControl1.Text = "verticalSpeedIndicatorInstrumentControl1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1246, 548);
			this.Controls.Add(this.verticalSpeedIndicatorInstrumentControl1);
			this.Controls.Add(this.headingIndicatorInstrumentControl1);
			this.Controls.Add(this.airSpeedIndicatorInstrumentControl1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBox10);
			this.Controls.Add(this.textBox9);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.gmap);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.altimeterInstrumentControl1);
			this.Controls.Add(this.turnCoordinatorInstrumentControl1);
			this.Controls.Add(this.attitudeIndicatorInstrumentControl1);
			this.Controls.Add(this.zedGraphControl1);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load_1);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
		private AttitudeIndicatorInstrumentControl attitudeIndicatorInstrumentControl1;
		private TurnCoordinatorInstrumentControl turnCoordinatorInstrumentControl1;
		private AltimeterInstrumentControl altimeterInstrumentControl1;
		private System.Windows.Forms.Panel panel1;
		private SharpGL.OpenGLControl openGLControl1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importPolygonToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importTextureToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem freezeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem unfreezeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem renderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wireframeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem solidToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lighterToolStripMenuItem;
		private GMap.NET.WindowsForms.GMapControl gmap;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label3;
		private AirSpeedIndicatorInstrumentControl airSpeedIndicatorInstrumentControl1;
		private HeadingIndicatorInstrumentControl headingIndicatorInstrumentControl1;
		private VerticalSpeedIndicatorInstrumentControl verticalSpeedIndicatorInstrumentControl1;
	}
}

