using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsDisplay : MonoBehaviour
{
    static int points;

    public static void addPoints(){
        points++;
    }
    
    public static void subPoints(){
        points--;
    }

    public static int getPoints(){
        return points;
    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(points>1){
            GetComponent<UnityEngine.UI.Text>().text = "Points: "+points.ToString();
        }
        else{
            GetComponent<UnityEngine.UI.Text>().text = "Point: "+points.ToString();
        }
        
    }
}
