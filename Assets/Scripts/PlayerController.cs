using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] GameObject projectile;

    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth = 100;
    [SerializeField] HealthBar healthBar;

    float damageCoolDown = 1f;
    float damageCoolDownTimer = 0;


    [SerializeField] InputAction moveAction;
    InputSystem_Actions inputActions;

    Rigidbody rb;
    [SerializeField] GameUI gameUI;
    Vector2 moveValue;
    Vector2 lookValue;
    public Vector3 lookDirection;
    float projectileSpeed = 10f;
    float fireRate = 1f;
    int bulletCount = 1;
    float bulletLifeSpan = 0.8f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SethHealth(maxHealth);
        moveAction.Enable();
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
        rb = GetComponent<Rigidbody>();
        
        StartCoroutine(ConstantFiring());
    }

    void FixedUpdate()
    {
        MovePlayer(); // ABSTRACTION

    }
  
    void MovePlayer() // ABSTRACTION
    { 
        moveValue = moveAction.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveValue.x, 0, moveValue.y);
        rb.AddForce(moveDirection*playerSpeed);

    }
    void fireProjectile() // ABSTRACTION
    {
        int incrementRotationBy = 360 / bulletCount;
        int rotation = 0;

        for (int i = 0; i < bulletCount; i++)
        {
      
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.Euler(0, rotation, 0));
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(bulletRb.transform.forward * projectileSpeed, ForceMode.Impulse);

            rotation += incrementRotationBy;
            Destroy(bullet, bulletLifeSpan);
        }

    }

    IEnumerator ConstantFiring()
    {
        while (true)
        { 
            fireProjectile(); // ABSTRACTION
            yield return new WaitForSeconds(fireRate);
        }
    }
    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= collision.gameObject.GetComponent<Enemy>().damageOntouch;
            healthBar.SethHealth(currentHealth);
            CheckForGameOver();
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Powerup"))
        {
            bulletCount += 1;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy Projectile"))
        {
            currentHealth -= other.GetComponent<MoveProjectile>().damage;
            healthBar.SethHealth(currentHealth);
            CheckForGameOver();
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        damageCoolDownTimer += Time.deltaTime;

        if (collision.gameObject.CompareTag("Enemy") & damageCoolDown <= damageCoolDownTimer)
        {
            currentHealth -= collision.gameObject.GetComponent<Enemy>().damageOntouch;
            healthBar.SethHealth(currentHealth);
            CheckForGameOver();
            damageCoolDownTimer = 0;
        }
        
        
    }


    void CheckForGameOver()
    {
        if (currentHealth <= 0)
        {
            gameUI.GameOver();
        }
    }
}
