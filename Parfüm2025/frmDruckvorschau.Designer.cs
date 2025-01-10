namespace Parfüm2025
{
    partial class frmDruckvorschau
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDruckvorschau));
            this.pnlHaupPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.konvertiereZurPdfDateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlNettoBrutto = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblNetto = new System.Windows.Forms.Label();
            this.lblBrutto = new System.Windows.Forms.Label();
            this.lblSteuer = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dgvVerkaufsdaten = new System.Windows.Forms.DataGridView();
            this.label28 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDatum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lable = new System.Windows.Forms.Label();
            this.lblKasse = new System.Windows.Forms.Label();
            this.lblBelegID = new System.Windows.Forms.Label();
            this.lblVollname = new System.Windows.Forms.Label();
            this.lblStadt = new System.Windows.Forms.Label();
            this.lblStrasse = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Anzahl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Beschreibung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Einzelpreis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gesamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHaupPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlNettoBrutto.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerkaufsdaten)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHaupPanel
            // 
            this.pnlHaupPanel.BackColor = System.Drawing.Color.White;
            this.pnlHaupPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.pnlHaupPanel.Controls.Add(this.pictureBox1);
            this.pnlHaupPanel.Controls.Add(this.button1);
            this.pnlHaupPanel.Controls.Add(this.pnlNettoBrutto);
            this.pnlHaupPanel.Controls.Add(this.dgvVerkaufsdaten);
            this.pnlHaupPanel.Controls.Add(this.label28);
            this.pnlHaupPanel.Controls.Add(this.panel3);
            this.pnlHaupPanel.Controls.Add(this.label13);
            this.pnlHaupPanel.Controls.Add(this.label12);
            this.pnlHaupPanel.Controls.Add(this.label11);
            this.pnlHaupPanel.Controls.Add(this.panel2);
            this.pnlHaupPanel.Controls.Add(this.lblDatum);
            this.pnlHaupPanel.Controls.Add(this.label7);
            this.pnlHaupPanel.Controls.Add(this.lable);
            this.pnlHaupPanel.Controls.Add(this.lblKasse);
            this.pnlHaupPanel.Controls.Add(this.lblBelegID);
            this.pnlHaupPanel.Controls.Add(this.lblVollname);
            this.pnlHaupPanel.Controls.Add(this.lblStadt);
            this.pnlHaupPanel.Controls.Add(this.lblStrasse);
            this.pnlHaupPanel.Controls.Add(this.label2);
            this.pnlHaupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHaupPanel.Location = new System.Drawing.Point(0, 0);
            this.pnlHaupPanel.Name = "pnlHaupPanel";
            this.pnlHaupPanel.Size = new System.Drawing.Size(784, 1061);
            this.pnlHaupPanel.TabIndex = 4;
            this.pnlHaupPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHaupPanel_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.konvertiereZurPdfDateiToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(266, 42);
            // 
            // konvertiereZurPdfDateiToolStripMenuItem
            // 
            this.konvertiereZurPdfDateiToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.konvertiereZurPdfDateiToolStripMenuItem.Image = global::Parfüm2025.Properties.Resources.pdf_file_format_6795752;
            this.konvertiereZurPdfDateiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.konvertiereZurPdfDateiToolStripMenuItem.Name = "konvertiereZurPdfDateiToolStripMenuItem";
            this.konvertiereZurPdfDateiToolStripMenuItem.Size = new System.Drawing.Size(265, 38);
            this.konvertiereZurPdfDateiToolStripMenuItem.Text = "Konvertiere zur Pdf Datei";
            this.konvertiereZurPdfDateiToolStripMenuItem.Click += new System.EventHandler(this.konvertiereZurPdfDateiToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Parfüm2025.Properties.Resources.Alowidat_Final_Logo_02;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.YellowGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(546, 952);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 87);
            this.button1.TabIndex = 56;
            this.button1.Text = "Diese Rechnungsvorlage \r\nwurde erstellt von:\r\nAlowidat Parfüm\r\n";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlNettoBrutto
            // 
            this.pnlNettoBrutto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlNettoBrutto.Controls.Add(this.lblNetto);
            this.pnlNettoBrutto.Controls.Add(this.lblBrutto);
            this.pnlNettoBrutto.Controls.Add(this.panel8);
            this.pnlNettoBrutto.Controls.Add(this.lblSteuer);
            this.pnlNettoBrutto.Location = new System.Drawing.Point(19, 552);
            this.pnlNettoBrutto.Name = "pnlNettoBrutto";
            this.pnlNettoBrutto.Size = new System.Drawing.Size(709, 80);
            this.pnlNettoBrutto.TabIndex = 55;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(589, 5);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 16);
            this.label21.TabIndex = 38;
            this.label21.Text = "Summe €";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel8.Controls.Add(this.label24);
            this.panel8.Controls.Add(this.label25);
            this.panel8.Controls.Add(this.label21);
            this.panel8.Location = new System.Drawing.Point(3, 12);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(706, 25);
            this.panel8.TabIndex = 47;
            // 
            // lblNetto
            // 
            this.lblNetto.AutoSize = true;
            this.lblNetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetto.Location = new System.Drawing.Point(330, 49);
            this.lblNetto.Name = "lblNetto";
            this.lblNetto.Size = new System.Drawing.Size(28, 16);
            this.lblNetto.TabIndex = 44;
            this.lblNetto.Text = "???";
            // 
            // lblBrutto
            // 
            this.lblBrutto.AutoSize = true;
            this.lblBrutto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrutto.Location = new System.Drawing.Point(599, 49);
            this.lblBrutto.Name = "lblBrutto";
            this.lblBrutto.Size = new System.Drawing.Size(31, 16);
            this.lblBrutto.TabIndex = 45;
            this.lblBrutto.Text = "???";
            // 
            // lblSteuer
            // 
            this.lblSteuer.AutoSize = true;
            this.lblSteuer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteuer.Location = new System.Drawing.Point(458, 49);
            this.lblSteuer.Name = "lblSteuer";
            this.lblSteuer.Size = new System.Drawing.Size(28, 16);
            this.lblSteuer.TabIndex = 46;
            this.lblSteuer.Text = "???";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(322, 5);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 16);
            this.label24.TabIndex = 41;
            this.label24.Text = "Netto €";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(449, 5);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 16);
            this.label25.TabIndex = 42;
            this.label25.Text = "Steuer€";
            // 
            // dgvVerkaufsdaten
            // 
            this.dgvVerkaufsdaten.AllowUserToAddRows = false;
            this.dgvVerkaufsdaten.AllowUserToDeleteRows = false;
            this.dgvVerkaufsdaten.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVerkaufsdaten.BackgroundColor = System.Drawing.Color.White;
            this.dgvVerkaufsdaten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVerkaufsdaten.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVerkaufsdaten.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVerkaufsdaten.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvVerkaufsdaten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerkaufsdaten.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Anzahl,
            this.Beschreibung,
            this.Ust,
            this.Einzelpreis,
            this.Gesamt});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVerkaufsdaten.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvVerkaufsdaten.Location = new System.Drawing.Point(19, 415);
            this.dgvVerkaufsdaten.Name = "dgvVerkaufsdaten";
            this.dgvVerkaufsdaten.ReadOnly = true;
            this.dgvVerkaufsdaten.RowHeadersVisible = false;
            this.dgvVerkaufsdaten.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvVerkaufsdaten.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvVerkaufsdaten.Size = new System.Drawing.Size(709, 88);
            this.dgvVerkaufsdaten.TabIndex = 53;
            this.dgvVerkaufsdaten.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvVerkaufsdaten_RowsAdded);
            this.dgvVerkaufsdaten.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvVerkaufsdaten_RowsRemoved);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(517, 33);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(203, 160);
            this.label28.TabIndex = 49;
            this.label28.Text = resources.GetString("label28.Text");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(19, 338);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(709, 27);
            this.panel3.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Beleg Nu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(152, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kasse";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(290, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kassieserin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(431, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Zahlungsart";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(571, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Datum";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(27, 287);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(448, 18);
            this.label13.TabIndex = 22;
            this.label13.Text = "Im folgenden der/die erworbene/n Artikel, die ich in Rechnung stelle:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(27, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(217, 18);
            this.label12.TabIndex = 21;
            this.label12.Text = "Sehr geehrte Damen und Herrn,";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.ForestGreen;
            this.label11.Location = new System.Drawing.Point(29, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 26);
            this.label11.TabIndex = 20;
            this.label11.Text = "RECHNUNG";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(33, 388);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(676, 1);
            this.panel2.TabIndex = 16;
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatum.Location = new System.Drawing.Point(586, 368);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(31, 16);
            this.lblDatum.TabIndex = 15;
            this.lblDatum.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(448, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Rechnung";
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable.Location = new System.Drawing.Point(308, 369);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(88, 16);
            this.lable.TabIndex = 11;
            this.lable.Text = "Kassieserin";
            // 
            // lblKasse
            // 
            this.lblKasse.AutoSize = true;
            this.lblKasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKasse.Location = new System.Drawing.Point(175, 368);
            this.lblKasse.Name = "lblKasse";
            this.lblKasse.Size = new System.Drawing.Size(15, 16);
            this.lblKasse.TabIndex = 9;
            this.lblKasse.Text = "1";
            // 
            // lblBelegID
            // 
            this.lblBelegID.AutoSize = true;
            this.lblBelegID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBelegID.Location = new System.Drawing.Point(36, 368);
            this.lblBelegID.Name = "lblBelegID";
            this.lblBelegID.Size = new System.Drawing.Size(31, 16);
            this.lblBelegID.TabIndex = 7;
            this.lblBelegID.Text = "???";
            // 
            // lblVollname
            // 
            this.lblVollname.AutoSize = true;
            this.lblVollname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVollname.Location = new System.Drawing.Point(74, 152);
            this.lblVollname.Name = "lblVollname";
            this.lblVollname.Size = new System.Drawing.Size(80, 18);
            this.lblVollname.TabIndex = 5;
            this.lblVollname.Text = "Empfänger";
            // 
            // lblStadt
            // 
            this.lblStadt.AutoSize = true;
            this.lblStadt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStadt.Location = new System.Drawing.Point(30, 194);
            this.lblStadt.Name = "lblStadt";
            this.lblStadt.Size = new System.Drawing.Size(114, 18);
            this.lblStadt.TabIndex = 4;
            this.lblStadt.Text = "74821 Mosbach";
            // 
            // lblStrasse
            // 
            this.lblStrasse.AutoSize = true;
            this.lblStrasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrasse.Location = new System.Drawing.Point(30, 172);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(109, 18);
            this.lblStrasse.TabIndex = 3;
            this.lblStrasse.Text = "Straßename 20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Herrn";
            // 
            // Anzahl
            // 
            this.Anzahl.HeaderText = "Parfüm Nr";
            this.Anzahl.Name = "Anzahl";
            this.Anzahl.ReadOnly = true;
            this.Anzahl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Beschreibung
            // 
            this.Beschreibung.HeaderText = "Gewicht";
            this.Beschreibung.Name = "Beschreibung";
            this.Beschreibung.ReadOnly = true;
            this.Beschreibung.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Ust
            // 
            this.Ust.HeaderText = "Ust%";
            this.Ust.Name = "Ust";
            this.Ust.ReadOnly = true;
            this.Ust.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Einzelpreis
            // 
            this.Einzelpreis.HeaderText = "Einzelpreis";
            this.Einzelpreis.Name = "Einzelpreis";
            this.Einzelpreis.ReadOnly = true;
            this.Einzelpreis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Gesamt
            // 
            this.Gesamt.HeaderText = "Gesamt";
            this.Gesamt.Name = "Gesamt";
            this.Gesamt.ReadOnly = true;
            // 
            // frmDruckvorschau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 1061);
            this.Controls.Add(this.pnlHaupPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDruckvorschau";
            this.Text = "Druck-Voschau";
            this.Load += new System.EventHandler(this.frmDruckvorschau_Load);
            this.pnlHaupPanel.ResumeLayout(false);
            this.pnlHaupPanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlNettoBrutto.ResumeLayout(false);
            this.pnlNettoBrutto.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerkaufsdaten)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHaupPanel;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblSteuer;
        private System.Windows.Forms.Label lblBrutto;
        private System.Windows.Forms.Label lblNetto;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.Label lblKasse;
        private System.Windows.Forms.Label lblBelegID;
        private System.Windows.Forms.Label lblVollname;
        private System.Windows.Forms.Label lblStadt;
        private System.Windows.Forms.Label lblStrasse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvVerkaufsdaten;
        private System.Windows.Forms.Panel pnlNettoBrutto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem konvertiereZurPdfDateiToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anzahl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Beschreibung;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ust;
        private System.Windows.Forms.DataGridViewTextBoxColumn Einzelpreis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gesamt;
    }
}