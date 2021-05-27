namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    partial class UCFacturiCompanie
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Nume_Client = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Numar_de_Telefon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nume_Abonament = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pret_Abonament = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Achitata = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nume_Client,
            this.Numar_de_Telefon,
            this.Email,
            this.Adresa,
            this.Nume_Abonament,
            this.Pret_Abonament,
            this.Achitata});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(22, 111);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(664, 388);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Nume_Client
            // 
            this.Nume_Client.Text = "Nume_Client";
            this.Nume_Client.Width = 76;
            // 
            // Numar_de_Telefon
            // 
            this.Numar_de_Telefon.Text = "Numar_de_Telefon";
            this.Numar_de_Telefon.Width = 103;
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
            this.Nume_Abonament.Width = 108;
            // 
            // Pret_Abonament
            // 
            this.Pret_Abonament.Text = "Pret_Abonament";
            this.Pret_Abonament.Width = 102;
            // 
            // Achitata
            // 
            this.Achitata.Text = "Achitata";
            // 
            // UCFacturiCompanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.listView1);
            this.Name = "UCFacturiCompanie";
            this.Size = new System.Drawing.Size(720, 545);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Nume_Client;
        private System.Windows.Forms.ColumnHeader Numar_de_Telefon;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Adresa;
        private System.Windows.Forms.ColumnHeader Nume_Abonament;
        private System.Windows.Forms.ColumnHeader Pret_Abonament;
        private System.Windows.Forms.ColumnHeader Achitata;
    }
}
