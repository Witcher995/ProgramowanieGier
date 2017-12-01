using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FlappyBird
{
    public class MenuMain : MenuBase
    {
        private Sprite logo;
        private Button startButton;
        private Button backButton;

        public MenuMain()
            : base()
        {
            this.logo = new Sprite("logo",((Settings.SCREEN_WIDTH* Settings.PIXEL_RAPIO)-(198*Settings.PIXEL_RAPIO))/2,140);
            this.startButton = new Button(((Settings.SCREEN_WIDTH* Settings.PIXEL_RAPIO)-(140*Settings.PIXEL_RAPIO))/2,250,1);
        }

        public override void Update(GameTime gameTime, Input input, Game1 game)
        {

            base.Update(gameTime,input, game);
            this.startButton.Update(gameTime,input);

            if (this.startButton.IsPressed())

                game.ChangeMenu(Menu.GAME);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.logo.Draw(spriteBatch);
            this.startButton.Draw(spriteBatch);
        }

    }
}
