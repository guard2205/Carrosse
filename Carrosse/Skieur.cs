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
    class Skieur : MonRectangle
    {
        #region Données membres
        private MonCercle _Head;
        private MyArm _LArm, _RArm;
        private MyLegSkieur _LFoot, _RFoot;
        private Decor _DecorArr;
        private MonRectangleTournant _LStick, _RStick; 

        #endregion

        #region Constructeurs
        public Skieur(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur, int HauteurDecor,int LongueurDecor) : base(hebergeur, xsg, ysg, longueur, hauteur)
        {
            this.DecorArr = new Decor(hebergeur, 0, HauteurDecor,  LongueurDecor, 80,Color.White, Color.White);
            this.Head = new MonCercle(hebergeur, xsg + longueur / 2, ysg - longueur * 3 / 4, longueur / 2);
            this.LArm = new MyArm(hebergeur, base.MS.X, ysg, longueur / 3, hauteur / 3);
            this.RArm = new MyArm(hebergeur, base.MS.X, ysg, longueur / 3, Hauteur / 3);
            this.LFoot = new MyLegSkieur(hebergeur, base.MI.X, ysg + hauteur, longueur / 2, hauteur / 2);
            this.RFoot = new MyLegSkieur(hebergeur, base.MI.X, ysg + hauteur, longueur / 2, hauteur / 2);
            this.LStick = new MonRectangleTournant(hebergeur, this.RArm.Hand.CID.X, this.RArm.Hand.CID.Y, (int)(hauteur * 1.8), longueur / 5, Color.Blue);

            this.RStick = new MonRectangleTournant(hebergeur, this.RArm.Hand.CID.X, this.RArm.Hand.CID.Y, (int)(hauteur*1.8), longueur/5, Color.Blue);
        }
        #endregion

        #region Accesseurs
        public MonRectangleTournant LStick
        {
            get { return _LStick; }
            set { _LStick = value; }
        }
        public MonRectangleTournant RStick
        {
            get { return _RStick; }
            set { _RStick = value; }
        }
        public Decor DecorArr
        {
            get { return _DecorArr; }
            set { _DecorArr = value; }
        }
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
        public void Marcher(int deplX, int deplY, IntPtr handle)
        {
            int i = 0;
            int j = 8;
            int CDG=1;

            // !!!!!!!!!!!!!!
            // attention les pixels sont en int ... 
            // !!!!!!!!!!!!!! 

            Cacher(handle);
            Bouger(40, 0, 0, 1.5708, 0, 1.5708, 0, 0, 0, 0,0,0);

            this.RStick.Bouger(0, 0, 2 * 1.5708);
            this.LStick.Bouger(0, 0, 2 * 1.5708);

            System.Threading.Thread.Sleep(100);
            Cacher(handle);
            Afficher(handle);

            System.Threading.Thread.Sleep(1000);
            Cacher(handle);
            // void Bouger(int deplX, int deplY, double abgh, double abgb, double abdh, double abdb, double ajgh, double ajgb, double ajdh, double ajdb)

            //premier mouvement 
            //mise en mouvement 
            // jambe gauche en mouvement vers l'avant
            // jambe droite en mouvement vers l'arriere
            // main droite en mouvement

            for (i = 0; i < j; i++)
            {
                Bouger((int)(deplX / (j * 3)), CDG + (int)(deplY / j * 4), -0.261799 / j, -1.0472 / j, 0, 0, +0.785398 / j, 0, -0.785398 / j, -0.785398 / j, 0, 0);
                Afficher(handle);
                System.Threading.Thread.Sleep(1000 / j);
                Cacher(handle);
            }

            //deuxieme mouvement 
            // reviens a la position de base 

            for (i = 0; i < j; i++)
            {
                Bouger((int)(deplX / (j * 6)), -CDG + (int)(deplY) / (j * 4), 0.261799 / j, +1.0472 / j, 0, -0, -0.785398 / j, 0, +0.785398 / j, +0.785398 / j, 0, 0);
                Afficher(handle);
                System.Threading.Thread.Sleep(1000 / j);
                Cacher(handle);
            }

            //Troisieme mouvement 
            //mise en mouvement opposée à la 1er
            //jambe gauche en mouvement vers l'arrière
            //jambe droite en mouvement vers l'avant
            // main droite en mouvement vers
            // main gauche en mouvement vers
            for (i = 0; i < j; i++)
            {
                Bouger((int)(deplX / (j * 3)), CDG + (int)(deplY / (4 * j)), 0, 0, -0.261799 / j, -1.0472 / j, -0.785398 / j, -0.785398 / j, +0.785398 / j, 0, 0, 0);
                Afficher(handle);
                System.Threading.Thread.Sleep(1000 / j);
                Cacher(handle);
            }

            // Quatrième mouvement 
            // reviens à la position de base 
            for (i = 0; i < j; i++)
            {
                Bouger(deplX / (6 * j), -CDG + (int)((deplY) / (4 * j)), 0, 0, 0.261799 / j, +1.0472 / j, +0.785398 / j, +0.785398 / j, -0.785398 / j, 0, 0, 0);
                Afficher(handle);
                System.Threading.Thread.Sleep(1000 / j);
                Cacher(handle);
            }
            Afficher(handle);

        }
        public void Accélération(IntPtr handle)
        {
            int i = 0, j = 8, y = 0, plan = 0;
            int CDG = 1;
            // void Bouger(int deplX, int deplY, double abgh, double abgb, double abdh, double abdb, double ajgh, double ajgb, double ajdh, double ajdb)


            for (i = 0; i < j; i++)
            {

                Cacher(handle);
                Bouger(2, CDG, 2.0944 / j, 0.523599 / j, 2.0944 / j, 0.523599 / j, 0.523599 / j, -1.0472 / j, 0.523599 / j, -1.0472 / j, 0, 0);
                Afficher(handle);
                System.Threading.Thread.Sleep(750 / j);
                Cacher(handle);
                plan++;
                if (plan % 4 == 0)
                {
                    DecorArr.BougerArr(-1, 0);
                }
            }

            for (i = 0; i < j; i++)
            {
                Cacher(handle);
                Bouger(1, -CDG, -1.5708 / j, -1.5708 / j, -1.5708 / j, -1.5708 / j, +0, 0, 0, 0, 0, 0);
                Afficher(handle);
                System.Threading.Thread.Sleep(750 / j);
                Cacher(handle);

                plan++;
                if (plan % 4 == 0)
                {
                    DecorArr.BougerArr(-1, 0);
                }
            }

            for (y = 0; y < 2; y++)
            {
                for (i = 0; i < j; i++)
                {
                    Cacher(handle);
                    Bouger(0, 0, 0.523599 / j, 2.0944 / j, 0.523599 / j, 2.0944 / j, 0, 0, 0, 0, 0, 0);
                    Afficher(handle);
                    System.Threading.Thread.Sleep(500 / j);
                    Cacher(handle);
                    plan++;
                    if (plan % 4 == 0)
                    {
                        DecorArr.BougerArr(-1, 0);
                    }
                    Cacher(handle);
                }

                for (i = 0; i < j; i++)
                {
                    Cacher(handle);
                    Bouger(0, 0, -0.523599 / j, -2.0944 / j, -0.523599 / j, -2.0944 / j, 0, 0, 0, 0, 0, 0);
                    Afficher(handle);
                    System.Threading.Thread.Sleep(500 / j);
                    Cacher(handle);
                    plan++;
                    if (plan % 4 == 0)
                    {
                        DecorArr.BougerArr(-1, 0);
                    }
                    Cacher(handle);
                }
            }
            for (i = 0; i < j; i++)
            {
                Cacher(handle);
                Bouger(0, 1, -0.523599 * 2 / j, -0 / j, -0.523599 * 2 / j, -0 / j, +0.523599 / j, 0, +0.523599 / j, 0, 0, 0);

                plan++;
                if (plan % 4 == 0)
                {
                    DecorArr.BougerArr(-1, 0);
                }
                Afficher(handle);
                System.Threading.Thread.Sleep(500 / j);
                Cacher(handle);
            }

            for (i = 0; i < j; i++)
            {
                Cacher(handle);
                Bouger(0, 0);
                plan++;

                if (plan % 4 == 0)
                {
                    DecorArr.BougerArr(-1, 0);
                }
                Afficher(handle);
                System.Threading.Thread.Sleep(500 / j);
                Cacher(handle);
            }

            //redescend vers le bas et esquive le 1er obstacle
            for (i = 0; i < 16; i++)
            {
                Cacher(handle);
                Bouger(0, 1,0,0,0,0,0,0,0,0,0,0);
                DecorArr.BougerObstacle1((int)(-750/16),0);
                    DecorArr.BougerArr(-2, 0);
                Afficher(handle);
                System.Threading.Thread.Sleep(1000 / j);
                Cacher(handle);
            }

            //remonte vers le haut et esquive le 2e obstacle
            for (i = 0; i < 16; i++)
            {
                Cacher(handle);
                Bouger(0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                DecorArr.BougerObstacle2((int)(-750 / 16), 0);
                    DecorArr.BougerArr(-2, 0);
                Afficher(handle);
                System.Threading.Thread.Sleep(1000 / j);
                Cacher(handle);
            }
            DecorArr._Obstacle2.CacherCarré(handle);

            //redescend vers le bas et continue à avancer
            for (i = 0; i < 8; i++)
            {
                Cacher(handle);
                DecorArr.BougerArr(-2, 0);
                Bouger(0, 1,0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                Afficher(handle);
                System.Threading.Thread.Sleep(1000 / j);
                Cacher(handle);
            }

            // reviens en position normal
            for (i = 0; i < 8; i++)
            {
                Cacher(handle);
                Bouger(0, -2, +0.523599 / j, 1.0472/j, 0.523599 / j, 1.0472/j, -1.0472 / j, +1.0472 / j, -1.0472 / j, +1.0472 / j, 0, 0);
                Afficher(handle);
                System.Threading.Thread.Sleep(1000 / j);
                Cacher(handle);
            }
            Afficher(handle);
        }
        public void Bouger(int deplX, int deplY, double abgh, double abgb, double abdh, double abdb, double ajgh, double ajgb, double ajdh, double ajdb,double apg, double apd)
        {
            // Angle Bras-Jambe Gauche-Droite Haut-Bas
            base.Bouger(deplX, deplY);
            this.RFoot.Bouger(deplX, deplY, ajdh, ajdb,apd);
            this.LFoot.Bouger(deplX, deplY, ajgh, ajgb,apg);
            this.Head.Bouger(deplX, deplY);
            this.LArm.Bouger(deplX, deplY, abgh, abgb);
            this.RArm.Bouger(deplX, deplY, abdh, abdb);

            this.LStick.X = LArm.Hand.MI.X;
            this.LStick.Y = LArm.Hand.MI.Y;
            this.LStick.Bouger(0, 0,abgb );

            this.RStick.X = RArm.Hand.MI.X;
            this.RStick.Y = RArm.Hand.MI.Y;
            this.RStick.Bouger(0, 0, abdb);
        }

        public new void Cacher(IntPtr handle)
        {
            this.DecorArr.Cacher(handle);
            base.Cacher(handle);
            this.LArm.Cacher(handle);
            this.LStick.CacherCarré(handle);
            this.LFoot.Cacher(handle);
            this.RArm.Cacher(handle);
            this.RStick.CacherCarré(handle);
            this.RFoot.Cacher(handle);
            this.Head.Cacher(handle);
        }

        public new void Afficher(IntPtr handle)
        {
            this.DecorArr.Afficher(handle);
            this.LArm.Afficher(handle);
            this.LStick.AfficherCarré(handle);
            this.LFoot.Afficher(handle);
            this.Head.Afficher(handle);
            base.Afficher(handle);
            this.Head.Afficher(handle);
            this.RFoot.Afficher(handle);
            this.RStick.AfficherCarré(handle);
            this.RArm.Afficher(handle);
            this.DecorArr._Obstacle2.AfficherCarré(handle);
        }
        #endregion
    }
}
