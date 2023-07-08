using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Camera cam;
    public Rigidbody2D rb;
    // public GameObject bulletPrefab; // Prefab for the bullet object
    // public Transform firePoint; // Transform representing the position to spawn the bullet

    private SpriteRenderer spriteRenderer;
    private Vector2 mousePos;
    private Vector2 input;
    

    private void Update()
    {
        // Player input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Update movement

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Shooting
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Shoot();
        // }
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + input * movementSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    // private void Shoot() {
    //     // Instantiate the bullet at the fire point's position and rotation
    //     Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    // }
}
