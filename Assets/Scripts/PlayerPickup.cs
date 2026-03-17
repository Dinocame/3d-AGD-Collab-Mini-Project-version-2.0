using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPoint;

    private PickupItem heldItem;

    public void PickupItem(PickupItem item)
    {
        if (heldItem != null) return;

        heldItem = item;
        item.OnPickup(holdPoint);
    }
}