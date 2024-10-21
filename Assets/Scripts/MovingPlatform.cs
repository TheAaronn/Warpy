using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public Transform target;
    public float speed = 10;
    private Vector3 posA, posB;

    void Start() {
        if (target != null) {
            target.parent = null;
            posA = transform.position;
            posB = target.position;
        }
    }

    void FixedUpdate() {
        if (target != null) {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }
        if (transform.position == target.position) {
            target.position = (target.position == posA) ? posB : posA;
        }
    }
}
