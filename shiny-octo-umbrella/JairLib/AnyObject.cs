using Microsoft.Xna.Framework;
using MonoGame.Extended.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib
{
    public class AnyObject : ITileObject
    {
        public AnyObject() { }
        public string identifier { get; set; }
        public Rectangle rectangle { get; set; }
        public Texture2DRegion texture { get; set; }
        public Color color { get; set; }
        public Vector3 absolutePosition { get; set; }
    }
}
