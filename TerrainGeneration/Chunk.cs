﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace drillGame
{
    public class Chunk
    {
        public Tile[,] tiles;
        public const int width = 8;
        public const int height = 54;
        public Vector2 position;

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tiles[x, y].Draw(spriteBatch, position * 8 + new Vector2(x, y));
                }
            }
        }

    }
}
