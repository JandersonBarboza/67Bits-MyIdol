using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCam : MonoBehaviour
{
    public List<GameObject> patrolPoints;
    public float speed = 2;
    public float distanceToDetect;
    public GameObject target;

    //private Animator anim;
    public int currentPointIndex;
    public bool isAttacking;
    public bool choosingNextPoint;

    public enum States { IDLE, MOVING, WASTED };
    public States state;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        currentPointIndex = 0;
    }

    private void Update()
    {
        if (state != States.WASTED && !choosingNextPoint)
        {
            Patrol();
        }
        //anim.SetBool("walk", state == States.MOVING);
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position, patrolPoints[currentPointIndex].transform.position) < 0.5f)
        {
            StartCoroutine(NextPatrolPoint());
        }
        else
        {
            state = States.MOVING;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(patrolPoints[currentPointIndex].transform.position.x, transform.position.y, patrolPoints[currentPointIndex].transform.position.z), speed * Time.deltaTime);
            transform.LookAt(new Vector3(patrolPoints[currentPointIndex].transform.position.x, transform.position.y, patrolPoints[currentPointIndex].transform.position.z));
        }
    }

    private IEnumerator NextPatrolPoint()
    {
        choosingNextPoint = true;
        state = States.IDLE;
        if (currentPointIndex < patrolPoints.Count - 1)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }

        yield return new WaitForSeconds(2);
        choosingNextPoint = false;
        state = States.MOVING;
    }

    private void OnTriggerStay(Collider other)
    {
        //if (state == States.IDLE)
        //{
        //    anim.SetBool("walk", true);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //StartCoroutine("StopAttack");
    }
}
