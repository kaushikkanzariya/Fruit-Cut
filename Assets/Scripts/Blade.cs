using UnityEngine;

public class Blade : MonoBehaviour
{
    public Transform spawnerParent;
    Rigidbody rb;

    SphereCollider sphereCollider;
    TrailRenderer trailRenderer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = rb.GetComponent<SphereCollider>();
        trailRenderer = rb.GetComponent<TrailRenderer>();
    }
    void Update()
    {
        if(GameManager.Instance.gameOver == true)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            sphereCollider.enabled = true;
            trailRenderer.enabled = true;
        }

        if (Input.GetMouseButtonUp(0))
        { 
            sphereCollider.enabled = false;
            trailRenderer.enabled = false;
        }

        BladeFollowToMouse();
    }

    void BladeFollowToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = -(Camera.main.gameObject.transform.position.z - spawnerParent.position.z);

        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
