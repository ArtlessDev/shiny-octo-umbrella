using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using System.Diagnostics;

namespace JairLib
{
    public class TileSpace : AnyObject
    {
        public bool isCollidable { get; set; }
        public int csvValue { get; set; }
        public Vector3 altitude { get; set; }
        public bool isPit {  get; set; }
        public TileSpaceType spaceType { get; set; }

        public TileSpace()
        {
            isCollidable = false;
            texture = Globals.atlas[0];
            rectangle = new Rectangle();
            color = Color.White;
        }
        public TileSpace(int value)
        {
            csvValue = value;
            isCollidable = setCollision();
            
            isPit = setPit();

            altitude = setAltitude();
            spaceType = setSpaceType();
            texture = Globals.gameObjectAtlas[value];
            rectangle = new Rectangle();
            color = Color.White;
        }

        public TileSpace(Texture2DAtlas specificAtlas, int value)
        {
            csvValue = value;
            isCollidable = setCollision();
            texture = specificAtlas[value];
            rectangle = new Rectangle();
            color = Color.White;
        }

        public bool setCollision()
        {
            switch (csvValue)
            {
                case 0:
                    return true;
                default:
                    return false;
            }
        }

        public TileSpaceType setSpaceType()
        {
            switch (csvValue)
            {
                case 2:
                    return TileSpaceType.Walkable;
                case 0:
                    return TileSpaceType.Wall;
                default:
                    return TileSpaceType.Pit;
            }
        }

        public Vector3 setAltitude()
        {
            if (isPit)
                return new Vector3(0,0,0);
            else 
                return new Vector3(0,0,5);
        }

        public bool setPit()
        {
            switch (csvValue)
            {
                case 5:
                case 12:
                    return true;
                default:
                    return false;
            }
        }

        public void Update(PlayerOverworld player)
        {
            //if (player.rectangle.Intersects(rectangle))
            //{
            //    Debug.WriteLine(csvValue);
            //}

        }
    }
}
