using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace JairLib
{
    public class TileTextures : AnyObject
    {

        public TileTextures()
        {
            rectangle = new Rectangle(0, 0, 64, 64);
            region = new Texture2DRegion(Globals.puzzleSet, 0, 0, 64, 64);
            color = Color.White;
        }
        public TileTextures(Texture2DRegion txtregion)
        {
            rectangle = new Rectangle(0, 0, 64, 64);
            region = txtregion;
            color = Color.White;
        }

        public Texture2DRegion region { get; set; }
    }

    //was planning an enum to determine collision but itd only really add an extra layer of confusion, will probably iterate on this
    public enum Texture
    {
        GroundTile,
    }
}
