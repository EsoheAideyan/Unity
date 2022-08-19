using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [Header("Destruction Timer")]
    //After this time, the object will be destroyed
    public float timeToDestruction = 6f/*  */;

    // Start is called before the first frame update
    void Start()
    {
        //Execute function based on timeToDestruction
        Invoke("DestroyObject", timeToDestruction);
    }

    void DestroyObject()
    {
        //Destroy GameObject
        Destroy(gameObject);
    }
}


