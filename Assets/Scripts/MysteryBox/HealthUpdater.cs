// public class HealthUpdater : MonoBehaviour
// {
//     [SerializeField] private int boxDestroy = 3;
//     public healthUpdate healthUpdate; 
//     public void updateHealth(int health){
//         healthUpdate.changeCurrentHealth(health);
//     }
    
//     public void OnCollisionEnter(Collision col){
//         if(col.gameObject.tag == "playerBullet"){
//             Destroy(col.gameObject);
//             boxDestroy = boxDestroy - 1;
//             if(boxDestroy <= 0){
//                 Destroy(this.gameObject);
//             }
            
//         }
//         if(boxDestroy == 0){
//             updateHealth(5);
//         }
//         return;
//     }
// }