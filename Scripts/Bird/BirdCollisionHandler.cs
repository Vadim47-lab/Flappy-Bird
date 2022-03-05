using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdCollisionHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _getPoint;
    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.TryGetComponent(out ScoreZone scoreZone))
        {
            GetComponent<AudioSource>().PlayOneShot(_getPoint);
            _bird.IncreaseScore();
        }

        else
        {
            _bird.Die();
        }
    }
}