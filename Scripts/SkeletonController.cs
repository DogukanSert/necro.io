using UnityEngine;
using System.Collections;

public class SkeletonController : MonoBehaviour {
    public float attackPoint;
    public float attackSpeed;
    public float healthPoint;
    public bool atWar;
    public bool isDead;
    public GameObject collided;


    // Use this for initialization
    void Start () {
        atWar = false;
        isDead = false;
        
    }

    void AttackSkeleton(GameObject attacked)
    {
        if (!isDead)
        {
            while (attacked.GetComponent<SkeletonController>().healthPoint > 0 && healthPoint > 0)
            {
                healthPoint -= attacked.GetComponent<SkeletonController>().attackPoint * attacked.GetComponent<SkeletonController>().attackSpeed * Time.deltaTime;
                attacked.GetComponent<SkeletonController>().healthPoint -= attackSpeed * attackPoint * Time.deltaTime;
            }

            if (healthPoint <= 0)
            {
                gameObject.SetActive(false);
                isDead = true;
            }

            else if (attacked.GetComponent<SkeletonController>().healthPoint <= 0)
            {
                attacked.SetActive(false);
            }
        }
    }
    void AttackBot(GameObject attacked)
    {
        if (!isDead)
        {
            while (attacked.GetComponent<BotController>().healthPoint > 0 && healthPoint > 0)
            {
                healthPoint -= attacked.GetComponent<BotController>().attackPoint * attacked.GetComponent<BotController>().attackSpeed * Time.deltaTime;
                attacked.GetComponent<BotController>().healthPoint -= attackSpeed * attackPoint * Time.deltaTime;
            }

            if (healthPoint <= 0)
            {
                gameObject.SetActive(false);
                isDead = true;
            }

            else if (attacked.GetComponent<BotController>().healthPoint <= 0)
            {
                attacked.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        bool botFlag = false;
        if (!other.gameObject.CompareTag(tag))
        {
            atWar = true;
            collided = other.gameObject;
            for (int i = 0; i < 4; i++)
            {
                    if (collided.tag == "Bot" + i )
                    {
                    Debug.Log(collided.tag.Substring(7));
                    if (!(collided.tag.Substring(7) == tag))
                        { 
                           AttackBot(other.gameObject);
                           botFlag = true;
                        }
                    }
            }
            if (!botFlag)
            {
                AttackSkeleton(other.gameObject);
            }
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
