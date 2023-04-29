using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    public GameObject solider;
    
    void Start()
    {
         
            InvokeRepeating("Spawn", 0f, 1f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        GameObject newObject = Instantiate(solider, transform.position, Quaternion.identity);
        newObject.transform.parent = transform;
        transform.Translate(0f, 0f, speed * Time.deltaTime);
    }
}
