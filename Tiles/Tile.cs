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

        public Tile(Vector2 _position, Texture2D _sprite)
        {
            position.X = _position.X * _sprite.Width;
            position.Y = _position.Y * _sprite.Height;
            sprite = _sprite;
        }
    }
}
