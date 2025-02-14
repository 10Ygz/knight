using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ReflectionUtility;
using ai;
using System.Numerics;

namespace Chivalry.code
{
    internal class traits
    {
        public static void Init()
        {                          //特质id↓ //贴图路径↓    //诞生率↓    //排斥的特质↓
            talent_AddActorTrait("talent1", "trait/talent1", 9f, "talent2,talent3,talent4,talent5,flair1,flair2,flair3,flair4,flair5");//骑士天赋•下
            talent_AddActorTrait("talent2", "trait/talent2", 5f, "talent1,talent3,talent4,talent5,flair1,flair2,flair3,flair4,flair5");//骑士天赋•中
            talent_AddActorTrait("talent3", "trait/talent3", 1f, "talent1,talent2,talent4,talent5,flair1,flair2,flair3,flair4,flair5");//骑士天赋•上
            talent_AddActorTrait("talent4", "trait/talent4", 0.001f, "talent1,talent2,talent3,talent5,flair1,flair2,flair3,flair4,flair5");//骑士天赋•传说

            ActorTrait talent5 = new ActorTrait();
            talent5.id = "talent5";
            talent5.path_icon = "trait/talent5";
            talent5.needs_to_be_explored = false;
            talent5.group_id = "SeedsofLife";
            talent5.inherit = 100f;
            AssetManager.traits.add(talent5);

            ActorTrait talent6 = new ActorTrait();
            talent6.id = "talent6";
            talent6.path_icon = "trait/talent6";
            talent6.needs_to_be_explored = false;
            talent6.group_id = "SeedsofLife";
            AssetManager.traits.add(talent6);

            ActorTrait talent7 = new ActorTrait();
            talent7.id = "talent7";
            talent7.path_icon = "trait/talent7";
            talent7.needs_to_be_explored = false;
            talent7.group_id = "SeedsofLife";
            talent7.base_stats[S.max_age] = 10f;
            talent7.action_death = traitAction.talent7_death;
            AssetManager.traits.add(talent7);

            ActorTrait Knight1 = new ActorTrait();
            Knight1.id = "Knight1";//侍从
            Knight1.path_icon = "trait/Knight1";
            Knight1.needs_to_be_explored = false;
            Knight1.group_id = "Knight";
            Knight1.base_stats[S.warfare] = 1f;
            Knight1.base_stats[S.damage] = 20f;
            Knight1.base_stats[S.health] = 300f;
            Knight1.base_stats[S.knockback_reduction] = 0.5f;
            Knight1.action_special_effect += traitAction.Knight2_effectAction;
            AssetManager.traits.add(Knight1);

            ActorTrait knight02 = new ActorTrait();
            knight02.id = "Knight2+";//预备骑士
            knight02.path_icon = "trait/Knight2+";
            knight02.needs_to_be_explored = false;
            knight02.group_id = "Knight";
            knight02.base_stats[S.max_age] = 20f;
            AssetManager.traits.add(knight02);

            ActorTrait Knight03 = new ActorTrait();
            Knight03.id = "Knight3+";//初级骑士
            Knight03.path_icon = "trait/Knight3+";
            Knight03.needs_to_be_explored = false;
            Knight03.group_id = "Knight";
            Knight03.base_stats[S.max_age] = 50f;
            AssetManager.traits.add(Knight03);

            ActorTrait Knight04 = new ActorTrait();
            Knight04.id = "Knight4+";//高级骑士
            Knight04.path_icon = "trait/Knight4+";
            Knight04.needs_to_be_explored = false;
            Knight04.group_id = "Knight";
            Knight04.base_stats[S.max_age] = 90f;
            AssetManager.traits.add(Knight04);

            ActorTrait Knight05 = new ActorTrait();
            Knight05.id = "Knight5+";//大骑士
            Knight05.path_icon = "trait/Knight5+";
            Knight05.needs_to_be_explored = false;
            Knight05.group_id = "Knight";
            Knight05.base_stats[S.max_age] = 160f;
            AssetManager.traits.add(Knight05);

            ActorTrait Knight06 = new ActorTrait();
            Knight06.id = "Knight6+";//大骑士
            Knight06.path_icon = "trait/Knight6+";
            Knight06.needs_to_be_explored = false;
            Knight06.group_id = "Knight";
            Knight06.base_stats[S.max_age] = 240f;
            AssetManager.traits.add(Knight06);

            ActorTrait Knight2 = new ActorTrait();
            Knight2.id = "Knight2";//预备骑士
            Knight2.path_icon = "trait/Knight2";
            Knight2.needs_to_be_explored = false;
            Knight2.group_id = "Knight";
            Knight2.base_stats[S.warfare] = 5f;
            Knight2.base_stats[S.damage] = 100f;
            Knight2.base_stats[S.health] = 1000f;
            Knight2.base_stats[S.armor] = 10f;
            Knight2.base_stats[S.speed] = 5f;
            Knight2.base_stats[S.range] = 1f;
            Knight2.base_stats[S.area_of_effect] = 1f;
            Knight2.base_stats[S.targets] = 2f;
            Knight2.base_stats[S.knockback_reduction] = 0.8f;
            Knight2.action_special_effect += traitAction.Knight3_effectAction;
            Knight2.action_special_effect += (WorldAction)Delegate.Combine(Knight2.action_special_effect,new WorldAction(traitAction.Knight2_Regen));
            AssetManager.traits.add(Knight2);

            ActorTrait Knight3 = new ActorTrait();
            Knight3.id = "Knight3";//初级骑士
            Knight3.path_icon = "trait/Knight3";
            Knight3.needs_to_be_explored = false;
            Knight3.group_id = "Knight";
            Knight3.base_stats[S.warfare] = 10f;
            Knight3.base_stats[S.damage] = 220f;
            Knight3.base_stats[S.health] = 5000f;
            Knight3.base_stats[S.armor] = 20f;
            Knight3.base_stats[S.speed] = 10f;
            Knight3.base_stats[S.range] = 3f;
            Knight3.base_stats[S.area_of_effect] = 4f;
            Knight3.base_stats[S.targets] = 2f;
            Knight3.base_stats[S.knockback_reduction] = 1f;
            Knight3.action_special_effect += traitAction.Knight4_effectAction;
            Knight3.action_special_effect += (WorldAction)Delegate.Combine(Knight3.action_special_effect,new WorldAction(traitAction.Knight3_Regen));
            AssetManager.traits.add(Knight3);

            ActorTrait Knight4 = new ActorTrait();
            Knight4.id = "Knight4";//高级骑士
            Knight4.path_icon = "trait/Knight4";
            Knight4.needs_to_be_explored = false;
            Knight4.group_id = "Knight";
            Knight4.base_stats[S.warfare] = 30f;
            Knight4.base_stats[S.damage] = 1000f;
            Knight4.base_stats[S.health] = 15000f;
            Knight4.base_stats[S.armor] = 30f;
            Knight4.base_stats[S.speed] = 20f;
            Knight4.base_stats[S.range] = 3f;
            Knight4.base_stats[S.area_of_effect] = 6f;
            Knight4.base_stats[S.targets] = 3f;
            Knight4.base_stats[S.knockback_reduction] = 1f;
            Knight4.action_special_effect += traitAction.Knight5_effectAction;
            Knight4.action_special_effect += (WorldAction)Delegate.Combine(Knight4.action_special_effect,new WorldAction(traitAction.Knight4_Regen));
            AssetManager.traits.add(Knight4);

            ActorTrait Knight5 = new ActorTrait();
            Knight5.id = "Knight5";//大骑士
            Knight5.path_icon = "trait/Knight5";
            Knight5.needs_to_be_explored = false;
            Knight5.group_id = "Knight";
            Knight5.base_stats[S.warfare] = 60f;
            Knight5.base_stats[S.damage] = 2000f;
            Knight5.base_stats[S.armor] = 50f;
            Knight5.base_stats[S.health] = 30000f;
            Knight5.base_stats[S.speed] = 25f;
            Knight5.base_stats[S.mod_health] = 0.50f;
            Knight5.base_stats[S.range] = 5f;
            Knight5.base_stats[S.area_of_effect] = 10f;
            Knight5.base_stats[S.targets] = 5f;
            Knight5.base_stats[S.knockback_reduction] = 1f;
            Knight5.action_attack_target += traitAction.warfare_attack_Knight5;
            Knight5.action_special_effect += traitAction.Knight6_effectAction;
            Knight5.action_special_effect += (WorldAction)Delegate.Combine(Knight5.action_special_effect,new WorldAction(traitAction.Knight5_Regen));
            AssetManager.traits.add(Knight5);

            ActorTrait Knight6 = new ActorTrait();
            Knight6.id = "Knight6";//传说大骑士
            Knight6.path_icon = "trait/Knight6";
            Knight6.needs_to_be_explored = false;
            Knight6.group_id = "Knight";
            Knight6.base_stats[S.warfare] = 100f;
            Knight6.base_stats[S.damage] = 10000f;
            Knight6.base_stats[S.armor] = 80f;
            Knight6.base_stats[S.speed] = 35f;
            Knight6.base_stats[S.health] = 120000f;
            Knight6.base_stats[S.mod_health] = 1f;
            Knight6.base_stats[S.range] = 6f;
            Knight6.base_stats[S.area_of_effect] = 10f;
            Knight6.base_stats[S.targets] = 6f;
            Knight6.base_stats[S.knockback_reduction] = 1f;
            Knight6.action_attack_target += traitAction.warfare_attack_Knight6;
            Knight6.action_special_effect += (WorldAction)Delegate.Combine(Knight6.action_special_effect,new WorldAction(traitAction.Knight6_Regen));
            AssetManager.traits.add(Knight6);
        }
        public static void talent_AddActorTrait(string id, string pathIcon, float birth, string opposite_stats_value)
        {
            ActorTrait talent = new ActorTrait();
            talent.id = id;
            talent.path_icon = pathIcon;
            talent.needs_to_be_explored = false;
            talent.birth = birth;
            talent.group_id = "SeedsofLife";
            talent.opposite = opposite_stats_value;
            talent.action_special_effect += traitAction.Knight1_effectAction;
            AssetManager.traits.add(talent);
        }
    }
}