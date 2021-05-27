namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    partial class UserControlAbMeu
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
            this.Nume_Abonament = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pret_Abonament = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Internet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Minute_Int = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SMS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Minute_Nat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Internet_Nelimitat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nume_Abonament,
            this.Pret_Abonament,
            this.Internet,
            this.Minute_Int,
            this.SMS,
            this.Minute_Nat,
            this.Internet_Nelimitat});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(39, 99);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(609, 320);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Nume_Abonament
            // 
            this.Nume_Abonament.Text = "Nume_Abonament";
            this.Nume_Abonament.Width = 111;
            // 
            // Pret_Abonament
            // 
            this.Pret_Abonament.Text = "Pret_Abonament";
            this.Pret_Abonament.Width = 102;
            // 
            // Internet
            // 
            this.Internet.Text = "Internet";
            this.Internet.Width = 68;
            // 
            // Minute_Int
            // 
            this.Minute_Int.Text = "Minute_Int";
            this.Minute_Int.Width = 90;
            // 
            // SMS
            // 
            this.SMS.Text = "SMS";
            // 
            // Minute_Nat
            // 
            this.Minute_Nat.Text = "Minute_Nat";
            this.Minute_Nat.Width = 73;
            // 
            // Internet_Nelimitat
            // 
            this.Internet_Nelimitat.Text = "Internet_Nelimitat";
            this.Internet_Nelimitat.Width = 96;
            // 
            // UserControlAbMeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserControlAbMeu";
            this.Size = new System.Drawing.Size(679, 454);
            this.Load += new System.EventHandler(this.UserControlAbMeu_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Nume_Abonament;
        private System.Windows.Forms.ColumnHeader Pret_Abonament;
        private System.Windows.Forms.ColumnHeader Internet;
        private System.Windows.Forms.ColumnHeader Minute_Int;
        private System.Windows.Forms.ColumnHeader SMS;
        private System.Windows.Forms.ColumnHeader Minute_Nat;
        private System.Windows.Forms.ColumnHeader Internet_Nelimitat;
    }
}
