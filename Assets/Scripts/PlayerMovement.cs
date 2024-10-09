using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public float speed = 5f;
    public float maxSpeed = 5f;
    public float jumpSpeed= 20f;
    private Rigidbody2D body;
    private Animator anim;

    private void Start(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update(){
        //body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
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
        if (Input.GetKey(KeyCode.Space)){
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
        // Flip
        if (h > 0.01f){
            transform.localScale = Vector3.one;
        } else if (h < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        anim.SetBool("Run", h != 0);
    }
}
