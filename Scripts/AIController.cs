using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour {

    public List<GameObject> Bots;
    public GameObject Bot;

 

    // Use this for initialization
    void Start () {

        for (int i =0; i<4; i++)
        {
            Bots.Add((Instantiate(Bot, new Vector3(Random.Range(0,10), Random.Range(0 ,10), Random.Range(0, 10)), Quaternion.identity)) as GameObject);
            Bots[i].name = "Bot" + i;
            Bots[i].tag = "Bot" + i;
        }

    }
	
	// Update is called once per frame
	void Update () {
      

    }
}
