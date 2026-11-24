using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        
        GameObject gmObject = GameObject.Find("GameManager");
        if (gmObject != null)
        {
            gameManager = gmObject.GetComponent<GameManager>();
        }
    }

    void Update()
    {
        
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 8f);

        
        if (transform.position.y > 6.5f)
        {
            Destroy(this.gameObject);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy") || other.GetComponent<Enemy>() != null || other.GetComponent<Enemy2>() != null)
        {
            
            if (gameManager != null)
            {
                gameManager.AddScore(1);
            }

            Destroy(other.gameObject); 
            Destroy(this.gameObject);  
        }
    }
}
