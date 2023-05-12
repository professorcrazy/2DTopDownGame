using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {
        collision.GetComponent<PlayerController>()?.KillPlayer();
        /*if (collision.CompareTag("Player")) {

        }*/
        Destroy(gameObject);
    }

}
