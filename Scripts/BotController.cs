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
    private bool atWar;

    // Use this for initialization
    void Start () {
        atWar = false;
        skeletonCount = Random.Range(1, 15);
        way = new Vector2(Random.Range(-6, 6), Random.Range(-6, 6));
        for (int i = 0; i < skeletonCount; i++)
        {
            Skeletons.Add((Instantiate(Skeleton, new Vector2(transform.position.x, transform.position.y), Quaternion.identity)) as GameObject);
            Skeletons[i].tag = "Respawn";
           
        }
    }
	
	// Update is called once per frame
	void Update () {

        //The AI is at peace movement
        if (!atWar)
        { 
                for (int i = 0; i < skeletonCount; i++)
                 {
                    if(Vector3.Distance(Skeletons[i].transform.position,transform.position) > 1)
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
            transform.position = Vector2.MoveTowards(transform.position, way, speed * Time.deltaTime);

        }
        //The AI is at war movement
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerSkeleton") || other.CompareTag("Player") )
        {
            atWar = true;
            //War is To Do

        }
    }
}
