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
    class Sprite
    {
        protected Texture2D thisSprite;
        public Vector2 position;
        public Color tint;
        public Rectangle CollisionRec;
        public float rotation;
        public float scale;
        protected string spriteName;

        public float Width
        {
            get { return thisSprite.Width; }
        }

        public float Height
        {

            get { return thisSprite.Height; }
        }

        public Sprite()
        {
        }

        public Sprite(ContentManager Content, string sentSpriteName, Vector2 pos)
        {
            spriteName = sentSpriteName;
            position = pos;

            tint = Color.White;
            rotation = 0.0f;
            scale = 1.0f;
            Load(Content);
        }

        public Sprite(ContentManager Content, string sentSpriteName, Vector2 pos, Color sentTint, float sentRotation, float sentScale)
        {
            position = pos;
            tint = sentTint;
            spriteName = sentSpriteName;
            rotation = sentRotation;
            scale = sentScale;
            Load(Content);
        }

        protected void Load(ContentManager Content)
        {
            thisSprite = Content.Load<Texture2D>(spriteName);
            CollisionRec = new Rectangle(0, 0, thisSprite.Width, thisSprite.Height);

            return;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Draw(thisSprite, position, null, tint, rotation, new Vector2(thisSprite.Width / 2, thisSprite.Height / 2), scale, SpriteEffects.None, 0);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch batch, float Alpha)
        {
            batch.Draw(thisSprite, position, null, tint * Alpha, rotation, new Vector2(thisSprite.Width / 2, thisSprite.Height / 2), scale, SpriteEffects.None, 0);
        }

        public virtual int getWidth()
        {
            return thisSprite.Width;
        }

        public virtual int getHeight()
        {
            return thisSprite.Height;
        }

        public void Update()
        {
            CollisionRec.X = (int)position.X - (thisSprite.Width / 2);
            CollisionRec.Y = (int)position.Y - (thisSprite.Height / 2);
            return;
        }

        public bool isCollidingWith(Rectangle checkRec)
        {
            bool result = this.CollisionRec.Intersects(checkRec);
            Console.WriteLine("********");
            Console.WriteLine("this : " + CollisionRec);
            Console.WriteLine("Other: " + checkRec);
            Console.WriteLine("Coll : " + result);
            return result;
        }
    }
}