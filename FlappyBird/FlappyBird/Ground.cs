using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class Ground :GameObject
    {
        private int baseX;
       private int currentOffset;
        private int timer;

      public Ground(int x, int y)
            :base(x,y,new Sprite("ground"))
            {
           this.baseX = x;
            this.currentOffset = 0;
            this.timer = 0;
            }


        public override void Update(GameTime gameTime,Input input)
        {
            base.Update(gameTime,input);

            this.timer += gameTime.ElapsedGameTime.Milliseconds;

            while(this.timer>=16)
            {
                this.timer -= 16;
                this.currentOffset += Settings.PIXEL_RAPIO;

            }

           
          
            if (this.currentOffset >= 1024)
                this.currentOffset = 0;

            this.hitbox.X = this.baseX - (this.currentOffset* Settings.PIXEL_RAPIO); 
        }

    }
}
