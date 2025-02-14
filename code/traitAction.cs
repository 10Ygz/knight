using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ai;
using UnityEngine;
using VideoCopilot.code.utils;

namespace Chivalry.code
{
    internal class traitAction
    {
        private static Dictionary<string, int> _reviveCounts = new Dictionary<string, int>(); //跟踪每个名字复活次数
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
            
            if (a.GetKnight() <= 4.99)
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
            if (a.GetKnight() <= 14.99)
            {
                return false;
            }

            a.ChangeKnight(-2);
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
                new string[] { "Knight2+" });

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
            // 检查骑士值是否小于x，如果是，则趺落境界
            if (a.GetKnight() < 13)
            {
                // 添加Knight1特质
                upTrait("特质", "Knight1", a, new string[] { "Knight2" }, new string[] { });
                return true; // 趺落境界处理完毕，返回true
            }
            
            if (a.GetKnight() <= 31.99)
            {
                return false;
            }

            a.ChangeKnight(-2);
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

            upTrait("特质", "Knight3", a, new string[] { "tumorInfection", "cursed", "infected", "mushSpores", "Knight2", "Knight2+" },
                new string[] { "Knight3+" });

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
            // 检查骑士值是否小于x，如果是，则趺落境界
            if (a.GetKnight() < 30)
            {
                upTrait("特质", "Knight2", a, new string[] { "Knight3" }, new string[] { });
                return true; // 趺落境界处理完毕，返回true
            }

            if (a.GetKnight() <= 49.99)
            {
                return false;
            }

            a.ChangeKnight(-3);
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

            upTrait("特质", "Knight4", a, new string[] { "tumorInfection", "cursed", "infected", "mushSpores", "Knight3", "Knight3+" },
                new string[] { "Knight4+" });

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
            // 检查骑士值是否小于x，如果是，则趺落境界
            if (a.GetKnight() < 47)
            {
                upTrait("特质", "Knight3", a, new string[] { "Knight4" }, new string[] { });
                return true; // 趺落境界处理完毕，返回true
            }

            if (a.GetKnight() <= 129.99)
            {
                return false;
            }

            a.ChangeKnight(-4);
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

            upTrait("特质", "Knight5", a, new string[] { "tumorInfection", "cursed", "infected", "mushSpores", "Knight4", "Knight4+" },
                new string[] { "Knight5+" });

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
            // 检查骑士值是否小于x，如果是，则趺落境界
            if (a.GetKnight() < 126)
            {
                upTrait("特质", "Knight4", a, new string[] { "Knight5" }, new string[] { });
                return true; // 趺落境界处理完毕，返回true
            }

            if (a.GetKnight() <= 299.99)
            {
                return false;
            }
            a.ChangeKnight(-5);
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
            a.data.setName(pTarget.a.getName()+" 传奇");
            a.data.favorite = true;
            // 初始化newName为当前名称
            string currentName = a.getName();
            string newName = currentName;
            // 随机选择一条提示信息
            System.Random random = new System.Random();
            int index = random.Next(grade91Tips.Count);
            string tip = grade91Tips[index];

            // 如果提示信息中包含占位符（比如 {0}），则替换为角色的名称
            if (tip.Contains("{0}"))
            {
                tip = string.Format(tip, newName);
            }

            // 显示随机选择的提示信息
            ActionLibrary.showWhisperTip(tip);

            upTrait("特质", "Knight6", a, new string[] { "tumorInfection", "cursed", "infected", "mushSpores", "Knight5", "Knight5+" },
                new string[] { "talent7", "Knight6+" });

            return true;
        }
        // 定义一组升级提示信息
        private static readonly List<string> grade91Tips = new List<string>
        {
            "「血染苍穹！[{0}]踏破万军，永耀之冠加冕战场！」",
            "「战鼓轰鸣！[{0}]以剑锋开辟永耀之路！」",
            "「铁蹄震天！[{0}]携圣焰横扫千军，登顶骑士之巅！」",
            "「圣焰熊熊！[{0}]以正义之名，照亮永耀之路，骑士之魂永存！」",
            "「战火洗礼！[{0}]历经千战，传奇之名永耀世间！」",
            "「剑指苍穹！[{0}]战无不胜，铸就永耀骑士的辉煌！」",
            "「战旗飘扬！[{0}]以血与火铸就永耀传奇！」"
        };
        public static bool talent7_death(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pTarget == null)
            {
                return false;
            }

            string entityName = pTarget.a.getName();
            //检查是否存在该名字的复活计数，如果不存在则初始化为1
            if (!_reviveCounts.TryGetValue(entityName, out int reviveCount))
            {
                _reviveCounts[entityName] = 1;
            }

            if (_reviveCounts[entityName] >= 3) //复活次数是否已达到限制
            {
                return false;
            }

            if (!pTarget.isActor())
            {
                return false;
            }

            Actor a = pTarget.a;
            a.removeTrait("tumorInfection");
            a.removeTrait("cursed");
            a.removeTrait("infected");
            a.removeTrait("mushSpores");
            a.removeTrait("plague");
            var act = World.world.units.createNewUnit(a.asset.id, pTile, 0f);
            ActorTool.copyUnitToOtherUnit(a, act);
            act.data.setName(pTarget.a.getName());
            act.data.traits = new List<string>() { "flair5","talent7" };
            act.data.health = 999;
            act.data.created_time = World.world.getCreationTime();
            act.data.age_overgrowth = 18;
            act.data.setName(entityName);
            teleportRandom(act);

            if (reviveCount < 3) //如果复活次数未达到限制，则添加flair5
            {
                act.data.traits = new List<string>() { "flair5","talent7" };
            }

            _reviveCounts[entityName] = reviveCount + 1; //增加该名字的复活次数计数器

            PowerLibrary pb = new PowerLibrary();
            pb.divineLightFX(pTarget.a.currentTile, null);

            return true;
        }
        public static bool teleportRandom(Actor a)
        {
            MapBox mapBox = World.world as MapBox;
            if (mapBox == null)
            {
                return false;
            }

            CitiesManager citiesManager = mapBox.list_base_managers.OfType<CitiesManager>().FirstOrDefault();
            if (citiesManager == null)
            {
                return false;
            }

            List<City> cities = citiesManager.list;
            if (cities.Count == 0)
            {
                return false;
            }

            System.Random random = new System.Random();
            int randomIndex = random.Next(cities.Count);
            City randomCity = cities[randomIndex];

            WorldTile cityCenterTile = randomCity.getTile();
            if (cityCenterTile == null || cityCenterTile.Type.block || !cityCenterTile.Type.ground)
            {
                return false;
            }

            a.cancelAllBeh(null);
            a.spawnOn(cityCenterTile, 0f);
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