using Unity.VisualScripting;
using UnityEngine;

namespace State
{
    public static class State
    {
        public static T GetVariableValue<T>(this MonoBehaviour instance, string name)
        {
            if (!instance.TryGetComponent(out Variables variables)) return default;

            var declaration = variables.declarations.GetDeclaration(name);
            return (T) declaration.value;
        }
    }
}
