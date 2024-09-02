using System.Collections;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public float CD;
    public Collider hitCollider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BodyPart"))
        {
            hitCollider.enabled = false;
            StartCoroutine(hitCD());

        }
    }
    private IEnumerator hitCD()
    {
        yield return new WaitForSeconds(CD);
        hitCollider.enabled = true;
    }
}
