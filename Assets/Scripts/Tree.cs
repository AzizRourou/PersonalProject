using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public Vector3 spawnPos = new Vector3(50f,0f,0f);
    //public BoxCollider2D respawnTrigger;
    public float speed = 5;
    

    private void Start() {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed,0f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        this.GetComponent<Rigidbody2D>().MovePosition(spawnPos);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Drops"){
            ScoreDisplay.addScore();
            Destroy(other.gameObject);
        }
    }

}
