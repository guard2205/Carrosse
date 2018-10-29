using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Carrosse
{
    class Jambe : Rectangle_Movable
    {
        #region Données membres
        private Rectangle_Movable Mollet, Pied;
       

        #endregion

        #region Constructeurs
        public Jambe(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) : base(hebergeur, xsg, ysg, longueur, hauteur)
        {
            this.Mollet = new Rectangle_Movable(hebergeur, xsg, ysg + hauteur, longueur, hauteur - hauteur / 10);
            this.Pied = new Rectangle_Movable(hebergeur, xsg, ysg + hauteur + hauteur - hauteur / 10, longueur + longueur, hauteur/6);
            this.Pot = Color.DarkBlue;
            this.Crayon = Color.Black;
            this.Mollet.Pot = Color.DarkBlue;
            this.Pied.Pot = Color.DarkGray;

        }
        #endregion

        #region Méthodes
        public new void Afficher(IntPtr handle)
        {
            base.Afficher(handle);
            this.Mollet.Afficher(handle);
            this.Pied.Afficher(handle);
        }

        public new void Cacher(IntPtr handle)
        {
            base.Cacher(handle);
            this.Mollet.Cacher(handle);
            this.Pied.Cacher(handle);
        }

        public void Bouger(int deplX, int deplY, double Angle_Jambe, double Angle_Avant)
        {
            this.Angles = Angle_Jambe;
            this.Mollet.Angles = Angle_Avant;
            base.Bouger(deplX, deplY);
            this.Mollet.X = base.CIG.X;
            this.Mollet.Y = base.CIG.Y;
            Point tr = new Point(this.Mollet.MS.X - this.MI.X, this.Mollet.MS.Y - this.MI.Y);
            this.Mollet.X -= tr.X;
            this.Mollet.Y -= tr.Y;
            this.Pied.X = this.Mollet.CIG.X;
            this.Pied.Y = this.Mollet.CIG.Y;
            this.Pied.Angles = Angle_Avant;
        }
        #endregion
    }
}
