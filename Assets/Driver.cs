using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 175f;
    [SerializeField] float moveSpeed = 10f;
    float speedBrake = 10f;
    float speedBoost = 10f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Boost"))
        {
            moveSpeed += speedBoost;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // collide with anything other than boost, package, drop point
        if(moveSpeed > 10)
        {
            moveSpeed -= speedBrake;
        }
    }
}
