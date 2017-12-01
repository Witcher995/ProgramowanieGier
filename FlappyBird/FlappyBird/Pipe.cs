using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FlappyBird
{
    public enum PipeType
    {
        TOP,
        BOT
    }

    class Pipe : GameObject
    {
        private PipeType pipeType;
        private int timer;
        private bool toDelete;
        private bool isPassed;

        public PipeType GetPipeType()
        {
            return this.pipeType;
        }
        public bool ToDelete()
        {
            return this.toDelete;
        }

        public bool IsPassed()
        {
            return this.isPassed;
        }

        public void SetPassed()
        {
             this.isPassed = true;
        }

        public Pipe(int x, int y, PipeType type)
            :base(x,y,new Sprite("top_pipe"))
        {
            this.pipeType = type;
            this.timer = 0;
            this.toDelete = false;
            this.isPassed = false;

            if (type == PipeType.BOT)
                this.sprite.SetOrientation(SpriteEffects.FlipVertically);


        }


            public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime,input);

            this.timer += gameTime.ElapsedGameTime.Milliseconds;

            while (this.timer >= 16)
            {
                this.timer -= 16;
                this.hitbox.X -= Settings.PIXEL_RAPIO;

                if (this.hitbox.X <= -46*Settings.PIXEL_RAPIO)
                    this.toDelete = true;

            }


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
