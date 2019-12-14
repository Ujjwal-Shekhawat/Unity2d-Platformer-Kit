using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Collectible : MonoBehaviour
{


    [SerializeField] private static float score = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player playerScript = collision.transform.GetComponent<Player>();
            playerScript.UpdateScore(score);
            score++;
            Destroy(gameObject);
        }
    }
}
