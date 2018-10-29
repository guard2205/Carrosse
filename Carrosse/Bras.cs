using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Math;

namespace Carrosse
{
    class Bras : Rectangle_Movable
    {
        #region Données membres
        private Rectangle_Movable AvantBras, Main;
        //private double Angle_Bras, Angle_Avant;
        #endregion

        #region Constructeurs
        public Bras(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) : base(hebergeur, xsg, ysg, longueur, hauteur)
        {
            this.AvantBras = new Rectangle_Movable(hebergeur, xsg, ysg + hauteur, longueur, hauteur - hauteur / 10);
            this.Main = new Rectangle_Movable(hebergeur, xsg, ysg + hauteur + hauteur - hauteur / 10, longueur, hauteur / 6);
            this.Pot = Color.Red;
            this.Crayon = Color.Black;
            this.AvantBras.Pot = Color.Red;
            this.Main.Pot = Color.LightPink;

        }
        #endregion

        #region Méthodes
        public new void Afficher(IntPtr handle)
        {
            base.Afficher(handle);
            this.AvantBras.Afficher(handle);
            this.Main.Afficher(handle);
        }

        public new void Cacher(IntPtr handle)
        {
            base.Cacher(handle);
            this.AvantBras.Cacher(handle);
            this.Main.Cacher(handle);
        }

        public void Bouger(int deplX, int deplY, double Angle_Bras, double Angle_Avant)
        {

            this.Angles = Angle_Bras;
            this.AvantBras.Angles = Angle_Avant;
            this.Main.Angles = Angle_Avant;
            base.Bouger(deplX, deplY);
            this.AvantBras.X = this.CIG.X;
            this.AvantBras.Y = this.CIG.Y;
            Point tr = new Point(this.AvantBras.MS.X - this.MI.X, this.AvantBras.MS.Y - this.MI.Y);
            this.AvantBras.X -= tr.X;
            this.AvantBras.Y -= tr.Y;
            this.Main.X = this.AvantBras.CIG.X;
            this.Main.Y = this.AvantBras.CIG.Y;
        }
        #endregion
    }
}
