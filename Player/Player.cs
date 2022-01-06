using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using nekoT;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace drillGame
{
    public class Player : SpriteAtlas 
    {
        InputWrapper input = new InputWrapper() { down = Keys.S, interact = Keys.X, left = Keys.A, right = Keys.D, up = Keys.W};

        Drill drill;
        AABB aabb;
        Vector2 velocity = Vector2.Zero;
        float speed = 4;
        

        public Player(Texture2D spritesheet, Vector2 _position, Drill _drill ) : base(spritesheet, 1, 4, 0) // check spriteatlas
        {
            drill = _drill;
            aabb = new AABB();
            Position = _position;
            Width = 32;
            Height = 64;
        }

        public override void Update(GameTime gameTime, Camera camera)
        {
            var ks = Keyboard.GetState();
            if (ks.IsKeyDown(input.up))
            {
                velocity.Y -= speed;
            }

            if (ks.IsKeyDown(input.down))
            {
                velocity.Y += speed;
            }

            if (ks.IsKeyDown(input.left))
            {
                velocity.X -= speed;
            }

            if (ks.IsKeyDown(input.right))
            {
                velocity.X += speed;
            }

            if (ks.IsKeyDown(input.interact))
            {
                drill.Dig(gameTime, new Vector2(Position.X, Position.Y + Origin.Y)); // please fix dig its broken again
            }


            Position += velocity;
            velocity = Vector2.Zero;
        }
    }
}
