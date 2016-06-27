using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BotController : MonoBehaviour {
    private Vector2 way;
    public List<GameObject> Skeletons;
    public GameObject Skeleton;
    private int skeletonCount;

    // Use this for initialization
    void Start () {
        skeletonCount = Random.Range(1, 15);
        way = new Vector2(Random.Range(-6, 6), Random.Range(-6, 6));
        for (int i = 0; i < skeletonCount; i++)
        {
            Skeletons.Add((Instantiate(Skeleton, new Vector2(transform.position.x, transform.position.y), Quaternion.identity)) as GameObject);
           
        }
    }
	
	// Update is called once per frame
	void Update () {
       
        for (int i = 0; i < skeletonCount; i++)
        {
            if(Vector3.Distance(Skeletons[i].transform.position,transform.position) < 0.1)
            { 
                Skeletons[i].transform.position = Vector2.MoveTowards(Skeletons[i].transform.position, transform.position,  3f*Time.deltaTime);
                if ((transform.position.x == way.x && transform.position.y == way.y))
                {
                    way = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
                }
            }
            else
            {
                Skeletons[i].transform.position = Vector2.MoveTowards(Skeletons[i].transform.position, way, 1.8f * Time.deltaTime);
                if ((transform.position.x == way.x && transform.position.y == way.y) )
                {
                    way = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
                }
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, way, 1.8f * Time.deltaTime);


    }
}
