namespace form_andmebaas
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
            this.toode_pb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Toode_txt = new System.Windows.Forms.TextBox();
            this.Kogus_txt = new System.Windows.Forms.TextBox();
            this.Hind_txt = new System.Windows.Forms.TextBox();
            this.lisa_kat_btn = new System.Windows.Forms.Button();
            this.kustuta_kat_btn = new System.Windows.Forms.Button();
            this.lisa_btn = new System.Windows.Forms.Button();
            this.uuenda_btn = new System.Windows.Forms.Button();
            this.kustuta_btn = new System.Windows.Forms.Button();
            this.puhasta_btn = new System.Windows.Forms.Button();
            this.otsifail_btn = new System.Windows.Forms.Button();
            this.kat_box = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.naita_kat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.toode_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toode_pb
            // 
            this.toode_pb.Location = new System.Drawing.Point(293, 2);
            this.toode_pb.Name = "toode_pb";
            this.toode_pb.Size = new System.Drawing.Size(495, 301);
            this.toode_pb.TabIndex = 0;
            this.toode_pb.TabStop = false;
            this.toode_pb.Click += new System.EventHandler(this.toode_pb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Toode:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kogus:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hind:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kategooriad:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(80, 308);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(708, 258);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseLeave);
            // 
            // Toode_txt
            // 
            this.Toode_txt.Location = new System.Drawing.Point(85, 26);
            this.Toode_txt.Name = "Toode_txt";
            this.Toode_txt.Size = new System.Drawing.Size(178, 20);
            this.Toode_txt.TabIndex = 6;
            // 
            // Kogus_txt
            // 
            this.Kogus_txt.Location = new System.Drawing.Point(85, 54);
            this.Kogus_txt.Name = "Kogus_txt";
            this.Kogus_txt.Size = new System.Drawing.Size(178, 20);
            this.Kogus_txt.TabIndex = 7;
            // 
            // Hind_txt
            // 
            this.Hind_txt.Location = new System.Drawing.Point(85, 83);
            this.Hind_txt.Name = "Hind_txt";
            this.Hind_txt.Size = new System.Drawing.Size(178, 20);
            this.Hind_txt.TabIndex = 8;
            // 
            // lisa_kat_btn
            // 
            this.lisa_kat_btn.Location = new System.Drawing.Point(6, 136);
            this.lisa_kat_btn.Name = "lisa_kat_btn";
            this.lisa_kat_btn.Size = new System.Drawing.Size(98, 36);
            this.lisa_kat_btn.TabIndex = 10;
            this.lisa_kat_btn.Text = "Lisa kategooriat";
            this.lisa_kat_btn.UseVisualStyleBackColor = true;
            this.lisa_kat_btn.Click += new System.EventHandler(this.lisa_kat_btn_Click);
            // 
            // kustuta_kat_btn
            // 
            this.kustuta_kat_btn.Location = new System.Drawing.Point(110, 136);
            this.kustuta_kat_btn.Name = "kustuta_kat_btn";
            this.kustuta_kat_btn.Size = new System.Drawing.Size(108, 36);
            this.kustuta_kat_btn.TabIndex = 11;
            this.kustuta_kat_btn.Text = "Kustuta kategooriat";
            this.kustuta_kat_btn.UseVisualStyleBackColor = true;
            this.kustuta_kat_btn.Click += new System.EventHandler(this.kustuta_kat_btn_Click);
            // 
            // lisa_btn
            // 
            this.lisa_btn.Location = new System.Drawing.Point(6, 308);
            this.lisa_btn.Name = "lisa_btn";
            this.lisa_btn.Size = new System.Drawing.Size(68, 19);
            this.lisa_btn.TabIndex = 12;
            this.lisa_btn.Text = "Lisa";
            this.lisa_btn.UseVisualStyleBackColor = true;
            this.lisa_btn.Click += new System.EventHandler(this.lisa_btn_Click);
            // 
            // uuenda_btn
            // 
            this.uuenda_btn.Location = new System.Drawing.Point(6, 333);
            this.uuenda_btn.Name = "uuenda_btn";
            this.uuenda_btn.Size = new System.Drawing.Size(68, 19);
            this.uuenda_btn.TabIndex = 13;
            this.uuenda_btn.Text = "Uuenda";
            this.uuenda_btn.UseVisualStyleBackColor = true;
            this.uuenda_btn.Click += new System.EventHandler(this.uuenda_btn_Click);
            // 
            // kustuta_btn
            // 
            this.kustuta_btn.Location = new System.Drawing.Point(6, 358);
            this.kustuta_btn.Name = "kustuta_btn";
            this.kustuta_btn.Size = new System.Drawing.Size(68, 19);
            this.kustuta_btn.TabIndex = 14;
            this.kustuta_btn.Text = "Kustuta";
            this.kustuta_btn.UseVisualStyleBackColor = true;
            this.kustuta_btn.Click += new System.EventHandler(this.kustuta_btn_Click);
            // 
            // puhasta_btn
            // 
            this.puhasta_btn.Location = new System.Drawing.Point(6, 383);
            this.puhasta_btn.Name = "puhasta_btn";
            this.puhasta_btn.Size = new System.Drawing.Size(68, 19);
            this.puhasta_btn.TabIndex = 15;
            this.puhasta_btn.Text = "Puhasta";
            this.puhasta_btn.UseVisualStyleBackColor = true;
            this.puhasta_btn.Click += new System.EventHandler(this.puhasta_btn_Click);
            // 
            // otsifail_btn
            // 
            this.otsifail_btn.Location = new System.Drawing.Point(293, 281);
            this.otsifail_btn.Name = "otsifail_btn";
            this.otsifail_btn.Size = new System.Drawing.Size(68, 21);
            this.otsifail_btn.TabIndex = 16;
            this.otsifail_btn.Text = "Otsi fail";
            this.otsifail_btn.UseVisualStyleBackColor = true;
            this.otsifail_btn.Click += new System.EventHandler(this.otsifail_btn_Click);
            // 
            // kat_box
            // 
            this.kat_box.FormattingEnabled = true;
            this.kat_box.Location = new System.Drawing.Point(87, 109);
            this.kat_box.Name = "kat_box";
            this.kat_box.Size = new System.Drawing.Size(176, 21);
            this.kat_box.TabIndex = 17;
            this.kat_box.SelectedIndexChanged += new System.EventHandler(this.kat_box_SelectedIndexChanged);
            // 
            // naita_kat
            // 
            this.naita_kat.Location = new System.Drawing.Point(6, 178);
            this.naita_kat.Name = "naita_kat";
            this.naita_kat.Size = new System.Drawing.Size(102, 32);
            this.naita_kat.TabIndex = 18;
            this.naita_kat.Text = "Näita kategooriat";
            this.naita_kat.UseVisualStyleBackColor = true;
            this.naita_kat.Click += new System.EventHandler(this.naita_kat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 579);
            this.Controls.Add(this.naita_kat);
            this.Controls.Add(this.kat_box);
            this.Controls.Add(this.otsifail_btn);
            this.Controls.Add(this.puhasta_btn);
            this.Controls.Add(this.kustuta_btn);
            this.Controls.Add(this.uuenda_btn);
            this.Controls.Add(this.lisa_btn);
            this.Controls.Add(this.kustuta_kat_btn);
            this.Controls.Add(this.lisa_kat_btn);
            this.Controls.Add(this.Hind_txt);
            this.Controls.Add(this.Kogus_txt);
            this.Controls.Add(this.Toode_txt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toode_pb);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.toode_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox toode_pb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox Toode_txt;
        private System.Windows.Forms.TextBox Kogus_txt;
        private System.Windows.Forms.TextBox Hind_txt;
        private System.Windows.Forms.Button lisa_kat_btn;
        private System.Windows.Forms.Button kustuta_kat_btn;
        private System.Windows.Forms.Button lisa_btn;
        private System.Windows.Forms.Button uuenda_btn;
        private System.Windows.Forms.Button kustuta_btn;
        private System.Windows.Forms.Button puhasta_btn;
        private System.Windows.Forms.Button otsifail_btn;
        private System.Windows.Forms.ComboBox kat_box;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button naita_kat;
    }
}

