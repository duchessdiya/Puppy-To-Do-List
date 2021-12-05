using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PuppyController : MonoBehaviour
{
    #region VARIABLES
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    GameObject AppLayout;
    Vector3 previousPosition;
    const string walkableTag = "Ground";
    const string playerTag = "Player";
    float timeJumpDelay = .5f;
    float jumpTime;
    [Header("Related Scripts")]
    [SerializeField]
    CharacterAnimator CharacterAnimatorScript;
    #endregion

    #region UNITY CALLBACK
    private void Start()
    {
        previousPosition = transform.position;
    }
    private void Update()
    {
        CheckMovement();
        CheckAnimations();
    }
    #endregion
    #region PRIVATE METHODS
    private void CheckMovement()
    {
        if(Input.GetMouseButton(0) && !AppLayout.gameObject.activeInHierarchy)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.tag ==  walkableTag)
                {
                    MoveTo(hit.point);
                }
                else if (hit.transform.gameObject.tag ==  playerTag)
                {
                    CheckJump();
                }
            }
        }
    }
    private void MoveTo(Vector3 targetPosition)
    {
        CharacterAnimatorScript.setWalk( agent.SetDestination(targetPosition) );
    }
    private void CheckAnimations()
    {
        if(transform.position == previousPosition)
        {
            CharacterAnimatorScript.setWalk(false);
        }
        previousPosition = transform.position;
    }
    private void CheckJump()
    {
        if(jumpTime + timeJumpDelay < Time.time)
        {
            jumpTime = Time.time;
            CharacterAnimatorScript.setJump(true);
        }
    }
    #endregion
}