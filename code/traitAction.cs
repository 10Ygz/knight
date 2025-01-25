using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ai;
using UnityEngine;

namespace InterestingTrait.code
{
    internal class traitAction
    {
        public static bool Knight1_effectAction(BaseSimObject pTarget, WorldTile pTile = null)//升.侍从
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
            if (a.stats["Knight"] <= 4.99)
            {
                return false;
            }
            string[] forbiddenTraits =
            {
                 "Knight2", "Knight3", "Knight4", "Knight5", "Knight6"
            };
            foreach (string trait in forbiddenTraits)
            {
                if (pTarget.a.hasTrait(trait))
                {
                    return false;
                }
            }
            upTrait("特质", "Knight1", a,
                new string[] { "tumorInfection", "cursed", "infected", "mushSpores", "plague", "madness" },
                new string[] { "特质" });

            return true;
        }
        public static bool Knight2_effectAction(BaseSimObject pTarget, WorldTile pTile = null)//升.预备骑士
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
            if (a.stats["Knight"] <= 14.99)
            {
                return false;
            }

            a.stats["Knight"] -= 2;
            double successRate = 0.9;
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

            upTrait("特质", "Knight2", a, new string[] { "tumorInfection", "cursed", "infected", "mushSpores", "Knight1" },
                new string[] { "特质" });

