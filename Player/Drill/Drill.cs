using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace drillGame
{
    public class Drill
    {
        public float cooldown;
        private float lastDrill = 0;

        private Dictionary<Vector2, Tile> tiles;
        //drills, you cant have a function with the same name as its enclosing type, which is why i choose Dig
        public void Dig(GameTime gameTime, Vector2 playerPosition)
        {
            if (lastDrill + cooldown > (float)gameTime.TotalGameTime.TotalSeconds) return;

            lastDrill = (float)gameTime.TotalGameTime.TotalSeconds;
            playerPosition -= new Vector2(Tile.size * .5f, Tile.size * .5f);
            playerPosition *= 0.065f;
            tiles.Remove(new Vector2((int)playerPosition.X, (int)playerPosition.Y));
        }

        public Drill(float _cooldown, Dictionary<Vector2, Tile> _tiles)
        {
            cooldown = _cooldown;
            tiles = _tiles;
        }
    }
}
