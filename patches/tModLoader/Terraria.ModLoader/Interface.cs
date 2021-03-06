using System;
using Terraria;
using Terraria.ModLoader.UI;

namespace Terraria.ModLoader
{
	internal static class Interface
	{
		internal const int modsMenuID = 10000;
		internal const int modSourcesID = 10001;
		//set initial Main.menuMode to loadModsID
		internal const int loadModsID = 10002;
		internal const int buildModID = 10003;
		internal const int buildAllModsID = 10004;
		internal const int errorMessageID = 10005;
		internal const int reloadModsID = 10006;
		private static UIMods modsMenu = new UIMods();
		internal static UILoadMods loadMods = new UILoadMods();
		private static UIModSources modSources = new UIModSources();
		internal static UIBuildMod buildMod = new UIBuildMod();
		internal static UIErrorMessage errorMessage = new UIErrorMessage();
		//add to Terraria.Main.DrawMenu in Main.menuMode == 0 after achievements
		//Interface.AddMenuButtons(this, this.selectedMenu, array9, array7, ref num, ref num3, ref num9, ref num4);
		internal static void AddMenuButtons(Main main, int selectedMenu, string[] buttonNames, float[] buttonScales, ref int offY, ref int spacing, ref int buttonIndex, ref int numButtons)
		{
			buttonNames[buttonIndex] = "Mods";
			if (selectedMenu == buttonIndex)
			{
				Main.PlaySound(10, -1, -1, 1);
				Main.menuMode = modsMenuID;
			}
			buttonIndex++;
			numButtons++;
			buttonNames[buttonIndex] = "Mod Sources";
			if (selectedMenu == buttonIndex)
			{
				Main.PlaySound(10, -1, -1, 1);
				Main.menuMode = modSourcesID;
			}
			buttonIndex++;
			numButtons++;
			offY = 220;
			for (int k = 0; k < numButtons; k++)
			{
				buttonScales[k] = 0.82f;
			}
			spacing = 45;
		}
		//add to end of if else chain of Main.menuMode in Terraria.Main.DrawMenu
		//Interface.ModLoaderMenus(this, this.selectedMenu, array9, array7, ref num, ref num3, ref num4);
		internal static void ModLoaderMenus(Main main, int selectedMenu, string[] buttonNames, float[] buttonScales, ref int offY, ref int spacing, ref int numButtons)
		{
			if (Main.menuMode == modsMenuID)
			{
				Main.MenuUI.SetState(modsMenu);
				Main.menuMode = 888;
			}
			else if (Main.menuMode == modSourcesID)
			{
				Main.MenuUI.SetState(modSources);
				Main.menuMode = 888;
			}
			else if (Main.menuMode == loadModsID)
			{
				Main.MenuUI.SetState(loadMods);
				Main.menuMode = 888;
				ModLoader.Load();
			}
			else if (Main.menuMode == buildModID)
			{
				Main.MenuUI.SetState(buildMod);
				Main.menuMode = 888;
				ModLoader.BuildMod();
			}
			else if (Main.menuMode == buildAllModsID)
			{
				Main.MenuUI.SetState(buildMod);
				Main.menuMode = 888;
				ModLoader.BuildAllMods();
			}
			else if (Main.menuMode == errorMessageID)
			{
				Main.MenuUI.SetState(errorMessage);
				Main.menuMode = 888;
			}
			else if (Main.menuMode == reloadModsID)
			{
				ModLoader.Reload();
			}
		}
	}
}
