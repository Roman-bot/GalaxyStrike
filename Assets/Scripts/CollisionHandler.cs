using System.Collections;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _playerDestroy;

    GameManager gameManager;
 
    void Start()
    {
        //Instantiate(_playerDestroy, this.transform.position, Quaternion.identity);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide with " + other.name);
        
        if (_playerDestroy!=null)
        {
            var ps = Instantiate(_playerDestroy, this.transform.position, Quaternion.identity);
            ps.Play();
            Debug.Log("Particle start " + _playerDestroy.name);
        }

        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
            gameManager.StartCoroutine("RestartLevel");
        }
        
    }

 
}
