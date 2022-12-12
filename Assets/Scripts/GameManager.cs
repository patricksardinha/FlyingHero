using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Button buttonInventory;
    public Button buttonQuitInventory;
    public Button buttonSettings;
    public Button buttonQuitSettings;
    public Button buttonMap;
    public Button buttonQuitMap;
    public GameObject panelInventory;
    public GameObject panelSettings;
    public GameObject panelMap;

    public GameObject player;
    private Animator playerAnimator;
    public Avatar avatarM;
    public Avatar avatarF;

    public GameObject audioBackground;

    private void Start()
    {
        playerAnimator = player.transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !panelInventory.activeSelf && !panelSettings.activeSelf)
        {
            panelInventory.SetActive(true);
            buttonInventory.gameObject.SetActive(false);
            buttonQuitInventory.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && panelInventory.activeSelf && !panelSettings.activeSelf)
        {
            panelInventory.SetActive(false);
            buttonQuitInventory.gameObject.SetActive(false);
            buttonInventory.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && !panelSettings.activeSelf)
        {
            panelSettings.SetActive(true);
            buttonSettings.gameObject.SetActive(false);
            buttonQuitSettings.gameObject.SetActive(true);
            if (panelInventory.activeSelf)
            {
                buttonQuitInventory.gameObject.SetActive(false);
            }
            else
            {
                buttonInventory.gameObject.SetActive(false);
            }
        } 
        else if (Input.GetKeyDown(KeyCode.E) && panelSettings.activeSelf)
        {
            panelSettings.SetActive(false);
            buttonQuitSettings.gameObject.SetActive(false);
            buttonSettings.gameObject.SetActive(true);
            if (panelInventory.activeSelf)
            {
                buttonQuitInventory.gameObject.SetActive(true);
            }
            else
            {
                buttonInventory.gameObject.SetActive(true);
            }
        }

        // Your are playing the girl
        if (panelSettings.activeSelf && !player.transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                // Deactivate the girl model
                player.transform.GetChild(1).transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
                // Activate the boy one
                player.transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
                // Change the Avatar in the Animator component (Armature object)
                playerAnimator.avatar = avatarM;

                // Buttons managing
                panelSettings.SetActive(false);
                buttonQuitSettings.gameObject.SetActive(false);
                buttonSettings.gameObject.SetActive(true);
                if (panelInventory.activeSelf)
                {
                    buttonQuitInventory.gameObject.SetActive(true);
                }
                else
                {
                    buttonInventory.gameObject.SetActive(true);
                }
            }
        }

        // Your are playing the boy
        if (panelSettings.activeSelf && !player.transform.GetChild(1).transform.GetChild(1).transform.GetChild(1).gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                // Deactivate the boy model
                player.transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                // Activate the girl one
                player.transform.GetChild(1).transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
                // Change the Avatar in the Animator component (Armature object)
                playerAnimator.avatar = avatarF;

                // Buttons managing
                panelSettings.SetActive(false);
                buttonQuitSettings.gameObject.SetActive(false);
                buttonSettings.gameObject.SetActive(true);
                if (panelInventory.activeSelf)
                {
                    buttonQuitInventory.gameObject.SetActive(true);
                }
                else
                {
                    buttonInventory.gameObject.SetActive(true);
                }
            }
        }

        if (panelSettings.activeSelf && Input.GetKeyDown(KeyCode.Y) && !audioBackground.activeSelf)
        {
            audioBackground.SetActive(true);
        }
        else if (panelSettings.activeSelf && Input.GetKeyDown(KeyCode.N) && audioBackground.activeSelf)
        {
            audioBackground.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.M) && !panelMap.activeSelf && !panelSettings.activeSelf)
        {
            panelMap.SetActive(true);
            buttonMap.gameObject.SetActive(false);
            buttonQuitMap.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.M) && panelMap.activeSelf && !panelSettings.activeSelf)
        {
            panelMap.SetActive(false);
            buttonQuitMap.gameObject.SetActive(false);
            buttonMap.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
