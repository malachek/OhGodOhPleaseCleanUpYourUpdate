using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Slider AmmoSlider;

    [SerializeField]
    private TextMeshProUGUI KillCountDisplay;

    [SerializeField]
    private TextMeshProUGUI BlockedCountDisplay;

    private int Kills = 0;

    private int BlockedShots = 0;

    Player player;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();

        //Subscribes to event for ammo
        player.OnPlayerShoot += UpdateAmmoCount;
        //Subcribes to event for kill
        player.OnBulletHitOrBlock += DetermineCountIncrease;

    }

    private void Start()
    {
        Kills = 0;
        AmmoSlider.value = 1;
        KillCountDisplay.text = $"Enemies Killed: {Kills}";
        BlockedCountDisplay.text = $"Blocked Shots: {BlockedShots}";
    }

    private void OnDestroy()
    {

        //Unsubscribes to event for ammo
        player.OnPlayerShoot -= UpdateAmmoCount;
        //Unsubcribes to event for kill
        player.OnBulletHitOrBlock += DetermineCountIncrease;
    }

    private void UpdateAmmoCount(float AmmoPercent)
    {
        AmmoSlider.value = AmmoPercent;
    }

    private void DetermineCountIncrease(bool IsHit)
    {
        if (IsHit) { IncreaseKillCount(); } else { BlockedShot(); }
    }

    private void IncreaseKillCount()
    {
        Kills++;
        KillCountDisplay.text = $"Enemies Killed: {Kills}";
    }

    private void BlockedShot()
    {
        BlockedShots++;
        BlockedCountDisplay.text = $"Blocked Shots: {BlockedShots}";
    }
}
