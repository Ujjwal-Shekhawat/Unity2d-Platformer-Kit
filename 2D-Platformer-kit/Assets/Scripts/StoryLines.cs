using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryLines : MonoBehaviour
{

    [SerializeField] private string SayHere;
    [SerializeField] private Text storyText;
    [SerializeField] private float timeBeforeDisappear = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            storyText.text = "Story : \n" + SayHere.ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Completed(timeBeforeDisappear));
        }
    }

    IEnumerator Completed(float Waitingtime)
    {
        yield return new WaitForSeconds(Waitingtime);
        storyText.text = "";
        Destroy(gameObject);
    }
}

/* NOTES : 
 * Add string which can be modified by the user so that the user can create his custom story mode
 * 
 * 
 * 
 * 
*/

