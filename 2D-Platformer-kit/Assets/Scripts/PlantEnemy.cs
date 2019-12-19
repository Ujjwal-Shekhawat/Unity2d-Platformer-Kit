using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Component sensingRange;
    [SerializeField] private enum state { normal, alerted};
    [SerializeField] private float attackspeed;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Animator animatio;
    [SerializeField] private float bouncines;
    [SerializeField] private GameObject deathEffect;

    state sense;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        attackspeed = 0.3f;
        bouncines = 150.0f;
        projectile = Resources.Load("PlantBullet") as GameObject;
        deathEffect = Resources.Load("enemyDeath") as GameObject;
        animatio = GetComponent<Animator>();
        sensingRange = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Turn();

        if (sense == state.alerted)
        {
            animatio.SetBool("Attack", true);
        }

        else
        {
            animatio.SetBool("Attack", false);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sense = state.alerted;
            StartCoroutine(Attack(attackspeed));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sense = state.normal;
            StopAllCoroutines();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bouncines);
            Destroy(Instantiate(deathEffect, transform.position, transform.rotation), 0.5f);
            Destroy(gameObject);
        }
    }

    void Turn()
    {
        float distancediffrence = transform.position.x - playerTransform.position.x;

        if (distancediffrence > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    IEnumerator Attack(float attacktimegap)
    {
        yield return new WaitForSeconds(attacktimegap);
        Instantiate(projectile, transform.position, transform.rotation);
        StartCoroutine(Attack(attacktimegap));
    }


}

/* NOTES : 
 * Add umm ... maybe a Death Animation | I think i will skip that
 * 
 * 
 * 
*/
