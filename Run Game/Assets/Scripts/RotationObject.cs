using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    [SerializeField] float speed = 150f;

    public float Speed
    {
        get { return speed; }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime , 0);
    }
}