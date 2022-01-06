using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using nekoT;

namespace drillGame
{
    public class Player : SpriteAtlas 
    {
        Drill drill;

        public Player(Drill _drill, Texture2D spritesheet, int rows, int columns, int frame) : base(spritesheet, rows, columns, frame)
        {
            drill = _drill;
        }


    }
}
