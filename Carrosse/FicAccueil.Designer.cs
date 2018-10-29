namespace Carrosse
{
    partial class EcranAccueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TV = new System.Windows.Forms.PictureBox();
            this.timerImage = new System.Windows.Forms.Timer(this.components);
            this.btnEffacer = new System.Windows.Forms.Button();
            this.btnStopDeplacerCTick = new System.Windows.Forms.Button();
            this.btnCreationCarrosse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TV)).BeginInit();
            this.SuspendLayout();
            // 
            // TV
            // 
            this.TV.Location = new System.Drawing.Point(17, 16);
            this.TV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TV.Name = "TV";
            this.TV.Size = new System.Drawing.Size(1043, 297);
            this.TV.TabIndex = 0;
            this.TV.TabStop = false;
            this.TV.Click += new System.EventHandler(this.TV_Click);
            // 
            // timerImage
            // 
            this.timerImage.Interval = 40;
            this.timerImage.Tick += new System.EventHandler(this.timerImage_Tick);
            // 
            // btnEffacer
            // 
            this.btnEffacer.Location = new System.Drawing.Point(17, 375);
            this.btnEffacer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEffacer.Name = "btnEffacer";
            this.btnEffacer.Size = new System.Drawing.Size(519, 28);
            this.btnEffacer.TabIndex = 10;
            this.btnEffacer.Text = "Effacer Tout";
            this.btnEffacer.UseVisualStyleBackColor = true;
            this.btnEffacer.Click += new System.EventHandler(this.btnEffacer_Click);
            // 
            // btnStopDeplacerCTick
            // 
            this.btnStopDeplacerCTick.Enabled = false;
            this.btnStopDeplacerCTick.Location = new System.Drawing.Point(544, 375);
            this.btnStopDeplacerCTick.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStopDeplacerCTick.Name = "btnStopDeplacerCTick";
            this.btnStopDeplacerCTick.Size = new System.Drawing.Size(516, 28);
            this.btnStopDeplacerCTick.TabIndex = 9;
            this.btnStopDeplacerCTick.Text = "Stop Tick";
            this.btnStopDeplacerCTick.UseVisualStyleBackColor = true;
            this.btnStopDeplacerCTick.Click += new System.EventHandler(this.btnStopDeplacerCTick_Click);
            // 
            // btnCreationCarrosse
            // 
            this.btnCreationCarrosse.Location = new System.Drawing.Point(17, 340);
            this.btnCreationCarrosse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreationCarrosse.Name = "btnCreationCarrosse";
            this.btnCreationCarrosse.Size = new System.Drawing.Size(1043, 28);
            this.btnCreationCarrosse.TabIndex = 11;
            this.btnCreationCarrosse.Text = "Creer Carrosse";
            this.btnCreationCarrosse.UseVisualStyleBackColor = true;
            this.btnCreationCarrosse.Click += new System.EventHandler(this.btnCreationCarrosse_Click);
            // 
            // EcranAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 511);
            this.Controls.Add(this.btnCreationCarrosse);
            this.Controls.Add(this.btnEffacer);
            this.Controls.Add(this.btnStopDeplacerCTick);
            this.Controls.Add(this.TV);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EcranAccueil";
            this.Text = "Dessins Animés";
            ((System.ComponentModel.ISupportInitialize)(this.TV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox TV;
        private System.Windows.Forms.Timer timerImage;
        private System.Windows.Forms.Button btnEffacer;
        private System.Windows.Forms.Button btnStopDeplacerCTick;
        private System.Windows.Forms.Button btnCreationCarrosse;
    }
}

