using System.Collections;
using UnityEngine;

[System.Serializable]
public class Treatment
{
    public string id;
    public string[] requestMessages;
    public string[] postMessages;

    public string GetRequestMessage()
    {
        int index = Random.Range(0, requestMessages.Length);
        return requestMessages[index];
    }

    public string GetPostMessage()
    {
        int index = Random.Range(0, postMessages.Length);
        return postMessages[index];
    }
}