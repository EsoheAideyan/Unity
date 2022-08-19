using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls: MonoBehaviour
{
    //Timer text object
    private Text timerText;
    //Timer counter for adding score
    private int timerCount;

    // Start is called before the first frame update
    void Start()
    {
        //Game is at a playing state
        Time.timeScale = 1f;
        //Executing a courtine
        StartCoroutine(CountTime());
        //Timer text equals finding
        //the score object and using
        //the text component
        timerText = GameObject.Find("Score").GetComponent<Text>();
    }

   IEnumerator CountTime()
   {
       //After 1 second
       //1 point is added to the score
       //and will repeat the function
       yield return new WaitForSeconds(1f);
       timerCount++;
       timerText.text = "Score: " + timerCount;
       StartCoroutine(CountTime());
   }
}
