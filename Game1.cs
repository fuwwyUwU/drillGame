﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using nekoT;

namespace drillGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D box; //used as a temp sprite
        TerrainGeneration.TerrainGenerator gen;
        
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
            gen.grassTile = Content.Load<Texture2D>("box");
            gen.sandTile = Content.Load<Texture2D>("sandtile");
            gen.waterTile = Content.Load<Texture2D>("watertile");
            gen.Generate(24, 24);
            Window.Title = gen.seed.ToString();
            box = Content.Load<Texture2D>("box");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            foreach(var tile in gen.tiles)
            {
                _spriteBatch.Draw(tile.sprite, tile.position, Color.White);
            }
            _spriteBatch.Draw(box, Mouse.GetState().Position.ToVector2(), Color.DarkOrange);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
