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
    class MyLeg : MonRectangleTournant
    {
        #region Données Membres
        private MonRectangleTournant _Thigh, _Foot;          // calf= mollet   thight =Cuisse 
        #endregion

        #region Constructeur
        public MyLeg(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) : base(hebergeur, xsg, ysg, longueur, hauteur)
        {
            this._Thigh = new MonRectangleTournant(hebergeur, xsg, ysg + hauteur, longueur, hauteur);
            this._Foot = new MonRectangleTournant(hebergeur, xsg, ysg + 2 * hauteur, (int)(longueur * 3 / 2), hauteur / 3);
            this._Thigh.Pot = Color.Blue;
            this._Foot.Pot = Color.Blue;
        }


        #endregion
        /*
       #region Accesseurs

       public MonRectangle Thigh
       {
           get { return _Thigh; }
           set { _Thigh = value; }
       }
       public MonRectangle Foot
       {
           get { return _Foot; }
           set { _Foot = value; }
       }
       #endregion
   */
        #region Methodes
        public /*new*/ void Bouger(int deplX, int deplY, double dAH, double dAB, double dAP)
        {
            base.Bouger(deplX, deplY, dAH);
            this._Thigh.X = base.MI.X;
            this._Thigh.Y = base.MI.Y;
            this._Thigh.X -= this._Thigh.MS.X - MI.X;
            this._Thigh.Y -= this._Thigh.MS.Y - MI.Y;
            this._Thigh.Bouger(0, 0, dAB);
            this._Foot.X = _Thigh.X;
            this._Foot.Y = _Thigh.Y;
            this._Foot.X -= this._Foot.MS.X - this._Thigh.MI.X;
            this._Foot.Y -= this._Foot.MS.Y - this._Thigh.MI.Y;
            this._Foot.Bouger(0, 0, dAP);
        }
        public new void Cacher(IntPtr handle)
        {
            base.Cacher(handle);
            this._Thigh.Cacher(handle);
            this._Foot.Cacher(handle);
        }
        public new void Afficher(IntPtr handle)
        {
            base.Afficher(handle);
            this._Thigh.Afficher(handle);
            this._Foot.Afficher(handle);
        }
        #endregion
    }
}
