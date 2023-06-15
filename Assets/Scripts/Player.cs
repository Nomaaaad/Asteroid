using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1;
    [SerializeField] private float _turnSpeed = 1;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletSpawnPos;

    private Rigidbody2D _rigidbody2D;
    private float _verticalMove;
    private float _horizontalMove;



    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        _verticalMove = Input.GetAxis("Vertical");
        _horizontalMove = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(transform.up * _moveSpeed);
        _rigidbody2D.AddTorque(-_horizontalMove * _turnSpeed);
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, transform.rotation);
        bullet.Project(transform.up);
    }
}
