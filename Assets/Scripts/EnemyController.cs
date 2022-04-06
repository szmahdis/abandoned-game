using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;

    Transform target;

    NavMeshAgent agent;

    CharacterCombat characterCombat;

    public CharacterStats playerStats;

    MeshRenderer enemyMesh;

    bool showed = false;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instace.player.transform;

        agent = GetComponent<NavMeshAgent>();

        characterCombat = GetComponent<CharacterCombat>();

        //playerStats = PlayerManager.instace.GetComponent<CharacterStats>();

        //gameObject. .SetActive(false);
        enemyMesh = GetComponentInChildren<MeshRenderer>();

        enemyMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distacne = Vector3.Distance(target.position, transform.position);

        if(distacne <= lookRadius)
        {
            //enemyMesh.enabled = true;

            if (!showed)
            {
                StartCoroutine(SetVisibleTime(3.0f));
                showed = true;
            }

            agent.SetDestination(target.position);

            //SetVisible();

            //SetVisible(1.0f);

            if(distacne <= 2.0f)
            {
                //haracterStats targetStats = GetComponent<CharacterStats>();
                Debug.LogWarning(playerStats);
                if (playerStats != null)
                {
                    StartCoroutine(SetVisibleTime(3.0f));
                    characterCombat.Attack(playerStats);

                    //may trigger some events here;
                    //enemyMesh.enabled = false;
                    //SetInvisible();

                }
                //face to the player
                //Face2Player();
            }

            if(distacne <= agent.stoppingDistance)
            {
                //attack the player
                //characterCombat.Attack(PlayerManager.instace.player.GetComponent<CharacterStats>());
                CharacterStats targetStats = GetComponent<CharacterStats>();
                Debug.LogWarning(targetStats);
                if (target != null)
                {
                    characterCombat.Attack(targetStats);
                }
                //face to the player
                Face2Player();    
            }
        }
        else
        {
            SetInvisible();
        }
    }

    void Face2Player()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


    public void SetVisible()
    {
        enemyMesh.enabled = true;
    }

    public void SetInvisible()
    {
        enemyMesh.enabled = false;
    }

    IEnumerator SetVisibleTime(float time)
    {
        SetVisible();
        yield return new WaitForSeconds(time);

        SetInvisible();
    }


    void Disappear()
    {

    }
}
