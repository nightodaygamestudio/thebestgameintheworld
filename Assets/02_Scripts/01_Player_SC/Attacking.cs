using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class Attacking : MonoBehaviour, i_Update
{
    [Header("Values")]
    public bool canAttack;
    public float AttackSpeed;
    [Header("Objects")]
    [SerializeField] Animator AttackAnim;
    [SerializeField] Collider swordCollider;

    private void Start()
    {
        UpdateManager.Instance.RegisterUpdate(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance.UnregisterUpdate(this);
    }

    public void CostumUpdate()
    {
        ColliderControler();
    }
    public void OnUpAttack(InputAction.CallbackContext context)
    {
        if (context.started && canAttack)
        {
            AttackAnim.SetTrigger("UpAttack");
            canAttack = false;
            StartCoroutine(OnAttackIsCD());
        }
    }
    public void SideUpAttack(InputAction.CallbackContext context)
    {
        if (context.started && canAttack)
        {
            AttackAnim.SetTrigger("SideAttack");
            canAttack = false;
            StartCoroutine(OnAttackIsCD());
        }
    }
    private void ColliderControler()
    {
        if (AttackAnim.GetCurrentAnimatorStateInfo(0).IsName("UpperStrike") || AttackAnim.GetCurrentAnimatorStateInfo(0).IsName("SideStrike"))
        {
            swordCollider.enabled = true;
        }
        else
        {
            swordCollider.enabled = false;
        }
    }
    public IEnumerator OnAttackIsCD()
    {
        yield return new WaitForSeconds(AttackSpeed);
        canAttack = true;
    }
}
