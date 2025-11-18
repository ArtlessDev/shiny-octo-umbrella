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
        public static Pigskin pigskin;
        public static void Update()
        {
            var adjustedSizeDifference = CircleTimingMinigame.SizeDifferences * 100f;
            Debug.WriteLine($"Size Difference between rectangles was: {adjustedSizeDifference}");
            

        }
        public static void Draw(SpriteBatch sb)
        {

        }
    }
}
