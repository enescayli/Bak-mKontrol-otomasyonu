namespace Bakım_modulu
{
    partial class frmPop_Up_Vardiya
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPop_Up_Vardiya));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboPersonel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMesaiSuresi = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblBasVardiya = new System.Windows.Forms.Label();
            this.txtAciklama_Var = new System.Windows.Forms.RichTextBox();
            this.lblVar_Sur = new System.Windows.Forms.Label();
            this.lblBitisVardiya = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPersonel_ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAçıklama_ = new System.Windows.Forms.RichTextBox();
            this.Lbl = new System.Windows.Forms.Label();
            this.Lbl2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 305);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(602, 208);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Tag = "";
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // comboPersonel
            // 
            this.comboPersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboPersonel.FormattingEnabled = true;
            this.comboPersonel.Location = new System.Drawing.Point(115, 24);
            this.comboPersonel.Name = "comboPersonel";
            this.comboPersonel.Size = new System.Drawing.Size(121, 24);
            this.comboPersonel.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(32, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Personel:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "HH.mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(204, 54);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 31);
            this.dateTimePicker1.TabIndex = 23;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(32, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Vardiya Baş. Saati";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(32, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Vardiya Bit. Saati";
            // 
            // lblMesaiSuresi
            // 
            this.lblMesaiSuresi.AutoSize = true;
            this.lblMesaiSuresi.BackColor = System.Drawing.Color.DarkCyan;
            this.lblMesaiSuresi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMesaiSuresi.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.lblMesaiSuresi.Location = new System.Drawing.Point(375, 24);
            this.lblMesaiSuresi.Name = "lblMesaiSuresi";
            this.lblMesaiSuresi.Size = new System.Drawing.Size(54, 20);
            this.lblMesaiSuresi.TabIndex = 27;
            this.lblMesaiSuresi.Text = "00.00";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(190)))), ((int)(((byte)(128)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 2;
            this.button1.ImageList = this.ımageList1;
            this.button1.Location = new System.Drawing.Point(597, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 43);
            this.button1.TabIndex = 28;
            this.button1.Text = "KAYDET";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "ErrorCircle.png");
            this.ımageList1.Images.SetKeyName(1, "tik-png-1.png");
            this.ımageList1.Images.SetKeyName(2, "save.png");
            this.ımageList1.Images.SetKeyName(3, "update.png");
            this.ımageList1.Images.SetKeyName(4, "refresh_reload_arrow_sync-512.png");
            this.ımageList1.Images.SetKeyName(5, "cycle+interface+update+icon-1320184070507016548.png");
            this.ımageList1.Images.SetKeyName(6, "cycle_circle_green-512.png");
            this.ımageList1.Images.SetKeyName(7, "Update-512.png");
            this.ımageList1.Images.SetKeyName(8, "symbol_refresh.png");
            this.ımageList1.Images.SetKeyName(9, "delete.png");
            this.ımageList1.Images.SetKeyName(10, "delete-icon-png-4.png");
            this.ımageList1.Images.SetKeyName(11, "61848.png");
            this.ımageList1.Images.SetKeyName(12, "delete-icon-png-4.png");
            this.ımageList1.Images.SetKeyName(13, "47-512.png");
            this.ımageList1.Images.SetKeyName(14, "967962d3aac34869f1bec88ea89f573b-search-blue-circle-icon-by-vexels.png");
            // 
            // lblBasVardiya
            // 
            this.lblBasVardiya.AutoSize = true;
            this.lblBasVardiya.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBasVardiya.Location = new System.Drawing.Point(306, 63);
            this.lblBasVardiya.Name = "lblBasVardiya";
            this.lblBasVardiya.Size = new System.Drawing.Size(51, 20);
            this.lblBasVardiya.TabIndex = 29;
            this.lblBasVardiya.Text = "label4";
            // 
            // txtAciklama_Var
            // 
            this.txtAciklama_Var.Location = new System.Drawing.Point(12, 194);
            this.txtAciklama_Var.Name = "txtAciklama_Var";
            this.txtAciklama_Var.Size = new System.Drawing.Size(349, 105);
            this.txtAciklama_Var.TabIndex = 30;
            this.txtAciklama_Var.Text = "";
            this.txtAciklama_Var.TextChanged += new System.EventHandler(this.txtAciklama_Var_TextChanged);
            // 
            // lblVar_Sur
            // 
            this.lblVar_Sur.AutoSize = true;
            this.lblVar_Sur.BackColor = System.Drawing.Color.DarkCyan;
            this.lblVar_Sur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVar_Sur.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblVar_Sur.Location = new System.Drawing.Point(242, 24);
            this.lblVar_Sur.Name = "lblVar_Sur";
            this.lblVar_Sur.Size = new System.Drawing.Size(135, 20);
            this.lblVar_Sur.TabIndex = 31;
            this.lblVar_Sur.Text = "Vardiya Süresi :";
            this.lblVar_Sur.Click += new System.EventHandler(this.lblVar_Sur_Click);
            // 
            // lblBitisVardiya
            // 
            this.lblBitisVardiya.AutoSize = true;
            this.lblBitisVardiya.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBitisVardiya.Location = new System.Drawing.Point(306, 106);
            this.lblBitisVardiya.Name = "lblBitisVardiya";
            this.lblBitisVardiya.Size = new System.Drawing.Size(51, 20);
            this.lblBitisVardiya.TabIndex = 32;
            this.lblBitisVardiya.Text = "label4";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.YellowGreen;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuncelle.ImageIndex = 7;
            this.btnGuncelle.ImageList = this.ımageList1;
            this.btnGuncelle.Location = new System.Drawing.Point(597, 75);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(126, 43);
            this.btnGuncelle.TabIndex = 33;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSil.ImageIndex = 12;
            this.btnSil.Location = new System.Drawing.Point(597, 124);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(126, 43);
            this.btnSil.TabIndex = 34;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(12, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 29);
            this.label4.TabIndex = 35;
            this.label4.Text = "AÇIKLAMA";
            // 
            // txtPersonel_
            // 
            this.txtPersonel_.Location = new System.Drawing.Point(424, 194);
            this.txtPersonel_.Name = "txtPersonel_";
            this.txtPersonel_.ReadOnly = true;
            this.txtPersonel_.Size = new System.Drawing.Size(188, 20);
            this.txtPersonel_.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(361, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "Personel :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(359, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "Açıklama :";
            // 
            // txtAçıklama_
            // 
            this.txtAçıklama_.ForeColor = System.Drawing.Color.DarkRed;
            this.txtAçıklama_.Location = new System.Drawing.Point(424, 220);
            this.txtAçıklama_.Name = "txtAçıklama_";
            this.txtAçıklama_.Size = new System.Drawing.Size(188, 79);
            this.txtAçıklama_.TabIndex = 39;
            this.txtAçıklama_.Text = "";
            this.txtAçıklama_.TextChanged += new System.EventHandler(this.txtAçıklama__TextChanged);
            // 
            // Lbl
            // 
            this.Lbl.AutoSize = true;
            this.Lbl.Location = new System.Drawing.Point(360, 283);
            this.Lbl.Name = "Lbl";
            this.Lbl.Size = new System.Drawing.Size(42, 13);
            this.Lbl.TabIndex = 40;
            this.Lbl.Text = "2000/0";
            // 
            // Lbl2
            // 
            this.Lbl2.AutoSize = true;
            this.Lbl2.Location = new System.Drawing.Point(617, 283);
            this.Lbl2.Name = "Lbl2";
            this.Lbl2.Size = new System.Drawing.Size(42, 13);
            this.Lbl2.TabIndex = 41;
            this.Lbl2.Text = "2000/0";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "HH.mm";
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(204, 98);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker2.Size = new System.Drawing.Size(96, 31);
            this.dateTimePicker2.TabIndex = 42;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged_1);
            // 
            // frmPop_Up_Vardiya
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.ClientSize = new System.Drawing.Size(761, 546);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.txtAçıklama_);
            this.Controls.Add(this.Lbl2);
            this.Controls.Add(this.txtAciklama_Var);
            this.Controls.Add(this.Lbl);
            this.Controls.Add(this.txtPersonel_);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblBitisVardiya);
            this.Controls.Add(this.lblVar_Sur);
            this.Controls.Add(this.lblBasVardiya);
            this.Controls.Add(this.lblMesaiSuresi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboPersonel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "frmPop_Up_Vardiya";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vardiya";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPop_Up_Vardiya_FormClosed);
            this.Load += new System.EventHandler(this.frmPop_Up_Vardiya_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboPersonel;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMesaiSuresi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblBasVardiya;
        private System.Windows.Forms.RichTextBox txtAciklama_Var;
        private System.Windows.Forms.Label lblVar_Sur;
        private System.Windows.Forms.Label lblBitisVardiya;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPersonel_;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtAçıklama_;
        private System.Windows.Forms.Label Lbl;
        private System.Windows.Forms.Label Lbl2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}