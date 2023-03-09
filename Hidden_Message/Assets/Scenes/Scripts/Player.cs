using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject ball;
    private Ball _ball_script;

    private Vector3 _mousePosition;

    private float _yAxis;
    private float _minX = -9f;
    private float _maxX = 9f;
    internal Vector2 leftPoint;
    internal Vector2 rightPoint;
    internal float topPoint;

    private bool _pressedKey = false;

    void Start()
    {
        //Y position for player's board
        _yAxis = transform.position.y;
        ball = Instantiate(ballPrefab, new Vector2(0, -3.7f), Quaternion.identity);
        _ball_script = GameObject.Find("Ball_prefab(Clone)").GetComponent<Ball>();

    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        leftPoint.x = _mousePosition.x - 0.15f;
        leftPoint.y = _yAxis;
        rightPoint.x = _mousePosition.x + 0.15f;
        rightPoint.y = _yAxis;
        topPoint = transform.position.y + 0.3f;

        transform.position = new Vector2(Mathf.Clamp(_mousePosition.x, _minX, _maxX), _yAxis);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _pressedKey = true;
            _ball_script.movingUp = true;
            _ball_script.movingRight = true;
        }

        if (ball.transform.position.y <= -4.9f)
        {
            Destroy(ball);
            ball = Instantiate(ballPrefab, new Vector2(0, -3.7f), Quaternion.identity);
            _pressedKey = false;
        }

        if (_pressedKey == true)
        {
            _ball_script.Ball_movement();
        }
    }
}
