using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private void Start()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * -10.0f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if (collision.CompareTag("Enemy"))
        {
            PlantEnemy scriptrefrence = collision.transform.GetComponent<PlantEnemy>();
            scriptrefrence.Death();
        }
    }
}
