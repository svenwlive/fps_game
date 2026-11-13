using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public TMP_Text HealthText; 
    
    // Start is called before the first frame update
    void Start()
    {
        HealthUpdate(); //syncronize health display at start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            health--;
            HealthUpdate();
            Destroy(col.gameObject); //destroy enemy on contact after receiving damage

            if (health <= 0)
            {
                // restart same scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (col.CompareTag("Healthpack"))
        {
            health++;
            HealthUpdate();
            Destroy(col.gameObject); //destroy healthpack on contact after receiving health
        }
    }

    void HealthUpdate()
    {
        HealthText.text = "Health: " + health; //updates health display
    }
}
