using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletController))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletLinkController : MonoBehaviour
{
    public GameObject Bullet1;
    public GameObject Bullet2;

    private void FixedUpdate()
    {
        if(Bullet1 == null || Bullet2 == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = (Bullet1.transform.position + Bullet2.transform.position) / 2;
        transform.LookAt2D(Bullet2.transform);
        Vector3 scale = transform.localScale;
        scale.x = Vector2.Distance(Bullet1.transform.position, Bullet2.transform.position);
        transform.localScale = scale;
    }
}
