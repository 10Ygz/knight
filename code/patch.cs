using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using UnityEngine;
using UnityEngine.UI;
using VideoCopilot.code.utils;


namespace ChivalryWizardingWorld.code
{
    internal class patch
    {
        public static bool window_creature_info_initialized;

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UnitWindow), nameof(UnitWindow.OnEnable))]
        private static void WindowCreatureInfo_OnEnable_postfix(UnitWindow __instance)
        {
            if (__instance.actor == null || !__instance.actor.isAlive())
                return;
            if (!window_creature_info_initialized)
            {
                window_creature_info_initialized = true;
                UnitWindowStatsIcon.Initialize(__instance);
            }

            UnitWindowStatsIcon.OnEnable(__instance, __instance.actor);
        }
        [HarmonyPostfix, HarmonyPatch(typeof(Actor), "updateAge")]
        public static void updateWorldTime_KnightPostfix(Actor __instance)
        {
            if (__instance == null)
            {
                return;
            }

            float age = (float)__instance.getAge();
            bool hasTalent6 = __instance.hasTrait("talent6");// 检查是否具有特质
            bool hasTalent5 = __instance.hasTrait("talent5");

            // 9岁时获得talent1-talent4的随机特质
            if (Mathf.FloorToInt(age) == 9 && !hasTalent5 && !hasTalent6 &&
            !HasAnyTalent(__instance, new[] { "talent1", "talent2", "talent3", "talent4" }) &&
            Randy.randomChance(0.2f))
            {
                var talentWeights = new (string traitId, int weight)[]
                {
                    ("talent1", 57),
                    ("talent2", 30),
                    ("talent3", 10),
                    ("talent4", 3)
                };

                // 计算总权重
                int totalWeight = talentWeights.Sum(t => t.weight);

                // 生成随机数
                int randomValue = UnityEngine.Random.Range(0, totalWeight);

                // 遍历权重选择特质
                string selectedTalent = "talent1"; // 默认值
                foreach (var talent in talentWeights)
                {
                    if (randomValue < talent.weight)
                    {
                        selectedTalent = talent.traitId;
                        break;
                    }
                    randomValue -= talent.weight;
                }

                __instance.addTrait(selectedTalent, false);
            }

            // 特质增加生命之力的处理
            var talentKnightChanges = new Dictionary<string, (float, float)>
            {
                { "talent1", (0.5f, 1.5f) },//下
                { "talent2", (1.0f, 2.0f) },//中
                { "talent3", (1.5f, 2.5f) },//上
                { "talent4", (2.0f, 5.0f) },//极
                { "talent6", (-1.0f, -2.0f) }//安享晚年
            };

            foreach (var change in talentKnightChanges)
            {
                // 如果具有talent6特质，并且当前特质是talent1到talent4，则跳过
                if ((hasTalent6 || hasTalent5) && (change.Key == "talent1" || change.Key == "talent2" || change.Key == "talent3" || change.Key == "talent4"))
                {
                    continue;
                }

                if (__instance.hasTrait(change.Key))
                {
                    float randomKnightIncrease = UnityEngine.Random.Range(change.Value.Item1, change.Value.Item2);
                    __instance.ChangeKnight(randomKnightIncrease);
                }
            }

            // 年龄和概率条件增加特质的处理
            var knightTraitThresholds = new Dictionary<string, float>
            {
                { "Knight1", 40f },//骑士学徒
                { "Knight2", 50f },//预备骑士+10
                { "Knight3", 50f },//初级骑士+20
                { "Knight4", 65f },//中级骑士+25
                { "Knight5", 70f },//高级骑士+30
                { "Knight6", 100f }//大骑士+60
            };
            const float talent6Chance = 0.2f;
            foreach (var threshold in knightTraitThresholds)
            {
                if (__instance.hasTrait(threshold.Key) && age > threshold.Value && Randy.randomChance(talent6Chance))
                {
                    __instance.addTrait("talent6", false);
                }
            }

            var grades = new Dictionary<string, float>
            {
                { "Knight1", 10f },
                { "Knight2", 18f },
                { "Knight3", 32f },
                { "Knight4", 53f },
                { "Knight5", 68f },
                { "Knight6", 75f },
            };
            foreach (var grade in grades)
            {
                UpdateKnightBasedOnGrade(__instance, grade.Key, grade.Value);
            }
        }
        private static void UpdateKnightBasedOnGrade(Actor actor, string traitName, float maxKnight)
        {
            if (actor.hasTrait(traitName))
            {
                float currentKnight = actor.GetKnight();
                float newValue = Mathf.Min(maxKnight, currentKnight);
                actor.SetKnight(newValue);
            }
        }
        private static bool HasAnyTalent(Actor actor, string[] traitIds)
        {
            foreach (string traitId in traitIds)
            {
                if (actor.hasTrait(traitId)) return true;
            }
            return false;
        }
    }
}