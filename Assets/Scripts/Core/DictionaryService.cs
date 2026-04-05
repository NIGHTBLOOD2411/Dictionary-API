using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DictionaryService : MonoBehaviour
{
    private const string BASE_URL = "https://api.dictionaryapi.dev/api/v2/entries/en/";

    public IEnumerator FetchDefinition(string word, Action<string> onSuccess, Action<string> onError)
    {
        string url = BASE_URL + word;

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                onError?.Invoke("Network error: " + request.error);
                yield break;
            }

            if (request.responseCode == 404)
            {
                onError?.Invoke("Word not found.");
                yield break;
            }

            string json = request.downloadHandler.text;

            string definition = ParseDefinition(json);

            if (string.IsNullOrEmpty(definition))
            {
                onError?.Invoke("No definition found.");
            }
            else
            {
                onSuccess?.Invoke(definition);
            }
        }
    }

    private string ParseDefinition(string json)
    {
        try
        {
            var data = JsonUtility.FromJson<DictionaryResponseWrapper>(WrapJson(json));
            return data.entries[0].meanings[0].definitions[0].definition;
        }
        catch
        {
            return null;
        }
    }

    private string WrapJson(string json)
    {
        return "{\"entries\":" + json + "}";
    }
}