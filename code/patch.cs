using System;
using System.Collections.Generic;
using HarmonyLib;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using UnityEngine;
using UnityEngine.UI;
using VideoCopilot.code.utils;


namespace InterestingTrait.code
{
    internal class patch
    {
        public static bool displayAreaInitialization = false;
        [Hotfixable]
        [HarmonyPostfix, HarmonyPatch(typeof(WindowCreatureInfo), "OnEnable")]
        public static void OnEnable_KnightPostfix(WindowCreatureInfo __instance)
        {
            if (!displayAreaInitialization)
            {
                displayAreaInitialization = true;
                var obj = new GameObject("KnightShow", typeof(Text), typeof(ContentSizeFitter));
                obj.transform.SetParent(__instance.transform.Find("Background"));
                obj.transform.localScale = Vector3.one;
                RectTransform rect = obj.GetComponent<RectTransform>();

                rect.pivot = new Vector2(0f, 1f);
                rect.anchorMin = new Vector2(0.5f, 1f);
                rect.anchorMax = new Vector2(0.5f, 1f);
                rect.localPosition = new Vector3(-50, 170, 0);
                rect.sizeDelta = new Vector2(800, 200);
                
            }
            Transform ActorShowYuanNneg = __instance.transform.Find("Background/KnightShow");
            Text ActorShowYuanNnegText = ActorShowYuanNneg.GetComponent<Text>();
            ActorShowYuanNnegText.text = LM.Get("Knight")+":\t"+__instance.actor.GetKnight();
            ActorShowYuanNnegText.font = LocalizedTextManager.currentFont;
            ActorShowYuanNnegText.alignment = TextAnchor.UpperLeft;
            ActorShowYuanNnegText.raycastTarget = false;
        }

        static float currentKnight = 0;

