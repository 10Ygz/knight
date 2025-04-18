using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ReflectionUtility;
using ai;
using System.Numerics;

namespace ChivalryWizardingWorld.code
{
    internal class traits
    {
        private static ActorTrait CreateTrait(string id, string path_icon, string group_id)
        {
            ActorTrait trait = new ActorTrait();
            trait.id = id;
            trait.path_icon = path_icon;
            trait.needs_to_be_explored = false;
            trait.group_id = group_id;
            trait.base_stats = new BaseStats();
            
            return trait;
        }
        public static ActorTrait talent_AddActorTrait(string id, string pathIcon)
        {
            ActorTrait talent = new ActorTrait
            {
                id = id,
                path_icon = pathIcon,
                group_id = "SeedsofLife",
                needs_to_be_explored = false
            };
            talent.action_special_effect += traitAction.Knight1_effectAction;
            AssetManager.traits.add(talent);
            return talent;
        }
        public static void Init()
        {
            _=talent_AddActorTrait("talent1", "trait/talent1");//骑士天赋•下
            _=talent_AddActorTrait("talent2", "trait/talent2");//骑士天赋•中
            _=talent_AddActorTrait("talent3", "trait/talent3");//骑士天赋•上
            _=talent_AddActorTrait("talent4", "trait/talent4");//骑士天赋•极

            ActorTrait talent5 = CreateTrait("talent5", "trait/talent5", "SeedsofLife");
            talent5.rate_inherit = 100;
            AssetManager.traits.add(talent5);
            
            ActorTrait talent6 = CreateTrait("talent6", "trait/talent6", "SeedsofLife");
            AssetManager.traits.add(talent6);

            ActorTrait knight02 = CreateTrait("Knight22", "trait/Knight2+", "Knight");
            SafeSetStat(knight02.base_stats, S.lifespan, 10f);
            AssetManager.traits.add(knight02);

            ActorTrait knight03 = CreateTrait("Knight3+", "trait/knight3+", "Knight");
            SafeSetStat(knight03.base_stats , S.lifespan, 20f);
            AssetManager.traits.add(knight03);
            
            ActorTrait Knight04 = CreateTrait("Knight4+", "trait/Knight4+", "Knight");
            SafeSetStat(Knight04.base_stats , S.lifespan, 25f);
            AssetManager.traits.add(Knight04);

            ActorTrait Knight05 = CreateTrait("Knight5+", "trait/Knight5+", "Knight");
            SafeSetStat(Knight05.base_stats , S.lifespan, 30f);
            AssetManager.traits.add(Knight05);

            ActorTrait Knight06 = CreateTrait("Knight6+", "trait/Knight6+", "Knight");
            SafeSetStat(Knight06.base_stats , S.lifespan, 60f);
            AssetManager.traits.add(Knight06);

            ActorTrait Knight1 = CreateTrait("Knight1", "trait/Knight1", "Knight");
            SafeSetStat(Knight1.base_stats , S.damage, 30f);
            SafeSetStat(Knight1.base_stats , S.health, 200f);
            //SafeSetStat(Knight1.base_stats , S.knockback_reduction, 0.5f);
            Knight1.action_special_effect += traitAction.Knight2_effectAction;
            Knight1.action_special_effect += traitAction.Knight_Regen1;
            AssetManager.traits.add(Knight1);

            ActorTrait Knight2 = CreateTrait("Knight2", "trait/Knight2", "Knight");
            SafeSetStat(Knight2.base_stats , S.damage, 50f);
            SafeSetStat(Knight2.base_stats , S.health, 300f);
            SafeSetStat(Knight2.base_stats , S.accuracy, 2f);
            SafeSetStat(Knight2.base_stats , S.multiplier_speed, 0.1f);
            SafeSetStat(Knight2.base_stats , S.skill_combat, 0.1f);
            //SafeSetStat(Knight2.base_stats , S.knockback_reduction, 0.6f);
            Knight2.action_special_effect += traitAction.Knight3_effectAction;
            Knight2.action_special_effect += traitAction.Knight_Regen1;
            AssetManager.traits.add(Knight2);

            ActorTrait Knight3 = CreateTrait("Knight3", "trait/Knight3", "Knight");
            SafeSetStat(Knight3.base_stats , S.damage, 60f);
            SafeSetStat(Knight3.base_stats , S.health, 400f);
            SafeSetStat(Knight3.base_stats , S.armor, 5f);
            SafeSetStat(Knight3.base_stats , S.targets, 0.1f);
            SafeSetStat(Knight3.base_stats , S.accuracy, 5f);
            SafeSetStat(Knight3.base_stats , S.multiplier_speed, 0.2f);
            SafeSetStat(Knight3.base_stats , S.skill_combat, 0.2f);
            //SafeSetStat(Knight3.base_stats , S.knockback_reduction, 0.7f);
            Knight3.action_special_effect += traitAction.Knight4_effectAction;
            Knight3.action_special_effect += traitAction.Knight_Regen1;
            AssetManager.traits.add(Knight3);

            ActorTrait Knight4 = CreateTrait("Knight4", "trait/Knight4", "Knight");
            SafeSetStat(Knight4.base_stats , S.damage, 70f);
            SafeSetStat(Knight4.base_stats , S.health, 500f);
            SafeSetStat(Knight4.base_stats , S.armor, 10f);
            SafeSetStat(Knight4.base_stats , S.targets, 1f);
            SafeSetStat(Knight4.base_stats , S.critical_chance, 0.2f);
            SafeSetStat(Knight4.base_stats , S.accuracy, 10f);
            SafeSetStat(Knight4.base_stats , S.multiplier_speed, 0.3f);
            SafeSetStat(Knight4.base_stats , S.skill_combat, 0.3f);
            //SafeSetStat(Knight4.base_stats , S.knockback_reduction, 0.8f);
            Knight4.action_special_effect += traitAction.Knight5_effectAction;
            Knight4.action_special_effect += traitAction.Knight_Regen2;
            AssetManager.traits.add(Knight4);

            ActorTrait Knight5 = CreateTrait("Knight5", "trait/Knight5", "Knight");
            SafeSetStat(Knight5.base_stats , S.warfare, 10f);
            SafeSetStat(Knight5.base_stats , S.damage, 100f);
            SafeSetStat(Knight5.base_stats , S.health, 800f);
            SafeSetStat(Knight5.base_stats , S.armor, 15f);
            SafeSetStat(Knight5.base_stats , S.targets, 2f);
            SafeSetStat(Knight5.base_stats , S.critical_chance, 0.3f);
            SafeSetStat(Knight5.base_stats , S.accuracy, 20f);
            SafeSetStat(Knight5.base_stats , S.multiplier_speed, 0.5f);
            SafeSetStat(Knight5.base_stats , S.skill_combat, 0.4f);
            //SafeSetStat(Knight5.base_stats , S.knockback_reduction, 1f);
            Knight5.action_special_effect += traitAction.Knight6_effectAction;
            Knight5.action_special_effect += traitAction.Knight_Regen2;
            AssetManager.traits.add(Knight5);

            ActorTrait Knight6 = CreateTrait("Knight6", "trait/Knight6", "Knight");
            SafeSetStat(Knight6.base_stats , S.warfare, 20f);
            SafeSetStat(Knight6.base_stats , S.damage, 180f);
            SafeSetStat(Knight6.base_stats , S.armor, 25f);
            SafeSetStat(Knight6.base_stats , S.health, 1500f);
            SafeSetStat(Knight6.base_stats , S.area_of_effect, 1f);
            SafeSetStat(Knight6.base_stats , S.targets, 5f);
            SafeSetStat(Knight6.base_stats , S.critical_chance, 0.5f);
            SafeSetStat(Knight6.base_stats , S.accuracy, 30f);
            SafeSetStat(Knight6.base_stats , S.multiplier_speed, 0.7f);
            SafeSetStat(Knight6.base_stats , S.skill_combat, 0.5f);
            //SafeSetStat(Knight6.base_stats , S.knockback_reduction, 1f);
            Knight6.action_special_effect += traitAction.Knight7_effectAction;
            Knight6.action_special_effect += traitAction.Knight_Regen3;
            AssetManager.traits.add(Knight6);
        }

        private static void SafeSetStat(BaseStats baseStats, string statKey, float value)
        {
            baseStats[statKey]= value;
        }
    }
}