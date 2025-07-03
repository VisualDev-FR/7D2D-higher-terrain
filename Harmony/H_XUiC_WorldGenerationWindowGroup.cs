using HarmonyLib;


[HarmonyPatch(typeof(XUiC_WorldGenerationWindowGroup), "OnOpen")]
public class XUiC_WorldGenerationWindowGroup_OnOpen
{
    public static int defaultOffset = 50;

    public static XUiC_ComboBoxInt terrainOffsetComboBox;

    public static int TerrainOffset => (int)terrainOffsetComboBox.Value;

    public static void Postfix(XUiC_WorldGenerationWindowGroup __instance)
    {
        if (__instance.GetChildById("terrainOffset") is XUiC_ComboBoxInt terrainOffsetComboBox)
        {
            terrainOffsetComboBox.Value = defaultOffset;
        }
    }
}