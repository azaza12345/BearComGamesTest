using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPos;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private int numberOfAttacks; 
    private PlayerAction playerAction;
    private Animator myAnimator;
    private void Start()
    {
        playerAction = GetComponent<PlayerAction>();
        myAnimator = GetComponent<Animator>();
    }
    public void Attack()
    {
        int randomAttack = Random.Range(1, numberOfAttacks + 1);
        if(!playerAction.canActivateThing)
            myAnimator.Play("PlayerAttack" + randomAttack);
    }

    private void DealDamage()
    {
        Collider[] enemies = Physics.OverlapSphere(attackPos.position, attackRange, enemyLayerMask);
        for(int i = 0; i<enemies.Length; i++)
        {
            if(enemies[i].gameObject.GetComponent<TakeDamage>())
                enemies[i].gameObject.GetComponent<TakeDamage>().InstantiateParticle();
        } 
    }


}
