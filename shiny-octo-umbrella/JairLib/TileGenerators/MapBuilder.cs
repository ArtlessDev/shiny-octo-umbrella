using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using System.Globalization;

namespace JairLib.TileGenerators
{
    public class MapBuilder
    {
        public MapBuilder()
        {
            //var defaultFilePath = "C:\\Code\\Jamsepticeye-submission\\JamSepticEyeGame\\JamSepticEyeGame\\Content\\Sprites\\grayboxedMap.csv";
            //var defaultFilePath = "C:\\Code\\Jamsepticeye-submission\\JamSepticEyeGame\\JamSepticEyeGame\\Content\\Sprites\\grayboxedMap.csv";
            //var defaultFilePath = "C:\\Code\\Jamsepticeye-submission\\JamSepticEyeGame\\JamSepticEyeGame\\Content\\Sprites\\test.csv";
            
            //filePath = ".\\Content\\grayboxedMap.csv";
            filePath = ".\\Content\\MapCsvFiles\\GrayBoxTrialMap.csv";
            
            Spaces = new List<TileSpace>();

            /// imports the csv, and fills the Spaces List to  
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var numberOfRows = 0;
                while (csv.Read())
                {
                    var indexer = 0;

                    for (int i = 0; i < Globals.mapWidth; i++)
                    {
                        var csvSpaceValue = int.Parse(csv.GetField(indexer));

                        Spaces.Add(
                            new TileSpace(csvSpaceValue)
                            {
                                rectangle = new Rectangle(i * 64, numberOfRows*64,64,64)
                            }
                        );
                        indexer++;
                    }
                    ///column needs to be the height value which is 40 in this case
                    /// rows need to be the width value, which in this case is 30
                    numberOfRows++;
                    columns = csv.ColumnCount;
                }
                rows = numberOfRows;

            }
        }

        public string filePath{ get; set; }
        public List<TileSpace> Spaces { get; set; }
        public int rows { get; set; }
        public int columns { get; set; }
        public static CsvReader csvFileReader {  get; set; }

        public void DrawMapFromList(SpriteBatch _spriteBatch)
        {
            if (Spaces != null)
            {
                var indexer = 0;

                ///currently will make a square and does not fill out the entire map, the map is however coming in correctly and has 1200 values
                for (int down = 0; down < rows; down++)
                {
                    for (int left = 0; left < columns; left++)
                    {
                        TileSpace t = Spaces[indexer];
                        _spriteBatch.Draw(Spaces[indexer].texture, new Vector2(t.rectangle.X, t.rectangle.Y), Color.White);
                        //_spriteBatch.Draw(Spaces[indexer].texture, new Vector2(32 * left, 32 * down), Color.White);
                        indexer++;
                    }
                }
            }
        }
    }
}
