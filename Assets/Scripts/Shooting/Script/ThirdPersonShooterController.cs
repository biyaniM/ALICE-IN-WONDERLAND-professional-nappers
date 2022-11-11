using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{
    [Header("Bullet Projectile Settings")]
    [Tooltip("Bullet Projectile Prefab")][SerializeField] private Transform PaintBallProjectile;
    [Tooltip("Gun Point on Player")][SerializeField] private Transform spawnProjectilePosition;
    private StarterAssetsInputs starterAssetsInputs;
    [Header("Ammo Settings")]
    [Tooltip("HUD Object")][SerializeField] Player player;
    public int maxAmmo = 10;
    public int currentAmmo;
    [Header("Shooting VFX")]
    [Tooltip("Particle System for Shooting VFX")][SerializeField] private ParticleSystem shootFlash;
    // private ThirdPersonController thirdPersonController;
    [Header("Player Rotation with Camera")]
    private GameObject TPPAimCamera;
    
    void Start(){
        player.InitAmmo(maxAmmo);
        Cursor.lockState = CursorLockMode.Locked;
        TPPAimCamera = GameObject.Find("TPPAimCamera");
    }
    void Awake(){
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        currentAmmo = player.ammoCount.currentAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        RotateWithCamera();

        //* Ammo Update
        currentAmmo = player.ammoCount.currentAmmo;
        if (player.ammoCount.currentAmmo>0){
            if (starterAssetsInputs.shoot){
                Shoot();
            }
        }else{
            //TODO Play no ammo audio.
        }
    }

    private void RotateWithCamera(){ //* Rotates the Player with the Camera
        Quaternion aimDir = TPPAimCamera.transform.rotation;
        aimDir.x = 0;
        aimDir.z = 0;
        transform.rotation = aimDir;
    }

    void Shoot(){
        shootFlash.Play();
        // Vector3 aimDir = (aimPosition - spawnProjectilePosition.position).normalized;
        Vector3 aimDir = spawnProjectilePosition.position.normalized;
        Instantiate(PaintBallProjectile, spawnProjectilePosition.position,spawnProjectilePosition.rotation);// Quaternion.LookRotation(aimDir, Vector3.up));
        starterAssetsInputs.shoot = false; //* To implement Semi-automatic Shooting.
        player.UpdateAmmo(player.ammoCount.currentAmmo - 1);
        
        string currentAmmoMessage = string.Format("Current Ammmo {0}/{1}",player.ammoCount.currentAmmo,player.ammoCount.totalAmmo);
        Debug.Log(currentAmmoMessage);
        // shootFlash.Pause();
    }
}
