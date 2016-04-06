using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BamBam
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        Texture2D imgFloresta,imgBamBam,imgBamBamEsquerda,imgObstaculo;
        Rectangle Floresta,BamBam,Obstaculo,Obstaculo2,Obstaculo3,Obstaculo4,Obstaculo5;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int Pulo, Gravidade;

        bool Pulando,BamBamEsquerda;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Floresta = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            BamBam = new Rectangle(-100, 275, 300, 300);
            Obstaculo = new Rectangle(120, 200, 400, 400);
            Obstaculo2 = new Rectangle(300, 120, 400, 400);
            Obstaculo3 = new Rectangle(520, 50, 400, 400);
            Obstaculo4 = new Rectangle(320, -80, 400, 400);
            Obstaculo5 = new Rectangle(60, -10, 400, 400);
            // TODO: Add your initialization logic here
            Pulo = 25;
            Gravidade = 1;
            Pulando = false;
            BamBamEsquerda = false;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imgFloresta = Content.Load<Texture2D>("FlorestaPNG");
            imgBamBam = Content.Load<Texture2D>("BamBamPNG");
            imgBamBamEsquerda = Content.Load<Texture2D>("BamBamEsquerdaPNG");
            imgObstaculo = Content.Load<Texture2D>("ObstaculoPNG");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (BamBam.X >= -100)
                {
                    BamBamEsquerda = true;
                    BamBam.X -= 7;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (BamBam.X <= Window.ClientBounds.Width / 2 + 220)
                {
                    BamBamEsquerda = false;
                    BamBam.X += 7;
                }

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Pulando == false)
            {
                Pulando = true;
            }

            if (Pulando == true)
            {
                BamBam.Y -= Pulo;
                Pulo -= Gravidade;

            }

            if (BamBam.Y > 250)
            {
                Pulando = false;
                Pulo = 15;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(imgFloresta,Floresta, Color.White);
            spriteBatch.Draw(imgObstaculo,Obstaculo, Color.White);
            spriteBatch.Draw(imgObstaculo, Obstaculo2, Color.White);
            spriteBatch.Draw(imgObstaculo, Obstaculo3, Color.White);
            spriteBatch.Draw(imgObstaculo, Obstaculo4, Color.White);
            spriteBatch.Draw(imgObstaculo, Obstaculo5, Color.White);

            if(BamBamEsquerda == false)
            {
                spriteBatch.Draw(imgBamBam, BamBam, Color.White);
            }
            if(BamBamEsquerda == true)
            {
                spriteBatch.Draw(imgBamBamEsquerda, BamBam, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
