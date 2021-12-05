using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    #region VARIABLES
    [Header("Childs to be Updated")]

    [SerializeField]
    Text myTextComponent;

    [SerializeField]
    GameObject isCompletedObject;

    [SerializeField]
    GameObject todoObject;

    [Header("Local Variables")]
    bool state;
    GameObject myParent;
    const string completedTag = "CompletedContent";
    const string todoTag = "TodoContent";
    #endregion

    #region PUBLIC METHODS

    public void UpdateListItem(string newText, bool isCompleted)
    {
        if(newText.Length > 0)
        {
            myTextComponent.text = newText;
        }
        isCompletedObject.SetActive(isCompleted);
        todoObject.SetActive(!isCompleted);

        UpdateParent(isCompleted);
        state = isCompleted;
    }
    public string GetText()
    {
       return myTextComponent.text;
    }
    public bool GetState()
    {
        return state;
    }
    public void ConvertTask(bool toCompleted)
    {
        DeleteMeFromParent();
        UpdateListItem(myTextComponent.text, toCompleted);
        myParent.transform.parent.GetComponent<ScrollViewController>().AddItem(GetComponent<ItemController>());
    }
    public void DeleteListItem()
    {
        DeleteMeFromParent();
        Destroy(gameObject);
    }
    #endregion
    #region PRIVATE METHODS
    private void UpdateParent(bool isCompleted)
    {
        if(isCompleted)
        {
            myParent = GameObject.FindGameObjectWithTag(completedTag);
        }
        else
        {
            myParent = GameObject.FindGameObjectWithTag(todoTag);   
        }
        transform.SetParent(myParent.transform);
    }
    private void DeleteMeFromParent()
    {
        myParent.transform.parent.GetComponent<ScrollViewController>().DeleteItem(transform.GetSiblingIndex());
    }
    #endregion
}

