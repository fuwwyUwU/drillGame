using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using drillGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using SimplexNoiseCSharp;
using FNL;

namespace TerrainGeneration
{
    public class TerrainGenerator
    {
        public List<Chunk> chunks = new();

       // private int width, height;
        public Texture2D treeTile, grassTile, sandTile, waterTile;
        public int seed;
        public float scale = 0.0001f;
        FastNoiseLite noise;

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
            seed = GenerateSeed();
            noise = new FastNoiseLite(seed);
            noise.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
        }

        Tile GetTile(float value, Vector2 pos)
        {
            if (pos.Y * value < 8) return new Tile(grassTile, pos, new AABB(pos, Vector2.One * 8)); //Check tile for info
            //else if (value <= 1.5f) return new Tile(sandTile);
           // else if (value > 1.5f && value <= 2f) return new Tile(waterTile);
            else return new Tile(treeTile, pos, new AABB(pos, Vector2.One * 8));
            
        }

        Chunk GenerateChunk(Vector2 chunk)
        {
            Chunk _chunk = new Chunk();
            _chunk.position = chunk;
            _chunk.tiles = new Tile[Chunk.width, Chunk.height];
            for (float x = 0; x < Chunk.width; x++)
            {
                for (float y = 0; y < Chunk.height; y++)
                {
                    float value = noise.GetNoise(chunk.X * Chunk.width + x / scale, chunk.X * Chunk.height + x / scale) +1 ;
                    _chunk.tiles[(int)x, (int)y] = GetTile(value, chunk * Chunk.size + new Vector2(x, y));
                }
            }
            foreach(var tile in _chunk.tiles)
            {
                tile.pos += chunk * Chunk.size;
            }
            return _chunk;
        }


        public void Generate(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    chunks.Add(GenerateChunk(new Vector2(x, y)));
                }
            }
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
