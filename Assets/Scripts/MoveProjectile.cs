using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    Rigidbody rb;

    float speed=20;
    float lifespan = 0.8f;
    public float damage = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifespan);
    }

    private void Update()
    {
       
            
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * speed);
    }

}
