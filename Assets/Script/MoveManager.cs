using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    Rigidbody rigi;
    bool left;
    bool right;

    [SerializeField] private float speed = 5f; // ileri gittimizde kullaca��z. 


    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // �leri gitmek i�in kullan�labilir. 
        
        //transform.Translate(0f, 0f, speed * Time.deltaTime);

        // Sa�a ve sola hareket

        Vector3 goRight = new Vector3(1f, transform.position.y, transform.position.z);
        Vector3 goLeft = new Vector3(-1.11f, transform.position.y, transform.position.z);


        if (Input.touchCount > 0)
        {

            
            Touch movement = Input.GetTouch(0);

            if (movement.deltaPosition.x > 5f)
            {
                right = true;
                left = false;
            }

            if (movement.deltaPosition.x < -5f)
            {
                right = false;
                left = true;

            }

            if (right == true)
            {
                transform.position = Vector3.Lerp(transform.position, goRight, 5 * Time.deltaTime);

                // sa� : 5.42  sol: 3.81

            }
            if (left == true)
            {
                transform.position = Vector3.Lerp(transform.position, goLeft, 5 * Time.deltaTime);

                // sa� : 5.42  sol: 3.81

            }
        }




    }
}
