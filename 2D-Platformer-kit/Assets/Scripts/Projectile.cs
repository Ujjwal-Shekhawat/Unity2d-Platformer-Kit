using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    [SerializeField] private float Damage = 1.0f;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private float seconds_of_projectile_inactivity = 0.2f;

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
        StartCoroutine(SafetyMeasures(objecthitted));
    }

    IEnumerator SafetyMeasures(Collider2D refrenceObject)
    {
        yield return new WaitForSeconds(seconds_of_projectile_inactivity);
        if (refrenceObject.CompareTag("Player"))
        {
            Player playerScript = refrenceObject.transform.GetComponent<Player>();
            playerScript.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}

/* NOTES : 
 * Add explosion animation | Thinking
 * 
 * 
 * 
*/
