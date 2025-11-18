using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib.FootballBoilerPlate
{
    public static class CircleTimingMinigame
    {
        public static CircleTimingMinigameObject PlayerInputObject = new()
        {
            color = Color.Green,
        };
        public static CircleTimingMinigameObject IntendedObject = new();
        public static bool shrinkGame = false;
        public static float SizeDifferences = 0;
        public static async void PassingMinigame(Quarterback qb)
        {

            if (!shrinkGame)
            {
                //here i can make the circles random sizes
                if (Globals.mouseState.WasButtonPressed(MouseButton.Left))
                {
                    IntendedObject.RectangleSize = 15f;
                    PlayerInputObject.RectangleSize = 2f;

                    shrinkGame = true;
                    return;
                }
            }

            if (shrinkGame)
            {
                if (IntendedObject.RectangleSize > 5)
                    IntendedObject.RectangleSize -= .08f;
                else
                    IntendedObject.RectangleSize -= .12f;
                //the shrinking speed will also be affected by the QB's stats
                IntendedObject.rectangle = new Rectangle(Globals.mouseRect.X - (int)(32 * IntendedObject.RectangleSize),
                    (int)(Globals.mouseRect.Y + Globals.MainCamera.Position.Y) - (int)(32 * IntendedObject.RectangleSize),
                    (int)(64 * IntendedObject.RectangleSize),
                    (int)(64 * IntendedObject.RectangleSize));
                PlayerInputObject.rectangle = new Rectangle(Globals.mouseRect.X - (int)(32 * PlayerInputObject.RectangleSize),
                    (int)(Globals.mouseRect.Y + Globals.MainCamera.Position.Y) - (int)(32 * PlayerInputObject.RectangleSize),
                    (int)(64 * PlayerInputObject.RectangleSize),
                    (int)(64 * PlayerInputObject.RectangleSize));


                if (Globals.mouseState.WasButtonPressed(MouseButton.Left))
                {
                    SizeDifferences = IntendedObject.RectangleSize - PlayerInputObject.RectangleSize;
                    GameState.CurrentState = FootballStates.HandlePass;
                    //Debug.WriteLine($"Size Difference between rectangles was: {SizeDifferences}");
                    shrinkGame = false;
                    return;
                }
            }
        }

        public static void Draw(SpriteBatch sb)
        {
            sb.Draw(GameState.PlayersTeam[0].texture, GameState.PlayersTeam[0].rectangle, GameState.PlayersTeam[0].color);
            sb.Draw(IntendedObject.texture, IntendedObject.rectangle, IntendedObject.color);
            sb.Draw(PlayerInputObject.texture, PlayerInputObject.rectangle, PlayerInputObject.color);
        }
    }
    public class CircleTimingMinigameObject : AnyObject
    {
        public CircleTimingMinigameObject()
        {
            texture = Globals.gameObjectAtlas[12];
            rectangle = new Rectangle(Globals.mouseRect.X, Globals.mouseRect.Y, 64, 64);
            color = Color.White;
        }
        public float RectangleSize;
        public Rectangle InputRectangle;
    }
}
