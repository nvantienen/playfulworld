using UnityEngine;

public class Target : MonoBehaviour
{
    public GunScript gun;
    public GameObject block;

    public float time = 0.1f;
    public float y;
    public float minSize = 1;
    public float maxSize = 5;


    private void Start()
    {
        y = transform.localScale.y;

    }

    private void Update()
    {

        transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(transform.localScale.x , y, transform.localScale.z ),time);
    }

    public void TakeDamage(float amount)
    {
        if (gun.BulletType == 1 & y < maxSize)
        {
            y += 1f;
            
        }
        else if(gun.BulletType == 0 & y > minSize)
        {
            y += -1f;  
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}