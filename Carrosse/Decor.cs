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
    class Decor : MonRectangle
    {
        #region Données Membres
        private MonRectangle _Montagne1, _Montagne2, _Neige, _Neige2, _Obstacle1;
        private MonCercle _Soleil;
        public MonRectangle _Obstacle2;
        #endregion

        #region Constructeur 
        public Decor(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur, Color crayon, Color pot) : base(hebergeur,xsg,ysg,longueur,hauteur, crayon, pot)
        {
            //this.DecorArr = new Decor(hebergeur, 0, 200, 700, 80,Color.White, Color.White);

            _Soleil = new MonCercle(hebergeur,((300+75)+(350+88))/2,ysg-175,20,Color.Yellow); // on le met entre les deux montagnes 
            _Montagne1 = new MonRectangle(hebergeur, 300, ysg-150, 150, 150,Color.Gray);
            _Montagne2 = new MonRectangle(hebergeur, 350, ysg-175, 175, 175,Color.Gray,Color.Gray);
            _Neige  = new MonRectangle(hebergeur, 360, ysg - 150, 30, 30, Color.White);
            _Neige2 = new MonRectangle(hebergeur, 420, ysg - 175, 35, 35, Color.White);
            _Obstacle2 = new MonRectangle(hebergeur, longueur, ysg - 30, 10, 60);
            _Obstacle1 = new MonRectangle(hebergeur, longueur, ysg - 60, 10, 60);
        }
        #endregion


        #region Méthode
        public new void BougerArr(int deplX, int deplY)
        {
            this._Montagne1.Bouger(deplX, deplY);
            this._Montagne2.Bouger(deplX, deplY);
            this._Neige.Bouger(deplX, deplY);
            this._Neige2.Bouger(deplX, deplY);
        }
        public new void BougerObstacle1(int deplX, int deplY)
        {
            this._Obstacle1.Bouger(deplX, deplY);
        }
        public new void BougerObstacle2(int deplX, int deplY)
        {
            this._Obstacle2.Bouger(deplX, deplY);
        }
        public new void Cacher(IntPtr handle)
        {
            base.Cacher(handle);
            this._Soleil.Cacher(handle);
            _Montagne1.CacherTriangle(handle);
            _Montagne2.CacherTriangle(handle);
            _Neige.CacherTriangle(handle);
            _Neige2.CacherTriangle(handle);
            _Obstacle1.CacherCarré(handle);
            _Obstacle2.CacherCarré(handle);
        }
        public new void Afficher(IntPtr handle)
        {
            base.AfficherCarré(handle);
            this._Soleil.Afficher(handle);
            this._Montagne1.AfficherTriangle(handle);
            this._Montagne2.AfficherTriangle(handle);
            this._Neige.AfficherTriangle(handle);
            this._Neige2.AfficherTriangle(handle);
            this._Obstacle1.AfficherCarré(handle);
            // afficher obstacle2 ailleurs pour qu'il soit devant le bonhomme
        }
        #endregion

    }
}
