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
        MessagePanel.SetActive(false);
    }

    public void ShowMessage(string Message, float Duration)
    {
        StartCoroutine(ShowMessageCoroutine(Message, Duration));
    }

    IEnumerator ShowMessageCoroutine(string Message, float Duration)
    {
        //Debug.Log("Showing some message. Duration: " + Duration);
        MessageText.text = Message;
        MessagePanel.SetActive(true);

        yield return new WaitForSeconds(Duration);

        MessagePanel.SetActive(false);
      //  Command.CommandExecutionComplete();
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
