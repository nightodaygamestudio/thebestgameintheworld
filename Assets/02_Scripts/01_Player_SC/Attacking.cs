using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class Attacking : MonoBehaviour
{
    [Header("Values")]
    public bool canAttack;
    public float AttackSpeed;
    [Header("Objects")]
    [SerializeField] Animator UpAttackAnim;
    [SerializeField] Collider swordCollider;
    public void OnUpAttack(InputAction.CallbackContext context)
    {
        if (context.started && canAttack)
        {
            UpAttackAnim.SetTrigger("UpAttack");
            canAttack = false;
            swordCollider.enabled = true;
            StartCoroutine(OnAttackIsCD());
        }
    }
    public void SideUpAttack(InputAction.CallbackContext context)
    {
        if (context.started && canAttack)
        {
            UpAttackAnim.SetTrigger("SideAttack");
            canAttack = false;
            swordCollider.enabled = true;
            StartCoroutine(OnAttackIsCD());
        }
    }
    public IEnumerator OnAttackIsCD()
    {
        yield return new WaitForSeconds(AttackSpeed);
        canAttack = true;
        swordCollider.enabled = false;
    }
}
