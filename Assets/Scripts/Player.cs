using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float turnSpeed = 1;

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
        _verticalMove = Input.GetAxisRaw("Vertical");
        _horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(transform.up * moveSpeed);
        _rigidbody2D.AddTorque(-_horizontalMove * turnSpeed);
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, transform.rotation);
        bullet.Project(transform.up);
    }
}
