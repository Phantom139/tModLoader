using System;
using Terraria.ID;
using Terraria.Map;
using Terraria.ModLoader;

namespace Terraria.ModLoader
{
	public class MapLegend
	{
		//change type of Lang.mapLegend to this class
		private string[] legend;

		public MapLegend(int size)
		{
			legend = new string[size];
		}

		public int Length
		{
			get
			{
				return legend.Length;
			}
		}

		public string this[int i]
		{
			get
			{
				return legend[i];
			}
			set
			{
				legend[i] = value;
			}
		}
		//in Terraria.Main.DrawInventory replace
		//  Lang.mapLegend[MapHelper.TileToLookup(Main.recipe[Main.availableRecipe[num60]].requiredTile[num62], 0)]
		//  with Lang.mapLegend.FromType(Main.recipe[Main.availableRecipe[num60]].requiredTile[num62])
		//in Terraria.Main.DrawInfoAccs replace Lang.mapLegend[MapHelper.TileToLookup(Main.player[Main.myPlayer].bestOre, 0)]
		//  with Lang.mapLegend.FromType(Main.player[Main.myPlayer].bestOre)
		public string FromType(int type)
		{
			if (type >= TileID.Count)
			{
				return TileLoader.GetTile(type).MapName(0, 0);
			}
			return this[MapHelper.TileToLookup(type, 0)];
		}
		//in Terraria.Main.DrawMap replace text = Lang.mapLegend[type]; with
		//  text = Lang.mapLegend[Main.Map[num91, num92]];
		public string this[MapTile mapTile]
		{
			get
			{
				Tile tile = Main.tile[mapTile.x, mapTile.y];
				if (tile.active())
				{
					if (tile.type >= TileID.Count)
					{
						return TileLoader.GetTile(tile.type).MapName(tile.frameX, tile.frameY);
					}
				}
				else if (tile.wall >= WallID.Count)
				{
					return WallLoader.GetWall(tile.wall).mapName;
				}
				return legend[mapTile.Type];
			}
		}
	}
}
