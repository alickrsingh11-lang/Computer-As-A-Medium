using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float speed = 3f;

    void Update()
    {
        
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);

        
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ActivateShield();
            }

           
            Destroy(this.gameObject);
        }
    }
}
