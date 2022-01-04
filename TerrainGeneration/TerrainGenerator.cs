using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using drillGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimplexNoise;
using System.Diagnostics;


namespace TerrainGeneration
{
    public class TerrainGenerator
    {
        List<Tile> tiles = new List<Tile>();
        private int width, height;
        Texture2D grassTile, sandTile, waterTile;

        

        public void Generate()
        {
            tiles = new List<Tile>();
            Noise.Seed = GenerateSeed();
            float[,] values = Noise.Calc2D(width, height, .001f);


            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    
                    if (values[x, y] <= 0.1f)
                    {
                        tiles.Add(new Tile(new Vector2(x * y).ToInt() * Tile.size, grassTile));
                    }
                    else if (values[x, y] > 0.1f && values[x, y] <= 0.5f)
                    {
                        tiles.Add(new Tile(new Vector2(x * y).ToInt() * Tile.size, sandTile));
                    }
                    else
                    {
                        tiles.Add(new Tile(new Vector2(x * y).ToInt() * Tile.size, waterTile));
                    }
                }
            }
        }

        private int GenerateSeed()
        {
            Random random = new Random();
            int length = 8;
            int result = 0;

            for (int i = 0; i < length; i++)
            {
                result += random.Next(0, 9);
            }

            return result;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var tile in tiles)
            {
                spriteBatch.Draw(tile.sprite, tile.position, Color.White);
            }
        }


        public TerrainGenerator(int _width, int _height, Texture2D _grassTile, Texture2D _sandTile, Texture2D _waterTile)
        {
            width = _width;
            height = _height;
            grassTile = _grassTile;
            sandTile = _sandTile;
            waterTile = _waterTile;
        }
    }
}
