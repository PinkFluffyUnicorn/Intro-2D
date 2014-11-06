using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_02_Beispiel
{
    class Tile
    {
        Sprite TileSprite;
        Vector2f position;
        bool walkable;

        public Tile(Vector2f _position, string texturepath, bool walk)
        {
            position = _position;
            
            TileSprite = new Sprite(new Texture(texturepath));
            TileSprite.Position = _position;
            walkable = walk;
        }

        public Vector2f getPosition()
        {
            return position;
        }

        public Sprite getTileSprite()
        {
            return TileSprite;
        }


        public void draw(RenderWindow win)
        {
            win.Draw(TileSprite);
        }
    }
}
