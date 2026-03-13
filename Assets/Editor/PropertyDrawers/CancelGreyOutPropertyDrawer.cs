using Assets.Scripts.Runtime.Models.PropertyAttributes;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.PropertyDrawers
{
    /// <summary>
    /// PropertyDrawer for the CancelGreyOut attribute
    /// </summary>
    [CustomPropertyDrawer(typeof(CancelGreyOutAttribute))]
    internal sealed class CancelGreyOutPropertyDrawer : PropertyDrawer
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
            bool enabled = GUI.enabled;
            GUI.enabled = true;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = enabled;
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