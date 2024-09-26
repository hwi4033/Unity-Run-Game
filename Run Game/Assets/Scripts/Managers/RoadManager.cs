using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadManager : State
{
    [SerializeField] List<GameObject> roads;

    [SerializeField] int createCount = 4;
    [SerializeField] float offset = 40.0f;

    [SerializeField] SpeedManager speedManager;

    // Start is called before the first frame update
    void Start()
    {
        roads.Capacity = 10;

        AddRoad();
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
        if (state == false) return;

        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * speedManager.Speed * Time.deltaTime);
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