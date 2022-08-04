using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainUIManager : MonoBehaviour
{
    public Text mainText;

    private void Start()
    {
        HolderOfInfo.instance.LoadNameAndScore();

        mainText.text = "Best Score: " + HolderOfInfo.instance.bestScore + " : " + HolderOfInfo.instance.bestScoreName;
    }


}
