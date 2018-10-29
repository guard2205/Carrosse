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
    class MonRectangle : MonPoint
    {
        #region Données membres
        private Color _Pot = Color.Red;
        private bool _Remplir = true;
        private int _Hauteur = 1;
        private int _Longueur = 1;
        #endregion

        #region Constructeurs
        public MonRectangle(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) : base(hebergeur, xsg, ysg)
        {
            Longueur = longueur;
            Hauteur = hauteur;
        }

        public MonRectangle(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur, Color pot) : base(hebergeur, xsg, ysg)
        {
            Longueur = longueur;
            Hauteur = hauteur;
            Pot = pot;
        }

        public MonRectangle(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur, Color crayon, Color pot) : base(hebergeur, xsg, ysg)
        {
            Longueur = longueur;
            Hauteur = hauteur;
            Pot = pot;
        }

        #endregion

        #region Accesseurs
        public Color Pot
        {
            get { return _Pot; }
            set {
                try { _Pot = value;}
                catch (Exception){}
            }
        }

        public bool Remplir
        {
            get { return _Remplir; }
            set { _Remplir = value; }
        }

        public int Longueur
        {
            get { return _Longueur; }
            set 
            {
                if (value < 0) { _Longueur = 1; }
                else { _Longueur = value; }
            }
        }

        public int Hauteur
        {
            get { return _Hauteur; }
            set
            {
                if (value < 0) { _Hauteur = 1; }
                else { _Hauteur = value; }
            }
        }
        // modification accesseur, je rajoute les points sans les mouvements pour la classe rectangle
        public Point CSG
        {
            get { return new Point(X, Y); }
        }
        public Point CIG
        {
            get { return new Point((int)X , (int)(Y + Hauteur )); }
        }
        public Point CSD
        {
            get { return new Point( (int)(Longueur+X), (int)Y); }
        }
        public Point CID
        {
            get { return new Point((int)(X + Longueur), (int)(Y + Hauteur)); }
        }
        public Point MS
        {
            get { return new Point((int)((CSD.X + CSG.X) / 2), (int)((CSG.Y + CSD.Y) / 2)); }
        }
        public Point MI
        {
            get { return new Point((int)((CID.X + CIG.X) / 2), (int)((CID.Y + CIG.Y) / 2)); }
        }


        #endregion

        #region Méthodes

        public override void Afficher(IntPtr handle)
        {
            if (this.Visible)
            {
                Graphics gr = Graphics.FromHwnd(handle);
                Point[] pt = new Point[4];
                pt[0] = CSG;
                pt[1] = CSD;
                pt[2] = CID;
                pt[3] = CIG;
                if (this.Remplir)
                {
                    gr.FillClosedCurve(new SolidBrush(this.Pot), pt);
                    gr.DrawClosedCurve(new Pen(this.Crayon), pt);
                }
            }
        }

        public void Afficher(Graphics gr)
        {
            Point[] pt = new Point[4];
            pt[0] = CSG;
            pt[1] = CSD;
            pt[2] = CID;
            pt[3] = CIG;
            if (this.Visible)
            {
                if (this.Remplir)
                {
                    gr.FillClosedCurve(new SolidBrush(this.Pot), pt);
                    gr.DrawClosedCurve(new Pen(this.Crayon), pt);
                }
            }
        }


        public override void Cacher(IntPtr handle)
        {
            Graphics gr = Graphics.FromHwnd(handle);
            Point[] pt = new Point[4];
            pt[0] = CSG;
            pt[1] = CSD;
            pt[2] = CID;
            pt[3] = CIG;
            //Alpha += 1;
            if (this.Remplir)
            {
                gr.FillClosedCurve(new SolidBrush(this.Fond), pt);
                gr.DrawClosedCurve(new Pen(this.Fond), pt);
            }
        }
        public void AfficherCarré(IntPtr handle)
        {
            if (this.Visible)
            {
                Graphics gr = Graphics.FromHwnd(handle);
                Point[] pt = new Point[4];
                pt[0] = CSG;
                pt[1] = CSD;
                pt[2] = CID;
                pt[3] = CIG;
                //Alpha += 1;
                if (this.Remplir)
                {
                    gr.FillPolygon(new SolidBrush(this.Pot), pt);
                    gr.DrawPolygon(new Pen(this.Crayon), pt);
                }
            }
        }
        public void AfficherCarré(Graphics gr)
        {
            Point[] pt = new Point[4];
            pt[0] = CSG;
            pt[1] = CSD;
            pt[2] = CID;
            pt[3] = CIG;
            //Alpha += 1;
            if (this.Visible)
            {
                if (this.Remplir)
                {
                    gr.FillPolygon(new SolidBrush(this.Pot), pt);
                    gr.DrawPolygon(new Pen(this.Crayon), pt);
                }
            }
        }


        public void CacherCarré(IntPtr handle)
        {
            Graphics gr = Graphics.FromHwnd(handle);
            Point[] pt = new Point[4];
            pt[0] = CSG;
            pt[1] = CSD;
            pt[2] = CID;
            pt[3] = CIG;
            //Alpha += 1;
            if (this.Remplir)
            {
                gr.FillPolygon(new SolidBrush(this.Fond), pt);
                gr.DrawPolygon(new Pen(this.Fond), pt);
            }
        }
        public void AfficherTriangle(IntPtr handle)
        {
            if (this.Visible)
            {
                Graphics gr = Graphics.FromHwnd(handle);
                Point[] pt = new Point[3];
                
                pt[1] = CID;
                pt[2] = CIG;
                pt[0] = MS;
                //Alpha += 1;
                if (this.Remplir)
                {
                    gr.FillPolygon(new SolidBrush(this.Pot), pt);
                    gr.DrawPolygon(new Pen(this.Crayon), pt);
                }
            }
        }
        public void AfficherTriangle(Graphics gr)
        {
            Point[] pt = new Point[3];
            
            pt[1] = CID;
            pt[2] = CIG;
            pt[0] = MS;
            //Alpha += 1;
            if (this.Visible)
            {
                if (this.Remplir)
                {
                    gr.FillPolygon(new SolidBrush(this.Pot), pt);
                    gr.DrawPolygon(new Pen(this.Crayon), pt);
                }
            }
        }


        public void CacherTriangle(IntPtr handle)
        {
            Graphics gr = Graphics.FromHwnd(handle);
            Point[] pt = new Point[3];
            
            pt[1] = CID;
            pt[2] = CIG;
            pt[0] = MS;
            //Alpha += 1;
            if (this.Remplir)
            {
                gr.FillPolygon(new SolidBrush(this.Fond), pt);
                gr.DrawPolygon(new Pen(this.Fond), pt);
            }
        }
        #endregion
    }
}
