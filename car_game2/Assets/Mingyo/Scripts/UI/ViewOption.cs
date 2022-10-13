using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewOption : MonoBehaviour
{
    FullScreenMode screenMode;
    public Toggle fullScreenBtn;
    List<Resolution> resolutions = new List<Resolution>();
    public TMP_Dropdown resolutionDropDown;
    int resolutionNum;


    private void Start()
    {
        InitUI();
    }

    void InitUI()
    {
        for(int i = 0; i < Screen.resolutions.Length; i++)
        {
            if(Screen.resolutions[i].refreshRate == 60)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }

        resolutions.Reverse();

        resolutionDropDown.options.Clear();

        int optionNum = 0;

        foreach(Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
            optionData.text = item.width + "X" + item.height + " " + item.refreshRate + "Hz";
            resolutionDropDown.options.Add(optionData);

            if(item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropDown.value = optionNum;
                optionNum++;
            }
        }
        resolutionDropDown.RefreshShownValue();

        fullScreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void DropDownOptionChange(int a)
    {
        resolutionNum = a;
    }

    public void OKButtonClick()
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);
    }

    public void ToggleBtn(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
}
