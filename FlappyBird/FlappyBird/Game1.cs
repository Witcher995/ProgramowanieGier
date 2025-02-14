﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird
{

    public enum Menu
    {
        MAIN,
        GAME
    }
   
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState oldKeyboard;
        MouseState oldMouse;

        MenuBase menu;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT;
            graphics.PreferredBackBufferWidth = Settings.SCREEN_WIDTH;
            graphics.IsFullScreen = Settings.IS_FULLSCREEN;
            this.IsMouseVisible = Settings.IS_MOUSE_VISIBLE;
            this.IsFixedTimeStep = true;
            Content.RootDirectory = "Content";
        }

      
        protected override void Initialize()
        {
           
            base.Initialize();

            this.menu = new MenuMain();
            this.oldKeyboard = Keyboard.GetState();
            this.oldMouse = Mouse.GetState();
        }

        
        protected override void LoadContent()
        {
       
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Resources.LoadImages(this.Content);
         
        }

      
        protected override void UnloadContent()
        {
        }

        public void ChangeMenu(Menu menu)
        {
            switch(menu)
            {
                case Menu.MAIN: this.menu = new MenuMain();
                    break;
                case Menu.GAME: this.menu = new MenuGame();
                    break;
                default:
                    break;

            }
        }
       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.menu.Update(gameTime,new Input(oldKeyboard,oldMouse, Keyboard.GetState(), Mouse.GetState()),this);

            oldKeyboard = Keyboard.GetState();
            oldMouse = Mouse.GetState();

            

            base.Update(gameTime);
        }

   
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Settings.BACKGROUND_COLOR);
            // spriteBatch.Begin(SpriteSortMode.Immediate,BlendState.AlphaBlend,SamplerState.PointClamp,null,null,null,null);
            spriteBatch.Begin();
            this.menu.Draw(this.spriteBatch);

            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
