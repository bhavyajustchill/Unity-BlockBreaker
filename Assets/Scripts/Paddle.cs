using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float minX, maxX;
    public bool autoPlay = false;

    private Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = Object.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
        
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        this.transform.position = paddlePos;
    }
}
