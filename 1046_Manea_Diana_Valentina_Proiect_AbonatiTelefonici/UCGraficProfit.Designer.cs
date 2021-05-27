namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    partial class UCGraficProfit
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnAbMeu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(237, 183);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Pret";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(685, 388);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Profit per Abonament";
            this.chart1.Titles.Add(title1);
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
            this.btnAbMeu.Location = new System.Drawing.Point(237, 102);
            this.btnAbMeu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAbMeu.Name = "btnAbMeu";
            this.btnAbMeu.Size = new System.Drawing.Size(172, 64);
            this.btnAbMeu.TabIndex = 4;
            this.btnAbMeu.Text = "Incarca Date";
            this.btnAbMeu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbMeu.UseVisualStyleBackColor = false;
            this.btnAbMeu.Click += new System.EventHandler(this.btnAbMeu_Click);
            // 
            // UCGraficProfit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.btnAbMeu);
            this.Controls.Add(this.chart1);
            this.Name = "UCGraficProfit";
            this.Size = new System.Drawing.Size(955, 598);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnAbMeu;
    }
}
