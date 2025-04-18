using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ai;
using UnityEngine;
using VideoCopilot.code.utils;

namespace ChivalryWizardingWorld.code
{
    internal class traitAction
    {
        public static bool Knight1_effectAction(BaseSimObject pTarget, WorldTile pTile = null) //升.侍从
        {
            if (pTarget == null)
            {
                return false;
            }

            if (!pTarget.isActor())
            {
                return false;
            }

            Actor a = pTarget.a;

            if (a.GetKnight() <= 4.99)
            {
                return false;
            }

            string[] forbiddenTraits = { "Knight2", "Knight3", "Knight4", "Knight5", "Knight6" };
            foreach (string trait in forbiddenTraits)
            {
                if (pTarget.a.hasTrait(trait))
                {
                    return false;
                }
            }

            upTrait(
                "特质",
                "Knight1",
                a,
                new string[]
                {
                    "tumorInfection",
                    "cursed",
                    "infected",
                    "mushSpores",
                    "plague",
                    "madness"
                },
                new string[] { "特质" }
            );

            return true;
        }

        public static bool Knight2_effectAction(BaseSimObject pTarget, WorldTile pTile = null) //升.预备骑士
        {
            if (pTarget == null)
            {
                return false;
            }

            if (!pTarget.isActor())
            {
                return false;
            }

            Actor a = pTarget.a;
            if (a.GetKnight() <= 9.99)
            {
                return false;
            }

            a.ChangeKnight(-2);
            double successRate = 0.8;
            if (a.hasTrait("talent1"))
            {
                successRate = 0.3;
            }
            else if (a.hasTrait("talent2"))
            {
                successRate = 0.6;
            }
            else if (a.hasTrait("talent3"))
            {
                successRate = 0.8;
            }

            double randomValue = UnityEngine.Random.Range(0.0f, 1.0f);
            if (randomValue > successRate)
            {
                return false; // 随机数大于成功率，则操作失败
            }

            upTrait(
                "Knight1",
                "Knight2",
                a,
                new string[] { "tumorInfection", "cursed", "infected", "mushSpores" },
                new string[] { "Knight22" }
            );

            return true;
        }

        public static bool Knight3_effectAction(BaseSimObject pTarget, WorldTile pTile = null) //升.初级骑士
        {
            if (pTarget == null)
            {
                return false;
            }

            if (!pTarget.isActor())
            {
                return false;
            }

            Actor a = pTarget.a;
            // 检查骑士值是否小于x，如果是，则趺落境界
            if (a.GetKnight() < 8)
            {
                // 添加Knight1特质
                upTrait("特质", "Knight1", a, new string[] { "Knight2" }, new string[] { });
                return true; // 趺落境界处理完毕，返回true
            }

            if (a.GetKnight() <= 17.99)
            {
                return false;
            }

            a.ChangeKnight(-2);
            double successRate = 0.6;
            if (a.hasTrait("talent1"))
            {
                successRate = 0.2;
            }
            else if (a.hasTrait("talent2"))
            {
                successRate = 0.4;
            }
            else if (a.hasTrait("talent3"))
            {
                successRate = 0.6;
            }

            double randomValue = UnityEngine.Random.Range(0.0f, 1.0f);
            if (randomValue > successRate)
            {
                return false; // 随机数大于成功率，则操作失败
            }

            upTrait(
                "Knight2",
                "Knight3",
                a,
                new string[]
                {
                    "tumorInfection",
                    "cursed",
                    "infected",
                    "mushSpores",
                    "Knight22"
                },
                new string[] { "Knight3+" }
            );

            return true;
        }

