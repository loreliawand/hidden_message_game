using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mousePosition;
    float yAxis;
    float minX = -9f;
    float maxX = 9f;
    void Start()
    {
        yAxis = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(Mathf.Clamp(mousePosition.x, minX, maxX), yAxis, 0f);
    }
}
