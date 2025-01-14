﻿using System;
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
        public Vector2 position;
        public readonly Texture2D sprite;
        public const int size = 16;
        public readonly bool isBreakable;


        public Tile(Texture2D _sprite, float x, float y)
        {

            sprite = _sprite;
            position.X = x;
            position.Y = y;
            isBreakable = true;
        }

        public Tile(Texture2D _sprite, float x, float y, bool _isBreakable)
        {
            sprite = _sprite;
            isBreakable = _isBreakable;
            position.X = x;
            position.Y = y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position * size, Color.White);
        }
    }
}

