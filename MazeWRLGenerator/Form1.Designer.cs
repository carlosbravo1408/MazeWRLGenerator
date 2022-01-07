namespace MazeWRLGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_outtxt = new System.Windows.Forms.RadioButton();
            this.rdb_intxt = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdb_spacdot = new System.Windows.Forms.RadioButton();
            this.rdb_tabn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdb_3 = new System.Windows.Forms.RadioButton();
            this.rdb_1 = new System.Windows.Forms.RadioButton();
            this.rdb_2 = new System.Windows.Forms.RadioButton();
            this.rdb_0 = new System.Windows.Forms.RadioButton();
            this.lbl_pos = new System.Windows.Forms.Label();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudx = new System.Windows.Forms.NumericUpDown();
            this.nudy = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btn_genArc = new System.Windows.Forms.Button();
            this.btn_vp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_d = new System.Windows.Forms.NumericUpDown();
            this.nud_h = new System.Windows.Forms.NumericUpDown();
            this.nud_esp = new System.Windows.Forms.NumericUpDown();
            this.btn_portapapeles = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.westWallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.northWallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.northAndWestWallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudy)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_d)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_esp)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_outtxt);
            this.groupBox1.Controls.Add(this.rdb_intxt);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 68);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rdb_outtxt
            // 
            this.rdb_outtxt.AutoSize = true;
            this.rdb_outtxt.Location = new System.Drawing.Point(7, 44);
            this.rdb_outtxt.Name = "rdb_outtxt";
            this.rdb_outtxt.Size = new System.Drawing.Size(87, 17);
            this.rdb_outtxt.TabIndex = 1;
            this.rdb_outtxt.Text = "String Output";
            this.rdb_outtxt.UseVisualStyleBackColor = true;
            this.rdb_outtxt.CheckedChanged += new System.EventHandler(this.rdb_outtxt_CheckedChanged);
            // 
            // rdb_intxt
            // 
            this.rdb_intxt.AutoSize = true;
            this.rdb_intxt.Checked = true;
            this.rdb_intxt.Location = new System.Drawing.Point(7, 20);
            this.rdb_intxt.Name = "rdb_intxt";
            this.rdb_intxt.Size = new System.Drawing.Size(73, 17);
            this.rdb_intxt.TabIndex = 0;
            this.rdb_intxt.TabStop = true;
            this.rdb_intxt.Text = "Text Input";
            this.rdb_intxt.UseVisualStyleBackColor = true;
            this.rdb_intxt.CheckedChanged += new System.EventHandler(this.rdb_intxt_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdb_spacdot);
            this.groupBox2.Controls.Add(this.rdb_tabn);
            this.groupBox2.Location = new System.Drawing.Point(186, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 68);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // rdb_spacdot
            // 
            this.rdb_spacdot.AutoSize = true;
            this.rdb_spacdot.Location = new System.Drawing.Point(7, 44);
            this.rdb_spacdot.Name = "rdb_spacdot";
            this.rdb_spacdot.Size = new System.Drawing.Size(125, 17);
            this.rdb_spacdot.TabIndex = 1;
            this.rdb_spacdot.Text = "space and semicolon";
            this.rdb_spacdot.UseVisualStyleBackColor = true;
            // 
            // rdb_tabn
            // 
            this.rdb_tabn.AutoSize = true;
            this.rdb_tabn.Checked = true;
            this.rdb_tabn.Location = new System.Drawing.Point(7, 20);
            this.rdb_tabn.Name = "rdb_tabn";
            this.rdb_tabn.Size = new System.Drawing.Size(104, 17);
            this.rdb_tabn.TabIndex = 0;
            this.rdb_tabn.TabStop = true;
            this.rdb_tabn.Text = "tab and newLine";
            this.rdb_tabn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdb_3);
            this.panel1.Controls.Add(this.rdb_1);
            this.panel1.Controls.Add(this.rdb_2);
            this.panel1.Controls.Add(this.rdb_0);
            this.panel1.Controls.Add(this.lbl_pos);
            this.panel1.Controls.Add(this.lbl_1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nudx);
            this.panel1.Controls.Add(this.nudy);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 111);
            this.panel1.TabIndex = 5;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // rdb_3
            // 
            this.rdb_3.AutoSize = true;
            this.rdb_3.Location = new System.Drawing.Point(132, 78);
            this.rdb_3.Name = "rdb_3";
            this.rdb_3.Size = new System.Drawing.Size(31, 17);
            this.rdb_3.TabIndex = 5;
            this.rdb_3.Text = "3";
            this.rdb_3.UseVisualStyleBackColor = true;
            // 
            // rdb_1
            // 
            this.rdb_1.AutoSize = true;
            this.rdb_1.Location = new System.Drawing.Point(92, 78);
            this.rdb_1.Name = "rdb_1";
            this.rdb_1.Size = new System.Drawing.Size(31, 17);
            this.rdb_1.TabIndex = 5;
            this.rdb_1.Text = "1";
            this.rdb_1.UseVisualStyleBackColor = true;
            // 
            // rdb_2
            // 
            this.rdb_2.AutoSize = true;
            this.rdb_2.Location = new System.Drawing.Point(132, 55);
            this.rdb_2.Name = "rdb_2";
            this.rdb_2.Size = new System.Drawing.Size(31, 17);
            this.rdb_2.TabIndex = 5;
            this.rdb_2.Text = "2";
            this.rdb_2.UseVisualStyleBackColor = true;
            // 
            // rdb_0
            // 
            this.rdb_0.AutoSize = true;
            this.rdb_0.Checked = true;
            this.rdb_0.Location = new System.Drawing.Point(92, 55);
            this.rdb_0.Name = "rdb_0";
            this.rdb_0.Size = new System.Drawing.Size(31, 17);
            this.rdb_0.TabIndex = 5;
            this.rdb_0.TabStop = true;
            this.rdb_0.Text = "0";
            this.rdb_0.UseVisualStyleBackColor = true;
            // 
            // lbl_pos
            // 
            this.lbl_pos.AutoSize = true;
            this.lbl_pos.Location = new System.Drawing.Point(167, 71);
            this.lbl_pos.Name = "lbl_pos";
            this.lbl_pos.Size = new System.Drawing.Size(35, 13);
            this.lbl_pos.TabIndex = 4;
            this.lbl_pos.Text = "label3";
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.Location = new System.Drawing.Point(167, 20);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(35, 13);
            this.lbl_1.TabIndex = 4;
            this.lbl_1.Text = "label3";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(3, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 46);
            this.button2.TabIndex = 3;
            this.button2.Text = "Generate draw Maze";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "x";
            // 
            // nudx
            // 
            this.nudx.Location = new System.Drawing.Point(107, 6);
            this.nudx.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudx.Name = "nudx";
            this.nudx.Size = new System.Drawing.Size(54, 20);
            this.nudx.TabIndex = 1;
            this.nudx.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudx.ValueChanged += new System.EventHandler(this.nudx_ValueChanged);
            // 
            // nudy
            // 
            this.nudy.Location = new System.Drawing.Point(107, 29);
            this.nudy.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudy.Name = "nudy";
            this.nudy.Size = new System.Drawing.Size(54, 20);
            this.nudy.TabIndex = 1;
            this.nudy.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudy.ValueChanged += new System.EventHandler(this.nudy_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate String";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 198);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(361, 219);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "VRLM (*.wrl)|*.wrl";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.richTextBox2);
            this.panel4.Controls.Add(this.btn_genArc);
            this.panel4.Controls.Add(this.btn_vp);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.nud_d);
            this.panel4.Controls.Add(this.nud_h);
            this.panel4.Controls.Add(this.nud_esp);
            this.panel4.Controls.Add(this.btn_portapapeles);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.richTextBox1);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Location = new System.Drawing.Point(472, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(367, 501);
            this.panel4.TabIndex = 8;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Font = new System.Drawing.Font("Consolas", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.ForeColor = System.Drawing.Color.Red;
            this.richTextBox2.Location = new System.Drawing.Point(234, 105);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(124, 83);
            this.richTextBox2.TabIndex = 12;
            this.richTextBox2.Text = "     +   + |      +   +\n0 ->   o   | 1 -> | o \n     +   + |      +   +\n----------" +
    "-|----------\n     +---+ |      +---+\n2 ->   o   | 3 -> | o \n     +   + |      + " +
    "  +";
            // 
            // btn_genArc
            // 
            this.btn_genArc.Location = new System.Drawing.Point(186, 449);
            this.btn_genArc.Name = "btn_genArc";
            this.btn_genArc.Size = new System.Drawing.Size(172, 49);
            this.btn_genArc.TabIndex = 11;
            this.btn_genArc.Text = "Generate *.wrl file";
            this.btn_genArc.UseVisualStyleBackColor = true;
            this.btn_genArc.Click += new System.EventHandler(this.btn_genArc_Click);
            // 
            // btn_vp
            // 
            this.btn_vp.Location = new System.Drawing.Point(3, 449);
            this.btn_vp.Name = "btn_vp";
            this.btn_vp.Size = new System.Drawing.Size(177, 49);
            this.btn_vp.TabIndex = 10;
            this.btn_vp.Text = "Preview";
            this.btn_vp.UseVisualStyleBackColor = true;
            this.btn_vp.Click += new System.EventHandler(this.btn_vp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Distance\r\nbetween walls";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "Wall\r\nheight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Wall\r\nthickness";
            // 
            // nud_d
            // 
            this.nud_d.DecimalPlaces = 5;
            this.nud_d.Location = new System.Drawing.Point(295, 423);
            this.nud_d.Minimum = new decimal(new int[] {
            168,
            0,
            0,
            196608});
            this.nud_d.Name = "nud_d";
            this.nud_d.Size = new System.Drawing.Size(63, 20);
            this.nud_d.TabIndex = 8;
            this.nud_d.Value = new decimal(new int[] {
            168,
            0,
            0,
            196608});
            // 
            // nud_h
            // 
            this.nud_h.DecimalPlaces = 5;
            this.nud_h.Location = new System.Drawing.Point(159, 423);
            this.nud_h.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nud_h.Name = "nud_h";
            this.nud_h.Size = new System.Drawing.Size(63, 20);
            this.nud_h.TabIndex = 8;
            this.nud_h.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // nud_esp
            // 
            this.nud_esp.DecimalPlaces = 5;
            this.nud_esp.Location = new System.Drawing.Point(55, 423);
            this.nud_esp.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            196608});
            this.nud_esp.Name = "nud_esp";
            this.nud_esp.Size = new System.Drawing.Size(62, 20);
            this.nud_esp.TabIndex = 8;
            this.nud_esp.Value = new decimal(new int[] {
            12,
            0,
            0,
            196608});
            this.nud_esp.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btn_portapapeles
            // 
            this.btn_portapapeles.Location = new System.Drawing.Point(233, 77);
            this.btn_portapapeles.Name = "btn_portapapeles";
            this.btn_portapapeles.Size = new System.Drawing.Size(131, 23);
            this.btn_portapapeles.TabIndex = 7;
            this.btn_portapapeles.Text = "Copy to ClipBoard";
            this.btn_portapapeles.UseVisualStyleBackColor = true;
            this.btn_portapapeles.Click += new System.EventHandler(this.btn_portapapeles_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 373F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(842, 507);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(463, 501);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.westWallToolStripMenuItem,
            this.northWallToolStripMenuItem,
            this.northAndWestWallToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 92);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.noneToolStripMenuItem.Text = "(&0) None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // westWallToolStripMenuItem
            // 
            this.westWallToolStripMenuItem.Name = "westWallToolStripMenuItem";
            this.westWallToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.westWallToolStripMenuItem.Text = "(&1) West Wall";
            this.westWallToolStripMenuItem.Click += new System.EventHandler(this.westWallToolStripMenuItem_Click);
            // 
            // northWallToolStripMenuItem
            // 
            this.northWallToolStripMenuItem.Name = "northWallToolStripMenuItem";
            this.northWallToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.northWallToolStripMenuItem.Text = "(&2) North Wall";
            this.northWallToolStripMenuItem.Click += new System.EventHandler(this.northWallToolStripMenuItem_Click);
            // 
            // northAndWestWallToolStripMenuItem
            // 
            this.northAndWestWallToolStripMenuItem.Name = "northAndWestWallToolStripMenuItem";
            this.northAndWestWallToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.northAndWestWallToolStripMenuItem.Text = "(&3) North and West Wall";
            this.northAndWestWallToolStripMenuItem.Click += new System.EventHandler(this.northAndWestWallToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 507);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "MazeVisualizerVer1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudy)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_d)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_esp)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_outtxt;
        private System.Windows.Forms.RadioButton rdb_intxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdb_spacdot;
        private System.Windows.Forms.RadioButton rdb_tabn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdb_3;
        private System.Windows.Forms.RadioButton rdb_1;
        private System.Windows.Forms.RadioButton rdb_2;
        private System.Windows.Forms.RadioButton rdb_0;
        private System.Windows.Forms.Label lbl_pos;
        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudx;
        private System.Windows.Forms.NumericUpDown nudy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_d;
        private System.Windows.Forms.NumericUpDown nud_h;
        private System.Windows.Forms.NumericUpDown nud_esp;
        private System.Windows.Forms.Button btn_portapapeles;
        private System.Windows.Forms.Button btn_genArc;
        private System.Windows.Forms.Button btn_vp;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem westWallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem northWallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem northAndWestWallToolStripMenuItem;
    }
}

