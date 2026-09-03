using UnityEngine;
using UnityEngine.UIElements;

public class AcidEnemy : Enemy  // INHERITANCE
{
    float stopDistance = 8;
    float resumeFollowDistance = 15;
    bool hasStopped = false;

    float fireInterval = 3f;
    float fireTime = 0;
    float projectileSpeed = 7f;
    float projectileLifeSpan = 4f;
    [SerializeField] GameObject acidBall;
    public override void FollowPlayer()  // POLYMORPHISM
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > stopDistance)
        {
            base.FollowPlayer();
        }
        else
        {
            hasStopped = true;
            SpitAcid(); // ABSTRACTION
        }
        if (hasStopped & distance > resumeFollowDistance)
        {
            hasStopped = false;
        }
    }
    void SpitAcid() // ABSTRACTION
    {
        if (hasStopped & Time.time > fireTime)
        {
            Vector3 fireDirection = ( player.transform.position - transform.position).normalized;
            fireTime = Time.time + fireInterval;
            GameObject thisAcidBall = Instantiate(acidBall, transform.position, acidBall.transform.rotation);
            Rigidbody thisAcidBallRb = thisAcidBall.GetComponent<Rigidbody>();
            thisAcidBallRb.AddForce(fireDirection * projectileSpeed, ForceMode.Impulse);

            Destroy(thisAcidBall, projectileLifeSpan);
        }
    }
}
