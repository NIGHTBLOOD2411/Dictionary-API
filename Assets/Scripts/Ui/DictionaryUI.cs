using UnityEngine;
using UnityEngine.UI;

public class DictionaryUI : MonoBehaviour
{
    public InputField inputField;
    public Button searchButton;
    public DictionaryService service;

    private bool isRequestRunning = false;

    public void OnSearchClicked()
    {
        if (isRequestRunning)
        {
            Debug.LogWarning("Request already in progress...");
            return;
        }

        string word = inputField.text.Trim();

        if (string.IsNullOrEmpty(word))
        {
            Debug.LogWarning("Enter a valid word");
            return;
        }

        StartRequest();

        StartCoroutine(service.FetchDefinition(
            word,
            OnSuccess,
            OnError
        ));
    }

    private void StartRequest()
    {
        isRequestRunning = true;
        inputField.interactable = false;
        searchButton.interactable = false;
        Debug.Log("Loading...");
    }

    private void EndRequest()
    {
        isRequestRunning = false;
        inputField.interactable = true;
        searchButton.interactable = true;
    }

    private void OnSuccess(string definition)
    {
        Debug.Log("<b>Definition:</b> " + definition);
        EndRequest();
    }

    private void OnError(string error)
    {
        Debug.LogError(error);
        EndRequest();
    }
}