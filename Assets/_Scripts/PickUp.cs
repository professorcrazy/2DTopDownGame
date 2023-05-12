using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int pointValue;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            ScoreManager.Instance.UpdateScore(pointValue);
            Destroy(this.gameObject);
        }
    }
}
