using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPoint;

    private PickupItem heldItem;

    public void PickupItem(PickupItem item)
    {
        if (heldItem != null)
        {
            DropItem();
        }

        heldItem = item;
        item.OnPickup(holdPoint);
    }

    void DropItem()
    {
        if (heldItem == null) return;

        PickupItem itemToDrop = heldItem;
        heldItem = null;

        itemToDrop.transform.SetParent(null);
        itemToDrop.OnDrop();

        Rigidbody rb = itemToDrop.GetComponent<Rigidbody>();
        Collider col = itemToDrop.GetComponent<Collider>();

        rb.isKinematic = false;
        rb.useGravity = true;
        col.enabled = true;

        rb.AddForce(transform.forward * 2f, ForceMode.Impulse);
    }
}