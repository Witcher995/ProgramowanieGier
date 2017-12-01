using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class MenuGame : MenuBase
    {
        private const int HOLE_HEIGHT = 175;

        private Sprite getReady;
        private Sprite Endscore;
        private List<Pipe> pipes;
        private Bird player;
        private bool start;
        private int timer;
        private Random random;

        private int score;

        private bool gameover;
        private bool setRotation;

        private Sprite gameOver;

        private Button backButton;
        public MenuGame()
            : base()
        {
            this.Endscore = new Sprite("score",80, 450);
            this.getReady = new Sprite("getready", ((Settings.SCREEN_WIDTH) / 4)-75,40);
            this.pipes = new List<Pipe>();
            this.player = new Bird(((Settings.SCREEN_WIDTH) / 2)- 36, 180);
            this.start = false;
            this.timer = 0;
            this.random = new Random();
            this.score = 0; 
            this.gameover = false;
            this.setRotation = false;
            this.gameOver = new Sprite("gameover", ((Settings.SCREEN_WIDTH) / 4)-100, ((Settings.SCREEN_HEIGHT) / 4)-25);
            this.backButton = new Button(((Settings.SCREEN_WIDTH * Settings.PIXEL_RAPIO) - (140 * Settings.PIXEL_RAPIO)) / 2, 440, 2);


        }

        public override void Update(GameTime gameTime,Input input, Game1 game)
        {

            base.Update(gameTime,input, game);
            this.backButton.Update(gameTime, input);
            if (this.backButton.IsPressed())

                game.ChangeMenu(Menu.GAME);
            if (!gameover)
            {

                this.ground.Update(gameTime, input);

                foreach (Pipe pipe in new List<Pipe>(this.pipes))
                {
                    pipe.Update(gameTime, input);
                  
                    if (pipe.ToDelete())
                        this.pipes.Remove(pipe);
                    if (this.player.CollisionWith(pipe))
                    {
                        this.gameover = true;
                        break;
                    }


                    if (pipe.GetPipeType() == PipeType.TOP && !pipe.IsPassed() && this.player.x > pipe.Right)
                    {
                        pipe.SetPassed();
                        this.score += 1;

                    }
                }

           


                if (this.player.CollisionWith(this.ground))
                {
                    this.gameover = true;
                    this.player.SetMaxRotation();
                    this.setRotation = true;
                    this.player.Update(gameTime, null);
                }
                else
                    this.player.Update(gameTime, input);



                this.timer += gameTime.ElapsedGameTime.Milliseconds;

                if (!this.start)
                {


                    if (this.timer >= 1500)
                    {
                        this.start = true;
                        this.timer = 0;
                        this.player.ActiveGravity();
                    }
                }
                else
                {
                    if (this.timer >= 3000)
                    {
                        this.timer = 0;

                        int topPipeY = this.random.Next(-450, -347);
                        int botPipeY = topPipeY + 512 + HOLE_HEIGHT;
                        this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, topPipeY, PipeType.TOP));
                        this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, botPipeY, PipeType.BOT));
                    }
                }
            }
            else
            {
                if (!this.player.CollisionWith(this.ground))
                    this.player.Update(gameTime, null);
                else if (!this.setRotation)
                {
                    this.player.SetMaxRotation();
                    this.setRotation = true;
                    this.player.Update(gameTime, null);
                }
            }
          
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
            foreach (Pipe pipe in this.pipes)
                pipe.Draw(spriteBatch);
            if (!this.start)
                this.getReady.Draw(spriteBatch);
            this.ground.Draw(spriteBatch);
            this.player.Draw(spriteBatch);
            if(gameover)
            {
               
                this.gameOver.Draw(spriteBatch);
            }
            if (this.start)
            {
                if (!gameover)
                    Number.Draw(spriteBatch, (Settings.SCREEN_WIDTH - ((score % 10) + 1 * (Number.NUMBER_WIDTH))) / 2, 50, score);
                else
                {
                    Number.Draw(spriteBatch, (Settings.SCREEN_WIDTH - ((score % 10) + 1 * (Number.NUMBER_WIDTH))) / 4, 450, score);
                    this.Endscore.Draw(spriteBatch);
                    this.backButton.Draw(spriteBatch);
                }
            }
          

        }
    }

    }

