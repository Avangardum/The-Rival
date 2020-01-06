using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject Shoot(GameObject bulletPrefab, float speed, Vector2 target, float angularDeviaton = 0)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.LookAt2D(target);
        bullet.transform.Rotate(0, 0, angularDeviaton);
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * speed;
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.Origin = gameObject;
        return bullet;
    }

    public GameObject Shoot(GameObject bulletPrefab, float speed, Transform target, float angularDeviaton = 0) => Shoot(bulletPrefab, speed, target.position, angularDeviaton);
}
