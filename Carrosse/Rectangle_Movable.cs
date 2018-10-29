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
    class Rectangle_Movable : MonPoint
    {
        #region Données membres
        private bool Remplir = true; // permet de remplir l'intérieur
        public Color Pot = Color.Red;
        private int Longueur, Hauteur; // Taille 
        private int x, y; // position
        private double Angle;   // angle de déplacement du rectangle 
        #endregion

        #region Constructeur
        public Rectangle_Movable(PictureBox hebergeur, int x, int y, int Longueur, int Hauteur) : base (hebergeur, x, y) // on utilise un des constructeurs de base du point et on y rajoute les spec du rectangle
        {
            this.Angle = 0;
            this.Hauteur = Hauteur;
            this.Longueur = Longueur;
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Accesseur
        public double Angles
        {
            get { return Angle; }
            set { Angle = value;}
        }

        public Point CSG
        {
           get { return new Point(X,Y); }
        }

        public Point CSD
        {
            get { return new Point ( (int)(X + Longueur * Cos(Angle)),(int)(Y - Longueur * Sin(Angle)));}
        }

        public Point CIG
        {
            get { return new Point((int)(X + Hauteur * Cos(3 * PI / 2 + Angle)),(int)(Y - Hauteur * Sin(3 * PI / 2 + Angle))); }
        }

        public Point CID
        {
            get { return new Point((int)(X + Longueur * Cos(Angle) + Hauteur * Cos(3 * PI / 2 + Angle)), (int)(Y - Longueur * Sin(Angle) - Hauteur * Sin(3 * PI / 2 + Angle)));}
        }

        public Point MI
        {
            get { return new Point((CID.X + CIG.X) / 2, (CID.Y + CIG.Y) / 2); }
        }

        public Point MS
        {
            get { return new Point((CSD.X + CSG.X) / 2, (CSD.Y + CSG.Y) / 2); }
        }
        #endregion

        

        public override void Bouger(int DeplX, int DeplY) // On le fait bouger sans pour autant faire bouger l'angle, on fait juste bouger les positions
        {
            base.Bouger(DeplX, DeplY);
        }
        #endregion
    }
}