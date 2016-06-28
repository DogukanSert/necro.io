using UnityEngine;
using System.Collections;

public class SkeletonController : MonoBehaviour {
    public float attackPoint;
    public float attackSpeed;
    public float healthPoint;
    public bool atWar;
    public GameObject collided;


    // Use this for initialization
    void Start () {
        atWar = false;
        collided = Instantiate(gameObject,new Vector3(0,0,0),Quaternion.identity) as GameObject;
    }

    void Attack(GameObject attacked)
    {
        while (attacked.GetComponent<SkeletonController>().healthPoint > 0 && healthPoint > 0)
        {
            healthPoint = attacked.GetComponent<SkeletonController>().attackPoint * attacked.GetComponent<SkeletonController>().attackSpeed * Time.deltaTime;
            attacked.GetComponent<SkeletonController>().healthPoint = attackSpeed * attackPoint * Time.deltaTime;
        }

        if (healthPoint == 0)
        {
            gameObject.SetActive(false);
        }

        else if (attacked.GetComponent<SkeletonController>().healthPoint == 0)
        {
            attacked.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag(tag))
        {
            atWar = true;
            collided = other.gameObject;
            Debug.Log(other.gameObject);
            Attack(other.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            atWar = false;
        }
    }
    //Update is called once per frame
    void Update () {
       
	
	}
}
