using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib.FootballBoilerPlate
{
    public static class GameState
    {
        public static FootballStates CurrentState = FootballStates.GeneratePlayer;
        public static List<FootballPlayer> DraftablePlayers = new List<FootballPlayer>();
        public static List<FootballPlayer> PlayersTeam = new List<FootballPlayer>(); // index 0 should always be a QB

        public static void DraftPlayers() // will probably need to return a list of players and call that team
        {
            //GeneratePlayers(9); //3x3 grid for user to choose from
            
        }

        public static List<FootballPlayer> GeneratePlayers(int NumOfPlayers)
        {
            //List<FootballPlayer> result = new List<FootballPlayer>();

            for (int i = 0; i<NumOfPlayers; i++)
            {
                DraftablePlayers.Add(new Quarterback(new Vector2(Globals.TileSize * i, Globals.MainCamera.Position.Y)));//Globals.MainCamera.Center.Y)));
                //Debug.WriteLine($"{DraftablePlayers[i].NumberId}  {DraftablePlayers[i].rectangle}");
            }


            return DraftablePlayers;
        }

        public static void DraftDraw(SpriteBatch sb)
        {
            foreach (var obj in DraftablePlayers)
            {
                //Debug.WriteLine($"{obj.NumberId}  {obj.rectangle}");
                sb.Draw(obj.texture, new Vector2(obj.rectangle.X, obj.rectangle.Y), obj.color);
            }
        }
    }
}
