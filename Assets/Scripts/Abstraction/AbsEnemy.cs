using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abstraction
{
    /// <summary>
    /// 敌人的接口
    /// </summary>
    public abstract class AbsEnemy : AbsCombatant
    {
        private void Start()
        {
            tag = nameof(AbsEnemy);
        }
    }
}
