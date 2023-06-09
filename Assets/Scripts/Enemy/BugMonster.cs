using Assets.Scripts.Abstraction;
using Assets.Scripts.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Enemy
{
    public class BugMonster : AbsEnemy
    {

        private int HP;

        private void Start()
        {
            HP = MaxHP;
        }

        private void OnCollisionStay(Collision collision)
        {
            GameObject gameObject = collision.gameObject;
            if (gameObject.CompareTag(nameof(AbsCharacter)))
            {
                gameObject.SendMessage(nameof(AbsCombatant.BeingAttacked), SendMessageOptions.DontRequireReceiver);
            }
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void BeingAttacked()
        {
            if (HP <= 0)
                Die();
        }

        public override void Die()
        {
            EventHandler.Invoke(this, new CombatantArgs
            {

            });
        }
    }
}
