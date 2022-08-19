using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Current cube game object
    [Header("Cube Object")]
    public GameObject currentCube;
    //Last cube game object
    [Header("Last Cube Object")]
    public GameObject lastCube;
    //Text object
    [Header("Text object")]
    public Text text;
    //Level number interger
    [Header("Current Level")]
    public int Level;
    //Boolean determing if game
    //is over
    [Header("Boolean")]
    public bool Done;

    //New Block function to create new blocks
    //for the game
    void Newblock()
    {
        //If the last cube is not
        //destroyed
        if(lastCube != null)
        {
            //The current cube position equals to all 3 axis positions
            //to the nearest integer
            currentCube.transform.position = new Vector3(Mathf.Round(currentCube.transform.position.x),currentCube.transform.position.y,Mathf.Round(currentCube.transform.position.z));
            //Current cube size equals to the last cube size
            if(lastCube.transform.localScale.x < Mathf.Abs(currentCube.transform.localScale.x - lastCube.transform.position.x) || lastCube.transform.localScale.z < Mathf.Abs(currentCube.transform.localScale.z - lastCube.transform.position.z))
            {
                Done = true;
                text.text = "Final Score: " + Level;
                StartCoroutine(X());
                return;
            }
            else
            {
                currentCube.transform.localScale = new Vector3(lastCube.transform.localScale.x - Mathf.Abs(currentCube.transform.position.x - lastCube.transform.position.x),
                                                           lastCube.transform.localScale.y,
                                                           lastCube.transform.localScale.z - Mathf.Abs(currentCube.transform.position.z - lastCube.transform.position.z));
            //current cubes positions equals to the current cubex x position of
            //last cubes y position 
            //z axis position of 0.5
            currentCube.transform.position = Vector3.Lerp(currentCube.transform.position, lastCube.transform.position, 0.5f) + Vector3.up * 5f;
            }

        } 

        lastCube = currentCube;
        currentCube = Instantiate(lastCube);
        currentCube.name = Level + "";
        currentCube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((Level / 100f) % 1f, 1f, 1f));
        Level++;
        text.text = "Score: " + Level;
        Camera.main.transform.position = currentCube.transform.position + new Vector3(100, 100, 100);
        Camera.main.transform.LookAt(currentCube.transform.position);

    }

    // Start is called before the first frame update
    void Start()
    {
        //New block function
        Newblock();  
        text.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //If done is true
        if(Done)
        {
            //return value
            return;
        }
        //Variable time equals to the time scine game startup
        var time = Mathf.Abs(Time.realtimeSinceStartup % 2f - 1f);
        var pos1 = lastCube.transform.position + Vector3.up * 10f;
        var pos2 = pos1 + ((Level % 2 == 0) ? Vector3.left : Vector3.forward) * 120;
        var pos3 = pos1 + ((Level % 2 ==0 ) ? Vector3.right : Vector3.back) * 120;
        if(Level % 2 == 0)
        {
            currentCube.transform.position = Vector3.Lerp(pos2, pos3, time);
        }
        else
        {
            currentCube.transform.position = Vector3.Lerp(pos3, pos2, time);
        }
        if(Input.GetMouseButtonDown(0))
        {
            Newblock();
        }
    }

    IEnumerator X()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");
    }
}
