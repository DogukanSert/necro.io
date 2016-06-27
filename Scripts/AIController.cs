using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour {

    public List<GameObject> Bots;
    public GameObject Bot;

 

    // Use this for initialization
    void Start () {

        for (int i =0; i<Random.Range(1,15); i++)
        {
             Bots.Add((Instantiate(Bot, new Vector3(0, 0, 0),Quaternion.identity)) as GameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
      

    }
}
