using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] firedObject;
    private float cooldownTimer;
    private void Attack()
    {
        cooldownTimer = 0;
        firedObject[FindFireObject()].transform.position = firepoint.position;
        firedObject[FindFireObject()].GetComponent<EnemyProjectile>().ActivateProjectile();


    }
    private int FindFireObject()
    {
        for(int i = 0; i<firedObject.Length;i++)
        {
            if(!firedObject[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
       if(cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }
}
