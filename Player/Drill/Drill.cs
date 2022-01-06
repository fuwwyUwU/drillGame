using System;
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
        public void Dig(GameTime gameTime, Vector2 removeAt)
        {
            //check if drill cooldown has expired
            if (lastDrill + cooldown > (float)gameTime.TotalGameTime.TotalSeconds) return;

            lastDrill = (float)gameTime.TotalGameTime.TotalSeconds;

            //account for the origin of where the sprites are drawn
            removeAt -= new Vector2(Tile.size * .5f, Tile.size * .5f);

            //divide by 16, because a tile is 16px^2
            removeAt *= 0.0625f;

            removeAt = new Vector2(MathF.Round(removeAt.X), MathF.Round(removeAt.Y));
            //remove the tile at the given position
            // round to the nearest center as all tiles position is based on thier center
            List<Tile> tilesToRemove = new();
            foreach (var tile in tiles)
            {
                if (tile.position == removeAt)
                {
                    tilesToRemove.Add(tile);
                }
            }
            for (int i = 0; i < tilesToRemove.Count; i++)
            {
                tiles.Remove(tilesToRemove[0]);
            }
        }

        public Drill(float _cooldown, List<Tile> _tiles)
        {
            cooldown = _cooldown;
            
            tiles = _tiles; //the tilemap it will remove from

            
        }
    }
}

