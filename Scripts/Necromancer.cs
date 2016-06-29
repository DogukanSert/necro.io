using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Necromancer : MonoBehaviour
{
    RaycastHit2D hit;
    Ray2D ray;
    Vector3 newPosition;
    public List<GameObject> Skeletons;
    public GameObject Skeleton;
    private int skeletonCount;
    private float playerSpeedOffset = 0.5f; 

    // Use this for initialization
    void Start ()
    {
        skeletonCount = Random.Range(10, 16);
        for (int i = 0; i < skeletonCount; i++)
        {
            Skeletons.Add((Instantiate(Skeleton, transform.position+ new Vector3(Random.Range(1,2),Random.Range(1, 2), 0), Quaternion.identity)) as GameObject);
            Skeletons[i].tag = this.tag;
        }
    }


	
	// Update is called once per frame
	void FixedUpdate() {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse[2] = 0;

            hit = Physics2D.Raycast(mouse, Vector2.zero);

            if (hit.collider.CompareTag("Floor"))
            {

                Vector3 difference = mouse - transform.position;
                transform.Translate(playerSpeedOffset *difference * Time.deltaTime);
                //transform.Translate(origin * Time.fixedDeltaTime);
                for (int i = 0; i < skeletonCount; i++){
                        if (Vector3.Distance(Skeletons[i].transform.position, transform.position) > 1)
                        {
                            Skeletons[i].transform.position = Vector2.MoveTowards(Skeletons[i].transform.position, transform.position, 4f * Time.deltaTime);
                        }
                        else
                        {
                            Skeletons[i].transform.Translate(playerSpeedOffset * difference * Time.deltaTime);
                        }      
                    }
                
            }
        }
	}

    
}
