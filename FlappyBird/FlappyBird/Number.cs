using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
   public class Number
    {

        public static int NUMBER_WIDTH = 18;
        public static int NUMBER_HEIGHT = 24;


        public static void Draw(SpriteBatch spriteBatch,int x, int y, int num)
        {
            string strNum = num.ToString();

            foreach (char c in strNum)
            {
                int n = c - '0';
                spriteBatch.Draw(Resources.Images["numbers"],
                    new Rectangle(x*Settings.PIXEL_RAPIO, y*Settings.PIXEL_RAPIO, NUMBER_WIDTH * Settings.PIXEL_RAPIO, NUMBER_HEIGHT * Settings.PIXEL_RAPIO),
                    new Rectangle(n * NUMBER_WIDTH, 0, NUMBER_WIDTH, NUMBER_HEIGHT), Color.White);
                x += NUMBER_WIDTH + 1;
            }
        }

    }
}
