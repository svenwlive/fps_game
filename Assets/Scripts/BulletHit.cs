using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float lifeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime); //when bullet is spawned, it destroys itself after lifeTime seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        // destroy bullet always
        Destroy(gameObject);
        
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
        }
    }

}
