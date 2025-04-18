using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChivalryWizardingWorld.code
{
    internal class traitGroup
    {
        public static void Init()
        {
            ActorTraitGroupAsset Knight = new ActorTraitGroupAsset();
            Knight.id = "Knight";
            Knight.name = "trait_group_Knight";
            Knight.color = "#FFFF00";
            AssetManager.trait_groups.add(Knight);

            ActorTraitGroupAsset SeedsofLife = new ActorTraitGroupAsset();
            SeedsofLife.id = "SeedsofLife";
            SeedsofLife.name = "trait_group_SeedsofLife";
            SeedsofLife.color = "#00FF00";
            AssetManager.trait_groups.add(SeedsofLife);
        }
    }
}
