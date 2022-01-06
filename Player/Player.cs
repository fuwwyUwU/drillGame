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
        float speed = 16;
        

        public Player(Vector2 _position, Drill _drill, Texture2D spritesheet, int rows, int columns, int frame) : base(spritesheet, rows, columns, frame)
        {
            drill = _drill;
            aabb = new AABB();
            Position = _position;
            Origin = new Vector2(8, 8);
        }

        public void Update(GameTime gameTime)
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
                drill.Dig(gameTime, new Vector2(Position.X, Position.Y + 16));
            }


            Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity = Vector2.Zero;
        }
    }
}
