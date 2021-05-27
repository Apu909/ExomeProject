namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    partial class UCclientiPlataFacturi
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.achitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPlata = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Nume_Client = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Numar_de_Telefon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nume_Abonament = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pret_Abonament = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.achitaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 26);
            // 
            // achitaToolStripMenuItem
            // 
            this.achitaToolStripMenuItem.Name = "achitaToolStripMenuItem";
            this.achitaToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.achitaToolStripMenuItem.Text = "Achita";
            this.achitaToolStripMenuItem.Click += new System.EventHandler(this.achitaToolStripMenuItem_Click);
            // 
            // btnPlata
            // 
            this.btnPlata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.btnPlata.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPlata.FlatAppearance.BorderSize = 0;
            this.btnPlata.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlata.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnPlata.Image = global::_1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici.Properties.Resources.icons8_pay_641;
            this.btnPlata.Location = new System.Drawing.Point(74, 24);
            this.btnPlata.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPlata.Name = "btnPlata";
            this.btnPlata.Size = new System.Drawing.Size(172, 64);
            this.btnPlata.TabIndex = 6;
            this.btnPlata.Text = "Plateste";
            this.btnPlata.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlata.UseVisualStyleBackColor = false;
            this.btnPlata.Click += new System.EventHandler(this.btnPlata_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nume_Client,
            this.Numar_de_Telefon,
            this.Email,
            this.Adresa,
            this.Nume_Abonament,
            this.Pret_Abonament});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(24, 130);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(716, 351);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Nume_Client
            // 
            this.Nume_Client.Text = "Nume_Client";
            // 
            // Numar_de_Telefon
            // 
            this.Numar_de_Telefon.Text = "Numar_de_Telefon";
            // 
            // Email
            // 
            this.Email.Text = "Email";
            // 
            // Adresa
            // 
            this.Adresa.Text = "Adresa";
            // 
            // Nume_Abonament
            // 
            this.Nume_Abonament.Text = "Nume_Abonament";
            // 
            // Pret_Abonament
            // 
            this.Pret_Abonament.Text = "Pret_Abonament";
            // 
            // UCclientiPlataFacturi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnPlata);
            this.Name = "UCclientiPlataFacturi";
            this.Size = new System.Drawing.Size(800, 517);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPlata;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem achitaToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Nume_Client;
        private System.Windows.Forms.ColumnHeader Numar_de_Telefon;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Adresa;
        private System.Windows.Forms.ColumnHeader Nume_Abonament;
        private System.Windows.Forms.ColumnHeader Pret_Abonament;
    }
}
