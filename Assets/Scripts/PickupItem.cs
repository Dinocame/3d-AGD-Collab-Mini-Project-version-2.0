using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private bool isHeld = false;
    private float pickupCooldown = 0f;

    void Update()
    {
        if (pickupCooldown > 0)
            pickupCooldown -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isHeld || pickupCooldown > 0) return;

        PlayerPickup player = other.GetComponent<PlayerPickup>();

        if (player != null)
        {
            player.PickupItem(this);
        }
    }

    public void OnPickup(Transform holdPoint)
    {
        isHeld = true;

        Rigidbody rb = GetComponent<Rigidbody>();
        Collider col = GetComponent<Collider>();

        rb.isKinematic = true;
        rb.useGravity = false;

        col.enabled = false;

        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void OnDrop()
    {
        isHeld = false;
        pickupCooldown = 0.5f; // prevents instant re-pickup
    }
}