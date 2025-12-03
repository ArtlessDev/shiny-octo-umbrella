using Microsoft.Xna.Framework;
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
            color = Color.White;
            rectangle = new Rectangle(0, 0, Globals.TileSize, Globals.TileSize);
        }
        
        public FootballPlayer(Vector2 vec)
        {
            color = Color.White;
            rectangle = new Rectangle((int)vec.X, (int)vec.Y, 64, 64);
        }

        public Color SetColor()
        {
            switch (NumberId)
            {
                case 99:
                    return Color.Gold;
                case > 88:
                    return Color.Purple;
                case > 80:
                    return Color.LightBlue;
                case > 70:
                    return Color.LightGreen;
                case > 50:
                    return Color.White;
                case > 30:
                    return Color.Orange;
                default: 
                    return Color.Red;
            }
        }

        public DominantHand handedness;

        public Color reservedColor;
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
            handedness = DominantHand.Left;
            NumberId = Random.Shared.Next(0, 99);
            ThrowingSpeed = 50;
            ThrowingStrength = 50;
            ThrowingAccuracy = 50;
            texture = Globals.gameObjectAtlas[6]; //blue
        }
        public Quarterback(Vector2 vec)
        {
            NumberId = Random.Shared.Next(0, 99);
            color = SetColor();
            reservedColor = color;
            rectangle = new Rectangle((int)vec.X, (int)Globals.MainCamera.Position.Y, Globals.TileSize, Globals.TileSize); //Globals.TileSize * i, )
            absolutePosition = new Vector3((int)vec.X, 64, 1);
            texture = Globals.gameObjectAtlas[6]; //blue
        }

        public void ThrowBall()
        {
            
        }
    }
    
    public class WideReceiver : FootballPlayer
    {
        public int CatchAbilityRating;

        public WideReceiver(Vector2 vec)
        {
            NumberId = Random.Shared.Next(0, 99);
            color = SetColor();
            reservedColor = color;
            rectangle = new Rectangle((int)vec.X, (int)Globals.MainCamera.Position.Y, Globals.TileSize, Globals.TileSize); //Globals.TileSize * i, )
            absolutePosition = new Vector3((int)vec.X, 64, 1);
            texture = Globals.gameObjectAtlas[7];
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
