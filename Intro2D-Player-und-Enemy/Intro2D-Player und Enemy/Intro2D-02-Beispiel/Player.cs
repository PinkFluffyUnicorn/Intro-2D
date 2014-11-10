using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_02_Beispiel
{
    class Player
    {
        class Player
    {
        Vector2f playerPosition;
        Sprite playerSprite;

        public Vector2f getPosition()
        {
            return playerPosition;
        }

        public float getHeight()
        {
            return playerSprite.Texture.Size.Y * playerSprite.Scale.Y;
        }

        public float getWidth()
        {
            return playerSprite.Texture.Size.X * playerSprite.Scale.X;
        }




        public Player()
        {
            Texture playerTexture = new Texture("Pictures/player.png");
            playerSprite = new Sprite(playerTexture);

            playerPosition = new Vector2f(51, 51);
            playerSprite.Position = playerPosition;

            playerSprite.Scale = new Vector2f(0.03125f, 0.03125f);
        }

        public void move(Map map)
        {
            bool Left = map.isWalckable((int) (this.getPosition().X - 1) / 50, (int)(this.getPosition().X + this.getHeight() - 1) / 50);
            bool Right = map.isWalckable((int) (this.getPosition().X + 1) / 50, (int)(this.getPosition().X + this.getHeight() + 1) / 50);
            bool Up = map.isWalckable((int)(this.getPosition().Y + 1) / 50, (int)(this.getPosition().Y + this.getWidth() + 1) / 50);
            bool Down = map.isWalckable((int)(this.getPosition().Y - 1) / 50, (int)(this.getPosition().Y + this.getHeight() + 1) / 50);


            if (Keyboard.IsKeyPressed(Keyboard.Key.A) && Left)
                playerPosition = new Vector2f(playerPosition.X - 0.1f, playerPosition.Y);
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) && Right)
                playerPosition = new Vector2f(playerPosition.X + 0.1f, playerPosition.Y);
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) && Up)
                playerPosition = new Vector2f(playerPosition.X, playerPosition.Y - 0.1f);
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) && Down)
                playerPosition = new Vector2f(playerPosition.X, playerPosition.Y + 0.1f);

            playerSprite.Position = playerPosition;
        }

        public void draw(RenderWindow win)
        {
            win.Draw(playerSprite);
        }

    }
}
