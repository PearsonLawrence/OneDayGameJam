using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public int DesiredWeapon;

    public GameObject bullets;
    public Transform[] Pos; //shoot position
    float cooldown;
    int gun;
    float dt;

    public LineRenderer line;
    // Use this for initialization
    void Start () {
        gun = DesiredWeapon;
	}
	

    void shotgun()
    {
        cooldown -= dt;
        if (cooldown <= 0)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject bullet = Instantiate(bullets, Pos[i].position, Pos[i].rotation);
            }
            cooldown = .1f;
        }
    }
    public ParticleSystem hitPS;
    void laser()
    {
        RaycastHit hit;
        if (Physics.Raycast(Pos[0].position, Pos[0].forward, out hit,1000))
        {
            if (hit.collider.GetComponent<Idamageable>() != null)
            {

                hit.collider.GetComponent<Idamageable>().TakeDamage(10);
              
            }; 
            line.enabled = true;
            line.SetPosition(0, Pos[0].position);
            line.SetPosition(1, hit.point);
        }
      
    }
    void Pistol()
    {
        cooldown -= dt;
        if (cooldown <= 0)
        {
            GameObject bullet = Instantiate(bullets, Pos[0].position, Pos[0].rotation);
            cooldown = .1f;
        }
    }

    float fire;
    void InputManager()
    {
        fire = Input.GetAxis("Fire1");
    }
    public float weaponTime;
	// Update is called once per frame
	void Update ()
    {
        gun = DesiredWeapon;
        if (weaponTime <= 0)
        {
            gun = 0;

            line.enabled = false;
            line.SetPosition(0, Pos[0].position);
            line.SetPosition(1, Pos[0].position);
        }
        dt = Time.deltaTime;

        weaponTime -= dt;
        InputManager();
        if (fire != 0)
        {
            switch (gun)
            {
                case 0:
                    Pistol();
                    break;
                case 1:
                    shotgun();
                    break;
                case 2:
                    laser();
                    break;

            }
        }
        else
        {
            line.enabled = false;
            line.SetPosition(0, Pos[0].position);
            line.SetPosition(1, Pos[0].position);
        }
    }
    
}
