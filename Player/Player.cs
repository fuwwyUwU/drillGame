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
         // { down = Keys.S, interact = Keys.X, left = Keys.A, right = Keys.D, up = Keys.W};

        //Drill drill;
        AABB aabb;
        Vector2 velocity = Vector2.Zero;
        float speed = 4;
        KeyboardState ks;
        

        public Player(Texture2D spritesheet, Vector2 _position/*, Drill _drill*/ ) : base(spritesheet, 1, 4, 0) // check spriteatlas
        {
            InputWrapper.SetKeys(Keys.W, Keys.S, Keys.A, Keys.D, Keys.X, Keys.OemPlus, Keys.OemMinus); //Made inputWrapper static class because i can
            //drill = _drill;
            aabb = new AABB(Position, new Vector2(16, 32));
            Position = _position;
            Width = 8;
            Height = 16;
        }

        public override void Update(GameTime gameTime, Camera camera)
        {
            ks = Keyboard.GetState();
            if (ks.IsKeyDown(InputWrapper.Up))
            {
                velocity.Y -= speed;
            }

            if (ks.IsKeyDown(InputWrapper.Down))
            {
                velocity.Y += speed;
            }

            if (ks.IsKeyDown(InputWrapper.Left))
            {
                velocity.X -= speed;
            }

            if (ks.IsKeyDown(InputWrapper.Right))
            {
                velocity.X += speed;
            }

            if (ks.IsKeyDown(InputWrapper.Interact))
            {
                //drill.Dig(gameTime, new Vector2(Position.X, Position.Y + Origin.Y)); // please fix dig its broken again
            }


            //var sweep = CollisionManager.TryMoveAABB(aabb, velocity);
            //Debug.WriteLine($"{aabb.Position} {aabb.HalfExtents}");

            //if (!sweep.hit.valid || sweep.time <= 0)
            //{
            //    Position += velocity;
            //    Debug.WriteLine("no hit");
            //}
            //else Position = sweep.position;
            //aabb.Position = Position;
            Position += velocity;
            velocity = Vector2.Zero;
            camZoom(camera);
        }
        private void camZoom(Camera _cam)
        {
            if (ks.IsKeyDown(InputWrapper.ZoomPlus)) _cam.Zoom += 0.1f;
            if (ks.IsKeyDown(InputWrapper.ZoomMinus)) _cam.Zoom -= 0.1f;
        }
    }
}
