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
        public int seed;
       // private int width, height;
        public Texture2D grassTile, sandTile, waterTile;

        public void Generate(int width, int height)
        {

            seed = GenerateSeed();
            for (float x = 0; x < width; x++)
            {
                for (float y = 0; y < height; y++)
                {
                    float value = (Noise.Generate((x / width) * seed, (y / height) * seed) + 1);
                    //if (y == 0 && value >= 1.5f) { tiles.Add(new Tile(new Vector2(x, y), grassTile)); continue; }
                    if (value < 0.3f && y * value < 1f)
                    {
                        tiles.Add( new Tile(waterTile, x, y));
                        continue;
                    }
                    else if ( y * value < 8)
                    {
                        tiles.Add( new Tile(grassTile, x, y));
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
            foreach (var tile in tiles) tile.position.Y += tile.sprite.Height;
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
    }
}
