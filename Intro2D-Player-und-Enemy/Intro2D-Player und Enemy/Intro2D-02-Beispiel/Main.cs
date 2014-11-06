using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Intro2D_02_Beispiel
{
    class Game
    {
        public static void Main()
        {
            // Erzeuge ein neues Fenster
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Mein erstes Fenster");

            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;

            initialize();
            loadContent();

            // Das eigentliche Spiel
            while (win.IsOpen())
            {
                // Schauen ob Fenster geschlossen werden soll
                win.DispatchEvents();

                update();
                draw(win);
            }
        }

        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            ((RenderWindow)sender).Close();
        }

        static Player player;
        static Enemy tobi, tobi2;
        static Map map;


        static void initialize()
        {
            player = new Player();
            tobi = new Enemy(new Vector2f(400f, 300f), "Pictures/Enemy.png");
            tobi2 = new Enemy(new Vector2f(100f, 200f), "Pictures/EnemyGreen.png");
            map = new Map();
        }

        static void loadContent()
        {

        }

        static void update()
        {
            player.move();
            tobi.move(player.getPosition());
            tobi2.move2();

            //all the collisions
            if(collision(player.getPosition(), player.getHeight(), player.getWidth(), tobi.getPosition(), tobi.getHeight(), tobi.getWidth()))
                Console.WriteLine("COLLISION!!11111");
        }

        static void draw(RenderWindow win)
        {
            win.Clear(new Color(0,0,255));
            map.draw(win);
            player.draw(win);
            tobi.draw(win);
            tobi2.draw(win);
            win.Display();
        }

        static bool collision(Vector2f objekt1, float höheObjekt1, float weiteObjekt1, Vector2f objekt2, float höheObjekt2, float weiteObjekt2)
        {
            float grXobj1 = objekt1.X + weiteObjekt1;
            float grXobj2 = objekt2.X + weiteObjekt2;
            float klXobj1 = objekt1.X;
            float klXobj2 = objekt2.X;

            float grYobj1 = objekt1.Y + höheObjekt1;
            float grYobj2 = objekt2.Y + höheObjekt2;
            float klYobj1 = objekt1.Y;
            float klYobj2 = objekt2.Y;

            if ((grXobj1 < klXobj2 && klXobj1 > grXobj2) || (grYobj1 < klYobj2 && klYobj1 > grYobj2))
                return false;
            else
                return true;
        }

        
    }
}
