using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollViewController : MonoBehaviour
{
    #region VARIABLES
    [Header("Serialized Fields")]

    [SerializeField]
    GameObject List_Item;

    [SerializeField]
    GameObject Contents;

    [SerializeField]
    GameObject CompletedAnimation;


    [SerializeField]
    string myName;
    const string playerPrefItemText = "Text";
    const string playerPrefItemState = "itemState";

    List<string> myListItemText;
    List<bool> myListItemState;

    #endregion

    #region UNITY CALLBACKS
    private void Start()
    {
        myListItemText = PlayerPrefsExtra.GetList<string>(myName + playerPrefItemText, new List <string>());
        myListItemState = PlayerPrefsExtra.GetList<bool>(myName + playerPrefItemState, new List <bool>());
        FetchList();
    }
    #endregion 

    #region PUBLIC METHODS
    public void AddListitem(string text, bool isCompleted, bool isNew)
    {
        GameObject newListItem = Instantiate(List_Item, Contents.transform);
        newListItem.GetComponent<ItemController>().UpdateListItem(text, isCompleted);

        if(isNew)
        {
            ItemController currentItemScript = newListItem.GetComponent<ItemController>();
            UpdateCurrentList(currentItemScript);
        }
    }
    public void DeleteItem(int itemIndex)
    {
        myListItemText.RemoveAt(itemIndex);
        myListItemState.RemoveAt(itemIndex);
        UpdatePlayerPrefs();
    }
    public void AddItem(ItemController newItemController)
    {
        if(newItemController.GetState())
        {
            CompletedAnimation.SetActive(true);
        }
        UpdateCurrentList(newItemController);
    }
    public void ClearPlayerPrefs(GameObject ItemToBeDeleted)
    {
        PlayerPrefsExtra.SetList<string>(myName + playerPrefItemText, new List<string>());
        PlayerPrefsExtra.SetList<bool>(myName + playerPrefItemState, new List<bool>());
    }
    
    #endregion

    #region PRIVATE METHODS
    private void FetchList()
    {
        for(int i = 0; i < myListItemText.Count; i++)
       {
           AddListitem(myListItemText[i],myListItemState[i], false);
       }
    }
    private void UpdateCurrentList(ItemController currentItemScript)
    {
        myListItemText.Add(currentItemScript.GetText());
        myListItemState.Add(currentItemScript.GetState());

        UpdatePlayerPrefs();
    }
    private void UpdatePlayerPrefs()
    {
        PlayerPrefsExtra.SetList<string>(myName + playerPrefItemText, myListItemText);
        PlayerPrefsExtra.SetList<bool>(myName + playerPrefItemState, myListItemState);
    }

    #endregion
}
 