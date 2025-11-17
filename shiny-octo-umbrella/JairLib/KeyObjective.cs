using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;
using System.Diagnostics;

namespace JairLib
{
    public class KeyObjective //: ITileObject
    {
        public KeyObjective() {
            texture = Globals.gameObjectAtlas[textureValue];
            color = Color.White;
        }
        public KeyObjective(Texture2DAtlas specifiedAtlas) {
            texture = specifiedAtlas[textureValue];
            color = Color.White;
        }
        public string objectiveTitle { get; set; }
        public string objectiveDescription { get; set; }
        public string identifier { get; set; }
        public int x {get; set;}
        public int y {get; set;}
        public int width {get; set;}
        public int height {get; set;}
        public Rectangle rectangle => new Rectangle(x,y,width,height);
        public int textureValue {  get; set; }
        public Texture2DRegion texture { get; set; }
        public Color color { get; set; }
        public bool IsCompletedFlag { get; set; }
        public bool IsMainQuest { get; set; }
        public bool IsAutoTrigger { get; set; }
        
    
        public void Update(GameTime gameTime, PlayerOverworld player)
        {
            if (player.rectangle.Intersects(this.rectangle) && Globals.keyb.WasKeyPressed(Keys.E))
            {
                //Debug.WriteLine(this.objectiveTitle);
                IsCompletedFlag = true;
            }
        }

        public void isPlayerInteracting()
        {

        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            if (IsCompletedFlag) 
            { 
                _spriteBatch.DrawString(Globals.font, objectiveDescription, new(rectangle.X, rectangle.Y), Color.White);
            }
            else
            {
                _spriteBatch.Draw(texture, new Vector2(rectangle.X, rectangle.Y), color);
            }
        }

        public void DrawNoCheck(SpriteBatch _spriteBatch, PlayerOverworld player)
        {
            if (this.IsAutoTrigger && player.rectangle.Intersects(this.rectangle))
            {
                _spriteBatch.DrawString(Globals.font, objectiveDescription, new(player.rectangle.X, player.rectangle.Y+32), Color.White);
            }

            _spriteBatch.Draw(texture, new Vector2(rectangle.X, rectangle.Y), color);
            if(IsCompletedFlag)
            {
                _spriteBatch.DrawString(Globals.font, objectiveDescription, new(rectangle.X, rectangle.Y-32), Color.White);
            }
        }
    }
}
