using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using drillGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimplexNoise;

namespace TerrainGeneration
{
    public class TerrainGenerator
    {
        public List<Tile> tiles = new();
        private Random rand = new();
        public int seed;
       // private int width, height;
        public Texture2D treeTile, grassTile, dirtTile, sandTile, waterTile;

        public void Generate(int width, int height)
        {

            seed = GenerateSeed();
            tiles.Add(new Tile(treeTile, rand.Next(0, width), -1));
            // spawn for tree shouldn't depend from seed cuz hard to make xD. and there will be
            //chance for it to not spawn or spawn multiple times(would be fixeable but still)
            for (float x = 0; x < width; x++)
            {
                for (float y = 0; y < height; y++)
                {
                    float value = (Noise.Generate((x / width) * seed, (y / height) * seed) + 1);

                    if (value <= 0.6f && y * value < 0.7f)
                    {
                        tiles.Add( new Tile(waterTile, x, y));
                        continue;
                    }
                    else if ( y * value < 8)
                    {
                        if (tiles[tiles.Count - 1].sprite == grassTile || tiles[tiles.Count -1].sprite == dirtTile) { tiles.Add(new Tile(dirtTile, x, y)); }
                        else
                        {
                            tiles.Add(new Tile(grassTile, x, y));
                        }
                        continue;
                    }
                    else if (value >= 0.3f && value <= 2f)
                        {
                        tiles.Add( new Tile(sandTile, x, y));
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            foreach (Tile t in tiles) t.position.Y += 1; // this adds space to world so all tiles well be 0y + value from world 0 :D
        }

        public int GenerateSeed()
        {
            Random random = new Random();
            int length = 20;
            int result = 0;

            for (int i = 0; i < length; i++)
            {
                result += random.Next(0, length+1);
            }

            return result;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var tile in tiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
