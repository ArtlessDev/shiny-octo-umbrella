using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib.FootballBoilerPlate
{
    public static class HandlePass
    {
        public static Pigskin pigskin = new((Quarterback)GameState.PlayersTeam[0]);
        public static Vector2 SelectedPos;
        public static Vector2 startPos;
        public static bool SetupFlag = true;
        public static bool CompletedFlag = false;
        public static float triggerTimes = 0f;
        public static void Update()
        {
            if (SetupFlag)
                return;
            if (CompletedFlag)
                return;

            var adjustedSizeDifference = CircleTimingMinigame.SizeDifferences * 100f;
            //seeing frame drops very early on in development, we're talkin' 11/19/2025, only a few builds in but this will definitely need to be reconstructed
            triggerTimes += .01f;
            var lerpedX = MathHelper.Lerp(startPos.X, SelectedPos.X, triggerTimes);
            var lerpedY = MathHelper.Lerp(startPos.Y, SelectedPos.Y, triggerTimes);
            //ball needs to travel from starting point where we see it at the RunPlay state
            //then it needs to move to the SelectedPos
            //Debug.WriteLine($"lerp x: {lerpedX} lerp y: {lerpedX}");
            //math is wrong here somewhere
            var adjustedX = (int)lerpedX;//(int)(Globals.MainCamera.Position.X + lerpedX);
            var adjustedY = (int)(lerpedY + Globals.MainCamera.Position.Y);//(int)(Globals.MainCamera.Position.Y + lerpedY);
            pigskin.rectangle = new(adjustedX, adjustedY, pigskin.rectangle.Width, pigskin.rectangle.Height);
            
            if (triggerTimes >= 1f)
            {
                CompletedFlag = true;
                GameState.CurrentState = FootballStates.GeneratePlayer;
                triggerTimes = 0;
                SetupFlag = true;
                pigskin.rectangle = new ((int)startPos.X, (int)startPos.Y, pigskin.rectangle.Width, pigskin.rectangle.Height);

                //need to reset values once this is hit, otherwise we can only run this once
            }
        }

        public static void Setup()
        {
            if (!SetupFlag)
                return;

            startPos = new Vector2(pigskin.rectangle.X-Globals.MainCamera.Position.X, pigskin.rectangle.Y-Globals.MainCamera.Position.Y);
            SetupFlag = false;
            CompletedFlag = false;

        }
        public static void Draw(SpriteBatch sb)
        {
            //sb.Draw(pigskin.texture, pigskin.rectangle, Color.White);
        }
    }
}
