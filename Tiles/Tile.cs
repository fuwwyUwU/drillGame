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
        public Vector2 pos; // i think this need it own position to help calculations

        public Tile(Texture2D _sprite, Vector2 position, AABB collider)
        {
            pos = position;
            sprite = _sprite;
            isBreakable = true;
            Game1.colliders.Add(collider);
        }

        public Tile(Texture2D _sprite, Vector2 position, bool _isBreakable, AABB collider)
        {
            pos = position;
            sprite = _sprite;
            isBreakable = _isBreakable;
            Game1.colliders.Add(collider);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(sprite, position * size, Color.White);
        }
    }
}

