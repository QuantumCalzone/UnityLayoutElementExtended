using UnityEngine;
using UnityEditor;

namespace UnityLayoutElementExtended
{
    [CustomPropertyDrawer(typeof(LayoutElementExtendedValue))]
    public class LayoutElementExtendedValuePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            GUI.Label(position, label, EditorStyles.boldLabel);

            var enabled = property.FindPropertyRelative("Enabled");
            EditorGUILayout.PropertyField(enabled);

            if (enabled.boolValue)
            {
                var referenceType = property.FindPropertyRelative("ReferenceType");
                var reference = property.FindPropertyRelative("Reference");
                var referenceDelta = property.FindPropertyRelative("ReferenceDelta");
                var targetValue = property.FindPropertyRelative("TargetValue");

                EditorGUILayout.PropertyField(referenceType);

                if ((LayoutElementExtendedValue.ReferenceTypes)referenceType.enumValueIndex != LayoutElementExtendedValue.ReferenceTypes.None)
                {
                    EditorGUILayout.PropertyField(reference);
                    EditorGUILayout.PropertyField(referenceDelta);
                    GUI.enabled = false;
                    EditorGUILayout.PropertyField(targetValue);
                    GUI.enabled = true;
                }
                else EditorGUILayout.PropertyField(targetValue);
            }

            EditorGUI.EndProperty();
        }
    }
}