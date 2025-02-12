using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chivalry.code
{
    internal class traitGroup
    {
        public static void Init()
        {
            ActorTraitGroupAsset Knight = new ActorTraitGroupAsset();
            Knight.id = "Knight";
            Knight.name = "trait_group_Knight";
            Knight.color = Toolbox.makeColor("#FFFF00", -1f);
            AssetManager.trait_groups.add(Knight);

            ActorTraitGroupAsset SeedsofLife = new ActorTraitGroupAsset();
            SeedsofLife.id = "SeedsofLife";
            SeedsofLife.name = "trait_group_SeedsofLife";
            SeedsofLife.color = Toolbox.makeColor("#00FF00", -1f);
            AssetManager.trait_groups.add(SeedsofLife);
        }
    }
}
