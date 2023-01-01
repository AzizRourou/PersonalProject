using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeCounter : MonoBehaviour
{
    public static Text counterText;
    public static float seconds = 0f, minutes = 2f;
    public static int remainingTime = 2 * 60;

    void Start()
    {
        counterText = GetComponent<Text>() as Text;
        StartCoroutine(timer());
    }

    
    void Update()
    {
        minutes = (int)(remainingTime/60f);
        seconds = (int)(remainingTime % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    //countDown
    IEnumerator timer()
    {
        while (remainingTime > 0f)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        
    }

    public static int getRemaining(){
        return remainingTime;
    }
}
