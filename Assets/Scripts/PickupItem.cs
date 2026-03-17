using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private bool isHeld = false;

    void OnTriggerEnter(Collider other)
    {
        if (isHeld) return;

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
        rb.isKinematic = true;
        rb.useGravity = false;

        Collider col = GetComponent<Collider>();
        col.enabled = false;

        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}