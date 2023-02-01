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
    public float ballSpeed = 1.0f;

    private bool pressedKey = false;

    void Start()
    {
        //Y position for player's board
        yAxis = transform.position.y;
        ball = Instantiate(ballPrefab, new Vector3(0, -3.7f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(Mathf.Clamp(mousePosition.x, minX, maxX), yAxis, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            pressedKey = true;
        }
        if (pressedKey == true)
        {
            ball.transform.Translate(Vector3.up * ballSpeed * Time.deltaTime);
        }
        if (ball.transform.position.y > 6.0f)
        {
            //It may be destroy object after reaching conditional position
            pressedKey = false;
            ball = Instantiate(ballPrefab, new Vector3(0, -3.7f, 0), Quaternion.identity);
        }
    }
}
