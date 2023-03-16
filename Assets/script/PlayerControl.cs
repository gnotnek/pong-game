using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //tombol up, down
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;

    //speed
    public float speed = 10.0f;

    //batas atas dan bawah
    public float yBoundary = 9.0f;

    //Rigidbody 2D raket
    private Rigidbody2D rigidBody2d;

    //score
    private int score;

    //last hit
    private ContactPoint2D lastContactPoint;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidBody2d.velocity;

        if(Input.GetKey(upButton)){
            velocity.y = speed;
        } else if (Input.GetKey(downButton)){
            velocity.y = -speed;
        } else {
            velocity.y = 0.0f;
        }

        rigidBody2d.velocity = velocity;

        Vector3 position = transform.position;
        
        if (position.y > yBoundary){
            position.y = yBoundary;
        } else if(position.y < -yBoundary){
            position.y = -yBoundary;
        }

        transform.position = position;
    }

    public void incScore(){
        score++;
    }

    public void resetScore(){
        score = 0;
    }

    public int Score{
        get { return score; }
    }

    public ContactPoint2D lastContact{
        get { return lastContactPoint; }
    }

    void onCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name.Equals("Ball")){
            lastContactPoint = collision.GetContact(0);
        }
    }
}
