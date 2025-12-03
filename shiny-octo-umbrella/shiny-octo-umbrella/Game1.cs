using JairLib;
using JairLib.FootballBoilerPlate;
using JairLib.TileGenerators;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Input;
using MonoGame.Extended.ViewportAdapters;
using System.Linq;

namespace shiny_octo_umbrella
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public MapBuilder map;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Globals.GlobalContent = Content;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720; 
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, Globals.ViewportWidth, Globals.ViewportHeight);
            Globals.MainCamera = new OrthographicCamera(viewportAdapter);
            Globals.MainCamera.Position = new Vector2(0, 30*64);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            Globals.Load();
            map = new MapBuilder();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.Update(gameTime);
            Globals.mouseRect = new Rectangle(Globals.mouseState.X, Globals.mouseState.Y, 3, 3);

            if (GameState.CurrentState == FootballStates.GeneratePlayer)
            {
                GameState.DraftablePlayers.Clear();
                GameState.GeneratePlayers(3);

                GameState.CurrentState = FootballStates.DraftPlayer;
            }

            if (GameState.CurrentState == FootballStates.DraftPlayer)
            {
                foreach (var obj in GameState.DraftablePlayers.ToList())
                {
                    Globals.IsMouseHovering(obj);

                    if (Globals.mouseState.WasButtonPressed(MouseButton.Left) && Globals.CheckMouseIntersection(obj))
                    {
                        //this is the crude way of centering the QB, need to isolate this portion and make it generic for other objects as this is something thats been slowing me down
                        obj.rectangle = new(
                            (int)Globals.MainCamera.Center.X-32,//(int)Globals.MainCamera.Position.X+(Globals.mapWidth*32), 
                            (int)Globals.MainCamera.Position.Y + 600,//(int)(Globals.MainCamera.Position.Y + (Globals.MainCamera.BoundingRectangle.Bottom * 32)), 
                            obj.rectangle.Width, 
                            obj.rectangle.Height);

                        GameState.PlayersTeam.Add(obj);
                        
                        GameState.CurrentState = GameState.IsFirstDraft? FootballStates.GeneratePlayer : FootballStates.PickPlay;
                        GameState.IsFirstDraft = false;

                        return;
                    }
                }

            }

            if (GameState.CurrentState == FootballStates.PickPlay)
            {

            }

            if (GameState.CurrentState == FootballStates.PlaceReceivers)
            {

            }

            if (GameState.CurrentState == FootballStates.RunPlay)
            {
                ///<summary>
                ///need to check out that new monogame library with all the shapes. need to brainstorm and test out different minigame styles
                ///
                /// </summary>

                Quarterback qb = (Quarterback)GameState.PlayersTeam[0];

                CircleTimingMinigame.PassingMinigame(qb);
            
            }

            if (GameState.CurrentState == FootballStates.HandlePass)
            {
                HandlePass.Setup();
                HandlePass.Update();
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var transformMatrix = Globals.MainCamera.GetViewMatrix();
            // TODO: Add your drawing code here
            _spriteBatch.Begin(transformMatrix: transformMatrix);

            map.DrawMapFromList(_spriteBatch);

            if (GameState.CurrentState == FootballStates.DraftPlayer)
            {
                GameState.DraftDraw(_spriteBatch);
            }

            if (GameState.CurrentState == FootballStates.RunPlay)
            {
                CircleTimingMinigame.Draw(_spriteBatch);
                
                _spriteBatch.Draw(Globals.pigskinSprite, new Rectangle(GameState.PlayersTeam[0].rectangle.X-64, GameState.PlayersTeam[0].rectangle.Y, GameState.PlayersTeam[0].rectangle.Width, GameState.PlayersTeam[0].rectangle.Height), GameState.PlayersTeam[0].color);

            }

            if (GameState.CurrentState == FootballStates.HandlePass)
            {
                _spriteBatch.Draw(Globals.pigskinSprite, HandlePass.pigskin.rectangle, GameState.PlayersTeam[0].color);

                HandlePass.Draw(_spriteBatch);

            }

            //if (GameState.CurrentState == FootballStates.HandlePass)
            //{
            //    HandlePass.Draw(_spriteBatch);
            //}

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
