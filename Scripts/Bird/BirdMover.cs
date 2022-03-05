using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private AudioClip _jumpBird;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotaion;
    private Quaternion _minRotaion;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _maxRotaion = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotaion = Quaternion.Euler(0, 0, _minRotationZ);

        ResetBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpBirdClick();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotaion, _rotationSpeed * Time.deltaTime);
    }

    public void OnJumpBirdClick()
    {
        GetComponent<AudioSource>().PlayOneShot(_jumpBird);
        _rigidbody.velocity = new Vector2(_speed, 0);
        transform.rotation = _maxRotaion;
        _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }
}