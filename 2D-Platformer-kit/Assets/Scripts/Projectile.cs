using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    [SerializeField] private float Damage = 1.0f;
    [SerializeField] private float projectileSpeed = 5f;

    private void Start()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.Translate(-Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D objecthitted)
    {
        if (objecthitted.CompareTag("Player"))
        {
            Player playerScript = objecthitted.transform.GetComponent<Player>();
            playerScript.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}

/* NOTES : 
 * Add explosion animation
 * 
 * 
 * 
*/
