using System.Collections;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    [SerializeField] float CD;
    [SerializeField] Collider hitCollider;
    [SerializeField] PlayerHealth ph;
    [SerializeField] float damage;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BodyPart"))
        {
            hitCollider.enabled = false;
            StartCoroutine(hitCD());
        }
        if (collision.gameObject.CompareTag("Head/Neck"))
        {
            hitCollider.enabled = false;
            HitController.Instance.Head_Neck_Hit = true;
            StartCoroutine(hitCD());
        }
        if (collision.gameObject.CompareTag("Torso/Waist"))
        {
            hitCollider.enabled = false;
            HitController.Instance.Torso_Waist_Hit = true;
            StartCoroutine(hitCD());
        }
        if (collision.gameObject.CompareTag("L_Thigh"))
        {
            hitCollider.enabled = false;
            HitController.Instance.L_Thigh_Hit = true;
            StartCoroutine(hitCD());
        }
        if (collision.gameObject.CompareTag("R_Thigh"))
        {
            hitCollider.enabled = false;
            HitController.Instance.R_Thigh_Hit = true;
            StartCoroutine(hitCD());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BodyPart"))
        {
            ph.TakeDamage(damage);
            StartCoroutine(hitCD());
            Instantiate(HitController.Instance.hitEffectBlood, transform.position, transform.rotation);
        }
    }

    private IEnumerator hitCD()
    {
        yield return new WaitForSeconds(CD);
        hitCollider.enabled = true;
    }
}