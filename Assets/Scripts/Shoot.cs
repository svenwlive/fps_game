using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //when left mouse button is clicked
        {
            GameObject b = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation); //spawn bullet at shootPoint position and rotation
            b.GetComponent<Rigidbody>().velocity = shootPoint.forward * speed; //set bullet velocity forward based on shootPoint forward direction and speed
        }
    }
}
