using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Abstraction
{
    public abstract class AbsCharacter : AbsCombatant
    {
        private void Start()
        {
            tag = nameof(AbsCharacter);
        }
    }
}
