using UnityEngine;

public class OrbDrag : MonoBehaviour
{
    private Vector3 offset;
    private bool isSnapped = false;
    private Transform snapPoint;

    void OnMouseDown()
    {
        if (!isSnapped) // Only allow dragging if not snapped
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseDrag()
    {
        if (!isSnapped)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    void OnMouseUp()
    {
        // If near a SnapPoint, snap to it
        if (snapPoint != null)
        {
            transform.position = snapPoint.position;
            isSnapped = true; // Lock the orb in place
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SnapPoint"))
        {
            snapPoint = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SnapPoint") && !isSnapped)
        {
            snapPoint = null;
        }
    }
}
