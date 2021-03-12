using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<GameObject> objects = new List<GameObject>(); // game objects to pool
    private List<List<GameObject>> pool = new List<List<GameObject>>(); // the pool
    [SerializeField] int amount; // number of each object to pool
    int maxAmount;
    // Start is called before the first frame update
    void Start()
    {
        maxAmount = amount * 2;
        pool.Clear();
        SpawnPoolObjects();
    }
    // spawn all the pools objects
    void SpawnPoolObjects()
    {
        // for every object in the pool
        for (int i = 0; i < objects.Count; i++)
        {
            // make a list of the object
            List<GameObject> objList = new List<GameObject>();
            // created object instances equal to count
            for (int j = 0; j < amount; j++)
            {
                // fill the list with the instantiated objects
                GameObject obj = Instantiate(objects[i], transform);
                obj.SetActive(false);
                objList.Add(obj);
            }
            // add the objects to the pool
            pool.Add(objList);
        }
    }

    public GameObject GetGameObject(int objectIndex)
    {
        if (objectIndex >= objects.Count)
        {
            Debug.LogError("pool object index out of range");
            return null;
        }
        GameObject obj = null;
        // find the first in active object in the pool
        for (int i = 0; i < pool[objectIndex].Count; i++)
        {
            if (!pool[objectIndex][i].activeSelf)
            {
                obj = pool[objectIndex][i];
                obj.SetActive(true);
                break;
            }
        }
        // if obj is null all pool objects should be active
        if (obj == null)
        {
            if (pool[objectIndex].Count < maxAmount)
            {
                Debug.LogWarning(objects[objectIndex].name + " Attempting to add to pool");
                // fill the list with the instantiated objects
                obj = Instantiate(objects[objectIndex], transform);
                obj.SetActive(true);
                pool[objectIndex].Add(obj);
            }
            else
            {
                Debug.LogError(objects[objectIndex].name + " Object pool full");
            }
        }
        return obj;
    }
    public GameObject GetGameObject(GameObject obj)
    {
        if (!objects.Contains(obj))
        {
            Debug.LogError("Pool doesn't have matching game object!");
            return null;
        }
        return GetGameObject(objects.IndexOf(obj));
    }
}
