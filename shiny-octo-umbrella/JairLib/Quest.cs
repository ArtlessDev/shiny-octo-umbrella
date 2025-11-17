using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text.Json;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using System.Security.AccessControl;
using System.Runtime.CompilerServices;

namespace JairLib
{
    public class Quest
    {
        public Quest() { }

        public string QuestIdentifier { get; set; }
        public KeyObjective StartingObjective { get; set; }
        public KeyObjective MiddleObjective { get; set; }
        public KeyObjective EndingObjective { get; set; }
        public List<KeyObjective> SideObjectives { get; set; }
        public bool QuestComplete {  get; set; }
    }

    public static class QuestSystem
    {
        public static Quest? CurrentQuest;
        public static bool InitiatedFirstQuest = false;
        //public static string FirstQuest = "C:\\Code\\Jamsepticeye-submission\\JamSepticEyeGame\\JamSepticEyeGame\\Content\\JsonFiles\\FirstQuest.json";
        //NEED TO DOUBLE CHECK THIS IN THE RELEASE BUILD TO MAKE SURE IT WORKS
        public static string FirstQuest = ".\\Content\\FirstQuest.json";
        public static string FirstQuestMod = "FirstQuest.json";

        public static void SetFirstQuestAsCurrent()
        {
            using Stream stream = TitleContainer.OpenStream(FirstQuest);
            string jsonString = File.ReadAllText(FirstQuest);
            CurrentQuest = JsonSerializer.Deserialize<Quest>(jsonString);
            CurrentQuest.QuestComplete = false;
        }

        public static void DrawCurrentQuestObjective(SpriteBatch _spriteBatch, PlayerOverworld player)
        {
            KeyObjective[] objectives =
            {
                CurrentQuest.StartingObjective,
                CurrentQuest.MiddleObjective,
                CurrentQuest.EndingObjective,
            };

            foreach (var obj in CurrentQuest.SideObjectives)
            {
                obj.DrawNoCheck(_spriteBatch, player);
                obj.texture = Globals.gameObjectAtlas[obj.textureValue];
            }

            if (CurrentQuest.QuestComplete)
            {
                if (CurrentQuest.SideObjectives[2].IsCompletedFlag)
                    _spriteBatch.DrawString(Globals.font, "GameOver", new(Globals.MainCamera.Position.X + (Globals.ViewportWidth / 2)-32, Globals.MainCamera.Position.Y + (Globals.ViewportHeight / 2)-32), Color.White);
                else 
                    _spriteBatch.DrawString(Globals.font, "GameOver", new(Globals.MainCamera.Position.X + (Globals.ViewportWidth/2) - 32, Globals.MainCamera.Position.Y +(Globals.ViewportHeight/2) - 32), Color.Red);
            }

            foreach (var objective in objectives)
            {

                if (!objective.IsCompletedFlag)
                {
                    objective.Draw(_spriteBatch);
                    objective.texture = Globals.gameObjectAtlas[objective.textureValue];
                    return;
                }
                
                if (objective.IsCompletedFlag)
                {
                    objective.Draw(_spriteBatch);
                }
            }

        }

        public static void Update(GameTime gameTime, PlayerOverworld player)
        {
            if (CurrentQuest.SideObjectives != null) {

                foreach (var obj in CurrentQuest.SideObjectives)
                {
                    //Debug.WriteLine(obj.texture);
                    if (player.rectangle.Intersects(obj.rectangle)
                        && Globals.keyb.WasKeyPressed(Keys.E))
                    {
                        Debug.WriteLine(obj.objectiveTitle);
                        obj.IsCompletedFlag = true;
                    }
                }

                if (CurrentQuest.SideObjectives[2].IsCompletedFlag && Globals.keyb.WasKeyPressed(Keys.E) 
                    && CurrentQuest.SideObjectives[2].rectangle.Intersects(player.rectangle)
                    && CurrentQuest.SideObjectives.Count<3)
                {
                    CurrentQuest.SideObjectives.RemoveAt(4);
                    CurrentQuest.SideObjectives.RemoveAt(3);
                    return;
                }
            }

            if (CurrentQuest.StartingObjective.IsCompletedFlag == true 
                && CurrentQuest.MiddleObjective.IsCompletedFlag == true 
                && CurrentQuest.EndingObjective.IsCompletedFlag == true)
            {
                CurrentQuest.QuestComplete = true;
            }

            if (CurrentQuest.StartingObjective.IsCompletedFlag == false)
            {
                if (player.rectangle.Intersects(CurrentQuest.StartingObjective.rectangle) && Globals.keyb.WasKeyPressed(Keys.E))
                {
                    CurrentQuest.StartingObjective.IsCompletedFlag = true;
                    InitiatedFirstQuest = true;
                    return;
                }
            }
            if (CurrentQuest.MiddleObjective.IsCompletedFlag == false)
            {
                if (player.rectangle.Intersects(CurrentQuest.MiddleObjective.rectangle) && Globals.keyb.WasKeyPressed(Keys.E))
                {
                    CurrentQuest.MiddleObjective.IsCompletedFlag = true;
                    InitiatedFirstQuest = true;

                    return;
                }
            }
            if (CurrentQuest.EndingObjective.IsCompletedFlag == false)
            {
                if (player.rectangle.Intersects(CurrentQuest.EndingObjective.rectangle) && Globals.keyb.WasKeyPressed(Keys.E))
                {
                    if (CurrentQuest.MiddleObjective.IsCompletedFlag && CurrentQuest.StartingObjective.IsCompletedFlag)
                    {
                        CurrentQuest.EndingObjective.IsCompletedFlag = true;
                        InitiatedFirstQuest = true;
                    }
                    return;
                }
            }

        }
    }
}
