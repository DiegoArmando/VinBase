/*  XNA Line Drawer Class
 *  
 *  Author: Gregory Walek
 * 
 *  Based on the Code Located at 
 *  http://www.xnawiki.com/index.php?title=Drawing_2D_lines_without_using_primitives
 */
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Visual_Novel_Base
{
    public static class LineDrawer
    {

        static Texture2D blank;

        private static void InitLineDrawer(GraphicsDevice GraphicsDevice)
        {
            blank = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blank.SetData(new[] { Color.White });
        }


        public static void DrawLine(SpriteBatch spriteBatch, float width, Color color, Vector2 point1, Vector2 point2)
        {
            if (blank == null)
            {
                InitLineDrawer(spriteBatch.GraphicsDevice);
            }

            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = Vector2.Distance(point1, point2);

            spriteBatch.Draw(blank, point1, null, color,
                       angle, Vector2.Zero, new Vector2(length, width),
                       SpriteEffects.None, 0);
        }

        public static void DrawRectangle(SpriteBatch spriteBatch, float width, Color color, Rectangle Rec)
        {
            DrawLine(spriteBatch, width, color, new Vector2((Rec.X), (Rec.Y)), new Vector2((Rec.X + Rec.Width), (Rec.Y)));
            DrawLine(spriteBatch, width, color, new Vector2((Rec.X + Rec.Width), Rec.Y), new Vector2((Rec.X + Rec.Width), (Rec.Y + Rec.Height)));
            DrawLine(spriteBatch, width, color, new Vector2((Rec.X + Rec.Width), (Rec.Y + Rec.Height)), new Vector2((Rec.X), (Rec.Y + Rec.Height)));
            DrawLine(spriteBatch, width, color, new Vector2((Rec.X), (Rec.Y + Rec.Height)), new Vector2((Rec.X), (Rec.Y)));
        }
    }


}
