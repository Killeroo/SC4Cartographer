using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Numerics;

using SC4Parser;

using Region = SC4Parser.Region.Region;

namespace SC4CartographerUI
{
    class MapRenderer
    {
        public static Bitmap CreateRegionBitmap(Region region, MapCreationParameters parameters)
        {
            // TODO: This is not accurate
            int gridSizeX = region.Terrain.Length;
            int gridSizeY = region.Terrain[0].Length;

            // Create our bitmap for our map
            Bitmap bmp = new Bitmap(
                gridSizeX * parameters.GridSegmentSize + 1,
                gridSizeY * parameters.GridSegmentSize + 1);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Render terrain map first
                if (parameters.VisibleMapObjects.Contains(MapObject.TerrainMap))
                {
                    // First get the height data from the region
                    float[][] heightMap = region.Terrain;

                    // Then create a list of enabled terrain layers, their height and respective colorObject
                    // We want stuff in a list because it more easy to work with than a dictionary
                    // (we want to be able to seek backwards and forwards from an index which is not so easy with a dict)
                    List<(int height, MapColorObject colorObject)> sortedTerrainList = new List<(int, MapColorObject)>();
                    foreach (var terrainData in parameters.TerrainDataDictionary)
                    {
                        if (terrainData.Value.enabled == false)
                        {
                            continue;
                        }

                        sortedTerrainList.Add((terrainData.Value.height, terrainData.Value.colorObject));
                    }

                    // Order it by height
                    sortedTerrainList.OrderBy(terrain => terrain.height);

                    // Go through each height in the height map
                    SolidBrush brush = new SolidBrush(Color.White);
                    Rectangle rect = new Rectangle();
                    for (int x = 0; x < gridSizeX; x++)
                    {
                        for (int y = 0; y < gridSizeY; y++)
                        {
                            // one grid segment has one height value, so we colour that grid segment
                            rect = new Rectangle(
                                    (parameters.GridSegmentSize * x),
                                    (parameters.GridSegmentSize * y),
                                    (parameters.GridSegmentSize),
                                    (parameters.GridSegmentSize));

                            float height = heightMap[y][x];

                            // Find the closest terrain layer
                            // Go through the sorted list and find the index of the layer
                            // that has the closest height to our current height
                            float currentBestDifference = 999999;
                            int currentBestIndex = 0;
                            for (int index = 0; index < sortedTerrainList.Count(); index++)
                            {
                                float diff = ((float)sortedTerrainList[index].height) - height;

                                if (diff > 0 && diff < currentBestDifference)
                                {
                                    currentBestIndex = index;
                                    currentBestDifference = diff;

                                    // Because the list is ordered, the first instance where we 
                                    // get a positive difference is going to be the closest layer to 
                                    // our current height. 
                                    // If we get out early then we save some time by not going through the whole list
                                    break;
                                }
                                else //if (index == sortedTerrainList.Count)
                                {
                                    // If we are at the end of the list and have found nothing then just
                                    // grab the last index and move out
                                    currentBestIndex = index;
                                }
                            }

                            if (parameters.BlendTerrainLayers)
                            {
                                // Blend the colour of a tile between the colors of the 2 height layers it falls between
                                if (currentBestIndex == 0 || currentBestIndex == sortedTerrainList.Count())
                                {
                                    // If the closest index that we found is the start or end of the list then we just
                                    // use that colour uniformaly
                                    brush.Color = parameters.ColorDictionary[sortedTerrainList[currentBestIndex].colorObject];
                                }
                                else
                                {
                                    // If we are not at the start or end of the list we are safe to fetch the previous index
                                    // and map the value to a color between the 2 closest color layers 
                                    brush.Color = Helper.MapColor(
                                        height,
                                        sortedTerrainList[currentBestIndex - 1].height,
                                        sortedTerrainList[currentBestIndex].height,
                                        parameters.ColorDictionary[sortedTerrainList[currentBestIndex - 1].colorObject],
                                        parameters.ColorDictionary[sortedTerrainList[currentBestIndex].colorObject]);
                                }
                            }
                            else
                            {
                                // Just paint the color of the layer we are in
                                brush.Color = parameters.ColorDictionary[sortedTerrainList[currentBestIndex].colorObject];
                            }


                            // Generate surface normals for each space on grid
                            Vector3[][] surfaceNormals = new Vector3[gridSizeX][];
                            for (x = 0; x < gridSizeX; x++)
                            {
                                for (y = 0; y < gridSizeY; y++)
                                {
                                    // Create vector for grid 
                                    Vector3 current = Helper.GridLocationToVector(x, y, heightMap[y][x], 16);
                                    //Vector3 right = Helper.GridLocationToVector(x, y + 1, heightMap[y][x])
                                    //Vector3 surfaceNormal = Vector3.Cross()
                                }
                            }


                            // Paint the actual grid
                            g.FillRectangle(brush, rect);
                        }
                    }
                }
                else
                {
                    // if not rendering terrain map, render the background color
                    g.Clear(parameters.ColorDictionary[MapColorObject.Background]);
                }

                // Render grid lines
                if (parameters.ShowGridLines)
                {
                    Pen gridLinesPen = new Pen(parameters.ColorDictionary[MapColorObject.GridLines]);
                    gridLinesPen.Width = 1;

                    for (int y = 0; y < gridSizeY; ++y)
                    {
                        g.DrawLine(gridLinesPen, 0, y * parameters.GridSegmentSize, gridSizeY * parameters.GridSegmentSize, y * parameters.GridSegmentSize);
                    }

                    for (int x = 0; x < gridSizeX; ++x)
                    {
                        g.DrawLine(gridLinesPen, x * parameters.GridSegmentSize, 0, x * parameters.GridSegmentSize, gridSizeY * parameters.GridSegmentSize);
                    }
                }

                // Render lots
                if (parameters.VisibleMapObjects.FindAll(x => x.ToString().Contains("Zone")).Count() != 0)
                {
                    Pen zoneOutlinePen = new Pen(parameters.ColorDictionary[MapColorObject.ZoneOutline]);
                    zoneOutlinePen.Width = 1;

                    foreach (var lot in region.Lots)
                    {
                        Rectangle rect = new Rectangle();

                        // Get colour of zone (and check if it should be displayed)
                        Color c = new Color();
                        switch (lot.ZoneType)
                        {
                            case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_LOW:
                                {
                                    // Check the zone is in the list of visible map objects
                                    if (parameters.VisibleMapObjects.Contains(MapObject.ResidentialLowZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.ResidentialLow];
                                    }
                                    else
                                    {
                                        // if not skip it
                                        continue;
                                    }

                                    break;
                                }

                            case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_MEDIUM:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.ResidentialMidZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.ResidentialMid];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_HIGH:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.ResidentialHighZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.ResidentialHigh];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_LOW:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.CommercialLowZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.CommercialLow];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_MEDIUM:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.CommercialMidZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.CommercialMid];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_HIGH:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.CommercialHighZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.CommercialHigh];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_LOW:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.IndustrialLowZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.IndustrialLow];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_MEDIUM:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.IndustrialMidZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.IndustrialMid];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_HIGH:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.IndustrialHighZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.IndustrialHigh];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_MILITARY:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.MilitaryZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.Military];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_AIRPORT:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.AirportZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.Airport];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_SEAPORT:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.SeaportZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.Seaport];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_SPACEPORT:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.SpaceportZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.Spaceport];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.PloppedBuildingZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING_ALT:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.PloppedBuildingZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            default:
                                c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                                break;
                        }

                        // Get the actual dimensions of the zone
                        switch (lot.Orientation)
                        {
                            case Constants.ORIENTATION_NORTH:
                            case Constants.ORIENTATION_SOUTH:
                                rect = new Rectangle(
                                    parameters.SegmentPaddingX + (parameters.GridSegmentSize * lot.MinTileX),
                                    parameters.SegmentPaddingY + (parameters.GridSegmentSize * lot.MinTileZ),
                                    (parameters.GridSegmentSize * lot.SizeX) - (parameters.SegmentPaddingX * 2),
                                    (parameters.GridSegmentSize * lot.SizeZ) - (parameters.SegmentPaddingY * 2));
                                break;

                            case Constants.ORIENTATION_WEST:
                            case Constants.ORIENTATION_EAST:
                                rect = new Rectangle(
                                    parameters.SegmentPaddingX + (parameters.GridSegmentSize * lot.MinTileX),
                                    parameters.SegmentPaddingY + (parameters.GridSegmentSize * lot.MinTileZ),
                                    (parameters.GridSegmentSize * lot.SizeZ) - (parameters.SegmentPaddingX * 2),
                                    (parameters.GridSegmentSize * lot.SizeX) - (parameters.SegmentPaddingY * 2));


                                break;

                        }

                        // Draw the zone on the bitmap
                        g.FillRectangle(new SolidBrush(c), rect);

                        // draw an outline if that option is enabled
                        if (parameters.ShowZoneOutlines)
                        {
                            g.DrawRectangle(zoneOutlinePen, rect);
                        }
                    }
                }

                // Render buildings
                //if (parameters.VisibleMapObjects.Contains(MapObject.Building))
                //{
                //    Brush b = new SolidBrush(parameters.ColorDictionary[MapColorObject.Buildings]);
                //    Pen pe = new Pen(parameters.ColorDictionary[MapColorObject.BuildingsOutline], 1);
                //    double unit = parameters.GridSegmentSize / 16d;

                //    foreach (var building in region.Buildings)
                //    {
                //        Rectangle rect = new Rectangle(
                //                (int)(unit * Math.Ceiling(building.MinCoordinateX)),
                //                (int)(unit * Math.Ceiling(building.MinCoordinateZ)),
                //                (int)(unit * Math.Ceiling(building.MaxCoordinateX - building.MinCoordinateX)),
                //                (int)(unit * Math.Ceiling(building.MaxCoordinateZ - building.MinCoordinateZ)));

                //        g.FillRectangle(b, rect);

                //        if (parameters.ShowBuildingOutlines)
                //        {
                //            g.DrawRectangle(pe, rect);
                //        }
                //    }
                //}

            }

            return bmp;
        }

        /// <summary>
        /// Create a map from MapCreationParameters
        /// </summary>
        /// <param name="save">The save game object to extract the data for the map from</param>
        /// <param name="parameters">The display parameters of the map</param>
        /// <returns>A bitmap of the map</returns>
        public static Bitmap CreateCityBitmap(SC4SaveFile save, MapCreationParameters parameters)
        {
            int gridSizeX = (int) save.GetRegionViewSubfile().CitySizeX;
            int gridSizeY = (int) save.GetRegionViewSubfile().CitySizeY;

            // Create our bitmap for our map
            Bitmap bmp = new Bitmap(
                gridSizeX * parameters.GridSegmentSize + 1,
                gridSizeY * parameters.GridSegmentSize + 1);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Render terrain map first
                if (parameters.VisibleMapObjects.Contains(MapObject.TerrainMap) 
                    && save.ContainsTerrainMapSubfile())
                {
                    // this can almost certainly done better but yeah...
                    // Did you know I spent 6 months writing this tool and the parser? :/

                    // First get the height data from the save
                    float[][] heightMap = save.GetTerrainMapSubfile().Map;

                    // Then create a list of enabled terrain layers, their height and respective colorObject
                    // We want stuff in a list because it more easy to work with than a dictionary
                    // (we want to be able to seek backwards and forwards from an index which is not so easy with a dict)
                    List<(int height, MapColorObject colorObject)> sortedTerrainList = new List<(int, MapColorObject)>();
                    foreach (var terrainData in parameters.TerrainDataDictionary)
                    {
                        if (terrainData.Value.enabled == false)
                        {
                            continue;
                        }

                        sortedTerrainList.Add((terrainData.Value.height, terrainData.Value.colorObject));
                    }

                    // Order it by height
                    sortedTerrainList.OrderBy(terrain => terrain.height);

                    // Go through each height in the height map
                    SolidBrush brush = new SolidBrush(Color.White);
                    for (int x = 0; x < gridSizeX; x++)
                    {
                        for (int y = 0; y < gridSizeY; y++)
                        {
                            // one grid segment has one height value, so we colour that grid segment
                            Rectangle rect = new Rectangle();
                            rect = new Rectangle(
                                    (parameters.GridSegmentSize * x),
                                    (parameters.GridSegmentSize * y),
                                    (parameters.GridSegmentSize),
                                    (parameters.GridSegmentSize));

                            float height = heightMap[x][y];//[y][x];
                            
                            // Find the closest terrain layer
                            // Go through the sorted list and find the index of the layer
                            // that has the closest height to our current height
                            float currentBestDifference = 999999;
                            int currentBestIndex = 0;
                            for (int index = 0; index < sortedTerrainList.Count(); index++)
                            {
                                float diff = ((float)sortedTerrainList[index].height) - height;

                                if (diff > 0 && diff < currentBestDifference)
                                {
                                    currentBestIndex = index;
                                    currentBestDifference = diff;

                                    // Because the list is ordered, the first instance where we 
                                    // get a positive difference is going to be the closest layer to 
                                    // our current height. 
                                    // If we get out early then we save some time by not going through the whole list
                                    break;
                                }
                                else //if (index == sortedTerrainList.Count)
                                {
                                    // If we are at the end of the list and have found nothing then just
                                    // grab the last index and move out
                                    currentBestIndex = index;
                                }
                            }

                            if (parameters.BlendTerrainLayers)
                            {
                                // Blend the colour of a tile between the colors of the 2 height layers it falls between
                                if (currentBestIndex == 0 || currentBestIndex == sortedTerrainList.Count())
                                {
                                    // If the closest index that we found is the start or end of the list then we just
                                    // use that colour uniformaly
                                    brush.Color = parameters.ColorDictionary[sortedTerrainList[currentBestIndex].colorObject];
                                }
                                else
                                {
                                    // If we are not at the start or end of the list we are safe to fetch the previous index
                                    // and map the value to a color between the 2 closest color layers 
                                    brush.Color = Helper.MapColor(
                                        height,
                                        sortedTerrainList[currentBestIndex - 1].height,
                                        sortedTerrainList[currentBestIndex].height,
                                        parameters.ColorDictionary[sortedTerrainList[currentBestIndex - 1].colorObject],
                                        parameters.ColorDictionary[sortedTerrainList[currentBestIndex].colorObject]);
                                }
                            }
                            else
                            {
                                // Just paint the color of the layer we are in
                                brush.Color = parameters.ColorDictionary[sortedTerrainList[currentBestIndex].colorObject];
                            }

                            // Paint the actual grid
                            g.FillRectangle(brush, rect);
                        }
                    }
                }
                else
                {
                    // if not rendering terrain map, render the background color
                    g.Clear(parameters.ColorDictionary[MapColorObject.Background]);
                }

                // Render grid lines
                if (parameters.ShowGridLines)
                {
                    Pen gridLinesPen = new Pen(parameters.ColorDictionary[MapColorObject.GridLines]);
                    gridLinesPen.Width = 1;

                    for (int y = 0; y < gridSizeY; ++y)
                    {
                        g.DrawLine(gridLinesPen, 0, y * parameters.GridSegmentSize, gridSizeY * parameters.GridSegmentSize, y * parameters.GridSegmentSize);
                    }

                    for (int x = 0; x < gridSizeX; ++x)
                    {
                        g.DrawLine(gridLinesPen, x * parameters.GridSegmentSize, 0, x * parameters.GridSegmentSize, gridSizeY * parameters.GridSegmentSize);
                    }
                }

                // Render lots
                if (parameters.VisibleMapObjects.FindAll(x => x.ToString().Contains("Zone")).Count() != 0
                    && save.ContainsLotSubfile())
                {
                    Pen zoneOutlinePen = new Pen(parameters.ColorDictionary[MapColorObject.ZoneOutline]);
                    zoneOutlinePen.Width = 1;

                    foreach (var lot in save.GetLotSubfile().Lots)
                    {
                        Rectangle rect = new Rectangle();

                        // Get colour of zone (and check if it should be displayed)
                        Color c = new Color();
                        switch (lot.ZoneType)
                        {
                            case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_LOW:
                                {
                                    // Check the zone is in the list of visible map objects
                                    if (parameters.VisibleMapObjects.Contains(MapObject.ResidentialLowZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.ResidentialLow];
                                    }
                                    else
                                    {
                                        // if not skip it
                                        continue;
                                    }

                                    break;
                                }

                            case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_MEDIUM:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.ResidentialMidZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.ResidentialMid];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_HIGH:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.ResidentialHighZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.ResidentialHigh];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_LOW:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.CommercialLowZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.CommercialLow];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_MEDIUM:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.CommercialMidZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.CommercialMid];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_HIGH:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.CommercialHighZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.CommercialHigh];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_LOW:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.IndustrialLowZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.IndustrialLow];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_MEDIUM:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.IndustrialMidZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.IndustrialMid];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_HIGH:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.IndustrialHighZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.IndustrialHigh];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_MILITARY:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.MilitaryZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.Military];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_AIRPORT:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.AirportZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.Airport];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_SEAPORT:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.SeaportZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.Seaport];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_SPACEPORT:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.SpaceportZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.Spaceport];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.PloppedBuildingZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING_ALT:
                                {
                                    if (parameters.VisibleMapObjects.Contains(MapObject.PloppedBuildingZone))
                                    {
                                        c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                }
                            default:
                                c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                                break;
                        }

                        // Get the actual dimensions of the zone
                        switch (lot.Orientation)
                        {
                            case Constants.ORIENTATION_NORTH:
                            case Constants.ORIENTATION_SOUTH:
                                rect = new Rectangle(
                                    parameters.SegmentPaddingX + (parameters.GridSegmentSize * lot.MinTileX),
                                    parameters.SegmentPaddingY + (parameters.GridSegmentSize * lot.MinTileZ),
                                    (parameters.GridSegmentSize * lot.SizeX) - (parameters.SegmentPaddingX * 2),
                                    (parameters.GridSegmentSize * lot.SizeZ) - (parameters.SegmentPaddingY * 2));
                                break;

                            case Constants.ORIENTATION_WEST:
                            case Constants.ORIENTATION_EAST:
                                rect = new Rectangle(
                                    parameters.SegmentPaddingX + (parameters.GridSegmentSize * lot.MinTileX),
                                    parameters.SegmentPaddingY + (parameters.GridSegmentSize * lot.MinTileZ),
                                    (parameters.GridSegmentSize * lot.SizeZ) - (parameters.SegmentPaddingX * 2),
                                    (parameters.GridSegmentSize * lot.SizeX) - (parameters.SegmentPaddingY * 2));


                                break;

                        }

                        // Draw the zone on the bitmap
                        g.FillRectangle(new SolidBrush(c), rect);

                        // draw an outline if that option is enabled
                        if (parameters.ShowZoneOutlines)
                        {
                            g.DrawRectangle(zoneOutlinePen, rect);
                        }
                    }
                }

                // Render buildings
                if (parameters.VisibleMapObjects.Contains(MapObject.Building)
                    && save.ContainsBuildingsSubfile())
                {
                    Brush b = new SolidBrush(parameters.ColorDictionary[MapColorObject.Buildings]);
                    Pen pe = new Pen(parameters.ColorDictionary[MapColorObject.BuildingsOutline], 1);
                    double unit = parameters.GridSegmentSize /  16d;

                    foreach (var building in save.GetBuildingSubfile().Buildings)
                    {
                        Rectangle rect = new Rectangle(
                                (int)(unit * Math.Ceiling(building.MinCoordinateX)),
                                (int)(unit * Math.Ceiling(building.MinCoordinateZ)),
                                (int)(unit * Math.Ceiling(building.MaxCoordinateX - building.MinCoordinateX)),
                                (int)(unit * Math.Ceiling(building.MaxCoordinateZ - building.MinCoordinateZ)));

                        g.FillRectangle(b, rect);

                        if (parameters.ShowBuildingOutlines)
                        {
                            g.DrawRectangle(pe, rect);
                        }
                    }
                }

                // Render Network Subfile 1
                if (parameters.VisibleMapObjects.FindAll(x => x.ToString().Contains("Network1")).Count() != 0
                    && save.ContainsNetworkSubfile1())
                {
                    foreach (NetworkTile1 tile in save.GetNetworkSubfile1().NetworkTiles)
                    {
                        // Check if we have a related enum for the network tile we are dealing with
                        if (MapCreationParameters.NetworkTypeToMapObject.ContainsKey(tile.NetworkType))
                        {
                            // Skip over if object isn't in visible objects
                            if (parameters.VisibleMapObjects.Contains(MapCreationParameters.NetworkTypeToMapObject[tile.NetworkType]) == false)
                                continue;
                        }

                        Color tileColor = new Color();
                        switch (tile.NetworkType)
                        {
                            case 0x00: tileColor = parameters.ColorDictionary[MapColorObject.Road]; break; // Road
                            case 0x01: tileColor = parameters.ColorDictionary[MapColorObject.Railway]; break; // Rail
                            //case 0x02: tileColor = Color.Blue; break;
                            case 0x03: tileColor = parameters.ColorDictionary[MapColorObject.Street]; break; // Street
                            //case 0x04: tileColor = Color.OrangeRed; break;
                            //case 0x05: tileColor = Color.Orange; break;
                            case 0x06: tileColor = parameters.ColorDictionary[MapColorObject.Avenue]; break; // Avenue
                            //case 0x07: tileColor = Color.YellowGreen; break;// subway?
                            //case 0x08: tileColor = Color.Green; break;// subway?
                            //case 0x09: tileColor = Color.Blue; break;
                            case 0x0A: tileColor = parameters.ColorDictionary[MapColorObject.OneWayRoad]; break; // One way
                            // case 0x0B: tileColor = Color.Green; break;
                            // case 0x0C: tileColor = Color.PaleVioletRed; break;
                            // case 0x0D: tileColor = Color.AntiqueWhite; break;
                            // case 0x0E: tileColor = Color.AntiqueWhite; break;
                            // case 0x0F: tileColor = Color.AntiqueWhite; break;
                            //default: tileColor = Color.Violet; break;
                        }

                        // So...
                        // First some context as to why you see the below. Network subfile 1 (that is the file inside simcity 4 save games
                        // that contains a list of all network tiles at ground level) has a bunch of different positional data in it, the purpose of which
                        // is not completely known.
                        // There are 2 sets of size coordinates for the tile, the second set (the variables with 2 at the end) seem to specify the size of the network tile
                        // in 'units' (16 'units' = 1 grid segment). So, because our rendering is grid based, it is pretty easy for us to convert the units to a grid coordinates (divide by 16)
                        // and render the tile. Wooow isn't that perfect, the world makes sense, puppies should be given to everyone.
                        // Sadly this is not the way the world works. For some unknown reason, when 2 network tiles of different types intersect this second set of coordinates 
                        // is rendered essentially meaningless. For some reason it is filled with 0s. So we use the first set of size coordinates for the network file, this set of coordinates
                        // seems to be a quarter of the size of the actual network tile (your guess is as good as mine, I will share my thoughts at the end of this over long comment)
                        // So to summerize, 2 sets of size coordinates per network tile, one is the size of the whole tile, the other the size of a quarter of the tile. For some reason
                        // one set of tiles doesn't work so we have to switch to using the other. Fin.
                        // (ps I think the quarter tile size is used because the network tiles are actually rendered in quarters, that is how they are able to be used in so many situations, turns and such)
                        if (tile.MaxSizeX2 > 5 && tile.MaxSizeZ2 > 5 && tile.MaxSizeY2 > 5
                            && tile.MinSizeX2 > 5 && tile.MinSizeZ2 > 5 && tile.MinSizeY2 > 5)
                        {
                            Rectangle rect = new Rectangle(
                                parameters.GridSegmentSize * (int)(Math.Truncate(tile.MinSizeX2 / 16)),
                                parameters.GridSegmentSize * (int)(Math.Truncate(tile.MinSizeZ2 / 16)),
                                parameters.GridSegmentSize * (int)(Math.Truncate((tile.MaxSizeX2 - tile.MinSizeX2) / 16)),
                                parameters.GridSegmentSize * (int)(Math.Truncate((tile.MaxSizeZ2 - tile.MinSizeZ2) / 16))
                            );


                            g.FillRectangle(new SolidBrush(tileColor), rect);
                        }
                        else
                        {
                            Rectangle rect = new Rectangle(
                                parameters.GridSegmentSize * (int)(Math.Truncate(tile.MinSizeX1 / 16)),
                                parameters.GridSegmentSize * (int)(Math.Truncate(tile.MinSizeZ1 / 16)),
                                parameters.GridSegmentSize * (int)(Math.Truncate((tile.MaxSizeX1 - tile.MinSizeX1) / 16) + 1),
                                parameters.GridSegmentSize * (int)(Math.Truncate((tile.MaxSizeZ1 - tile.MinSizeZ1) / 16) + 1)
                            );

                            g.FillRectangle(new SolidBrush(tileColor), rect);
                        }
                    }
                }

                // Render Network Subfile 2
                if (parameters.VisibleMapObjects.FindAll(x => x.ToString().Contains("Network2")).Count() != 0
                    && save.ContainsNetworkSubfile2())
                {
                    foreach (NetworkTile2 tile in save.GetNetworkSubfile2().NetworkTiles)
                    {
                        // Check if we have a related enum for the network tile we are dealing with
                        if (MapCreationParameters.NetworkTypeToMapObject.ContainsKey(tile.NetworkType))
                        {
                            // Skip over if object isn't in visible objects
                            if (parameters.VisibleMapObjects.Contains(MapCreationParameters.NetworkTypeToMapObject[tile.NetworkType]) == false)
                                continue;
                        }

                        if (tile.MaxSizeX2 > 0 && tile.MaxSizeZ2 > 0)
                        {
                            Rectangle rect = new Rectangle(
                                parameters.GridSegmentSize * (int)(Math.Truncate(tile.MinSizeX2 / 16)),
                                parameters.GridSegmentSize * (int)(Math.Truncate(tile.MinSizeZ2 / 16)),
                                parameters.GridSegmentSize * (int)(Math.Truncate((tile.MaxSizeX2 - tile.MinSizeX2) / 16)),
                                parameters.GridSegmentSize * (int)(Math.Truncate((tile.MaxSizeZ2 - tile.MinSizeZ2) / 16))
                            );

                            g.FillRectangle(new SolidBrush(Color.Purple), rect);
                        }
                    }
                }

                // Render Bridge Network Subfile
                if (parameters.VisibleMapObjects.FindAll(x => x.ToString().Contains("Network1")).Count() != 0
                   && save.ContainsBridgeNetworkSubfile())
                {
                    // Loop through each tile in save
                    foreach (BridgeNetworkTile tile in save.GetBridgeNetworkSubfile().NetworkTiles)
                    {
                        // Check if we have a related enum for the network tile we are dealing with
                        if (MapCreationParameters.NetworkTypeToMapObject.ContainsKey(tile.NetworkType))
                        {
                            // Skip over if object isn't in visible objects
                            if (parameters.VisibleMapObjects.Contains(MapCreationParameters.NetworkTypeToMapObject[tile.NetworkType]) == false)
                                continue;
                        }

                        // Select colour
                        Color tileColor = new Color();
                        switch (tile.NetworkType)
                        {
                            case 0x00: tileColor = parameters.ColorDictionary[MapColorObject.Road]; break; // Road
                            case 0x01: tileColor = parameters.ColorDictionary[MapColorObject.Railway]; break; // Rail
                            //case 0x02: tileColor = Color.Blue; break;
                            case 0x03: tileColor = parameters.ColorDictionary[MapColorObject.Street]; break; // Street
                            //case 0x04: tileColor = Color.OrangeRed; break;
                            //case 0x05: tileColor = Color.Orange; break;
                            case 0x06: tileColor = parameters.ColorDictionary[MapColorObject.Avenue]; break; // Avenue
                            //case 0x07: tileColor = Color.YellowGreen; break;// subway?
                            //case 0x08: tileColor = Color.Green; break;// subway?
                            //case 0x09: tileColor = Color.Blue; break;
                            case 0x0A: tileColor = parameters.ColorDictionary[MapColorObject.OneWayRoad]; break; // One way
                            // case 0x0B: tileColor = Color.Green; break;
                            // case 0x0C: tileColor = Color.PaleVioletRed; break;
                            // case 0x0D: tileColor = Color.AntiqueWhite; break;
                            // case 0x0E: tileColor = Color.AntiqueWhite; break;
                            // case 0x0F: tileColor = Color.AntiqueWhite; break;
                            //default: tileColor = Color.Violet; break;
                        }

                        // Draw the tile
                        Rectangle rect = new Rectangle(
                            parameters.GridSegmentSize * (int)(Math.Truncate(tile.MinSizeX / 16)),
                            parameters.GridSegmentSize * (int)(Math.Truncate(tile.MinSizeZ / 16)),
                            parameters.GridSegmentSize * (int)(Math.Truncate((tile.MaxSizeX - tile.MinSizeX) / 16) + 1),
                            parameters.GridSegmentSize * (int)(Math.Truncate((tile.MaxSizeZ - tile.MinSizeZ) / 16) + 1)
                        );

                        g.FillRectangle(new SolidBrush(tileColor), rect);
                    }
                }

                if (save.ContainsPrebuiltNetworkSubfile())
                {
                    // Loop through each tile in save
                    //foreach (PrebuiltNetworkTile tile in save.GetPrebuiltNetworkSubfile().NetworkTiles)
                    //{
                    //    // Check if we have a related enum for the network tile we are dealing with
                    //    if (MapCreationParameters.NetworkTypeToMapObject.ContainsKey(tile.NetworkType))
                    //    {
                    //        // Skip over if object isn't in visible objects
                    //        if (parameters.VisibleMapObjects.Contains(MapCreationParameters.NetworkTypeToMapObject[tile.NetworkType]) == false)
                    //            continue;
                    //    }

                    //    // Select colour
                    //    Color tileColor = new Color();
                    //    switch (tile.NetworkType)
                    //    {
                    //        case 0x00: tileColor = parameters.ColorDictionary[MapColorObject.Road]; break; // Road
                    //        case 0x01: tileColor = parameters.ColorDictionary[MapColorObject.Railway]; break; // Rail
                    //        //case 0x02: tileColor = Color.Blue; break;
                    //        case 0x03: tileColor = parameters.ColorDictionary[MapColorObject.Street]; break; // Street
                    //        //case 0x04: tileColor = Color.OrangeRed; break;
                    //        //case 0x05: tileColor = Color.Orange; break;
                    //        case 0x06: tileColor = parameters.ColorDictionary[MapColorObject.Avenue]; break; // Avenue
                    //        //case 0x07: tileColor = Color.YellowGreen; break;// subway?
                    //        //case 0x08: tileColor = Color.Green; break;// subway?
                    //        //case 0x09: tileColor = Color.Blue; break;
                    //        case 0x0A: tileColor = parameters.ColorDictionary[MapColorObject.OneWayRoad]; break; // One way
                    //                                                                                             // case 0x0B: tileColor = Color.Green; break;
                    //                                                                                             // case 0x0C: tileColor = Color.PaleVioletRed; break;
                    //                                                                                             // case 0x0D: tileColor = Color.AntiqueWhite; break;
                    //                                                                                             // case 0x0E: tileColor = Color.AntiqueWhite; break;
                    //                                                                                             // case 0x0F: tileColor = Color.AntiqueWhite; break;
                    //                                                                                             //default: tileColor = Color.Violet; break;
                    //    }
                    //    tileColor = Color.Pink;

                    //    // Draw the tile
                    //    if (tile.MaxSizeX2 > 0 && tile.MaxSizeZ2 > 0)
                    //    {
                    //        Rectangle rect = new Rectangle(
                    //            parameters.GridSegmentSize * (int)(Math.Truncate(tile.MinSizeX2 / 16)),
                    //            parameters.GridSegmentSize * (int)(Math.Truncate(tile.MinSizeZ2 / 16)),
                    //            parameters.GridSegmentSize * (int)(Math.Truncate((tile.MaxSizeX2 - tile.MinSizeX2) / 16)),
                    //            parameters.GridSegmentSize * (int)(Math.Truncate((tile.MaxSizeZ2 - tile.MinSizeZ2) / 16))
                    //        );

                    //        g.FillRectangle(new SolidBrush(Color.Purple), rect);
                    //    }
                    //}
                }

            }

            return bmp;
        }
    }
}
