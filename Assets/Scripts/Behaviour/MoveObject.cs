using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveObject : MonoBehaviour
{
    public Vector3 moveToPosition = new Vector3(0, 0, 60);
    public float Duration = 100;
    public float InvokeOnDoneInSeconds = 3;
    public UnityEvent OnDone;
    
    private float elapsedTime;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(InvokeOnDoneInSeconds);
        OnDone?.Invoke();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        var interpolate = elapsedTime / Duration;
        transform.position = Vector3.Lerp(transform.position, moveToPosition, interpolate);
    }
}