using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour 
{
    public TextMeshProUGUI MessageText;
    public GameObject MessagePanel;

    public static MessageManager Instance;

    void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    public void ShowMessage(string Message, float Duration)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(ShowMessageCoroutine(Message, Duration));
    }

    IEnumerator ShowMessageCoroutine(string Message, float Duration)
    {
      
        MessageText.text = Message;
        
        yield return new WaitForSeconds(Duration);
        this.gameObject.SetActive(false);
      
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ShowMessage("Your turn",5);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowMessage("Enemy turn",6);
        }
    }
}
