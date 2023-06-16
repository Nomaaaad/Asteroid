using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    public ParticleSystem explosion;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI liveText;

    public float respawnTime = 3;
    public int lives = 3;
    public int score = 0;


    private void Awake()
    {
        Instance = this;
        scoreText.text = "0";
        liveText.text = lives.ToString();
    }


    public void AsteroidDestroyed(Asteroid asteroid)
    {
        explosion.transform.position = asteroid.transform.position;
        explosion.Play();

        // Score
        if (asteroid.size < .75f)
        {
            score += 100;
        }
        else if (asteroid.size < 1.2f)
        {
            score += 50;
        }
        else
        {
            score += 25;
        }

        scoreText.text = score.ToString();
    }

    public void PlayerDied()
    {
        explosion.transform.position = player.transform.position;
        explosion.Play();

        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnTime);
        }

        liveText.text = lives.ToString();

    }

    private void Respawn()
    {
        player.transform.position = Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");

        player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), 2);
        player.animator.SetTrigger("isRespawning");
    }

    private void TurnOnCollisions()
    {
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        lives = 3;
        score = 0;
        scoreText.text = "0";
        liveText.text = lives.ToString();
        Invoke(nameof(Respawn), respawnTime);

    }
}
