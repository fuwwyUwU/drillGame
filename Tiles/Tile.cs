using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace drillGame
{
    public class Tile
    {
        public Vector2 position;
        public readonly Texture2D sprite;
        public const int size = 16;
        public readonly bool isBreakable;

        public Tile(Texture2D _sprite, float x, float y)
        {

            sprite = _sprite;
            position.X +=  x* sprite.Width;
            position.Y += y*sprite.Height;
            isBreakable = true;
        }

        public Tile(Texture2D _sprite, float x, float y, bool _isBreakable)
        {
            sprite = _sprite;
            isBreakable = _isBreakable;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
