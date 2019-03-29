using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public GameObject myWeapon;
    public GameObject weaponOnGround;
    public GunScript gunScript;
    // Start is called before the first frame update
    void Start()
    {
        myWeapon.SetActive(false);

    }
    void OnTriggerEnter(Collider _collider)
    {
        if(_collider.gameObject.tag == "Player")
        {
            gunScript.enabled = true;
            myWeapon.SetActive(true);
            weaponOnGround.SetActive(false);
        }
    }

}