using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstaclePositionManager : MonoBehaviour
{
    [SerializeField] Transform[] parentRoads;
    [SerializeField] float[] randomPositionZ = new float[16];

    [SerializeField] int index = -1;

    private void Awake()
    {
        for (int i = 0; i < randomPositionZ.Length; i++)
        {
            randomPositionZ[i] = i * 2.5f - 10;
        }
    }

    private void Start()
    {
        StartCoroutine(SetPosition());
    }

    private IEnumerator SetPosition()
    {
        while (true)
        {
            yield return CoroutineCache.WaitForSecond(2.5f);

            transform.localPosition = new Vector3(0, 0, randomPositionZ[Random.Range(0, randomPositionZ.Length)]);
        }        
    }

    public void InitializePosition()
    {
        index = (index + 1) % parentRoads.Length;

        transform.SetParent(parentRoads[index]);

        transform.localPosition += new Vector3(0, 0, 40);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}