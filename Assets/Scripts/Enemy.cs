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

}
