using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {
    public int weaponType;
    public float weapontime;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<WeaponManager>().DesiredWeapon = weaponType;
            other.GetComponent<WeaponManager>().weaponTime = weapontime;

            Destroy(gameObject);
        }
        
    }
}
