using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public GameObject[] BodyParts;
    public float force;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Weapon"))
        {
            foreach (GameObject part in BodyParts)
            {
                if (collision.contacts[0].thisCollider.gameObject == part)
                {
                    DetachBodyPart(part);
                    break;
                }
            }
        }
    }

    void DetachBodyPart(GameObject part)
    {
        Debug.Log("fall");
        part.transform.parent = null;
        Rigidbody rb = part.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(transform.forward * force);
        }
    }
}
