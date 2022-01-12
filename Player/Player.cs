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
        bool debugging;
        bool debugPressed;
        

        public Player(Texture2D spritesheet, Vector2 _position/*, Drill _drill*/ ) : base(spritesheet, 1, 4, 0) // check spriteatlas
        {
            InputWrapper.SetKeys(Keys.W, Keys.S, Keys.A, Keys.D, Keys.X, Keys.OemPlus, Keys.OemMinus, Keys.F11); //Made inputWrapper static class because i can
            //drill = _drill;
            aabb = new AABB(Position, new Vector2(4, 8));
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

            if (ks.IsKeyDown(InputWrapper.Debug))
            {
                if (debugPressed) return;
                debugging = debugging == false ? true : false;
            }
            else
            {
                debugPressed = false;
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
            Sweep sweep = null;
            foreach (var collider in Game1.colliders)
            {
                var checkSweep = aabb.SweepAABB(collider, velocity);
                if (checkSweep.hit != null)
                {
                    sweep = checkSweep;
                    break;
                }
            }

            if (sweep != null && !debugging)
            {
                Position = sweep.hit.delta;
            }
            else
            {
                Position += velocity;
            }
            Position += velocity;
            aabb.pos = Position;
            velocity = Vector2.Zero;
            camZoom(camera);
        }
        private void camZoom(Camera _cam)
        {
            if (ks.IsKeyDown(InputWrapper.ZoomPlus)) _cam.Zoom += 0.1f;
            if (ks.IsKeyDown(InputWrapper.ZoomMinus)) _cam.Zoom -= 0.1f;
        }

        public Vector2 GetCurrentChunk()
        {
            //16 is the with and height of a tile
            Vector2 currentChunk = Position / (Chunk.size * 16);
            return Vector2.Round(currentChunk);
        }
    }
}
