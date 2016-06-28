using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BotController : MonoBehaviour {
    public float speed = 1.0f;
    public float speedRatio = 1.5f;

    private Vector2 way;
    public List<GameObject> Skeletons;
    public GameObject Skeleton;
    private int skeletonCount;
    
    public float attackPoint;
    public float attackSpeed;
    public float healthPoint;

    // Use this for initialization
    void Start () {
        

        skeletonCount = Random.Range(10, 15);
        way = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        for (int i = 0; i < skeletonCount; i++)
        {
            Skeletons.Add((Instantiate(Skeleton, new Vector2(transform.position.x, transform.position.y), Quaternion.identity)) as GameObject);
            Skeletons[i].tag = this.name;

        }
    }
	
	// Update is called once per frame
	void Update () {

        //The AI is at peace movement
       
        for (int i = 0; i < skeletonCount; i++)
        {
            if (!(Skeletons[i].GetComponent<SkeletonController>().atWar))
            {
                if (Vector3.Distance(Skeletons[i].transform.position,transform.position) > 1)
                { 
                    Skeletons[i].transform.position = Vector2.MoveTowards(Skeletons[i].transform.position, transform.position,  speed * speedRatio * Time.deltaTime);
                    if ((transform.position.x == way.x && transform.position.y == way.y))
                    {
                        way = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
                    }
                }
                else
                {
                    Skeletons[i].transform.position = Vector2.MoveTowards(Skeletons[i].transform.position, way, speed * Time.deltaTime);
                    if ((transform.position.x == way.x && transform.position.y == way.y))
                    {
                        way = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
                    }
                }

            }
            else
            {
                for (int j=0; j<skeletonCount; j++)
                {
                    Skeletons[i].transform.position = Vector2.MoveTowards(transform.position, Skeletons[j].GetComponent<SkeletonController>().collided.transform.position, speed * Time.deltaTime);
                }
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, way, speed * Time.deltaTime);
            

    }
    

    
}
