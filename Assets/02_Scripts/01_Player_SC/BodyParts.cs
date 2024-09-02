using System.Collections;
using UnityEngine;

public class BodyParts : MonoBehaviour
{
    public float destroyTime;
    public float force;
    public Collider Collider;
    private void Start()
    {
        Collider = GetComponent<Collider>();
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Weapon") && !BoolControler.Instance.HasBeenHit)
        {
            BoolControler.Instance.HasBeenHit = true;
            DetachBodyPart();
            Debug.Log("1");
            StartCoroutine(hasbeenhitcd());
        }
    }

    void DetachBodyPart()
    {

        transform.parent = null;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        Vector3 forceDirection = (transform.position - transform.position).normalized + Vector3.up;
        rb.AddForce(forceDirection * force, ForceMode.Impulse);
        Debug.Log("2");
        Collider.enabled = false;
    }
    IEnumerator hasbeenhitcd()
    {
        yield return new WaitForSeconds(1);
        BoolControler.Instance.HasBeenHit = false;
    }

}
