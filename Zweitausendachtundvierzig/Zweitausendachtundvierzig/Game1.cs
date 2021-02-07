using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Zweitausendachtundvierzig.Model;

namespace Zweitausendachtundvierzig
{
    public class Game1 : Game
    {
        Random rnd = new Random();

        Texture2D emptySlotTexture;
        Texture2D slotTextureTwo;
        Texture2D slotTextureFour;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        List<FieldSlot> playfieldCollection = new List<FieldSlot>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            RestartGame();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            emptySlotTexture = Content.Load<Texture2D>("emptySlot");
            slotTextureTwo = Content.Load<Texture2D>("slotTwo");
            slotTextureFour = Content.Load<Texture2D>("slotFour");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var kstate = Keyboard.GetState();

            if(kstate.IsKeyDown(Keys.Space))
            {
                RestartGame();
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            
            foreach(FieldSlot playfieldSlot in playfieldCollection)
            {
                DrawFieldSlotAt(playfieldSlot.GetSlotValue(), playfieldSlot.GetPositionX(), playfieldSlot.GetPositionY());
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void RestartGame()
        {
            playfieldCollection.Clear();
            playfieldCollection = new List<FieldSlot>();

            for(int y = 0; y < 4; y++)
            {
                for(int x = 0; x < 4; x++)
                {
                    FieldSlot baseFieldSlot = new FieldSlot(x, y);
                    playfieldCollection.Add(baseFieldSlot);
                }
            }

            SpawnNewField();
            SpawnNewField();
            

        }

        public void SpawnNewField()
        {
            int randomFieldIndex = rnd.Next(playfieldCollection.Where(x=>x.GetFieldState() == FieldSlotOccupation.Empty).Count());

            playfieldCollection[randomFieldIndex].Init();

        }

        private void DrawFieldSlotAt(int value, int indexX, int indexY)
        {
            Vector2 position = new Vector2(indexX * 102, indexY * 102);
            switch (value)
            {
                case 0:
                    _spriteBatch.Draw(emptySlotTexture, position, Color.White);
                    break;
                case 2:
                    _spriteBatch.Draw(slotTextureTwo, position, Color.White);
                    break;
            }
        }
    }
}
