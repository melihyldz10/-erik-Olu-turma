
namespace Proje
{
    partial class myContent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(myContent));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_İcerikSil = new System.Windows.Forms.Button();
            this.btn_Guncelle = new System.Windows.Forms.Button();
            this.btn_indir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1026, 521);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // btn_İcerikSil
            // 
            this.btn_İcerikSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btn_İcerikSil.FlatAppearance.BorderSize = 0;
            this.btn_İcerikSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_İcerikSil.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_İcerikSil.ForeColor = System.Drawing.Color.White;
            this.btn_İcerikSil.Image = ((System.Drawing.Image)(resources.GetObject("btn_İcerikSil.Image")));
            this.btn_İcerikSil.Location = new System.Drawing.Point(1031, 465);
            this.btn_İcerikSil.Margin = new System.Windows.Forms.Padding(4);
            this.btn_İcerikSil.Name = "btn_İcerikSil";
            this.btn_İcerikSil.Size = new System.Drawing.Size(58, 56);
            this.btn_İcerikSil.TabIndex = 11;
            this.btn_İcerikSil.UseVisualStyleBackColor = false;
            this.btn_İcerikSil.Click += new System.EventHandler(this.btn_İcerikSil_Click);
            // 
            // btn_Guncelle
            // 
            this.btn_Guncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btn_Guncelle.FlatAppearance.BorderSize = 0;
            this.btn_Guncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guncelle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guncelle.ForeColor = System.Drawing.Color.White;
            this.btn_Guncelle.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guncelle.Image")));
            this.btn_Guncelle.Location = new System.Drawing.Point(1031, 401);
            this.btn_Guncelle.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Guncelle.Name = "btn_Guncelle";
            this.btn_Guncelle.Size = new System.Drawing.Size(58, 56);
            this.btn_Guncelle.TabIndex = 12;
            this.btn_Guncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Guncelle.UseVisualStyleBackColor = false;
            this.btn_Guncelle.Click += new System.EventHandler(this.btn_Guncelle_Click);
            // 
            // btn_indir
            // 
            this.btn_indir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btn_indir.FlatAppearance.BorderSize = 0;
            this.btn_indir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_indir.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_indir.ForeColor = System.Drawing.Color.White;
            this.btn_indir.Image = ((System.Drawing.Image)(resources.GetObject("btn_indir.Image")));
            this.btn_indir.Location = new System.Drawing.Point(1031, 337);
            this.btn_indir.Margin = new System.Windows.Forms.Padding(4);
            this.btn_indir.Name = "btn_indir";
            this.btn_indir.Size = new System.Drawing.Size(58, 56);
            this.btn_indir.TabIndex = 13;
            this.btn_indir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_indir.UseVisualStyleBackColor = false;
            this.btn_indir.Click += new System.EventHandler(this.btn_indir_Click);
            // 
            // myContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_indir);
            this.Controls.Add(this.btn_Guncelle);
            this.Controls.Add(this.btn_İcerikSil);
            this.Controls.Add(this.dataGridView1);
            this.Name = "myContent";
            this.Size = new System.Drawing.Size(1089, 521);
            this.Load += new System.EventHandler(this.myContent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_İcerikSil;
        private System.Windows.Forms.Button btn_Guncelle;
        private System.Windows.Forms.Button btn_indir;
    }
}
