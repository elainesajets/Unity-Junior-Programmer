using UnityEngine;

public class BeadDrag : MonoBehaviour
{
    [SerializeField] float liftHeight = 10f;
    private Camera cam;
    private bool dragging;
    private Vector3 grabOffset;
    private float grabY;
    private float originalY;

    [SerializeField] AudioClip pickUpClip;

    void Awake()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        originalY = transform.position.y;
        grabY = originalY + liftHeight;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, new Vector3(0f, grabY, 0f));

        if (plane.Raycast(ray, out float enter))
        {
            Vector3 hit = ray.GetPoint(enter);
            grabOffset = new Vector3(transform.position.x - hit.x, 0f, transform.position.z - hit.z);
        }
        if (pickUpClip != null)
        {
            AudioSource.PlayClipAtPoint(pickUpClip, cam.transform.position);
            Debug.Log("Sound played");
        }

        dragging = true;
        Debug.Log("Bead clicked");
    }

    void OnMouseUp()
    {
        Vector3 p = transform.position;
        p.y = originalY;
        transform.position = p;
        dragging = false;
    }

    void Update()
    {
        if (!dragging) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, new Vector3(0f, grabY, 0f));

        if (plane.Raycast(ray, out float enter))
        {
            Vector3 hit = ray.GetPoint(enter);
            Vector3 target = hit + grabOffset;
            target.y = grabY;
            transform.position = target;
        }
    }
}