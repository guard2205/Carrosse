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
    class piquet : Rectangle_Movable
    {
#region Données membres
        private Rectangle_Movable _GardeMain, piquet;
        #endregion

        #region Constructeurs
        public piquet(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) : base ( hebergeur, xsg, ysg, longueur, hauteur)
        {
        }
#endregion

    }
}
