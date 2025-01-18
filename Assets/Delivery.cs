using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool isPickedUp = false;
    int packagesDelivered = 0;
    Color32 noPackageColor = new Color32(255, 255, 255, 255);
    Color32 hasPackageColor = new Color32(255, 77, 0, 255);
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // other.tag == "Package"
        if (other.CompareTag("Package")) 
        {
            PickUpPackage(other);
        }
        else if (other.CompareTag("DropPoint"))
        {
            DeliverPackage();
        }
    }

    private void PickUpPackage(Collider2D package)
    {
        if (isPickedUp)
        {
            return;
        }

        isPickedUp = true;
        Destroy(package.gameObject);
        spriteRenderer.color = hasPackageColor;
    }

    private void DeliverPackage()
    {
        if (!isPickedUp) 
        {
            return; 
        }

        isPickedUp = false;
        packagesDelivered++;
        spriteRenderer.color = noPackageColor;
    }
}
