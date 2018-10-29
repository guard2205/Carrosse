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
    class MonCarrosse : MonRectangle // class MonCarrosse qui dans l'animatition représente le buste. 
    {
        #region Données membres
        private MonCercle  _Head;   
        private MyArm _LArm, _RArm;
        private MyLegSkieur _LFoot, _RFoot;
        #endregion

        #region Constructeurs
        public MonCarrosse(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) : base(hebergeur, xsg, ysg, longueur, hauteur)
        {
            this.Head = new MonCercle(hebergeur, xsg + longueur / 2, ysg - longueur*3/4, longueur/2);
            this.LArm = new MyArm(hebergeur, base.MS.X, ysg, longueur/3, hauteur/3); 
            this.RArm = new MyArm(hebergeur, base.MS.X  , ysg, longueur/3, Hauteur/3);
            this.LFoot = new MyLegSkieur(hebergeur, base.MI.X , ysg + hauteur, longueur/2, hauteur / 2);
            this.RFoot = new MyLegSkieur(hebergeur, base.MI.X , ysg + hauteur, longueur/2, hauteur / 2);
        }
        #endregion

        #region Accesseurs
        public MonCercle Head
        {
            get { return _Head; }
            set { _Head = value; }
        }
        public MyLegSkieur LFoot
        {
            get { return _LFoot; }
            set { _LFoot = value; }
        }

        public MyLegSkieur RFoot
        {
            get { return _RFoot; }
            set { _RFoot = value; }
        }

        public MyArm LArm
        {
            get { return _LArm; }
            set { _LArm = value; }
        }

        public MyArm RArm
        {
            get { return _RArm; }
            set { _RArm = value; }
        }
        #endregion

        #region Méthodes
        public void Bouger(int deplX, int deplY,double abgh, double abgb,double abdh, double abdb, double ajgh, double ajgb, double ajdh,double ajdb, double apg, double apd)
        { // Angle Bras-Jambe Gauche-Droite Haut-Bas
            base.Bouger(deplX, deplY);
            this.RFoot.Bouger(deplX, deplY, ajdh, ajdb, apd);
            this.LFoot.Bouger(deplX, deplY, ajgh, ajgb, apg);
            this.Head.Bouger(deplX, deplY);
            this.LArm.Bouger(deplX, deplY, abgh, abgb);
            this.RArm.Bouger(deplX, deplY, abdh, abdb);
        }

        public new void Cacher(IntPtr handle)
        {
            base.Cacher(handle);
            this.LArm.Cacher(handle);
            this.LFoot.Cacher(handle);
            this.RArm.Cacher(handle);
            this.RFoot.Cacher(handle);
            this.Head.Cacher(handle);
        }

        public new void Afficher(IntPtr handle)
        {
            
            this.LArm.Afficher(handle);
            this.LFoot.Afficher(handle);
            this.Head.Afficher(handle);           
            base.Afficher(handle);
            this.Head.Afficher(handle);
            this.RArm.Afficher(handle);
            this.RFoot.Afficher(handle);
        }
        #endregion
    }
}