            return true;
        }
        public static bool Knight3_effectAction(BaseSimObject pTarget, WorldTile pTile = null)//升.初级骑士
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
            if (a.stats["Knight"] <= 31.99)
            {
                return false;
            }

            a.stats["Knight"] -= 2;
            double successRate = 0.9;
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

            upTrait("特质", "Knight3", a, new string[] { "tumorInfection", "cursed", "infected", "mushSpores", "Knight2" },
                new string[] { "特质" });

            return true;
        }
        public static bool Knight4_effectAction(BaseSimObject pTarget, WorldTile pTile = null)//升.高级骑士
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
            if (a.stats["Knight"] <= 49.99)
            {
                return false;
            }

            a.stats["Knight"] -= 3;
            double successRate = 0.9;
            if (a.hasTrait("talent1"))
            {
                successRate = 0.006;
            }
            else if (a.hasTrait("talent2"))
            {
                successRate = 0.1;
            }
            else if (a.hasTrait("talent3"))
            {
                successRate = 0.3;
            }
            double randomValue = UnityEngine.Random.Range(0.0f, 1.0f);
            if (randomValue > successRate)
            {
                return false; // 随机数大于成功率，则操作失败
            }

            upTrait("特质", "Knight4", a, new string[] { "tumorInfection", "cursed", "infected", "mushSpores", "Knight3" },
                new string[] { "特质" });

            return true;
        }
        public static bool Knight5_effectAction(BaseSimObject pTarget, WorldTile pTile = null)//升.大骑士
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
            if (a.stats["Knight"] <= 129.99)
            {
                return false;
            }

            a.stats["Knight"] -= 4;
            double successRate = 0.9;
            if (a.hasTrait("talent1"))
            {
                successRate = 0.001;
            }
            else if (a.hasTrait("talent2"))
            {
                successRate = 0.01;
            }
            else if (a.hasTrait("talent3"))
            {
                successRate = 0.1;
            }
            double randomValue = UnityEngine.Random.Range(0.0f, 1.0f);
            if (randomValue > successRate)
            {
                return false;
            }

            upTrait("特质", "Knight5", a, new string[] { "tumorInfection", "cursed", "infected", "mushSpores", "Knight4" },
                new string[] { "特质" });

            return true;
        }
        public static bool Knight6_effectAction(BaseSimObject pTarget, WorldTile pTile = null)//升.传说骑士
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
            if (a.stats["Knight"] <= 299.99)
            {
                return false;
            }
            a.stats["Knight"] -= 5;
            double successRate = 0.9;
            if (a.hasTrait("talent1"))
            {
                successRate = 0.001;
            }
            else if (a.hasTrait("talent2"))
            {
                successRate = 0.005;
            }
            else if (a.hasTrait("talent3"))
            {
                successRate = 0.05;
            }
            double randomValue = UnityEngine.Random.Range(0.0f, 1.0f);
            if (randomValue > successRate)
            {
                return false; // 随机数大于成功率，则操作失败
            }

            upTrait("特质", "Knight6", a, new string[] { "tumorInfection", "cursed", "infected", "mushSpores", "Knight5" },
                new string[] { "特质" });

            return true;
        }
        //骑士的真伤效果
        public static bool warfare_attack_Knight5(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            // 每次攻击计算自身warfare值的随机倍数，再减少目标血量
            if (pTarget != null && pTarget.a != null && pTarget.a.data != null && pSelf != null && pSelf.a != null &&
                pSelf.a.stats != null)
            {
                // warfare值的随机倍数，范围在x到x之间
                float warfareMultiplierMin = 10f;
                float warfareMultiplierMax = 20f;
                float warfareMultiplier =
                    UnityEngine.Random.Range(warfareMultiplierMin, warfareMultiplierMax);

                float damageBasedOnWarfare = pSelf.a.stats[S.warfare] * warfareMultiplier; // 根据warfare计算伤害
                int damageToDeal = Mathf.FloorToInt(damageBasedOnWarfare);                // 将浮点数伤害转换为整数

                pTarget.a.data.health -= damageToDeal; // 减去基于warfare的伤害值

                if (pTarget.a.data.health <= 0)
                {
                    pTarget.a.data.alive = false;
                    AttackType attackTypeInstance = new AttackType();
                    (pTarget.a as Actor)?.killHimself(false, attackTypeInstance, true, true, true);
                }
            }

            return true;
        }
        public static bool warfare_attack_Knight6(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            // 每次攻击计算自身指挥值的随机倍数，再减少目标血量
            if (pTarget != null && pTarget.a != null && pTarget.a.data != null && pSelf != null && pSelf.a != null &&
                pSelf.a.stats != null)
            {
                // 指挥值的随机倍数，范围在x到x之间
                float warfareMultiplierMin = 8f;
                float warfareMultiplierMax = 18f;
                float warfareMultiplier =
                    UnityEngine.Random.Range(warfareMultiplierMin, warfareMultiplierMax);

                float damageBasedOnWarfare = pSelf.a.stats[S.warfare] * warfareMultiplier; // 根据指挥计算伤害
                int damageToDeal = Mathf.FloorToInt(damageBasedOnWarfare);                // 将浮点数伤害转换为整数

                pTarget.a.data.health -= damageToDeal; // 减去基于指挥的伤害值

                if (pTarget.a.data.health <= 0)
                {
                    pTarget.a.data.alive = false;
                    AttackType attackTypeInstance = new AttackType();
                    (pTarget.a as Actor)?.killHimself(false, attackTypeInstance, true, true, true);
                }
            }

            return true;
        }
        //骑士的恢复生命值效果
        public static bool Knight2_Regen(BaseSimObject pTarget, WorldTile pTile = null)//预备
        {
            if (pTarget.a.hasTrait("infected"))
            {
                return true;
            }
            bool flag = true;
            if (pTarget.a.asset.needFood)
            {
                flag = (pTarget.a.data.hunger > 0);
            }
            if (pTarget.a.data.health != pTarget.getMaxHealth())
            {
                pTarget.a.restoreHealth(20);
                pTarget.a.spawnParticle(Toolbox.color_heal);
            }
            return true;
        }
        public static bool Knight3_Regen(BaseSimObject pTarget, WorldTile pTile = null)//初骑
        {
            if (pTarget.a.hasTrait("infected"))
            {
                return true;
            }
            bool flag = true;
            if (pTarget.a.asset.needFood)
            {
                flag = (pTarget.a.data.hunger > 0);
            }
            if (pTarget.a.data.health != pTarget.getMaxHealth())
            {
                pTarget.a.restoreHealth(50);
                pTarget.a.spawnParticle(Toolbox.color_heal);
            }
            return true;
        }
        public static bool Knight4_Regen(BaseSimObject pTarget, WorldTile pTile = null)//高骑
        {
            bool flag = true;
            if (pTarget.a.asset.needFood)
            {
                flag = (pTarget.a.data.hunger > 0);
            }
            if (pTarget.a.data.health != pTarget.getMaxHealth())
            {
                pTarget.a.restoreHealth(100);
                pTarget.a.spawnParticle(Toolbox.color_heal);
            }
            return true;
        }
        public static bool Knight5_Regen(BaseSimObject pTarget, WorldTile pTile = null)//大骑
        {
            bool flag = true;
            if (pTarget.a.asset.needFood)
            {
                flag = (pTarget.a.data.hunger > 0);
            }
            if (pTarget.a.data.health != pTarget.getMaxHealth())
            {
                pTarget.a.restoreHealth(800);
                pTarget.a.spawnParticle(Toolbox.color_heal);
            }
            return true;
        }
        public static bool Knight6_Regen(BaseSimObject pTarget, WorldTile pTile = null)//传奇
        {
            bool flag = true;
            if (pTarget.a.asset.needFood)
            {
                flag = (pTarget.a.data.hunger > 0);
            }
            if (pTarget.a.data.health != pTarget.getMaxHealth())
            {
                pTarget.a.restoreHealth(1600);
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
        public static bool upTrait(string   old_trait, string new_trait, Actor actor, string[] other_Oldtraits = null,
                                   string[] other_newTrait = null)
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