using UnityEngine;

public class MoveForward : MonoBehaviour
{
    Rigidbody projectileRb;
    GameObject player;
    PlayerController controller;
    float speed = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectileRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        controller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        projectileRb.AddForce(controller.lookDirection * speed);
    }
}
