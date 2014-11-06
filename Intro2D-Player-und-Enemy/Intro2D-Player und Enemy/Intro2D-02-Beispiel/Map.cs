using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_02_Beispiel
{
    class Map // Matrix mit 50x50
    {
        Tile[,] mapTiles; // breite x höhe
        int[,] map;
        Tile block1;
        Tile block2;




        public Vector2f getPosition(int h, int w)
        {
            return this.mapTiles[h,w].getPosition();
        }

        public float getHeight(int h, int w)
        {
            return 50;
        }

        public float getWidth(int h, int w)
        {
            return 50;
        }

        public Map()
        {
            map = new int[,] { {1,1,1,1,1,1,1,1,1,1,1,1},
                           {1,0,0,0,0,0,0,0,0,0,0,0},
                           {1,0,0,0,0,0,0,0,0,0,0,0},
                           {1,1,1,1,1,0,0,0,1,1,1,1},
                           {1,0,0,0,0,0,0,0,0,0,0,0},
                           {1,0,0,0,0,0,0,0,0,0,0,0},
                           {1,0,0,0,0,1,1,1,1,1,1,1},
                           {1,0,0,0,0,0,0,0,0,0,0,0},
                           {1,0,0,0,0,0,0,0,0,0,0,0},
                           {1,1,1,0,0,0,0,0,0,1,1,1},
                           {1,0,0,0,0,0,0,0,0,0,0,0},
                           {1,0,0,0,0,0,0,0,0,0,0,0},
                           {1,1,1,1,0,0,0,0,1,1,1,1},
                           {1,0,0,0,0,0,0,0,0,0,0,0},
                           {1,0,0,0,0,0,0,0,0,0,0,0},
                           {1,0,0,0,0,0,0,0,0,0,0,0}};
            mapTiles = new Tile[map.GetLength(0), map.GetLength(1)];
            for ( int i = 0; i < mapTiles.GetLength(0); i++)
            {
                for(int j = 0; j < mapTiles.GetLength(1); j++ )
                {
                    if(map[i,j] == 0)
                    {
                        mapTiles[i, j] = new Tile( new Vector2f((float)(50 * i), (float)(50 * j)),"Pictures/tile1.png",true);
                    }
                    else
                    {
                        mapTiles[i, j] = new Tile(new Vector2f((float)(50 * i), (float)(50 * j)), "Pictures/tile2.png", false);
                    }
                }
            }

        }

        public void draw(RenderWindow win)
        {
            for (int i = 0; i < mapTiles.GetLength(0); i++)
            {
                for (int j = 0; j < mapTiles.GetLength(1); j++)
                {
                    win.Draw(mapTiles[i, j].getTileSprite());
                }
            }

        }


    }
}
