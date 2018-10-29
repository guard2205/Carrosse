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
    class MyFoot : MonRectangleTournant
    {
        #region Donnée membres 
        MonRectangleTournant _Ski;
        #endregion

        #region Constructeur
         public  MyFoot(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) : base(hebergeur, xsg, ysg, longueur, hauteur)
         {
            this._Ski = new MonRectangleTournant(hebergeur, xsg,ysg, longueur*8, hauteur/4);
         }

        public /*new*/ void BougerPied(int deplX, int deplY, double dAH)
        {
            base.Bouger(deplX, deplY, dAH);
            this._Ski.X = base.MI.X;
            this._Ski.Y = base.MI.Y;
            this._Ski.X -= this._Ski.MS.X - MI.X;
            this._Ski.Y -= this._Ski.MS.Y - MI.Y;
            this._Ski.Bouger(0, 0, 0);
        }
        public  void CacherPied(IntPtr handle)
        {
            base.Cacher(handle);
            this._Ski.CacherCarré(handle);
        }
        public  void AfficherPied(IntPtr handle)
        {
            base.Afficher(handle);
            this._Ski.AfficherCarré(handle);
        }

        #endregion
    }
}
