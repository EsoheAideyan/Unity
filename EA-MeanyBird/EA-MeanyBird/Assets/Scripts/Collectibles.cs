﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    //If an object collides with  trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Add score
        Score.score++;
    }
}
