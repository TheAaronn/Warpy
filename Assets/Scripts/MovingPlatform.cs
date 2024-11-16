using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform target;
    public float speed = 10;
    private Vector3 posA, posB;
    public Transform playerOriginalParent;

    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            posA = transform.position;
            posB = target.position;
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }
        if (transform.position == target.position)
        {
            target.position = (target.position == posA) ? posB : posA;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFeet"))
        {
            collision.transform.parent.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFeet"))
        {
            collision.transform.parent.parent = playerOriginalParent;
        }
    }
}
