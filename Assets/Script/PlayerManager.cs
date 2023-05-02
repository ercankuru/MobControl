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
        // Sol fare tuþuna basýldýysa yeni nesne oluþtur
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            SpawnNewObject();
        }

        // Sol fare tuþu býrakýldýysa yeni nesne oluþturmayý durdur
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }

        // Sol fare tuþu basýlý tutuluyorsa Player nesnesini hareket ettir
        if (isMouseDown)
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            float movementDistance = horizontalInput * speed * Time.deltaTime;
            transform.position += new Vector3(movementDistance, 0f, 0f);
        }

        // Her spawnRate saniyede bir yeni nesne oluþtur
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

    // Yeni nesne oluþtur ve Player nesnesinin 90 derece saðýnda yerleþtir
    private void SpawnNewObject()
    {
        // Player nesnesinin dönüþünü al
        //Quaternion rotation = transform.rotation;

        // Yatay eksen etrafýnda 90 derece saða dönüþtür
       // Vector3 rightVector = Quaternion.AngleAxis(-90f, Vector3.up) * transform.forward;
        //Vector3 rightVector2 = Quaternion.AngleAxis(0f, Vector3.up) * transform.forward;



        // Yeni nesne oluþtur ve konumunu belirle
        GameObject newObject = Instantiate(newObjectPrefab);
        newObject.transform.position = playerSpawn.transform.position ;



       // newObject.transform.rotation = rotation;
        // Yeni nesnenin yönünü belirle
        //Quaternion newObjectRotation = Quaternion.LookRotation(rightVector2, Vector3.up);
        //newObject.transform.rotation = newObjectRotation;



        // Yeni nesneyi hareket ettir
        
        Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed * 2f;

    }





}


    


    

