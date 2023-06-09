using Assets.Scripts.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abstraction
{
    public abstract class AbsCombatant : MonoBehaviour
    {
        /// <summary>
        /// 最大血量
        /// </summary>
        public int MaxHP;

        /// <summary>
        /// 攻击
        /// </summary>
        public int Atk;

        /// <summary>
        /// 防御
        /// </summary>
        public int Def;

        /// <summary>
        /// 对外广播，例如死亡等事件
        /// </summary>
        public EventHandler<CombatantArgs> EventHandler;

        /// <summary>
        /// 进行攻击
        /// </summary>
        /// <param name="gameObject"></param>
        public abstract void Attack();

        /// <summary>
        /// 受到攻击
        /// </summary>
        public abstract void BeingAttacked();

        /// <summary>
        /// 死亡
        /// </summary>
        public abstract void Die();
    }
}
