using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 500f;
    [SerializeField] private float _maxLifetime = 10f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * _speed);

        Destroy(gameObject, _maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
