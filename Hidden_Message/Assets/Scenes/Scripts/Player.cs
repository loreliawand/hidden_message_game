using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject ball;

    private Vector3 mousePosition;

    private float yAxis;
    private float minX = -9f;
    private float maxX = 9f;
    private float ballSpeed = 1.0f;
    private float x;
    private float y;
    private Vector2 leftPoint;
    private Vector2 rightPoint;
    private float topPoint;

    private bool pressedKey = false;
    private bool movingUp = false;
    private bool movingRight = false;

    void Start()
    {
        //Y position for player's board
        yAxis = transform.position.y;
        ball = Instantiate(ballPrefab, new Vector2(0, -3.7f), Quaternion.identity);
        x = Random.Range(0.0f, 1.0f);
        y = Random.Range(0.0f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        leftPoint.x = mousePosition.x - 0.15f;
        leftPoint.y = yAxis;
        rightPoint.x = mousePosition.x + 0.15f;
        rightPoint.y = yAxis;
        topPoint = transform.position.y + 0.3f;

        transform.position = new Vector2(Mathf.Clamp(mousePosition.x, minX, maxX), yAxis);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressedKey = true;
            movingUp = true;
            movingRight = true;
        }

        if (ball.transform.position.y >= 4.9f)
        {
            movingUp = false;
        }
        else if ((ball.transform.position.x >= leftPoint.x && ball.transform.position.x <= rightPoint.x) && (ball.transform.position.y <= topPoint))
        {
            movingUp = true;
        }
        else if (ball.transform.position.y <= -4.9f)
        {
            Destroy(ball);
            ball = Instantiate(ballPrefab, new Vector2(0, -3.7f), Quaternion.identity);
            pressedKey = false;
        }

        if (ball.transform.position.x >= 8.75f)
        {
            movingRight = false;
        }
        else if (ball.transform.position.x <= -8.75)
        {
            movingRight = true;
        }

        if (pressedKey == true)
        {
            if (movingUp == true)
            {
                if (movingRight == true)
                {
                    Moving(x, y);
                }
                else
                {
                    Moving(-x, y);
                }
            }
            else if (movingUp == false)
            {
                if (movingRight == true)
                {
                    Moving(x, -y);
                }
                else
                {
                    Moving(-x, -y);
                }
            }
        }
    }

    private void Moving(float x, float y)
    {
        ball.transform.Translate(new Vector2(x, y) * ballSpeed * Time.deltaTime);
    }
}
