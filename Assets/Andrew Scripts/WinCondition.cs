using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Win1")
        {
            SceneManager.LoadScene("level 2");
        }
        if (collision.gameObject.tag == "Win2")
        {
            SceneManager.LoadScene("Main menu");
        }
    }
}
