using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10f;

    private void Update()  
    {
        transform.Translate(new Vector3(0f, 0f, projectileSpeed * Time.deltaTime));
    }
    public void OnTriggerEnter(Collider col)
    {

    }
}