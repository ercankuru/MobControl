using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject playerSpawn;
    public GameObject playerPrefab;
    public GameObject newObjectPrefab;
    public float spawnRate = 1f;
    public float speed = 5f;

    private float spawnTimer = 0f;
    private bool isMouseDown = false;

    private void Update()
    {
        // Sol fare tu�una bas�ld�ysa yeni nesne olu�tur
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            SpawnNewObject();
        }

        // Sol fare tu�u b�rak�ld�ysa yeni nesne olu�turmay� durdur
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }

        // Sol fare tu�u bas�l� tutuluyorsa Player nesnesini hareket ettir
        if (isMouseDown)
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            float movementDistance = horizontalInput * speed * Time.deltaTime;
            transform.position += new Vector3(movementDistance, 0f, 0f);
        }

        // Her spawnRate saniyede bir yeni nesne olu�tur
        if (isMouseDown)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRate)
            {
                SpawnNewObject();
                spawnTimer = 0f;
            }
        }
    }

    // Yeni nesne olu�tur ve Player nesnesinin 90 derece sa��nda yerle�tir
    private void SpawnNewObject()
    {
        // Player nesnesinin d�n���n� al
        Quaternion rotation = transform.rotation;

        // Yatay eksen etraf�nda 90 derece sa�a d�n��t�r
       // Vector3 rightVector = Quaternion.AngleAxis(-90f, Vector3.up) * transform.forward;
        //Vector3 rightVector2 = Quaternion.AngleAxis(0f, Vector3.up) * transform.forward;

        // Yeni nesne olu�tur ve konumunu belirle
        GameObject newObject = Instantiate(newObjectPrefab);
        newObject.transform.position = playerSpawn.transform.position ;
        newObject.transform.rotation = rotation;
        // Yeni nesnenin y�n�n� belirle
        //Quaternion newObjectRotation = Quaternion.LookRotation(rightVector2, Vector3.up);
        //newObject.transform.rotation = newObjectRotation;


        // Yeni nesneyi hareket ettir
        Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }
}


    


    

