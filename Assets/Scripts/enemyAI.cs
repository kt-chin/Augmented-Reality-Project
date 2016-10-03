using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour {
    private Transform target;
    public GameObject bullet;
    private GameObject bulletInstance;
    private float moveSpeed = 3.0f;
    private float rotSpeed = 3.0f;
    public int hp = 100;
    public float cdTime = 5.0f;
    public int dmg;
    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotSpeed * Time.deltaTime);
        cdTime -= Time.deltaTime;
        if (Vector3.Distance(transform.position,target.position) > 3.0f )
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
       if(cdTime <= 0)
        {
            bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * 600);
            cdTime = 5.0f;
        }
	}
    void OnCollisionEnter(Collision collide)
    {
        if(collide.gameObject.tag == "projectile")
        {
             dmg = Random.Range(5, 12);
             hp -= dmg;
        }
    }
}
