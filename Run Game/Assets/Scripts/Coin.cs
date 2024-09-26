using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : State, IColliderable
{
    [SerializeField] float speed;
    [SerializeField] GameObject rotationObject;

    public void Activate()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnEnable()
    {
        base.OnEnable();

        rotationObject = GameObject.Find("RotationGameObject");

        speed = rotationObject.GetComponent<RotationObject>().Speed;

        transform.localRotation = rotationObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == false) return;

        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}