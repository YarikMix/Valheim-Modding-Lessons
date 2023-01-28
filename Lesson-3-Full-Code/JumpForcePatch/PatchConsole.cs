using HarmonyLib;

namespace JumpForcePatch
{
    class PatchConsole
    {
        [HarmonyPatch(typeof(Terminal), nameof(Terminal.IsCheatsEnabled))]
        public static class Terminal_IsCheatsEnabled_Postfix
        {
            public static void Postfix(ref bool __result)
            {
                __result = true;
            }
        }

        [HarmonyPatch(typeof(Console), nameof(Console.IsConsoleEnabled))]
        public static class Console_IsConsoleEnabled_Postfix
        {
            public static void Postfix(ref bool __result)
            {
                __result = true;
            }
        }

        [HarmonyPatch(typeof(CraftingStation), nameof(CraftingStation.Start))]
        public static class CraftingStation_Start_Postfix
        {
            public static void Postfix(CraftingStation __instance)
            {
                __instance.m_craftRequireRoof = false;
            }
        }
    }
}
