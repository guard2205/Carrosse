using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carrosse
{
    public partial class EcranAccueil : Form
    {
        private Skieur ca;
 
        private BufferedGraphics bufferG = null;
        private Graphics g;

        public EcranAccueil()
        {
            InitializeComponent();
            // Modification contre le scintillement - Creation d'une mémoire tampon graphique
            bufferG = BufferedGraphicsManager.Current.Allocate(TV.CreateGraphics(), TV.DisplayRectangle);
            g = bufferG.Graphics;
        }

        private void timerImage_Tick(object sender, EventArgs e)
        {
            if (this.ca.X + this.ca.Longueur >= this.TV.Width)
            {
                this.timerImage.Stop();
                this.btnStopDeplacerCTick.Enabled = false;
            }
            else
            {
                this.ca.Cacher(this.TV.Handle);
                this.ca.Bouger(4, 0, 0.1, -0.2, -0.1, 0.2, -0.1, -0.2, 0.1, 0.2,0,0);
                this.ca.Afficher(this.TV.Handle);
            }
        }

        private void btnStopDeplacerCTick_Click(object sender, EventArgs e)
        {
            this.timerImage.Stop();
            this.btnStopDeplacerCTick.Enabled = false;
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            Graphics gr = Graphics.FromHwnd(this.TV.Handle);
            gr.FillRectangle(new SolidBrush(this.TV.BackColor), 0, 0, this.TV.Bounds.Width, this.TV.Bounds.Height);
        }

        private void btnCreationCarrosse_Click(object sender, EventArgs e)
        {
            // Personnage( hebergeur,  xsg,  ysg,  longueur,  hauteur,  abgh,  abgb,  abdh,  abdb,  ajgh,  ajgb,  ajdh,  ajdb)
            this.ca = new Skieur(this.TV, 20, 100, 20, 60,200, 700);
            
            
            this.ca.Marcher(200, 0, this.TV.Handle);
            this.ca.Accélération(this.TV.Handle);
        }

        private void TV_Click(object sender, EventArgs e)
        {

        }
    }
}
