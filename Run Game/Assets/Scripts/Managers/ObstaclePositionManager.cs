using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstaclePositionManager : MonoBehaviour
{
    [SerializeField] Transform[] positionX;
    [SerializeField] Transform[] parentRoads;
    [SerializeField] ObstacleManager obstacleManager;

    [SerializeField] bool state = false;
    [SerializeField] int index = -1;
    [SerializeField] float[] randomPositionZ = new float[16];

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

            if (state == true)
            {
                obstacleManager.GetObstacle().SetActive(true);

                obstacleManager.GetObstacle().transform.position = transform.localPosition;

                obstacleManager.GetObstacle().transform.position = positionX[Random.Range(0, positionX.Length)].position;

                obstacleManager.GetObstacle().transform.SetParent(transform.root.GetChild(index));
            }
        }
    }

    public void InitializePosition()
    {
        state = true;

        index = (index + 1) % parentRoads.Length;

        transform.SetParent(parentRoads[index]);

        transform.localPosition += new Vector3(0, 0, 40);
    }
}