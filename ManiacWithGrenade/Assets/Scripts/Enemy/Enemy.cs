using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : SpawnedObjectBase
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    private const float MAX_HEALTH = 100.0f;

    private float health;

    public void RestoreHealth()
    {
        health = MAX_HEALTH;
        UpdateUI();
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0.0f, MAX_HEALTH);
        UpdateUI();

        if (health.Equals(0.0f))
        {
            // Die
            spawner.SpawnWithDelay();
        }
    }

    private void UpdateUI()
    {
        healthSlider.value = health / MAX_HEALTH;
        healthText.text = health.ToString();
    }
}
