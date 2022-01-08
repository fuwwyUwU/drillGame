using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


namespace drillGame
{
    public class Tile
    {
        public readonly Texture2D sprite;
        public const int size = 16;
        public readonly bool isBreakable;


        public Tile(Texture2D _sprite)
        {

            sprite = _sprite;
            isBreakable = true;
        }

        public Tile(Texture2D _sprite, bool _isBreakable)
        {
            sprite = _sprite;
            isBreakable = _isBreakable;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(sprite, position * size, Color.White);
        }
    }
}

