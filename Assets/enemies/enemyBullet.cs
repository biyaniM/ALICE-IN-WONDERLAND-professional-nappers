using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10f;
    private Rigidbody bulletRigidbody;
    // private float bulletLifeSpan = 
    private void Awake(){
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start(){
        //bulletRigidbody.AddForce(bulletRigidbody.transform.forward * bulletSpeed);
        bulletRigidbody.velocity = bulletRigidbody.transform.forward * projectileSpeed;
    }
    private void Update()  
    {
        // transform.Translate(new Vector3(0f, 0f, projectileSpeed * Time.deltaTime));
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag!="enemy1" && collision.gameObject.tag!="enemy2" && collision.gameObject.tag!="enemy3"){ 
            // Debug.Log("What is the enemy bullet hitting? "+collision.gameObject);
            Destroy(gameObject);
        }
    }
}