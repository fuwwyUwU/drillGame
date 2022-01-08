using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using drillGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FNL;
using System.Diagnostics;

namespace TerrainGeneration
{
    public class TerrainGenerator
    {
        public List<Chunk> chunks = new();

       // private int width, height;
        public Texture2D treeTile, grassTile, sandTile, waterTile;
        float scale = 0.00001f;
        FastNoiseLite noise;
        public int seed;

        List<Vector2> reqchunks = new List<Vector2>();

        public void ReloadChunks(Vector2 centerChunk, Vector2 chunksToLoad)
        {
            reqchunks.Clear();
            //calculate all the chunks which should be in the list
            
            for (int i = (int)centerChunk.X - (int)chunksToLoad.X; i <= (int)centerChunk.X + (int)chunksToLoad.X; i++)
            {
                for (int j = (int)centerChunk.Y - (int)chunksToLoad.Y; j <= (int)centerChunk.Y + (int)chunksToLoad.Y; j++)
                {
                    reqchunks.Add(new Vector2(i, j));
                }
            }

            //remove all chunks which arent needed
            for (int i = chunks.Count; i > 0; i--)
            {
                for (int j = reqchunks.Count; j > 0; j--)
                {
                    if (chunks[i - 1].position == reqchunks[j - 1])
                    {
                        reqchunks.Remove(reqchunks[j - 1]);
                        break;
                    }

                    if (j == 1)
                    {
                        chunks.Remove(chunks[i - 1]);
                    }
                }


            }

            //add the new chunks 
            foreach (var req in reqchunks)
            {
                chunks.Add(GenerateChunk(req));
            }
        }

        public TerrainGenerator()
        {
            noise = new FastNoiseLite();
            seed = GenerateSeed();
            noise.SetSeed(seed);
            noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2S);
        }

        Tile GetTile(float value)
        {
            if (value < 0) return new Tile(grassTile);
            else if (value > 0) return new Tile(sandTile);
            else if (value == 0) return new Tile(waterTile);
            else return new Tile(treeTile);
            
        }

        Chunk GenerateChunk(Vector2 chunk)
        {
            Chunk _chunk = new Chunk();
            _chunk.position = chunk;
            _chunk.tiles = new Tile[8, 8];
            for (int x = 0; x < Chunk.width; x++)
            {
                for (int y = 0; y < Chunk.height; y++)
                {
                    float value = noise.GetNoise((chunk.X * 8 + x) * scale, (chunk.Y * 8 + y) * scale);
                    _chunk.tiles[x, y] = GetTile(value);
                    
                }
            }
            return _chunk;
        }


        public void Generate(int width, int height)
        {
            Debug.WriteLine(chunks.Count);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    chunks.Add(GenerateChunk(new Vector2(x, y)));   
                }
            }
            Debug.WriteLine(chunks.Count);

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
            foreach(var chunk in chunks)
            {
                chunk.Draw(spriteBatch);
            }
        }
    }
}
