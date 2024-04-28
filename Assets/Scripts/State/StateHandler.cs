using System;
using Unity.VisualScripting;
using UnityEngine;

namespace State
{
    [ExecuteAlways]
    [RequireComponent(typeof(Variables), typeof(StateMachine))]
    public class StateHandler : MonoBehaviour {
        public StateMachine _stateMachine;
        public Variables _variables;

        public StateHandler _instance;

        private void Awake()
        {
            _instance = this;
            _variables = GetComponent<Variables>();
            _stateMachine = GetComponent<StateMachine>();
        }

        private void Start()
        {
            // VariableObserver<float>.OnVariableChanged += VariableChange;
            // State.SubscribeVariable(ref _instance, "NumberOfBlocks");
        }

        private void OnDestroy()
        {
            // VariableObserver<float>.OnVariableChanged -= VariableChange;
        }

        public void VariableChange(object newValue)
        {
            Debug.Log("VARIABLE CHANGED => " + newValue);
        }
    }
}