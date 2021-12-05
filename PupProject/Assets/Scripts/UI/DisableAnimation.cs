using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimation : MonoBehaviour
{
    #region PUBLIC METHODS
    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
