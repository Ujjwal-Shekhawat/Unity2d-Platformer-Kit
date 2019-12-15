using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float linear_interpolate_speed = 1f;
    [SerializeField] private Vector3 zoffset = new Vector3(0, 0, 1);
    [SerializeField] private float randomForPerlinPositive = -0.001f, randomForPerlinNegative = 0.001f; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 playerPositionRectified = player.position - zoffset;
        transform.position = Vector3.Lerp(transform.position, playerPositionRectified, linear_interpolate_speed);
    }

    public void Shake()
    {
        transform.position = transform.position + new Vector3(Mathf.PerlinNoise(Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive), Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive)), Mathf.PerlinNoise(Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive), Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive)), 0);
        transform.position = player.position;
        transform.position = transform.position + new Vector3(Mathf.PerlinNoise(Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive), Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive)), Mathf.PerlinNoise(Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive), Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive)), 0);
        transform.position = player.position;
        transform.position = transform.position + new Vector3(Mathf.PerlinNoise(Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive), Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive)), Mathf.PerlinNoise(Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive), Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive)), 0);
        transform.position = player.position;
        transform.position = transform.position + new Vector3(Mathf.PerlinNoise(Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive), Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive)), Mathf.PerlinNoise(Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive), Random.RandomRange(randomForPerlinNegative, randomForPerlinPositive)), 0);
        transform.position = player.position;

        //Not in mood to add actual shake effect sorry guys
    }
}

/* NOTES : 
 * This script is completed
 * My be i will think of adding some more functionality
 * Camera shake can be addd
 * Some camera effects can be added
*/
