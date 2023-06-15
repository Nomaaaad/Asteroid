using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1;
    [SerializeField] private float _turnSpeed = 1;

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
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(transform.up * _moveSpeed);
        _rigidbody2D.AddTorque(-_horizontalMove * _turnSpeed);
    }
}
