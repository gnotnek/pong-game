using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //player 1
    public PlayerControl player1;
    private Rigidbody2D player1Rigidbody;

    //player 2
    public PlayerControl player2;
    private Rigidbody2D player2Rigidbody;

    //ball
    public BallControll ball;
    private Rigidbody2D ballRigidbody;
    private CircleCollider2D ballCollider;

    //score max
    public int maxScore;

    //debug window show
    private bool isDebugWindowShown = false;

    // Start is called before the first frame update
    void Start()
    {
        player1Rigidbody = player1.GetComponent<Rigidbody2D>();
        player2Rigidbody = player2.GetComponent<Rigidbody2D>();
        ballRigidbody = ball.GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI() {
        //tampilan skor p1 kiri, p2 kanan
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100),""+player1.Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 - 12, 20, 100, 100),""+player2.Score);

        if(GUI.Button(new Rect(Screen.width / 2 -60, 35, 120, 153), "RESTART")){
            player1.resetScore();
            player2.resetScore();

            ball.SendMessage("restartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if(player1.Score == maxScore){
            GUI.Label(new Rect(Screen.width / 2 -150, Screen.height/2-10, 2000, 1000), "PLAYER 1 WINS");

            ball.SendMessage("resetBall", null, SendMessageOptions.RequireReceiver);
        }
        if (player2.Score == maxScore){
            GUI.Label(new Rect(Screen.width / 2 +30, Screen.height/2-10, 2000, 1000), "PLAYER 2 WINS");

            ball.SendMessage("resetBall", null, SendMessageOptions.RequireReceiver);
        }
    
        if(isDebugWindowShown){
            Color oldColor = GUI.backgroundColor;;
            GUI.backgroundColor = Color.red; 
        }
    }
}
