using UnityEngine;

public class BulletRingLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _linkPrefab;
    [SerializeField] private float _initialRadius;
    [SerializeField] private float _speed;
    [SerializeField] private int _bulletsCount;
    [SerializeField] private int _gapSize;

    public void LaunchRing(Vector2 gapDirection)
    {
        #region Local Variables
        GameObject lastSpawnedBullet = null;
        float step = 360f / (_bulletsCount + _gapSize);//угловое расстояние между соседними пулями
        Vector2 radiusVector = gapDirection.normalized * _initialRadius;//вектор, по которому строится кольцо
        float commitedRotation = 0;//вращение, совершённое радиус-вектором
        float stopAngle;//угол, при достижении которого останавливается спавн пуль
        int missingBulletsInTheBegginning;
        int missingBulletsInTheEnd;
        #endregion

        #region Local Methods
        void RotateRadiusVector(float angle)
        {
            radiusVector.RotateAroundOrigin(angle);
            commitedRotation += angle;
        }

        void SpawnBullet()
        {
            if (commitedRotation > stopAngle)
                return;
            GameObject bullet = Instantiate(_bulletPrefab, (Vector2)transform.position + radiusVector, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = radiusVector.normalized * _speed;
            BulletController bulletController = bullet.GetComponent<BulletController>();
            bulletController.Origin = gameObject;
            if (lastSpawnedBullet != null)
            {
                GameObject link = Instantiate(_linkPrefab);
                BulletLinkController linkController = link.GetComponent<BulletLinkController>();
                linkController.Bullet1 = lastSpawnedBullet;
                linkController.Bullet2 = bullet;
                link.GetComponent<BulletController>().Origin = gameObject;
            }
            lastSpawnedBullet = bullet;
        }
        #endregion

        if (_gapSize % 2 == 0)
        {
            missingBulletsInTheBegginning = missingBulletsInTheEnd = _gapSize / 2;
            RotateRadiusVector(step / 2);
        }
        else
        {
            missingBulletsInTheBegginning = missingBulletsInTheEnd = (_gapSize - 1) / 2;
            RotateRadiusVector(step);
        }

        stopAngle = 360f - step - step * missingBulletsInTheEnd;
        RotateRadiusVector(step * missingBulletsInTheBegginning);
        SpawnBullet();

        while(commitedRotation < stopAngle)
        {
            RotateRadiusVector(step);
            SpawnBullet();
        }

        //Debug.Break();
    }
}
