using UnityEditor;
using UnityEditor.UI;

namespace UnityLayoutElementExtended
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(LayoutElementExtended), true)]
    public class LayoutElementExtendedEditor : LayoutElementEditor
    {
        private SerializedProperty m_IgnoreLayout = null;
        private SerializedProperty m_LayoutPriority = null;

        private SerializedProperty MinWidthExtended = null;
        private SerializedProperty MinHeightExtended = null;
        private SerializedProperty PreferredWidthExtended = null;
        private SerializedProperty PreferredHeightExtended = null;
        private SerializedProperty FlexibleWidthExtended = null;
        private SerializedProperty FlexibleHeightExtended = null;
        private SerializedProperty MaxWidth = null;
        private SerializedProperty MaxHeight = null;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_IgnoreLayout);

            if (!m_IgnoreLayout.boolValue)
            {
                EditorGUILayout.BeginVertical("Box");

                EditorGUILayout.LabelField("Extended", EditorStyles.boldLabel);

                DisplayPropertyFieldInBox(MinWidthExtended);
                DisplayPropertyFieldInBox(MinHeightExtended);
                DisplayPropertyFieldInBox(PreferredWidthExtended);
                DisplayPropertyFieldInBox(PreferredHeightExtended);
                DisplayPropertyFieldInBox(FlexibleWidthExtended);
                DisplayPropertyFieldInBox(FlexibleHeightExtended);
                DisplayPropertyFieldInBox(MaxWidth);
                DisplayPropertyFieldInBox(MaxHeight);

                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.PropertyField(m_LayoutPriority);

            serializedObject.ApplyModifiedProperties();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            m_IgnoreLayout = serializedObject.FindProperty("m_IgnoreLayout");
            m_LayoutPriority = serializedObject.FindProperty("m_LayoutPriority");

            MinWidthExtended = serializedObject.FindProperty("MinWidthExtended");
            MinHeightExtended = serializedObject.FindProperty("MinHeightExtended");
            PreferredWidthExtended = serializedObject.FindProperty("PreferredWidthExtended");
            PreferredHeightExtended = serializedObject.FindProperty("PreferredHeightExtended");
            FlexibleWidthExtended = serializedObject.FindProperty("FlexibleWidthExtended");
            FlexibleHeightExtended = serializedObject.FindProperty("FlexibleHeightExtended");
            MaxWidth = serializedObject.FindProperty("MaxWidth");
            MaxHeight = serializedObject.FindProperty("MaxHeight");
        }

        private void DisplayPropertyFieldInBox(SerializedProperty target)
        {
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(target);
            EditorGUILayout.EndVertical();
        }
    }
}
