using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Visual_Novel_Base
{
    //TODO: Add in a smaller box to contain the character who is speaking's name
    class DialogBox
    {
        //Sprite box;
        Texture2D box;
        Texture2D nameBox;
        Vector2 boxCoordinates;
        Vector2 nameBoxCoordinates;
        Vector2 textCoordinates;
        Vector2 nameCoordinates;
        string currentString = "";
        string characterName = "";

        SpriteFont font;

        double boxWidth;
        double boxHeight;

        float boxXPos;
        float boxYPos;

        public DialogBox(int screenWidth, int screenHeight, Color sentColor, GraphicsDeviceManager graphics, SpriteFont spriteFont)
        {
            font = spriteFont;

            boxWidth = (double)screenWidth * 0.9;
            boxHeight = (double)screenHeight * 0.25;

            //This will put the box at 5% from the screen's side, and 5% from the screen's bottom
            boxXPos = (float)screenWidth / 20;
            boxYPos = (float)(screenHeight * 0.95 - boxHeight);

            //Make a new Texture that is a rectangle
            box = new Texture2D(graphics.GraphicsDevice, (int)boxWidth, (int)boxHeight);

            //For each pixel in the rectangle, make a spot in an array
            Color[] data = new Color[(int)boxWidth * (int)boxHeight];

            //Fill each spot in the color array with the desired color
            //Modify this for loop later for curved corners
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = sentColor;
            }

            //Set the data of the box (in this case, what color each pixel is, by sending it an array of colors
            box.SetData(data);

            nameBox = new Texture2D(graphics.GraphicsDevice, (int)(boxWidth / 7.0f), (int)(boxHeight / 7.0f));

            Color[] nameData = new Color[(int)(boxWidth / 7.0f) * (int)(boxHeight / 7.0f)];

            Color darkerShade = new Color();
            darkerShade = sentColor;
            
            if (sentColor.R <= 30) darkerShade.R = 0;
            else darkerShade.R = (byte)(sentColor.R - 30);

            if (sentColor.G <= 30) darkerShade.G = 0;
            else darkerShade.G = (byte)(sentColor.G - 30);

            if (sentColor.B <= 30) darkerShade.B = 0;
            else darkerShade.B = (byte)(sentColor.B - 30);

            darkerShade.A = sentColor.A;
            
            

            for (int i = 0; i < nameData.Length; ++i)
            {
                nameData[i] = darkerShade;
            }

            nameBox.SetData(nameData);
            updateCharacter(sentColor.ToString() + darkerShade.ToString());

            //Where the box is drawn, starting at the upper left pixel
            boxCoordinates = new Vector2(boxXPos, boxYPos);
            textCoordinates = boxCoordinates + new Vector2(5.0f, 5.0f);

            nameBoxCoordinates = new Vector2(boxXPos, boxYPos - (int)(boxHeight / 7.0f));
            nameCoordinates = nameBoxCoordinates + new Vector2(1.0f, 1.0f);

        }

        public void updateString(string update)
        {
            currentString = update;
        }

        public void updateCharacter(string update)
        {
            characterName = update;
        }

		//TODO: Add in the ability to load the text one character at a time in variable speeds
		//SLOW
		//NORMAL
		//FAST
		//INSTANT

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(box, boxCoordinates, Color.White);
            spriteBatch.Draw(nameBox, nameBoxCoordinates, Color.White);

            spriteBatch.DrawString(font, currentString, textCoordinates, Color.White);
            spriteBatch.DrawString(font, characterName, nameCoordinates, Color.White);
        }
    }
}
