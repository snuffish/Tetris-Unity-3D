using System;
using UnityEngine;
using UnityEngine.Events;

public class InputKeyAction : MonoBehaviour
{
    public KeyCode key;
    public UnityEvent OnAction;

    private void Update() {
        if (Input.GetKeyDown(key))
            OnAction?.Invoke();
    }
}