using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using nekoT;
using System.Threading;
using System.Collections.Generic;

namespace drillGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D box; //used as a temp sprite
        TerrainGeneration.TerrainGenerator gen;
        public static List<CollisionManager.AABB> colliders;
        Drill drill;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gen = new();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gen.grassTile = Content.Load<Texture2D>("grass");
            gen.sandTile = Content.Load<Texture2D>("sandtile");
            gen.waterTile = Content.Load<Texture2D>("watertile");
            gen.Generate(96, 56);
            Window.Title = gen.seed.ToString();
            box = Content.Load<Texture2D>("box");
            drill = new Drill(1, gen.tiles);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (IsActive)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Thread.Sleep(250);
                    gen.tiles.Clear();
                    gen.Generate(96, 56);
                    Window.Title = gen.seed.ToString();
                    Thread.Sleep(250);
                }

                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    drill.Dig(gameTime, Mouse.GetState().Position.ToVector2());
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            foreach(var tile in gen.tiles)
            {
                _spriteBatch.Draw(tile.Value.sprite, tile.Key * Tile.size, Color.White);
            }

            

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
