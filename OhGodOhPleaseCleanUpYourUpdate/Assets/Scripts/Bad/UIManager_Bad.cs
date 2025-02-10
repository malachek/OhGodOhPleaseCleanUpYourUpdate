using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Bad : MonoBehaviour
{
    public Slider AmmoSlider;
    public TextMeshProUGUI KillCountDisplay;
    public TextMeshProUGUI BlockedCountDisplay;

    private void Awake()
    {
        // [hint] Subscribe? <- ask us what this means
    }

    private void Start()
    {
        AmmoSlider.value = 1;
        Player_Bad player = GameObject.FindFirstObjectByType<Player_Bad>();
        KillCountDisplay.text = "Enemies Killed: " + player.Kills + ".";
        BlockedCountDisplay.text = "Blocked Shots: " + player.Blocks + ".";
    }

    private void Update()
    {
        Player_Bad player = GameObject.FindFirstObjectByType<Player_Bad>();
        AmmoSlider.value = (float)player.BulletCount / player.MaxBullets;
        KillCountDisplay.text = "Enemies Killed: " + player.Kills + ".";
        BlockedCountDisplay.text = "Blocked Shots: " + player.Blocks + ".";
    }

    private void OnDestroy()
    {
        // [hint] Do I need to unsubscribe if i unsubscribe
        // [hint] Wait who calls me...
    }

}
