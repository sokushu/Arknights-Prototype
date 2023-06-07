using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abstraction
{
    public interface ICharacter
    {
        public void Attack(GameObject gameObject);
    }
}
