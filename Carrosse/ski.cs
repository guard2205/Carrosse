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
    class ski : MonRectangleTournant
    {
        #region Données Membres 
        #endregion

        #region Constructeur
        public ski(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) :base(hebergeur,xsg, ysg, longueur, hauteur)
        {
        }

        #endregion
       
        #region Methodes
        public /*new*/ void Bouger(int deplX, int deplY, double dAH, double dAB)
        {
            base.Bouger(deplX, deplY, 0);
            Bouger(0, 0, 0);
            Bouger(0, 0, 0);
        }
        public new void Cacher(IntPtr handle)
        {
            base.Cacher(handle);
        }
        public new void Afficher(IntPtr handle)
        {
            base.Afficher(handle);
        }
        #endregion
    }
}
