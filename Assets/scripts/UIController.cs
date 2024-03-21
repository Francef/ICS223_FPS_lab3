using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private SettingsPopup settingsPopup;
    private float initialHealth = 1.0f;
    private int popupsActive = 0;
    [SerializeField] private GameOverPopup gameOverPopup;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth(initialHealth);
        SetGameActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && popupsActive == 0)
        {
            optionsPopup.Open();
        }
    }

    // update score display
    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1;                         // unpause the game
            Cursor.lockState = CursorLockMode.Locked;   // lock cursor at center
            Cursor.visible = false;                     // hide cursor
            crossHair.gameObject.SetActive(true);       // show the crosshair
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
        }
        else
        {
            Time.timeScale = 0;                         // pause the game
            Cursor.lockState = CursorLockMode.None;     // let cursor move freely
            Cursor.visible = true;                      // hide cursor
            crossHair.gameObject.SetActive(false);      // turn off the crosshair
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
        }
    }

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.AddListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, OnPopupClosed);
        
    }

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.RemoveListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, OnPopupClosed);

    }

    private void OnHealthChanged(float newHealth)
    {
        UpdateHealth(newHealth);
    }

    public void UpdateHealth(float healthPercentage)
    {
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);
        healthBar.fillAmount = healthPercentage;
    }

    private void OnPopupOpened()
    {
        if (popupsActive == 0)
        {
            SetGameActive(false);
        }
        popupsActive++;
    }

    private void OnPopupClosed()
    {
        popupsActive--;
        if (popupsActive == 0) 
        {
            SetGameActive(true);
        }
    }

    public void ShowGameOverPopup()
    {
        gameOverPopup.Open();
    }

}
