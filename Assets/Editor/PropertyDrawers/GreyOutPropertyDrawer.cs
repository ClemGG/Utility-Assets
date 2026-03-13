using Assets.Scripts.Runtime.Models.PropertyAttributes;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.PropertyDrawers
{
    /// <summary>
    /// PropertyDrawer for the GreyOut attribute
    /// </summary>
    [CustomPropertyDrawer(typeof(GreyOutAttribute))]
    internal sealed class GreyOutPropertyDrawer : PropertyDrawer
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
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }

        /// <summary>
        /// Ensures the field will stay at the proper position
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="label">The text</param>
        /// <returns>The proper height of the field</returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        #endregion
    }
}