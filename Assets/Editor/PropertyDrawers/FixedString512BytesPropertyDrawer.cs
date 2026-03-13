using Unity.Collections;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.PropertyDrawers
{
    /// <summary>
    /// PropertyDrawer for a FixedString512Bytes
    /// </summary>
    [CustomPropertyDrawer(typeof(FixedString512Bytes))]
    internal sealed class FixedString512BytesPropertyDrawer : PropertyDrawer
    {
        #region Public methods

        /// <summary>
        /// Called when the UI is drawn
        /// </summary>
        /// <param name="position">The position of the field</param>
        /// <param name="property">The property to serialize</param>
        /// <param name="label">The text</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            string fixedStringValue = EditorGUI.TextField(position, label, property.boxedValue.ToString());

            if (EditorGUI.EndChangeCheck())
            {
                property.boxedValue = new FixedString512Bytes(fixedStringValue);
            }
        }

        /// <summary>
        /// Ensures the field will stay at the proper position
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="label">The text</param>
        /// <returns>The proper height of the field</returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        #endregion
    }
}