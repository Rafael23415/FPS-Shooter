using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hints : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    private float hintChangeInterval = 7f;
    public AudioSource hintClick;

    List<string> hintCount = new List<string>
    {
        "Can't see anything, try clicking L",
        "Be afraid of them",
        "Don't get to close",
        "Always reload when you can, maybe you will need this extra bullets",
        "Look for batteries, they'll give you extra health",
        "Trust no one in the darkness",
        "Venture deeper, but beware"
    };

    private Coroutine changeHintCoroutine;

    private void Start()
    {
        StartChangeHintAutomatically();
    }

    public void PressButton()
    {
        hintClick.Play();
        ChangeHint();
    }


    private void ChangeHint()
    {
        if (changeHintCoroutine != null)
        {
            StopCoroutine(changeHintCoroutine);
        }
        changeHintCoroutine = StartCoroutine(ChangeHintAutomatically());
    }

    private void StartChangeHintAutomatically()
    {
        if (changeHintCoroutine != null)
        {
            StopCoroutine(changeHintCoroutine);
        }
        changeHintCoroutine = StartCoroutine(ChangeHintAutomatically());
    }

    private IEnumerator ChangeHintAutomatically()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, hintCount.Count);
            string randomHint = hintCount[randomIndex];
            hintText.text = randomHint;
            yield return new WaitForSeconds(hintChangeInterval);
        }
    }
}






