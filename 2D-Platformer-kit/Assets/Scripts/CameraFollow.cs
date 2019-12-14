using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float linear_interpolate_speed = 1f;
    [SerializeField] private Vector3 zoffset = new Vector3(0, 0, 1);

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 playerPositionRectified = player.position - zoffset;
        transform.position = Vector3.Lerp(transform.position, playerPositionRectified, linear_interpolate_speed);
    }
}
