using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{
    
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform PaintBallProjectile;
    [SerializeField] private Transform spawnProjectilePosition;
    private StarterAssetsInputs starterAssetsInputs;
    [SerializeField] Player player;
    public int maxAmmo = 10;
    // private AmmoCount
    void Start(){
        player.InitAmmo(maxAmmo);
    }
    void Awake(){
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 aimPosition = Vector3.zero;
        // Get Screen centre
        // Vector2 screenCentrePoint = new Vector2(Screen.width /2f , Screen.height / 2f);
        // Ray ray = Camera.main.ScreenPointToRay(screenCentrePoint);
        // if (Physics.Raycast(ray, hitInfo: out RaycastHit rayCastHit, 999f, aimColliderLayerMask)){
        //     transform.position = rayCastHit.point;
        //     // debugTransform.position = rayCastHit.point;
        // }
        if (player.ammoCount.currentAmmo>0){
            if (starterAssetsInputs.shoot){
                // Vector3 aimDir = (aimPosition - spawnProjectilePosition.position).normalized;
                Vector3 aimDir = spawnProjectilePosition.position.normalized;
                Instantiate(PaintBallProjectile, spawnProjectilePosition.position,spawnProjectilePosition.rotation);// Quaternion.LookRotation(aimDir, Vector3.up));
                starterAssetsInputs.shoot = false; //* To implement Semi-automatic Shooting.
                player.UpdateAmmo(player.ammoCount.currentAmmo - 1);
                string currentAmmoMessage = string.Format("Current Ammmo {0}/{1}",player.ammoCount.currentAmmo,player.ammoCount.totalAmmo);
                Debug.Log(currentAmmoMessage);
            }
        }else{

        }
    }
}
