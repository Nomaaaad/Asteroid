using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private float speed = 50;
    [SerializeField] private float maxLifetime = 50;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    public float size = 1f;
    public float minSize = .5f;
    public float maxSize = 1.5f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        transform.eulerAngles = new Vector3(0, 0, Random.value * 360f);
        transform.localScale = Vector3.one * size;

        _rigidbody2D.mass = size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * speed);

        Destroy(gameObject, maxLifetime);
    }
}
