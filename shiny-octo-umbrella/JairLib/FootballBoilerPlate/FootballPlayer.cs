using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib.FootballBoilerPlate
{
    /// <summary>
    /// floats should be more granular stats
    /// ints should be more for general 'madden' style stats
    /// </summary>

    public class FootballPlayer : AnyObject
    {
        public FootballPlayer()
        {

        }

        public PlayerSide PlayerSide;
        public float Speed;
        public float Stamina;
        public int NumberId;
    }

    public class Quarterback : FootballPlayer
    {
        public float ThrowingSpeed;
        public float ThrowingStrength;
        public float ThrowingAccuracy;

        public Quarterback()
        {
            NumberId = Random.Shared.Next(0, 99);
        }

        public void ThrowBall()
        {
            throw new NotImplementedException();
        }
    }
    
    public class WideReceiver : FootballPlayer
    {
        public int CatchAbilityRating;

        public WideReceiver()
        {

        }
    }
        
    public class RunningBack : FootballPlayer
    {

    }
        
    public class TightEnd : FootballPlayer
    {
        public int CatchAbilityRating;

    }
}