        public static bool Knight4_effectAction(BaseSimObject pTarget, WorldTile pTile = null) //升.中级骑士
        {
            if (pTarget == null)
            {
                return false;
            }

            if (!pTarget.isActor())
            {
                return false;
            }

            Actor a = pTarget.a;
            // 检查骑士值是否小于x，如果是，则趺落境界
            if (a.GetKnight() < 16)
            {
                upTrait("特质", "Knight2", a, new string[] { "Knight3" }, new string[] { });
                return true; // 趺落境界处理完毕，返回true
            }

            if (a.GetKnight() <= 31.99)
            {
                return false;
            }

            a.ChangeKnight(-3);
            double successRate = 0.6;
            if (a.hasTrait("talent1"))
            {
                successRate = 0.05;
            }
            else if (a.hasTrait("talent2"))
            {
                successRate = 0.3;
            }
            else if (a.hasTrait("talent3"))
            {
                successRate = 0.6;
            }

            double randomValue = UnityEngine.Random.Range(0.0f, 1.0f);
            if (randomValue > successRate)
            {
                return false; // 随机数大于成功率，则操作失败
            }

            upTrait(
                "Knight3",
                "Knight4",
                a,
                new string[]
                {
                    "tumorInfection",
                    "cursed",
                    "infected",
                    "mushSpores",
                    "Knight3+"
                },
                new string[] { "Knight4+", "dash" }
            );

            return true;
        }

        public static bool Knight5_effectAction(BaseSimObject pTarget, WorldTile pTile = null) //升.高骑士
        {
            if (pTarget == null)
            {
                return false;
            }

            if (!pTarget.isActor())
            {
                return false;
            }

            Actor a = pTarget.a;
            // 检查骑士值是否小于x，如果是，则趺落境界
            if (a.GetKnight() < 29)
            {
                upTrait("特质", "Knight3", a, new string[] { "Knight4" }, new string[] { });
                return true; // 趺落境界处理完毕，返回true
            }

            if (a.GetKnight() <= 52.99)
            {
                return false;
            }

            a.ChangeKnight(-4);
            double successRate = 0.6;
            if (a.hasTrait("talent1"))
            {
                successRate = 0.01;
            }
            else if (a.hasTrait("talent2"))
            {
                successRate = 0.2;
            }
            else if (a.hasTrait("talent3"))
            {
                successRate = 0.6;
            }

            double randomValue = UnityEngine.Random.Range(0.0f, 1.0f);
            if (randomValue > successRate)
            {
                return false;
            }

            upTrait(
                "Knight4",
                "Knight5",
                a,
                new string[]
                {
                    "tumorInfection",
                    "cursed",
                    "infected",
                    "mushSpores",
                    "Knight4+"
                },
                new string[] { "Knight5+", "deflect_projectile" }
            );

            return true;
        }

        public static bool Knight6_effectAction(BaseSimObject pTarget, WorldTile pTile = null) //升.大骑士
        {
            if (pTarget == null)
            {
                return false;
            }

            if (!pTarget.isActor())
            {
                return false;
            }

            Actor a = pTarget.a;
            // 检查骑士值是否小于x，如果是，则趺落境界
            if (a.GetKnight() < 49)
            {
                upTrait("特质", "Knight4", a, new string[] { "Knight5" }, new string[] { });
                return true; // 趺落境界处理完毕，返回true
            }

            if (a.GetKnight() <= 67.99)
            {
                return false;
            }

            a.ChangeKnight(-5);
            double successRate = 0.9;
            if (a.hasTrait("talent1"))
            {
                successRate = 0.01;
            }
            else if (a.hasTrait("talent2"))
            {
                successRate = 0.02;
            }
            else if (a.hasTrait("talent3"))
            {
                successRate = 0.03;
            }

            double randomValue = UnityEngine.Random.Range(0.0f, 1.0f);
            if (randomValue > successRate)
            {
                return false; // 随机数大于成功率，则操作失败
            }

            a.data.favorite = true;
            string actorName = a.getName();
            bool hasTitle = _knightTitles.Any(title => actorName.Contains(title));
            if (!hasTitle)
            {
                int index = UnityEngine.Random.Range(0, _knightTitles.Length);
                string selectedTitle = _knightTitles[index];
                a.data.setName($"{actorName}  —{selectedTitle}");
            }

            upTrait(
                "Knight5",
                "Knight6",
                a,
                new string[]
                {
                    "tumorInfection",
                    "cursed",
                    "infected",
                    "mushSpores",
                    "Knight5+"
                },
                new string[] { "Knight6+", "dodge" }
            );

            return true;
        }

