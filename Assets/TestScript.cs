using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class MyIntEvent : UnityEvent<int>
{

}

public class TestScript : MonoBehaviour
{
    public UnityEvent myTestEvent;
}
