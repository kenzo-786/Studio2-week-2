using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;

    [SerializeField] float fallDelay = 1f;
    [SerializeField] float destroyDelay = 2f;

    [SerializeField] bool isFalling = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFalling)
            return;

        if (collision.transform.tag == "Player")
        {
            StartCoroutine(StartFall());
        }
    }

    private IEnumerator StartFall()
    {
        isFalling = true;

        yield return new WaitForSeconds(fallDelay);

        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
