using System;
using System.Collections.Generic;
using HarmonyLib;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using UnityEngine;
using UnityEngine.UI;
using VideoCopilot.code.utils;


namespace Chivalry.code
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
                rect.localPosition = new Vector3(-100, 155, 0);
                rect.sizeDelta = new Vector2(800, 200);
            }
            Transform ActorShowYuanNneg = __instance.transform.Find("Background/KnightShow");
            Text ActorShowYuanNnegText = ActorShowYuanNneg.GetComponent<Text>();
            ActorShowYuanNnegText.text = LM.Get("Knight")+":\t"+__instance.actor.GetKnight();
            ActorShowYuanNnegText.font = LocalizedTextManager.currentFont;
            ActorShowYuanNnegText.alignment = TextAnchor.UpperLeft;
            ActorShowYuanNnegText.raycastTarget = false;
        }

        [HarmonyPostfix, HarmonyPatch(typeof(Actor), "updateAge")]
        public static void updateWorldTime_KnightPostfix(Actor __instance)
        {
            if (__instance == null)
            {
                return;
            }

            float age = (float)__instance.getAge();
            bool hasTalent6 = __instance.hasTrait("talent6");// 检查是否具有talent6特质

            // 特质增加生命之力的处理
            var talentKnightChanges = new Dictionary<string, float>
            {
                { "talent1", 1f },
                { "talent2", 1.5f },
                { "talent3", 2f },
                { "talent4", 10f },
                { "talent6", -5f }
            };

            foreach (var change in talentKnightChanges)
            {
                // 如果具有talent6特质，并且当前特质是talent1到talent4，则跳过
                if (hasTalent6 && (change.Key == "talent1" || change.Key == "talent2" || change.Key == "talent3" || change.Key == "talent4"))
                {
                    continue;
                }

                if (__instance.hasTrait(change.Key))
                {
                    __instance.ChangeKnight(change.Value);
                }
            }

            // 年龄和概率条件增加特质的处理
            var knightTraitThresholds = new Dictionary<string, float>
            {
                { "Knight1", 68f },//侍从
                { "Knight2", 68f },//晨星骑士
                { "Knight3", 78f },//曦光骑士
                { "Knight4", 118f },//烈阳骑士
                { "Knight5", 188f }//穹辉骑士
            };
            const float talent6Chance = 0.2f;
            foreach (var threshold in knightTraitThresholds)
            {
                if (__instance.hasTrait(threshold.Key) && age > threshold.Value && Toolbox.randomChance(talent6Chance))
                {
                    __instance.addTrait("talent6", false);
                }
            }

            var grades = new Dictionary<string, float>
            {
                { "Knight1", 15f },
                { "Knight2", 32f },
                { "Knight3", 50f },
                { "Knight4", 130f },
                { "Knight5", 300f },
                { "Knight6", 320f },
                { "talent5", 0f }
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
    }
}