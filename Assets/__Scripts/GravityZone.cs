using UnityEngine;

public class GravityZone : MonoBehaviour
{
    public float gravityStrength = 5f; // Adjust this if needed

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Orb")) // Check if an Orb is inside the gravity zone
        {
            Debug.Log("🌀 Orb is inside Gravity Zone: " + other.name); // Debug Log to check if this runs

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb != null) // Ensure Rigidbody2D exists
            {
                Vector2 direction = (transform.position - other.transform.position).normalized;
                rb.AddForce(direction * gravityStrength);
                Debug.Log("🔵 Applying Gravity Force to Orb: " + direction * gravityStrength);
            }
        }
    }
}
