using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceName : MonoBehaviour
{
    public bool needTexts;
    public GameObject text;
    public Text placeText;
    public string placeName;

    protected IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }

    public void showText()
    {
        if (needTexts)
        {
            StartCoroutine(placeNameCo());
        }
    }
}