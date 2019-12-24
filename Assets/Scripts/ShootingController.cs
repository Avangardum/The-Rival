using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject Shoot(GameObject bulletPrefab, float speed, Vector2 target, float angularDeviaton = 0)
    {
        GameObject createdObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        createdObject.transform.LookAt2D(target);
        createdObject.transform.Rotate(0, 0, angularDeviaton);
        createdObject.GetComponent<Rigidbody2D>().velocity = createdObject.transform.right * speed;
        return createdObject;
    }

    public GameObject Shoot(GameObject bulletPrefab, float speed, Transform target, float angularDeviaton = 0) => Shoot(bulletPrefab, speed, target.position, angularDeviaton);
}
