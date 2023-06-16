using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    public float respawnTime = 3;
    public int lives = 3;


    private void Awake()
    {
        Instance = this;
    }

    public void PlayerDied()
    {
        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnTime);
        }

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
        //
    }
}
