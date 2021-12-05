using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class InputFieldHandler : MonoBehaviour
{
    #region VARIABLES
    InputField inputField;
    [Header("Related Scripts")]
    [SerializeField]
    ScrollViewController todoScrollScript;
    #endregion

    #region UNITY CALLBACKS
    private void Start()
    {
        inputField = GetComponent<InputField>();
    }
    #endregion

    #region PUBLIC METHODS
    public void ApplyingText()
    {
        string userInput = inputField.text;
        if(userInput.Length > 0)
        {
            inputField.text = null;
            todoScrollScript.AddListitem(userInput, false, true);
        }
    }
    #endregion
}