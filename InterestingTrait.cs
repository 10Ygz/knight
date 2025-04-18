using HarmonyLib;

using ChivalryWizardingWorld.code;

using NeoModLoader.api;

namespace ChivalryWizardingWorld
{
    internal class ChivalryWizardingWorldClass : BasicMod<ChivalryWizardingWorldClass>
    {
        public static string id = "shiyue.worldbox.mod.ChivalryWizardingWorld";
        protected override void OnModLoad()
        {
            stats.Init();
            traitGroup.Init();
            traits.Init();
            new Harmony(id).PatchAll(typeof(patch));
        }

    }

}
