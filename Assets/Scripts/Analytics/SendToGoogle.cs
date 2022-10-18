using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendToGoogle : MonoBehaviour
{   
    // prod level
    // [SerializeField] private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSe1Jc8y171JmrqUy1h_NyxluyZk6d4JB8wBOd7Xp4UsTSB5Uw/formResponse";
    // dev level
    [SerializeField] private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSf3B08L-3hPyw2etOwwyMn7hOziz6TsQF395ZD9-dtHGqFzrQ/formResponse";

    private IEnumerator Post(string s1, string s2, string s3, string s4, string s5, string s6, string s7)
    {
        WWWForm form = new WWWForm();
        // prod level
        // form.AddField("entry.649184814", s1);
        // form.AddField("entry.997830938", s2);
        // form.AddField("entry.736906660", s3);
        // dev level
        form.AddField("entry.964876058", s1);
        form.AddField("entry.1863695262", s2);
        form.AddField("entry.63079170", s3);
        form.AddField("entry.652952371", s4);
        form.AddField("entry.1094316276", s5);
        form.AddField("entry.1432532251", s6);
        form.AddField("entry.378489738", s7);

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

    public void Send(string a, string b, string c, string d, string e, string f, string g)
    {
        StartCoroutine(Post(a, b, c, d, e, f, g));
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
