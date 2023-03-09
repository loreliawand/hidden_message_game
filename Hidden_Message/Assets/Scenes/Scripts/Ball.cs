using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Player player;
    public float ballSpeed = 1.0f;
    internal float x;
    internal float y;
    internal bool movingUp = false;
    internal bool movingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        x = Random.Range(0.0f, 1.0f);
        y = Random.Range(0.0f, 1.0f);
    }
    // Update is called once per frame
    void Update()
    {

    }

    internal void Ball_movement()
    {
        if (transform.position.y >= 4.9f)
        {
            movingUp = false;
        }
        else if ((transform.position.x >= player.leftPoint.x && transform.position.x <= player.rightPoint.x) && (transform.position.y <= player.topPoint))
        {
            movingUp = true;
        }

        if (transform.position.x >= 8.75f)
        {
            movingRight = false;
        }
        else if (transform.position.x <= -8.75f)
        {
            movingRight = true;
        }

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

    internal void Moving(float x, float y)
    {
        transform.Translate(new Vector2(x, y) * ballSpeed * Time.deltaTime);
    }
}

