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
        public static Texture2D box; //used as a temp sprite
        TerrainGeneration.TerrainGenerator gen;
        public static List<AABB> colliders;
        Drill drill;
        Player _player;
        Camera _cam;
        Vector2 loadedChunks = new Vector2(4, 4); //determents how many chunks should be loaded at once
        
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
            colliders = new List<AABB>();
            _cam = new();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gen = new()
            {
                treeTile = Content.Load<Texture2D>("treeTile"),
                waterTile = Content.Load<Texture2D>("watertile")
                ,
                grassTile = Content.Load<Texture2D>("grass"),
                sandTile = Content.Load<Texture2D>("sandtile"),
        };
            gen.Generate(4, 4);
            Window.Title = gen.seed.ToString(); ;
            box = Content.Load<Texture2D>("box");
            //drill = new Drill(1, gen.tiles);
            _player = new Player(box, Vector2.Zero/*, drill*/);
         //   _player = new(drill,);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (IsActive)
            {
                _cam.View = GraphicsDevice.Viewport;
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Thread.Sleep(250);
                    gen.chunks.Clear();
                    gen.Generate(1, 1);
                    Window.Title = gen.seed.ToString();
                    Thread.Sleep(250);
                }

                _player.Update(gameTime,_cam);
                _cam.Follow(_player.Position);
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);

            _spriteBatch.Begin(transformMatrix:_cam.Transform, samplerState:SamplerState.PointClamp);
            // TODO: Add your drawing code here
            gen.Draw(_spriteBatch);

            _player.Draw(_spriteBatch);
            


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
