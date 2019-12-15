﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    [SerializeField] private float Damage = 5.0f;

    private void Start()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.Translate(-Vector2.right * 1f * Time.deltaTime);
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