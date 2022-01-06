﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace drillGame
{
    public class Drill
    {
        public float cooldown;
        private float lastDrill = 0;

        private List<Tile> tiles;
        //drills, you cant have a function with the same name as its enclosing type, which is why i choose Dig
        //bro help me how your code work
        public void Dig(GameTime gameTime, Vector2 playerPosition)
        {
            if (lastDrill + cooldown > (float)gameTime.TotalGameTime.TotalSeconds) return;
            lastDrill = (float)gameTime.TotalGameTime.TotalSeconds;
            playerPosition -= new Vector2(Tile.size * .5f, Tile.size * .5f);
            playerPosition *= 0.0625f;
            tiles.RemoveAll(item => item.position == new Vector2(MathF.Round(playerPosition.X), MathF.Round(playerPosition.Y)));
        }

        public Drill(float _cooldown, List<Tile> _tiles)
        {
            cooldown = _cooldown;
            tiles = _tiles;

            
        }
    }
}

