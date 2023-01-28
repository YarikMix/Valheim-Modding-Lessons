using BepInEx;
using HarmonyLib;
using Jotunn.Managers;
using UnityEngine;
using Jotunn.Entities;
using Jotunn.Configs;

namespace JumpForcePatch
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    public class Main : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.jotunnmodstub";
        public const string PluginName = "JotunnModStub";
        public const string PluginVersion = "1.0.0";

        public static Harmony harmony = new Harmony(PluginGUID);

        public void Awake()
        {
            SetupConsoleCommands();
            PrefabManager.OnVanillaPrefabsAvailable += SetupStatusEffects;
            PrefabManager.OnVanillaPrefabsAvailable += CloneSword;
            harmony?.PatchAll();
        }

        public void OnDestroy()
        {
            harmony?.UnpatchSelf();
        }

        public void CloneSword()
        {
            GameObject gameObject = PrefabManager.Instance.CreateClonedPrefab("TestSword", "SwordBronze");

            CustomItem customItem = new CustomItem(gameObject, false, new ItemConfig() { 
                Name = "Kek",
                Description = "Lol",
                CraftingStation = "piece_workbench",
                RepairStation = "piece_workbench",
                Amount = 1,
                MinStationLevel = 1,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 1
                    },
                    new RequirementConfig()
                    {
                        Item = "Stone",
                        Amount = 1,
                        AmountPerLevel = 1
                    }
                }
            });
            customItem.ItemDrop.m_itemData.m_shared.m_name = "Kek";
            customItem.ItemDrop.m_itemData.m_shared.m_description = "Lol";
            customItem.ItemDrop.m_itemData.m_shared.m_damages.m_fire = 999;
            customItem.ItemDrop.m_itemData.m_shared.m_equipStatusEffect = ScriptableObject.CreateInstance<SE_TestStatusEffect>();

            ItemManager.Instance.AddItem(customItem);


            PrefabManager.OnVanillaPrefabsAvailable -= CloneSword;
        }

        public void SetupStatusEffects()
        {
            ItemManager.Instance.AddStatusEffect(new CustomStatusEffect(ScriptableObject.CreateInstance<SE_TestStatusEffect>(), true));

            PrefabManager.OnVanillaPrefabsAvailable -= SetupStatusEffects;
        }

        public void SetupConsoleCommands()
        {
            CommandManager.Instance.AddConsoleCommand(new TestCommand());
        }
    }
}