        [HarmonyPrefix, HarmonyPatch(typeof(ActorBase), "updateStats")]
        public static bool updateStats(ActorBase __instance)
        {
            if (!__instance.statsDirty)
            {
                return false;
            }

            __instance.statsDirty = false;
            __instance.batch.c_stats_dirty.Remove(__instance.a);
            if (!__instance.isAlive())
            {
                return false;
            }

            __instance.checkColorSets();
            if (string.IsNullOrEmpty(__instance.data.mood))
            {
                __instance.data.mood = "normal";
            }

            MoodAsset moodAsset = AssetManager.moods.get(__instance.data.mood);
            __instance.stats.clear();
            __instance.stats.mergeStats(__instance.asset.base_stats);
            __instance.stats.mergeStats(moodAsset.base_stats);
            __instance.stats["Knight"] = currentKnight;
            BaseStats stats = __instance.stats;
            string pKey = S.diplomacy;
            stats[pKey] += (float)__instance.data.diplomacy;
            stats = __instance.stats;
            pKey = S.stewardship;
            stats[pKey] += (float)__instance.data.stewardship;
            stats = __instance.stats;
            pKey = S.intelligence;
            stats[pKey] += (float)__instance.data.intelligence;
            stats = __instance.stats;
            pKey = S.warfare;
            stats[pKey] += (float)__instance.data.warfare;
            if (__instance.hasAnyStatusEffect())
            {
                foreach (StatusEffectData statusEffectData in __instance.activeStatus_dict.Values)
                {
                    __instance.stats.mergeStats(statusEffectData.asset.base_stats);
                }
            }

            if (!__instance.hasWeapon())
            {
                ItemAsset itemAsset = AssetManager.items.get(__instance.asset.defaultAttack);
                if (itemAsset != null)
                {
                    __instance.stats.mergeStats(itemAsset.base_stats);
                }
            }

            __instance.s_attackType = __instance.getWeaponAsset().attackType;
            __instance.s_slashType = __instance.getWeaponAsset().path_slash_animation;
            __instance.dirty_sprite_item = true;
            for (int i = 0; i < __instance.data.traits.Count; i++)
            {
                string pID = __instance.data.traits[i];
                ActorTrait actorTrait = AssetManager.traits.get(pID);
                if (actorTrait != null && (!actorTrait.only_active_on_era_flag ||
                                           ((!actorTrait.era_active_moon || World.world_era.flag_moon) &&
                                            (!actorTrait.era_active_night || World.world_era.overlay_darkness))))
                {
                    __instance.stats.mergeStats(actorTrait.base_stats);
                }
            }

            if (__instance.asset.unit)
            {
                __instance.s_personality = null;
                if ((__instance.kingdom != null && __instance.kingdom.isCiv() && __instance.isKing()) ||
                    (__instance.city != null && __instance.city.leader == __instance))
                {
                    string pID2 = "balanced";
                    float num = __instance.stats[S.diplomacy];
                    if (__instance.stats[S.diplomacy] > __instance.stats[S.stewardship])
                    {
                        pID2 = "diplomat";
                        num = __instance.stats[S.diplomacy];
                    }
                    else if (__instance.stats[S.diplomacy] < __instance.stats[S.stewardship])
                    {
                        pID2 = "administrator";
                        num = __instance.stats[S.stewardship];
                    }

                    if (__instance.stats[S.warfare] > num)
                    {
                        pID2 = "militarist";
                    }

                    __instance.s_personality = AssetManager.personalities.get(pID2);
                    __instance.stats.mergeStats(__instance.s_personality.base_stats);
                }
            }

            Clan clan = __instance.getClan();
            if (clan != null && clan.bonus_stats != null)
            {
                __instance.stats.mergeStats(clan.bonus_stats.base_stats);
            }

            stats = __instance.stats;
            pKey = S.health;
            stats[pKey] += (float)((__instance.data.level - 1) * 20);
            stats = __instance.stats;
            pKey = S.damage;
            stats[pKey] += (float)((__instance.data.level - 1) / 2);
            stats = __instance.stats;
            pKey = S.armor;
            stats[pKey] += (float)((__instance.data.level - 1) / 3);
            stats = __instance.stats;
            pKey = S.attack_speed;
            stats[pKey] += (float)(__instance.data.level - 1);
            bool flag = __instance.hasTrait("madness");
            __instance.data.s_traits_ids.Clear();
            __instance.s_action_attack_target = null;
            List<ItemAsset> list = __instance.s_special_effect_items;
            if (list != null)
            {
                list.Clear();
            }

            Dictionary<ItemAsset, double> dictionary = __instance.s_special_effect_items_timers;
            if (dictionary != null)
            {
                dictionary.Clear();
            }

            List<ActorTrait> list2 = __instance.s_special_effect_traits;
            if (list2 != null)
            {
                list2.Clear();
            }

            Dictionary<ActorTrait, double> dictionary2 = __instance.s_special_effect_traits_timers;
            if (dictionary2 != null)
            {
                dictionary2.Clear();
            }

            foreach (string text in __instance.data.traits)
            {
                ActorTrait actorTrait2 = AssetManager.traits.get(text);
                if (actorTrait2 != null)
                {
                    __instance.data.s_traits_ids.Add(text);
                    if (actorTrait2.action_special_effect != null)
                    {
                        if (__instance.s_special_effect_traits == null)
                        {
                            __instance.s_special_effect_traits = new List<ActorTrait>();
                            __instance.s_special_effect_traits_timers = new Dictionary<ActorTrait, double>();
                        }

                        __instance.s_special_effect_traits.Add(actorTrait2);
                    }

                    if (actorTrait2.action_attack_target != null)
                    {
                        __instance.s_action_attack_target =
                            (AttackAction)Delegate.Combine(__instance.s_action_attack_target,
                                actorTrait2.action_attack_target);
                    }
                }
            }

            __instance.has_trait_light = __instance.hasTrait("light_lamp");
            __instance.has_trait_weightless = __instance.hasTrait("weightless");
            __instance.has_status_frozen = __instance.hasStatus("frozen");
            if (!__instance.hasWeapon())
            {
                ItemAsset weaponAsset = __instance.getWeaponAsset();
                __instance.addItemActions(weaponAsset);
                if (weaponAsset.item_modifiers != null)
                {
                    foreach (string pID3 in weaponAsset.item_modifiers)
                    {
                        ItemAsset itemAsset2 = AssetManager.items_modifiers.get(pID3);
                        if (itemAsset2 != null)
                        {
                            __instance.addItemActions(itemAsset2);
                        }
                    }
                }
            }

            if (__instance.asset.use_items)
            {
                List<ActorEquipmentSlot> list3 = ActorEquipment.getList(__instance.equipment);
                for (int j = 0; j < list3.Count; j++)
                {
                    ActorEquipmentSlot actorEquipmentSlot = list3[j];
                    if (actorEquipmentSlot.data != null)
                    {
                        ItemData itemData = actorEquipmentSlot.data;
                        ItemAsset pItemAsset = AssetManager.items.get(itemData.id);
                        __instance.addItemActions(pItemAsset);
                        foreach (string pID4 in itemData.modifiers)
                        {
                            ItemAsset pItemAsset2 = AssetManager.items_modifiers.get(pID4);
                            __instance.addItemActions(pItemAsset2);
                        }
                    }
                }
            }

            bool flag2 = __instance.hasTrait("madness");
            if (__instance.s_special_effect_traits == null || __instance.s_special_effect_traits.Count == 0)
            {
                __instance.s_special_effect_traits = null;
                __instance.s_special_effect_traits_timers = null;
                __instance.batch.c_trait_effects.Remove(__instance.a);
            }
            else
            {
                __instance.batch.c_trait_effects.Add(__instance.a);
            }

            if (__instance.s_special_effect_items == null || __instance.s_special_effect_items.Count == 0)
            {
                __instance.s_special_effect_items = null;
                __instance.s_special_effect_items_timers = null;
                __instance.batch.c_item_effects.Remove(__instance.a);
            }
            else
            {
                __instance.batch.c_item_effects.Add(__instance.a);
            }

            if (flag2 != flag)
            {
                __instance.checkMadness(flag2);
            }

            __instance.has_trait_peaceful = __instance.hasTrait("peaceful");
            __instance.has_trait_fire_resistant = __instance.hasTrait("fire_proof");
            __instance.has_status_burning = __instance.hasStatus("burning");
            __instance.has_trait_madness = __instance.hasTrait("madness");
            if (__instance.asset.use_items)
            {
                List<ActorEquipmentSlot> list4 = ActorEquipment.getList(__instance.equipment);
                for (int k = 0; k < list4.Count; k++)
                {
                    ActorEquipmentSlot actorEquipmentSlot2 = list4[k];
                    if (actorEquipmentSlot2.data != null)
                    {
                        ItemTools.mergeStatsWithItem(__instance.stats, actorEquipmentSlot2.data, false);
                    }
                }
            }

            __instance.stats.normalize();
            __instance.stats.checkMods();
            if (__instance.event_full_heal)
            {
                __instance.event_full_heal = false;
                __instance.stats.normalize();
                __instance.data.health = __instance.getMaxHealth();
            }

            Culture culture = __instance.getCulture();
            if (culture != null)
            {
                stats = __instance.stats;
                pKey = S.damage;
                stats[pKey] += __instance.stats[S.damage] * culture.stats.bonus_damage.value;
                stats = __instance.stats;
                pKey = S.armor;
                stats[pKey] += __instance.stats[S.armor] * culture.stats.bonus_armor.value;
                stats = __instance.stats;
                pKey = S.max_age;
                stats[pKey] += (float)culture.getMaxAgeBonus();
            }

            if (__instance.kingdom != null)
            {
                stats = __instance.stats;
                pKey = S.damage;
                stats[pKey] += __instance.stats[S.damage] * __instance.kingdom.stats.bonus_damage.value;
                stats = __instance.stats;
                pKey = S.armor;
                stats[pKey] += __instance.stats[S.armor] * __instance.kingdom.stats.bonus_armor.value;
            }

            if (__instance.asset.unit)
            {
                __instance.calculateFertility();
            }

            stats = __instance.stats;
            pKey = S.zone_range;
            stats[pKey] += (float)((int)(__instance.stats[S.stewardship] / 10f));
            stats = __instance.stats;
            pKey = S.cities;
            stats[pKey] += (float)((int)__instance.stats[S.stewardship] / 6 + 1);
            stats = __instance.stats;
            pKey = S.bonus_towers;
            stats[pKey] += (float)((int)(__instance.stats[S.warfare] / 10f));
            if (__instance.s_attackType == WeaponType.Range)
            {
                stats = __instance.stats;
                pKey = S.range;
                stats[pKey] += __instance.stats[S.range] * World.world_era.range_weapons_mod;
            }

            __instance.attackTimer = 0f;
            __instance.stats.normalize();
            if (__instance.data.health > __instance.getMaxHealth())
            {
                __instance.data.health = __instance.getMaxHealth();
            }

            __instance.target_scale = __instance.stats[S.scale];
            __instance.s_attackSpeed_seconds =
                (300f - __instance.stats[S.attack_speed]) / (100f + __instance.stats[S.attack_speed]);
            if (__instance.s_attackSpeed_seconds < 0.1f)
            {
                __instance.s_attackSpeed_seconds = 0.1f;
            }

            WorldAction action_recalc_stats = __instance.asset.action_recalc_stats;
            if (action_recalc_stats == null)
            {
                return false;
            }

            action_recalc_stats(__instance, null);
            return false;
        }
        [HarmonyPostfix, HarmonyPatch(typeof(Actor), "updateAge")]
        public static void updateWorldTime_KnightPostfix(Actor __instance)
        {
            Actor actor = __instance;
            if (actor == null)
            {
                return;
            }


            if (actor.hasTrait("talent1"))
            {
                actor.stats["Knight"] += 1;
            }
            if (actor.hasTrait("talent2"))
            {
                actor.stats["Knight"] += 1.5f;
            }
            if (actor.hasTrait("talent3"))
            {
                actor.stats["Knight"] += 2;
            }
            if (actor.hasTrait("talent4"))
            {
                actor.stats["Knight"] += 10;
            }

            UpdateKnightBasedOnGrade(__instance, "Knight1", 15f);
            UpdateKnightBasedOnGrade(__instance, "Knight2", 32f);
            UpdateKnightBasedOnGrade(__instance, "Knight3", 50f);
            UpdateKnightBasedOnGrade(__instance, "Knight4", 130f);
            UpdateKnightBasedOnGrade(__instance, "Knight5", 300f);
            UpdateKnightBasedOnGrade(__instance, "Knight6", 320f);
            UpdateKnightBasedOnGrade(__instance, "talent5", 0f);
        }
        private static void UpdateKnightBasedOnGrade(Actor actor, string traitName, float maxKnight)
        {
            if (actor.hasTrait(traitName))
            {
                float currentKnight = actor.stats["Knight"];
                float newValue = Mathf.Min(maxKnight, currentKnight);
                actor.stats["Knight"] = newValue;
            }
        }
    }
}