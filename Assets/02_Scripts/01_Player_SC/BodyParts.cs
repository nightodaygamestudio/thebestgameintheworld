using System.Collections;
using UnityEngine;

public class BodyParts : MonoBehaviour
{
    public float destroyTime;
    public float force;
    public bool cutOff = false;
    public bool TorsoHitRBRemover;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon") && !HitController.Instance.HasBeenHit && !cutOff)
        {
            HitController.Instance.HasBeenHit = true;
            DetachBodyPart();
            Debug.Log("1");
            StartCoroutine(hasbeenhitcd());
        }
        if (collision.gameObject.CompareTag("Ground")) { StartCoroutine(Grounded()); }
    }
    public void DetachBodyPart()
    {
        cutOff = true;
        Instantiate(HitController.Instance.hitEffectBlood, transform.position, transform.rotation);
        transform.parent = null;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        Vector3 forceDirection = (transform.position - transform.position).normalized + Vector3.right;
        rb.AddForce(forceDirection * force, ForceMode.Impulse);
        Debug.Log("2");
    }
    IEnumerator hasbeenhitcd() { yield return new WaitForSeconds(1); HitController.Instance.HasBeenHit = false; }
    IEnumerator Grounded() { yield return new WaitForSeconds(1f); Rigidbody rb = GetComponent<Rigidbody>(); rb.isKinematic = true; }
}
