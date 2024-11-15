using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float speed = 5f;
    public float maxSpeed = 5f;
    public float jumpSpeed= 20f;
    public bool grounded = true;
    private Rigidbody2D body;
    private Animator anim;

    private void Start(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update(){
        if (Input.GetKey(KeyCode.Space) && grounded){
            Jump();
        }
        // Variables for jump animation
        anim.SetBool("grounded", grounded);
    }
    private void FixedUpdate(){
        float h = Input.GetAxis("Horizontal");
        body.AddForce(Vector2.right * speed * h);
        if(body.velocity.x > maxSpeed){
            body.velocity = new Vector2(maxSpeed, body.velocity.y);
        }
        if(body.velocity.x < -maxSpeed){
            body.velocity = new Vector2(-maxSpeed, body.velocity.y);
        }
        // Flip
        if (h > 0.01f){
            transform.localScale = Vector3.one;
        } else if (h < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        anim.SetBool("run", h != 0);
    }
    void Jump(){
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        anim.SetTrigger("jump");
        grounded = false;
    }
    void OnBecameInvisible() {
        transform.position = new Vector3(-5, -3, 0);
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Floor")
        {
            grounded = true;
        }
        else if(col.gameObject.tag == "Enemy")
        {
            grounded = true;
            transform.position = new Vector3(-5, -3, 0);
            body.velocity = new Vector2(0, 0);
            Debug.Log("Vida menos");
        }
    }
    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == "Floor"){
            grounded = false;
        }
    }
}

