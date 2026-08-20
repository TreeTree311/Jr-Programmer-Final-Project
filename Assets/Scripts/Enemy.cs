using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    [SerializeField] float enemyHealth;

    Rigidbody enemyrb;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyrb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();

    }
     void FollowPlayer()
    {
        Vector3 lookDirecion = (player.transform.position - transform.position).normalized;
        enemyrb.AddForce(lookDirecion*enemySpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Projectile"))
        {
            enemyHealth -= other.GetComponent<MoveProjectile>().damage;
            Destroy(other.gameObject);
            if (enemyHealth < 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
