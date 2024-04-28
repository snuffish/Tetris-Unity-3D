using System;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class VariableObserver<T> : MonoBehaviour
    {
        public T observedVariable;
        private T _previousValue;

        public delegate void VariableChanged(T newValue);

        public static event VariableChanged OnVariableChanged;

        private void Update()
        {
            if (EqualityComparer<T>.Default.Equals(observedVariable, _previousValue)) return;

            _previousValue = observedVariable;
            OnVariableChanged?.Invoke(observedVariable);
        }
    }
}