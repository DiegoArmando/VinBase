using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visual_Novel_Base
{
    class Character
    {
        public Emotion currentEmotion;

        Sprite currentSprite;
        Sprite DEFAULT;

        public Character(Microsoft.Xna.Framework.Content.ContentManager Content, string characterFilename, Microsoft.Xna.Framework.Vector2 pos)
        {
            currentEmotion = Emotion.DEFAULT;

            //Add stuff about this later
            currentSprite = new Sprite();
			if (characterFilename == "") 
			{
				//Load the default character
			}
            DEFAULT = new Sprite(Content, characterFilename, pos);

            currentSprite = DEFAULT;
        }

        public void Draw(Microsoft.Xna.Framework.GameTime gameTime, SpriteBatch spriteBatch)
        {
            currentSprite.Draw(gameTime, spriteBatch);
        }

        public void changeEmotion(Emotion sentEmotion)
        {
            currentEmotion = sentEmotion;

            //Find a way to make the sprite simply the name of the character plus the emotion, and fetch that image
            //currentSprite = 
        }
    }
}
