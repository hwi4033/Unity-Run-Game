using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour, IColliderable
{
    [SerializeField] float speed;
    [SerializeField] GameObject rotationObject;

    [SerializeField] ParticleSystem particleSystem;

    public void Activate()
    {
        particleSystem.Play();

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnEnable()
    {
        rotationObject = GameObject.Find("RotationGameObject");

        speed = rotationObject.GetComponent<RotationObject>().Speed;

        transform.localRotation = rotationObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
