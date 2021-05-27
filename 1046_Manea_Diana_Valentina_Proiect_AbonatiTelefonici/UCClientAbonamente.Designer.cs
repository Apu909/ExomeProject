namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    partial class UCClientAbonamente
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
            this.btnAbMeu = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // btnAbMeu
            // 
            this.btnAbMeu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.btnAbMeu.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAbMeu.FlatAppearance.BorderSize = 0;
            this.btnAbMeu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbMeu.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbMeu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnAbMeu.Image = global::_1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici.Properties.Resources.icons8_add_folder_64;
            this.btnAbMeu.Location = new System.Drawing.Point(158, 28);
            this.btnAbMeu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAbMeu.Name = "btnAbMeu";
            this.btnAbMeu.Size = new System.Drawing.Size(172, 64);
            this.btnAbMeu.TabIndex = 3;
            this.btnAbMeu.Text = "Adauga Abonament";
            this.btnAbMeu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbMeu.UseVisualStyleBackColor = false;
            this.btnAbMeu.Click += new System.EventHandler(this.btnAbMeu_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // UCClientAbonamente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAbMeu);
            this.Name = "UCClientAbonamente";
            this.Size = new System.Drawing.Size(773, 814);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbMeu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
