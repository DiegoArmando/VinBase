#region Using Statements
using System;
using System.Collections.Generic;
using System.IO;//For reading from a file
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Visual_Novel_Base
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 

    /// <summary>
    /// The enumeration to be shared across text/characters/sprites for emotions
    /// </summary>
	/// TODO: Add support eventually to add your own things to the enumeration.
	/// Read these in from a file?
    public enum Emotion
    {
        DEFAULT,
        HAPPY,
        SAD,
        ANGRY,
        SHY,
        EMBARRASED
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont spriteFont;

        List<Sprite> spriteList;
        List<String> nameList;
        List<String> fileData;

        //Add in the dictionary after getting filename things with loading sprites into characters working
        //Dictionary<String, Character> 

        DialogBox dialogBox;

        StreamReader reader = new StreamReader("StartFile.txt");

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
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
            spriteList = new List<Sprite>();
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");

            //The entire file will be read into a list of strings to be processed one at a time.
            //This is to overcome my knowledge limitations of using the StreamReader object
            fileData = new List<string>();

            //TODO: Fix sending the size of the game window instead of the screen size to the dialog box
            dialogBox = new DialogBox(GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height, Color.Navy, graphics, spriteFont);
            //TODO: Add flexibility to the do while loop, so things like extra spaces don't break it
            string dialog = "";
            string character = "";
            string nextLine;


            //Read the entire file
            do
            {
                //reads in each line, ad puts that line as an item in the list
                fileData.Add(reader.ReadLine());
            } while (reader.Peek() != -1);//checks the next character of the file to make sure it exists. When it doesn't exist, the file is at its end.


            //TODO: Comment this block, add in /n chracters after determining line width by word.
            for (int i = 0; i < fileData.Count; i++)
            {
                nextLine = fileData[i];

                if (nextLine == "<text>")
                {
                    do
                    {
                        i++;
                        nextLine = fileData[i];
                        dialog += nextLine;
                        dialog += "\n";
                    } while (fileData[i + 1] != "</text>");
                }

                else if (nextLine == "<character>")
                {
                    i++;
                    nextLine = fileData[i];
                    character = nextLine;
                }
            }

            dialogBox.updateString(dialog);
            dialogBox.updateCharacter(character);

            //TODO: Add in loading the character sprite based on the name, add support for multiple characters

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

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            foreach (Sprite s in spriteList)
            {
                s.Update();
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

            spriteBatch.Begin();

            // TODO: Add your drawing code here

            foreach (Sprite s in spriteList)
            {
                s.Draw(gameTime, spriteBatch);
            }

            dialogBox.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
