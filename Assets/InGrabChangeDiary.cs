using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InGrabChangeDiary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public void InGrabChangeDiaryState(SelectEnterEventArgs args)
    {
        if(args.interactable.gameObject.name == "Diary")
        {
            GameManager.Instance.diary.transform.GetChild(0).gameObject.SetActive(false);
            GameManager.Instance.diary.transform.GetChild(1).gameObject.SetActive(true);
            UiManager.Instance.diaryCanvas.gameObject.SetActive(true);
        }
    }

    public void InGrabEndChangeDiaryState(SelectExitEventArgs args)
    {
        if(args.interactable.gameObject.name == "Diary")
        {
            GameManager.Instance.diary.transform.GetChild(1).gameObject.SetActive(false);
            GameManager.Instance.diary.transform.GetChild(0).gameObject.SetActive(true);
            UiManager.Instance.diaryCanvas.gameObject.SetActive(false);
        }
    }
}
