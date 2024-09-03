using System.Collections;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public float CD;
    public Collider hitCollider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BodyPart")) { hitCollider.enabled = false; StartCoroutine(hitCD()); }
        if (collision.gameObject.CompareTag("Head/Neck")) { HitControler.Instance.Head_Neck_Hit = true; StartCoroutine(hitCD()); }
        if (collision.gameObject.CompareTag("Torso/Waist")) { HitControler.Instance.Torso_Waist_Hit = true; StartCoroutine(hitCD()); }
        if (collision.gameObject.CompareTag("L_Thigh")) { HitControler.Instance.L_Thigh_Hit = true; StartCoroutine(hitCD()); }
        if (collision.gameObject.CompareTag("R_Thigh")) { HitControler.Instance.R_Thigh_Hit = true; StartCoroutine(hitCD()); }
    }
    private IEnumerator hitCD()
    {
        yield return new WaitForSeconds(CD);
        hitCollider.enabled = true;
    }

}
