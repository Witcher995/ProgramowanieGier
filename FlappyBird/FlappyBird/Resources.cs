using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace FlappyBird
{
    public class Resources
    {
        public static Dictionary<String, Texture2D> Images;
     

        public static void LoadImages(ContentManager content)
        {
            Images = new Dictionary<string, Texture2D>();

            List<String> Graphics = new List<string>()
            {
                "background",
                "ground",
                "menu_buttons",
                "numbers",
                "logo",
                "top_pipe",
               "bird",
               "gameover",
               "getready",
               "score"

            };
            foreach(String img in Graphics)
            Images.Add(img, content.Load<Texture2D>("Graphics/" + img));
        }
        
    }



    
}
