using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public static int points = 0;
    public GameObject drops;
    public int remainingTime=2*60;
    public GameObject gmOver;

    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update () { 
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(h, v);
        movement.Normalize();
        GetComponent<Rigidbody2D>().velocity = movement*speed;
        if(Input.GetKeyDown("space")){
            Drop();
        }
        remainingTime = UITimeCounter.getRemaining();
    }

    private void FixedUpdate() {
        if(remainingTime==0f){
            
            this.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Food"){
            this.transform.localScale = this.transform.localScale + new Vector3(0.2f,0.2f,0f);
            PointsDisplay.addPoints();
        }
        if(other.gameObject.tag=="Obstacle"){
            if(PointsDisplay.getPoints()<5){
                //Time.timeScale = 0;
                this.gameOver();
            }
            else{
                for(int i = 0;i<5;i++){
                    PointsDisplay.subPoints();
                    this.transform.localScale = this.transform.localScale - new Vector3(0.2f,0.2f,0f);
                }
            }
        }
    }

    private void Drop(){
        if(PointsDisplay.getPoints()>0){
            PointsDisplay.subPoints();
            this.transform.localScale = this.transform.localScale - new Vector3(0.2f,0.2f,0f);
            Instantiate(drops,
                        new Vector3(this.transform.position.x,
                                    GetComponent<BoxCollider2D>().bounds.min.y,
                                    0f),
                        new Quaternion(1,0,0,0));
        }
    }

    void gameOver(){
        gmOver.SetActive(true);
        Time.timeScale = 0f;
    }

}
