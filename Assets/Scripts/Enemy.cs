using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed; // ENCAPSULATION
    [SerializeField] float enemyHealth; // ENCAPSULATION
    public float damageOntouch;

    public Rigidbody enemyrb;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        enemyrb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        FollowPlayer();

    }
     public virtual void FollowPlayer()
    {
        Vector3 lookDirecion = (player.transform.position - transform.position).normalized;
        enemyrb.AddForce(lookDirecion*enemySpeed);
    }

    public  void OnTriggerEnter(Collider other)
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
