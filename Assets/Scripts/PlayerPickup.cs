using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPoint;
    public PickupItem startingItem;

    private PickupItem heldItem;

    void Start()
    {
        if (startingItem != null)
        {
            SpawnStartingItem();
        }
    }

    void SpawnStartingItem()
    {
        PickupItem item = Instantiate(startingItem, holdPoint.position, holdPoint.rotation);
        PickupItem(item);
    }

    public void PickupItem(PickupItem item)
    {
        if (heldItem != null) return;

        heldItem = item;
        item.OnPickup(holdPoint);
    }
}