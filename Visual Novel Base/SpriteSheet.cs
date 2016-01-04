using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Visual_Novel_Base
{
    class SpriteSheet: Sprite
    {
        public Rectangle spriteBox;

        public SpriteSheet(string sentSpriteName, Vector2 pos, Color sentTint, ContentManager Content, Rectangle sentBox)
        {
            spriteBox = sentBox;
            position = pos;
            tint = sentTint;
            spriteName = sentSpriteName;
            Load(Content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            //batch.Begin();
            batch.Draw(thisSprite, position, spriteBox, tint);
            //batch.End();
        }
    }
}
