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
    
    void Awake(){
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 aimPosition = Vector3.zero;
        // Get Screen centre
        Vector2 screenCentrePoint = new Vector2(Screen.width /2f , Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCentrePoint);
        if (Physics.Raycast(ray, out RaycastHit rayCastHit, 999f, aimColliderLayerMask)){
            transform.position = rayCastHit.point;
            debugTransform.position = rayCastHit.point;
        }

        if (starterAssetsInputs.shoot){
            // Vector3 aimDir = (aimPosition - spawnProjectilePosition.position).normalized;
            Vector3 aimDir = spawnProjectilePosition.position.normalized;
            Instantiate(PaintBallProjectile, spawnProjectilePosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;
        }
    }
}
