using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    public InputField inputField;
    public Button startButton;
    public bool valueChanged = false;
    void Start()
    {

    }

    public void StartGame()
    {
        if (valueChanged == true)
        {
            HolderOfInfo.instance.playerName = inputField.text;
            SceneManager.LoadScene(1);
        }
    }

    public void ValueChanged()
    {
        valueChanged = true;
    }

}
