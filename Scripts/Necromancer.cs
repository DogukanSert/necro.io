using UnityEngine;
using System.Collections;

public class Necromancer : MonoBehaviour
{
    RaycastHit2D hit;
    Ray2D ray;
    Vector3 newPosition;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        if (Input.GetMouseButton(0))
        {
            Vector3 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            origin[2] = 0;

            hit = Physics2D.Raycast(origin, Vector2.zero);

            if (hit.collider.CompareTag("Floor"))
            {
                
                Vector3 pos = Vector3.MoveTowards(transform.position, origin, 9);
                transform.position += pos * Time.deltaTime;
                //transform.Translate(origin * Time.fixedDeltaTime);
            }
        }
	}

    void LateUpdate()
    {
        newPosition = transform.position;
    }
}
