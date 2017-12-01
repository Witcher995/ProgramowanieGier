using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public abstract class MenuBase
    {
        protected Sprite background;
       
        protected Ground ground;

        protected MenuBase()
        {
            this.background = new Sprite("background");
            this.ground = new Ground(0, 395 * Settings.PIXEL_RAPIO);
        }

        public virtual void Update(GameTime gameTime,Input input, Game1 game)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
          
            this.ground.Draw(spriteBatch);
        }


    }
}
