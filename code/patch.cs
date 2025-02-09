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
            Actor actor = __instance;
            if (actor == null)
            {
                return;
            }

            if (actor.hasTrait("talent1"))
            {
                actor.ChangeKnight(1);
            }
            if (actor.hasTrait("talent2"))
            {
                actor.ChangeKnight(1.5f);
            }
            if (actor.hasTrait("talent3"))
            {
                actor.ChangeKnight(2);
            }
            if (actor.hasTrait("talent4"))
            {
                actor.ChangeKnight (10);
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
                float currentKnight = actor.GetKnight();
                float newValue = Mathf.Min(maxKnight, currentKnight);
                actor.SetKnight(newValue);
            }
        }
    }
}