using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D spawnArea;
    public BoxCollider2D player;
    
    private void RandomizePosition(){
        Bounds bounds = this.spawnArea.bounds;
        Bounds forbidden = this.player.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        while(x<=forbidden.max.x+2f && x>=forbidden.min.x-2f && y<=forbidden.max.y+2f && y>=forbidden.min.y-2f){
            x = Random.Range(bounds.min.x, bounds.max.x);
            y = Random.Range(bounds.min.y, bounds.max.y);
        }
        this.transform.position = new Vector3(x, y, 0.0f);
    }

    void Start()
    {
        RandomizePosition();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
            RandomizePosition();
        }
    }


}
