using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private GameObject leftEdge;
    [SerializeField] private GameObject rightEdge;

    [Header("Enemy")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Transform currentPoint;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = rightEdge.transform;
        anim.SetBool("Moving", true);
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == rightEdge.transform)
        {
            rb.velocity = new Vector2(-speed, 0);
            
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == rightEdge.transform)
        {
            flip();
            currentPoint = leftEdge.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == leftEdge.transform)
        {
            flip();
            currentPoint = rightEdge.transform;
        }
    }
    
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}