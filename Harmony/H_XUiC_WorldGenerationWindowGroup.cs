using HarmonyLib;


[HarmonyPatch(typeof(XUiC_WorldGenerationWindowGroup), "OnOpen")]
public class H_XUiC_WorldGenerationWindowGroup_OnOpen
{
    public static int defaultOffset = 50;

    public static XUiC_ComboBoxInt terrainOffsetComboBox;

    public static int TerrainOffset => (int)terrainOffsetComboBox.Value;

    public static void Postfix(XUiC_WorldGenerationWindowGroup __instance)
    {
        if (ModManager.ModLoaded("TheDescent"))
        {
            Log.Out("[HigherTerrain] TheDescent is loaded, aborting 'XUiC_WorldGenerationWindowGroup_OnOpen'");
            return;
        }

        terrainOffsetComboBox = __instance.GetChildById("terrainOffset") as XUiC_ComboBoxInt;

        if (terrainOffsetComboBox != null)
        {
            terrainOffsetComboBox.Value = defaultOffset;
        }
    }
}