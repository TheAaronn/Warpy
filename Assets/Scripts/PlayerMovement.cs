using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour {
    public float speed = 5f;
    public float maxSpeed = 5f;
    public float jumpSpeed= 20f;
    public bool grounded = true;
    private Rigidbody2D body;
    private Animator anim;

    public LifesCounter lifesCounter;
    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update(){
        if (Input.GetKey(KeyCode.Space) && grounded){
            audioManager.PlaySFX(audioManager.jump);
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
    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "Level 2"){
            MoveToSpawnPoint();
        }
    }
    void Jump(){
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        anim.SetTrigger("jump");
        grounded = false;
    }
    private void MoveToSpawnPoint() {
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        if (spawnPoint != null) {
            transform.position = spawnPoint.transform.position;
        }
    }
    void OnBecameInvisible() {
        lifesCounter.LoseLife();
        MoveToSpawnPoint();
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Floor")
        {
            grounded = true;
        }
        else if(col.gameObject.tag == "Enemy"){
            grounded = true;
            lifesCounter.LoseLife();
            audioManager.PlaySFX(audioManager.death);
            MoveToSpawnPoint();
        }else if(col.gameObject.tag == "Water") {
            lifesCounter.LoseLife();
            audioManager.PlaySFX(audioManager.death);
            MoveToSpawnPoint();
        }else if(col.gameObject.CompareTag("Goal")){
            GameManager.Instance.Victory();
        }
    }
    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == "Floor"){
            grounded = false;
        }
    }
}

