using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D playerBod;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float playerScale = 1.7f;
    [SerializeField] private bool inair = false;
    [SerializeField] private Animator animatio;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Text scoreText;

    //Start function called when the object is instiancated
    void Start()
    {
        //Create a user defined function Setup() to set all the things up according to players convinence
        playerBod = GetComponent<Rigidbody2D>();
        animatio = GetComponent<Animator>();
        transform.localScale = new Vector3(playerScale, playerScale, playerScale);
    }

    //Update function called every frame
    private void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");

        Locomotion(hor);
        Animate(hor);

        jump();
    }

    //Locomotion function (Used Defined). This function is responsible for player movement
    void Locomotion(float hor)
    {
        if(hor != 0)
        {
            transform.Translate(Vector2.right * speed * hor * Time.deltaTime);
        }

        if (hor < 0)
        {
            transform.localScale = new Vector3(-playerScale, playerScale, playerScale);
        }

        if (hor > 0)
        {
            transform.localScale = new Vector3(playerScale, playerScale, playerScale);
        }
    }

    //Animate function (User Defined). This function is responsible for player animations
    void Animate(float hor)
    {
        if (hor != 0)
        {
            animatio.SetBool("walk", true);
        }

        else
        {
            animatio.SetBool("walk", false);
        }
    }

    //jump function (User Defined). This function is responsible for player jump and also the jump animations are handled here
    void jump()
    {
        if (Input.GetKeyDown("space") && Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer))
        {
            playerBod.velocity = new Vector2(0f, 5f);
        }
        
        else if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer))
        {
            animatio.SetBool("jumping", false);
        }

        else
        {
            animatio.SetBool("jumping", true);
        }
    }

    //UpdateScore function (Used Defined). This function is responsible for Updating the player score
    public void UpdateScore(float score)
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
