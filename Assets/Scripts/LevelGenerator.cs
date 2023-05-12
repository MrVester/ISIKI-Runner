using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // const float defaultRot = 11.25f;

    public float offsetBetweenInstances = 0.1f;
    public GameObject[] levelPrefabs;
    public int startTonnelAmount = 7;
    public int startDefaultTonnelAmount = 4;
    public List<GameObject> instances;
    private int randomPrefab;
    private int randomAngle;


    // Start is called before the first frame update
    void Start()
    {
        //Generate first 7 tonnels
        for (int i = -1; i < startTonnelAmount - 1; i++)
        {
            randomAngle = Random.Range(0, 7) * 45;
            if (i >= -1 && i <= startDefaultTonnelAmount)
            {
                randomPrefab = 0;
            }
            else
            {
                randomPrefab = Random.Range(0, levelPrefabs.Length);
            }

            instances.Add(Instantiate(levelPrefabs[randomPrefab], new Vector3(0, 0, i * 20), Quaternion.Euler(new Vector3(0, 0, levelPrefabs[randomPrefab].transform.rotation.eulerAngles.z + randomAngle))));


        }

        foreach (GameObject gameObject in instances)
        {
            gameObject.AddComponent<AddForce>();
            gameObject.AddComponent<TriggerEnter>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (instances.Count != 0 && instances[0].transform.position.z < -40)
        {
            randomAngle = Random.Range(0, 7) * 45;
            randomPrefab = Random.Range(0, levelPrefabs.Length);
            float posZofLastInstance = instances[instances.Count - 1].transform.position.z;
            float offset = instances[0].GetComponent<AddForce>().speed;
            instances.Add(Instantiate(levelPrefabs[randomPrefab], new Vector3(0, 0, posZofLastInstance + 20 - offset), Quaternion.Euler(new Vector3(0, 0, /*defaultRot*/levelPrefabs[randomPrefab].transform.rotation.eulerAngles.z + randomAngle))));
            instances[instances.Count - 1].AddComponent<AddForce>();
            instances[instances.Count - 1].AddComponent<TriggerEnter>();
            Destroy(instances[0]);
            instances.RemoveAt(0);
        }
    }
}
