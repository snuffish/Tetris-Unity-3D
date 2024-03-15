using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class Test : MonoBehaviour {
    private SplineAnimate _splineAnimate;
    private SplineContainer _splineContainer;

    public Transform A;
    public Transform B;

    public Transform BulletPrefab;

    public float fireRate = .5f;
    public float elapsedTime;
    private Transform _gun;

    private void Awake() {
        _splineAnimate = GetComponent<SplineAnimate>();
        _splineContainer = _splineAnimate.Container;
        _gun = A.Find("Gun");
    }

    private void Start() {
        InvokeRepeating("FireGun", 3f, .5f);
    }

    private void FireGun() {
        Instantiate(BulletPrefab, _gun.position + _gun.up, Quaternion.identity);
    }

    private void Update() {
        A.LookAt(B);

        // elapsedTime += Time.deltaTime;
        // if (elapsedTime >= fireRate) {
        //     var gun = A.Find("Gun");
        //     Instantiate(BulletPrefab, gun.position + gun.up, Quaternion.identity);
        //     elapsedTime = 0;
        // }

        B.GetOrAddComponent<MovingObject>();
    }
}

internal class MovingObject : MonoBehaviour {
    private float _elapsedTime;
    private Vector3 target = new Vector3(10, 0);

    private void Update() {
        _elapsedTime += Time.deltaTime;
        
        var moveToPos = Vector3.Lerp(transform.position, target, Time.deltaTime);
        transform.position = moveToPos;

        // Debug.Log($"moveToPos:{moveToPos}");
        // Debug.Log($"elapsedTime:{_elapsedTime}");

        if (transform.position == moveToPos) {
            Debug.Log("KLAAAR!");
        }

        // if (_elapsedTime >= 5) {
        //     _elapsedTime = 0;
        //     target = new Vector3(-10, 0);
        // }
    }
}