using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class playerScript : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image filler;
    [SerializeField]
    private GameObject bullet, projectileEmitter;
    
    public GameObject bulletInstance;
    private int dmg;
    private int playerHP = 100;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleHP();
        Destroy(bulletInstance, 3.5f);
    }
    
  
    public void OnClick()
    {
        bulletInstance = Instantiate(bullet, projectileEmitter.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * 400);
    } 
    void OnCollisionEnter(Collision collide)
    {
        if(collide.gameObject.tag == "projectile")
        {
            dmg = Random.Range(4, 7);
            playerHP -= dmg;
        }
    }
    void HandleHP()
    {
        filler.fillAmount = hpMap(playerHP, 0.0f, 100.0f, 0.0f, 1.0f);
    }
    private float hpMap(float val, float minHP, float maxHP, float retMin, float retMax)
    {
        return (val - minHP) * (retMax - retMin) / (maxHP - minHP) + retMin;
    }
}