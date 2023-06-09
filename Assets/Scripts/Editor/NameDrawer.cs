using Assets.Scripts.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    [CustomPropertyDrawer(typeof(NameAttribute))]
    public class NameDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            NameAttribute nameAttribute = (NameAttribute)attribute;
            label.text = nameAttribute.Name;
            EditorGUI.PropertyField(position, property, label, true);
        }
    }
}
