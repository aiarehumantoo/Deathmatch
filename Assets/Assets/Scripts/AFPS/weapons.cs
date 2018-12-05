using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFPS
{
    public class weapons : MonoBehaviour
    {
        // Just rail and lg for testing purposes
        // Weapon "swaps" with color? blue for lg, green for rail. TESTING
        // Basic functionality. Add effects later.
        // remake with weapons slots, stats, switching etc
        // effects with particles
        // point A to B effect / particles?

        // Rail is default weapon.
        int fireMode = 0;                               // 0 = rail, 1 = LG
        public string activeWeapon = "rail";
        int damagePerShot = 40;                        // The damage inflicted by each bullet.
        float timeBetweenBullets = 1f;                  // The time between each shot.
        float range = 100f;                             // The distance the gun can fire.
        bool singleShot = true;                         // Delete weapon effects with delay if rail and on Mouse1 release if LG.

        public AudioClip[] m_HitSounds;
        private AudioSource m_AudioSource;

        //weapon color coding. for testing
        public Material rail;
        public Material lg;
        public Renderer weapon;
        ParticleSystem weaponParticles;

        float timer;                                    // A timer to determine when to fire.
        Ray shootRay = new Ray();                       // A ray from the gun end forwards.
        RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
        int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.


        void Awake()
        {
            // Create a layer mask for the Shootable layer.
            shootableMask = LayerMask.GetMask("Enemy");

            weaponParticles = GetComponent<ParticleSystem>();
        }

        private void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the Fire1 button is being press and it's time to fire...
            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                // ... shoot the gun.
                Fire();
            }
            else
            {

            }

            //cycle weapons.
            if (Input.GetButtonDown("CycleWeapons"))
            {
                //next weapon.
                CycleWeapons();
            }
        }

        void Fire()
        {
            // Reset the timer.
            timer = 0f;

            // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            // Perform the raycast against gameobjects on the shootable layer and if it hits something...
            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                // Try and find an EnemyHealth script on the gameobject hit.
                TargetDummy targetDummy = shootHit.collider.GetComponent<TargetDummy>();

                // If the EnemyHealth component exist...
                if (targetDummy != null)
                {
                    // ... the enemy should take damage.
                    targetDummy.TakeDamage(damagePerShot, shootHit.point);
                    PlayHitSounds();
                }

                // Set the second position of the line renderer to the point the raycast hit.                               end point of effect
                //gunLine.SetPosition(1, shootHit.point);
            }
            // If the raycast didn't hit anything on the shootable layer...
            else
            {
                // ... set the second position of the line renderer to the fullest extent of the gun's range.               alt end point of effect
                //gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }

        void CycleWeapons()
        {
            //TODO; make into cycle through list of weapons. Config file for weapons ?
            if (fireMode == 0)
            {
                //LG
                fireMode = 1;
                activeWeapon = "LG";
                damagePerShot = 1;                  // The damage inflicted by each bullet.
                timeBetweenBullets = 0.01f;         // The time between each shot.
                range = 100f;                       // The distance the gun can fire.
                singleShot = false;                 // For disabling weapon effects.
                weapon.material = lg;
                return;
            }

            if (fireMode == 1)
            {
                //rail
                fireMode = 0;
                activeWeapon = "rail";
                damagePerShot = 40;                // The damage inflicted by each bullet.
                timeBetweenBullets = 1f;            // The time between each shot.
                range = 100f;                       // The distance the gun can fire.
                singleShot = true;                  // For disabling weapon effects.
                weapon.material = rail;
                return;
            }
        }

        private void PlayHitSounds()
        {
            // pick & play a random jump sound from the array,
            // excluding sound at index 0
            //int n = Random.Range(1, m_HitSounds.Length);
            m_AudioSource.clip = m_HitSounds[1];
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
            // move picked sound to index 0 so it's not picked next time
            //m_HitSounds[n] = m_HitSounds[0];
            //m_HitSounds[0] = m_AudioSource.clip;
        }
    }
}
