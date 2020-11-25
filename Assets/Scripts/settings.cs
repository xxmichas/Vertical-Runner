using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Audio;

public class settings : MonoBehaviour
{
    public GameObject SettingsScreen;

    public Dropdown ResolutionDropdown;

    public Toggle FullScrn;

    Resolution[] resolutions;

    private void Start()
    {
        if (Screen.fullScreen)
        {
            FullScrn.isOn = true;
        }
        else
        {
            FullScrn.isOn = false;
        }

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int CurrentResolutionIndex = 0;

        for (int i = 0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = CurrentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void Fullscreen(bool Fullscreen)
    {
        Screen.fullScreen = Fullscreen;
    }

    public void BackToMenu()
    {
        SettingsScreen.SetActive(false);
    }
}
