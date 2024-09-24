using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;

    [SerializeField] int createCount = 4;
    [SerializeField] float offset = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        roads.Capacity = 10;

        AddRoad();

        StartCoroutine(SpeedManager.Instance.Increase());
    }

    void AddRoad()
    {
        for (int i = 0; i < createCount; i++)
        {
            roads.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * SpeedManager.Instance.Speed * Time.deltaTime);
        }
    }

    public void NewPosition()
    {
        GameObject newRoad = roads[0];

        roads.Remove(newRoad);

        float newZ = roads[roads.Count - 1].transform.position.z + offset;

        newRoad.transform.position = new Vector3(0, 0, newZ);

        roads.Add(newRoad);       
    }
}