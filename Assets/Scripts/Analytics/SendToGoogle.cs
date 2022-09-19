using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendToGoogle : MonoBehaviour
{
    [SerializeField] private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSe1Jc8y171JmrqUy1h_NyxluyZk6d4JB8wBOd7Xp4UsTSB5Uw/formResponse";

    private IEnumerator Post(string s1, string s2, string s3)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.649184814", s1);
        form.AddField("entry.997830938", s2);
        form.AddField("entry.736906660", s3);
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }

    }

    public void Send(string a, string b, string c)
    {
        StartCoroutine(Post(a, b, c));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
