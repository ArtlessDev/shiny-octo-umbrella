using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib.FootballBoilerPlate
{
    public static class DraftState
    {
        public static FootballStates CurrentState = FootballStates.GeneratePlayer;
        public static List<FootballPlayer> DraftablePlayers = new List<FootballPlayer>();

        public static void DraftPlayers() // will probably need to return a list of players and call that team
        {
            //GeneratePlayers(9); //3x3 grid for user to choose from

        }

        public static List<FootballPlayer> GeneratePlayers(int NumOfPlayers)
        {
            //List<FootballPlayer> result = new List<FootballPlayer>();

            for (int i = 0; i<NumOfPlayers; i++)
            {
                DraftablePlayers.Add(new Quarterback());
                Debug.WriteLine(DraftablePlayers[i].NumberId);
            }

            CurrentState = FootballStates.DraftPlayer;

            return DraftablePlayers;
        }
    }
}
