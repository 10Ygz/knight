using HarmonyLib;

using Chivalry.code;

using NeoModLoader.api;

namespace Chivalry
{
    internal class ChivalryClass : BasicMod<ChivalryClass>
    {
        public static string id = "shiyue.worldbox.mod.Chivalry";
        protected override void OnModLoad()
        {
            stats.Init();
            traitGroup.Init();
            traits.Init();
            new Harmony(id).PatchAll(typeof(patch));
        }

    }

}
