using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public Player player;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] int numOfBulletsToKill = 3;

    private void Update()  
    {
        transform.Translate(new Vector3(0f, 0f, projectileSpeed * Time.deltaTime));
    }
    public void OnCollisionEnter(Collision collision)
    {
        Collider col = collision.collider;
        if(col.gameObject.tag == "Player"){
            Debug.Log("Player Hit");

            float maxHealth = (float) player.GetMaxHealth();
            int currHealth = player.GetCurrHealth();
            int damage = (int) Mathf.Ceil( (float) maxHealth / numOfBulletsToKill);

            player.UpdateHealth(currHealth - damage);
        }
        

    }
}