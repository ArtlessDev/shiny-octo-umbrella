using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib.FootballBoilerPlate
{
    public class Pigskin : AnyObject
    {
        public Pigskin(Quarterback qb)
        {
            Velocity = 10f;
            IntendedLandingSpot = new(Globals.mouseRect.X, Globals.mouseRect.Y);
            ActualLandingSpot = new (qb.ThrowingAccuracy * Globals.mouseRect.X, qb.ThrowingAccuracy * Globals.mouseRect.Y);
        }

        public float Velocity;
        public Vector2 IntendedLandingSpot;
        public Vector2 ActualLandingSpot;

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
