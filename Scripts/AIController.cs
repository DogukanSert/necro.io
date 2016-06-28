using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour {

    public List<GameObject> Bots;
    public GameObject Bot;

 

    // Use this for initialization
    void Start () {

        for (int i =0; i<10; i++)
        {
             Bots.Add((Instantiate(Bot, new Vector3(Random.Range(1,6), Random.Range(1, 6), Random.Range(1, 6)), Quaternion.identity)) as GameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
      

    }
}
