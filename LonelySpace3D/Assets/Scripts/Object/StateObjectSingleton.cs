using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StateObjectSingleton : MonoBehaviour
{
    private static StateObjectSingleton instance;
    private Dictionary<GameObject, bool > stateObject = new Dictionary<GameObject, bool>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static StateObjectSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StateObjectSingleton>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("InterfaceSingleton");
                    instance = singletonObject.AddComponent<StateObjectSingleton>(); 
                }
            }
            return instance;
        }
    }
    public void AddNewObjectInDictionary(GameObject obj, bool isObjectUp)
    {
        if (!stateObject.ContainsKey(obj))
            stateObject[obj] = isObjectUp;
        else
            stateObject[obj] = isObjectUp;

        Debug.Log($"Add new object: {obj}, state: {isObjectUp}");
    }
    public bool GetObjectState(GameObject obj)
    {
        if (stateObject.ContainsKey(obj))
        {
            return stateObject[obj];
        }
        return false;
    }
}
