using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float maxSpeed = 30f;
    public float minSpeed = 7f;
    public float minY = -5.2f;
    public float maxY = 8.4f;
    public float x = 50f;

    private void Start() {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-Random.Range(minSpeed,maxSpeed),0f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Respawn"){
            if(x>20){
                x--;
            }
            this.GetComponent<Rigidbody2D>().MovePosition(new Vector3(x, Random.Range(minY,maxY),0f));
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-Random.Range(minSpeed,maxSpeed),0f);
        }
    }

}
