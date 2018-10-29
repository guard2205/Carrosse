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
    class MyArm : MonRectangleTournant
    {
        #region Données Membres
        private MonRectangleTournant _ForeArm, _Hand;

        #endregion

        #region Constructeur
        public MyArm(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) : base(hebergeur, xsg, ysg, longueur, hauteur)
        {
            this._ForeArm = new MonRectangleTournant(hebergeur, xsg, ysg + hauteur, longueur ,hauteur);
            this._Hand = new MonRectangleTournant(hebergeur, xsg, ysg + 2 * hauteur , longueur, hauteur / 3);

            // A essayer avec un rectangle tournant
            //this._Piquet = new MonRectangleTournantCarré(hebergeur, xsg, ysg ,12/2*hauteur , 1/2*longueur);


            this._ForeArm.Pot = Color.Yellow;
            this._Hand.Pot = Color.Yellow;
        }

        #endregion

        #region Accesseur 
        public MonRectangleTournant Hand
        {
            get { return _Hand; }
            set { _Hand = value; }
        }
        #endregion

        #region Methodes
        public void Bouger(int deplX, int deplY, double dAH, double dAB)
        {


            base.Bouger(deplX, deplY, dAH);

            this._ForeArm.X = base.CIG.X;
            this._ForeArm.Y = base.CIG.Y;
            this._ForeArm.X -= this._ForeArm.MS.X - MI.X;
            this._ForeArm.Y -= this._ForeArm.MS.Y - MI.Y;
            this._ForeArm.Bouger(0, 0, dAB);

            this.Hand.X = _ForeArm.X;
            this.Hand.Y = _ForeArm.Y;
            this.Hand.X -= this._Hand.MS.X - _ForeArm.MI.X;
            this.Hand.Y -= this._Hand.MS.Y - _ForeArm.MI.Y;
            this.Hand.Bouger(0, 0, dAB);
        }
        public new void Cacher(IntPtr handle)
        {
            base.Cacher(handle);
            this._ForeArm.Cacher(handle);
            this.Hand.Cacher(handle);
        }
        public new void Afficher(IntPtr handle)
        {
            base.Afficher(handle);
            this._ForeArm.Afficher(handle);
            this.Hand.Afficher(handle);
        }
        #endregion
    }
}