using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    #region VARIABLES
    [SerializeField]
    GameObject target;
    Vector3 offset;
    #endregion

    #region UNITY CALLBACKS
    public void Start()
    {
        CalcOffset();
    }
    private void LateUpdate() //to make camera follow puppy everytime it moves
    {
        transform.position = target.transform.position + offset;
    }
    #endregion

    private void CalcOffset()
    {
        offset = transform.position - target.transform.position;
    }
}
