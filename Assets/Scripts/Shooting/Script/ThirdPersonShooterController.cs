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
        
        Instantiate(PaintBallProjectile, spawnProjectilePosition.position,spawnProjectilePosition.rotation);
        
        try{ FindObjectOfType<AudioManager>().play("shooting"); }
        catch (System.NullReferenceException e) { Debug.LogWarning("Shoot sound not appointed in "+gameObject.scene+"\n"+e.ToString()); }

        starterAssetsInputs.shoot = false; //* To implement Semi-automatic Shooting.
        player.UpdateAmmo(player.ammoCount.currentAmmo - 1);
    }
}
