using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffCorrectMarker : MonoBehaviour
{
    public SB_Slidebar sb_Slidebar;
    public SB_TrueRange sb_TrueRange;
    public GameObject correctMarker;
    public GameObject incorrectMarker;
    public GameObject marker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (sb_Slidebar.InTune)
        {
            StartCoroutine(ActiveCorrectMarker());
            //correctMarker.SetActive(true);
        }
        if (sb_Slidebar.incorrectPress)
        {
            StartCoroutine(DesactiveCorrectMarker());
        }
    }

    IEnumerator ActiveCorrectMarker()
    {
        correctMarker.SetActive(true);
        yield return new WaitForSeconds(0.1f);        
        correctMarker.SetActive(false);
        //sb_TrueRange.isSetupDone = false;
        sb_TrueRange.SetVariable();
        sb_Slidebar.InTune = false;
    }

    IEnumerator DesactiveCorrectMarker()
    {
        marker.SetActive(false);
        incorrectMarker.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        incorrectMarker.SetActive(false);
        marker.SetActive(true);
        //sb_TrueRange.SetupVariables();
        sb_TrueRange.SetVariable();
        sb_Slidebar.incorrectPress = false;
    }
}