using UnityEngine;

namespace Assets.Scripts.Runtime.Models.PropertyAttributes
{
    /// <summary>
    /// Draws the assigned field in the Inspector
    /// even if nested inside a field marked with ReadOnly
    /// </summary>
    public sealed class CancelGreyOutAttribute : PropertyAttribute
    {

    }
}