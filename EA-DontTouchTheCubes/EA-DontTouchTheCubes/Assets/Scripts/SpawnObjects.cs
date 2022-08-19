using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [Header("spawn Cube Object")]
    //Cube that is going to be spawn
    public GameObject spawnCube;
    //difficulty of the game
    [Header("Default Difficulty")]
    public float difficulty = 40f;
    //Time for the next cube
    //to be spawned.
    float spawn;

    // Update is called once per frame
    void Update()
    {
        //The next cube to be spawn will
        //be based on the difficulty and
        //game speed
        spawn = difficulty * Time.deltaTime;
        //Difficulty of the game is based of
        //Speed of the game times 4
        difficulty = Time.deltaTime * 4;
        //While loop for spawning cubes.
        //If the spawn time is greater
        //than 0
        while (spawn > 0)
        {
            //Spawn time minus 1
            spawn -= 1;
            //Random position of the cubes on the x ans z axis
            Vector3 v3Pos = transform.position + new Vector3(Random.value * 40f - 20f, 0, Random.value * 40f - 20f);
            //Random rotation of the cubes on the x and z axis
            Quaternion qRotation = Quaternion.Euler(0, Random.value * 360f, Random.value * 30f);
            //Random scale of the cubes on the x and z axis
            GameObject createObject = Instantiate(spawnCube, v3Pos, qRotation);
        }

    }
}
