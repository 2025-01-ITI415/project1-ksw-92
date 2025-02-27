using UnityEngine;
using UnityEngine.InputSystem;

public class Orb : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    private Rigidbody2D rb;
    public LineManager lineManager; // Reference to LineManager

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) // Detect click
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.transform == transform)
            {
                Debug.Log("✅ Orb Clicked!");
                isDragging = true;
                offset = transform.position - mousePos;

                // **Set Rigidbody to Kinematic to allow smooth dragging**
                rb.isKinematic = true;
            }
        }
        if (isDragging && Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0;

            Debug.Log("🖱️ Mouse Position: " + mousePos); // Check if the mouse position updates
            Debug.Log("🔹 Orb Current Position: " + transform.position);

            transform.position = Vector3.Lerp(transform.position, mousePos + offset, Time.deltaTime * 15);

            Debug.Log("🚀 Updated Orb Position: " + transform.position);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.isKinematic = false; // Restore physics behavior
        Debug.Log("🛑 Orb Released!");

        if (lineManager != null)
        {
            lineManager.AddPoint(transform.position);
        }
        else
        {
            Debug.LogWarning("⚠️ No LineManager assigned to Orb!");
        }
    }
}
