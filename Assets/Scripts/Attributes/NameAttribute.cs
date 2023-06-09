using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Attributes
{
    /// <summary>
    /// 显示名称
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class NameAttribute : PropertyAttribute
    {
        public string Name { get; private set; }
        public NameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
