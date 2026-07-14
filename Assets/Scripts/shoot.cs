using UnityEngine;

public class CarShooter : MonoBehaviour
{
    public GameObject bulletPrefab;   // 총알 프리팹
    public Transform firePoint;       // 발사 위치
    public float fireRate = 0.3f;     // 발사 간격

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}