        public static bool Knight7_effectAction(BaseSimObject pTarget, WorldTile pTile = null) //大骑士
        {
            if (pTarget == null)
            {
                return false;
            }

            if (!pTarget.isActor())
            {
                return false;
            }

            Actor a = pTarget.a;
            // 检查骑士值是否小于x，如果是，则趺落境界
            if (a.GetKnight() < 63)
            {
                upTrait("特质", "Knight5", a, new string[] { "Knight6" }, new string[] { });
                return true; // 趺落境界处理完毕，返回true
            }

            return true;
        }
        private static readonly string[] _knightTitles = { "「帝国玫瑰」", "「拜伦斯的雄狮」", "「断矛者」", "「宽恕之棘」", "「红隼」", "「白手套」", "「车轮伯爵」"
, "「无鞘」", "「鸦喙」", "「宴会蜘蛛」", "「绯红之冠」", "「赤色黎明」", "「黑桃密使」", "「毒蝎骑士」", "「密语伯爵」", "「黑天鹅之喙」", "「锈冠」", "「影桥」"
, "「白天鹅之翼」", "「哑剧皇冠」", "「黑弥撒」", "「摇篮铁律」", "「绯红安魂曲」", "「黑铁摇篮曲」", "「染血鸢尾」", "「泣铁蔷薇」", "「青铜挽歌」", "「赤红飓风」"
, "「铸铁玫瑰」", "「悼亡晨星」", "「噬魂长枪」", "「白银钢脊」", "「无声坚壁」", "「秘银壁垒」", "「凛冬之剑」", "「寒铁龙骑」", "「碧落剑圣」", "「孤儿院院长」"
, "「石心仲裁者」", "「破晓追猎者」" , "「铁幕游侠」", "「永夜守钟人」" , "「黑骑士」", "「炽诚之剑」", "「曙光长枪」" , "「慈悲坚盾」", "「黎明破晓者」" };

        //骑士的恢复生命值效果
        public static bool Knight_Regen1(BaseSimObject pTarget, WorldTile pTile = null) //1%
        {
            if (pTarget.a.data.health < pTarget.a.getMaxHealth())
            {
                int tHealthToRegen = pTarget.a.getMaxHealthPercent(0.01f);
                pTarget.a.restoreHealth(tHealthToRegen);
                pTarget.a.spawnParticle(Toolbox.color_heal);
            }

            return true;
        }
        public static bool Knight_Regen2(BaseSimObject pTarget, WorldTile pTile = null) //2%
        {
            if (pTarget.a.data.health < pTarget.a.getMaxHealth())
            {
                int tHealthToRegen = pTarget.a.getMaxHealthPercent(0.02f);
                pTarget.a.restoreHealth(tHealthToRegen);
                pTarget.a.spawnParticle(Toolbox.color_heal);
            }

            return true;
        }
        public static bool Knight_Regen3(BaseSimObject pTarget, WorldTile pTile = null) //3%
        {
            if (pTarget.a.data.health < pTarget.a.getMaxHealth())
            {
                int tHealthToRegen = pTarget.a.getMaxHealthPercent(0.03f);
                pTarget.a.restoreHealth(tHealthToRegen);
                pTarget.a.spawnParticle(Toolbox.color_heal);
            }

            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="old_trait">升级前的特质</param>
        /// <param name="new_trait">升级到的特质</param>
        /// <param name="actor">单位传入</param>
        /// <param name="other_Oldtraits">升级要删掉的特质(不包括升级前的主特质)</param>
        /// <param name="other_newTrait">升级后要伴随添加的特质(不包含主特质)</param>
        /// <returns></returns>
        public static bool upTrait(
            string old_trait,
            string new_trait,
            Actor actor,
            string[] other_Oldtraits = null,
            string[] other_newTrait = null
        )
        {
            if (actor == null)
            {
                return false;
            }

            foreach (string VARIABLE in other_newTrait)
            {
                actor.addTrait(VARIABLE);
            }

            foreach (var VARIABLE in other_Oldtraits)
            {
                actor.removeTrait(VARIABLE);
            }

            actor.addTrait(new_trait);
            actor.removeTrait(old_trait);
            return true;
        }
    }
}
