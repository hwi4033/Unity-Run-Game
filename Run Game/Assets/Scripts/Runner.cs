using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE,
    RIGHT
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] float positionX = 2.0f;
    [SerializeField] Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    void Update()
    {
        OnKeyUpdate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void OnKeyUpdate()
    {
        if (roadLine > RoadLine.LEFT)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // if (roadLine != RoadLine.Left)
                roadLine--;
            }
        }

        if (roadLine < RoadLine.RIGHT)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // if (roadLine != RoadLine.Right)
                roadLine++;
            }
        }
    }

    void Move()
    {
        rigidBody.position = new Vector3((int)roadLine * positionX, 0, 0);
    }
}