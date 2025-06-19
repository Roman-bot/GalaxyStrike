using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _enemyDestroy;

    [SerializeField]
    int enemyHitpoints;

    Scoreboard _scoreboard;

    private void Start()
    {
        _scoreboard = GameObject.Find("Canvas").GetComponent<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Hit the " + this.gameObject.name);
        //Debug.DrawLine(transform.position, other.transform.position, Color.red, 2f);
        HitEnemy();
    }

    void HitEnemy()
    {
        enemyHitpoints--;
        if (enemyHitpoints < 0)
        {
            Instantiate(_enemyDestroy, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            _scoreboard.IncreaseScore();

        }
    }

}
