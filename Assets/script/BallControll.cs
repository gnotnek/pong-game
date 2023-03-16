using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    //rigid bola
    private Rigidbody2D rigidBody2d;

    //besarnya gaya awal yang diberikan
    public float xInitialForce;
    public float yInitialForce;

    //titik asal lintasan
    private Vector2 trajectoryOrigin;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        Invoke("pushBall", 2);
        trajectoryOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resetBall(){
        //reset posisi
        transform.position = Vector2.zero;
        //reset kecepatan
        rigidBody2d.velocity = Vector2.zero;
    }

    void pushBall(){
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rigidBody2d.AddForce(new Vector2(20, -15));
        } else {
            rigidBody2d.AddForce(new Vector2(-20, -15));
        }
    }

    void restartGame(){
        resetBall();
        Invoke("pushBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = rigidBody2d.velocity.x;
            vel.y = (rigidBody2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rigidBody2d.velocity = vel;
        }
    }

    void onCollutionExit2D(Collision2D coll){
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin{
        get {return trajectoryOrigin;}
    }
}
