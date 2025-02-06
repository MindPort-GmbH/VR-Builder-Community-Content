using UnityEngine;
using VRBuilder.Core.Properties;

namespace VRBuilder.Community
{
    /// <summary>
    /// Base implementation for process data properties.
    /// </summary>    
    [DisallowMultipleComponent]
    public class OpaqueProperty : NumberDataProperty
    {

        public void setOpacity(float value)
        {
            foreach (Renderer renderer in gameObject.GetComponents<Renderer>())
            {
                foreach (Material material in renderer.materials)
                {
                    Color transparentColor = material.GetColor("_Color");
                    transparentColor.a = value;
                    material.SetColor("_Color", transparentColor);
                }
            }
        }

        public void Start()
        {
            OnValueChanged.AddListener(setOpacity);
        }


    }
}