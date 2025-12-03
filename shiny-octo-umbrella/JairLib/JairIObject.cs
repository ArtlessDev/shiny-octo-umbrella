using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

public interface IJairObject 
{
    public string identifier {get; set;}
    public Rectangle rectangle{get; set;}
    public Texture2D texture{get;}
    public Color color{get; set;}
}

//not used for this game
public interface ICustomButton
{
    public void ButtonClicked()
    {
        Debug.WriteLine("1");
    }
}

public interface ITileObject
{
    public string identifier { get; set; }
    public Rectangle rectangle { get; set; }
    public Color color { get; set; }
    public Vector3 absolutePosition { get; set; }
}

public enum PlayerState
{
    Walking,
    Waiting,
    Jumping,
    Freefall,
    Dead,
}

public enum Direction
{
    Left,
    Right,
    Up,
    Down,
}

public enum TileSpaceType
{
    Walkable,
    Wall,
    Pit,
}

public enum PlayerSide
{
    Offense,
    Defense,
}

public enum FootballStates
{
    None,
    GeneratePlayer,
    DraftPlayer,
    PickPlay,
    PlaceReceivers,
    RunPlay,
    HandlePass,
}

public enum DominantHand
{
    Left,
    Right,
}