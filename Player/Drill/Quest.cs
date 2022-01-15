using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nekoT
{
    public static class Quest
    {
        public static string QuestString = "Not Null";
        private static Vector2 vector = Vector2.Zero;
        public static void DrawQuest(SpriteBatch _spritebatch, SpriteFont font)
        {

            _spritebatch.DrawString(font, QuestString, new(QuestString.Length, 0), Color.MonoGameOrange);
        }
    }
}
