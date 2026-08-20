using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] GameObject projectile;


    [SerializeField] InputAction moveAction;
    InputSystem_Actions inputActions;

    Rigidbody rb;
    Vector2 moveValue;
    Vector2 lookValue;
    public Vector3 lookDirection;
    float projectileSpeed = 500f;
    float fireRate = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(ConstantFiring());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer(); 
        
       
    }
    private void Update()
    {

        //if (inputActions.Player.Attack.triggered)
        //{
        //    fireProjectile();
        //}
    }
    void MovePlayer()
    { 
        moveValue = moveAction.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveValue.x, 0, moveValue.y);
        rb.AddForce(moveDirection*playerSpeed);

    }
    void fireProjectile()
    {
        Instantiate(projectile,transform.position, projectile.transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(Vector3.up * projectileSpeed);

    }

    IEnumerator ConstantFiring()
    {
        while (true)
        { 
            fireProjectile();
            yield return new WaitForSeconds(fireRate);
        }
    }
}
