using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GateManager : MonoBehaviour
{

    public GameObject objectToSpawn;
    public GameObject spawnPoint;
    public float spawnMultiplier;
    public float spawnForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int spawnCount = Random.Range(1, 3);
            spawnCount *= Mathf.RoundToInt(spawnMultiplier);
            Vector3 spawnPosition = spawnPoint.transform.position ; //+new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f))
            for (int i = 0; i < spawnCount; i++)
            {
                GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                // Oluþturulan yeni objeye bir güç uyguluyoruz, böylece obje hareket eder.
                spawnedObject.GetComponent<Rigidbody>().AddForce(other.transform.forward * spawnForce, ForceMode.Impulse);

                Vector3 rightVector2 = Quaternion.AngleAxis(360f, Vector3.up) * transform.forward;
                Quaternion newObjectRotation = Quaternion.LookRotation(rightVector2, Vector3.up);
                spawnedObject.transform.rotation = newObjectRotation;


                Rigidbody rigidbody = spawnedObject.GetComponent<Rigidbody>();
                //rigidbody.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
                rigidbody.velocity = transform.forward * spawnForce * 2f;
            }
        }
    }

}
