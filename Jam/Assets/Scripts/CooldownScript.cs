using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownScript : MonoBehaviour
{
    public Image cooldownImage;

    public float cooldownTime;
    public float cooldownMaxTime;

    public Button buttonPowerUp;

    public bool isInCooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldownTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownImage.fillAmount = cooldownTime / cooldownMaxTime;

        if (isInCooldown)
        {
            cooldownTime -= Time.deltaTime;
            buttonPowerUp.interactable = false;

            if (cooldownTime <= 0)
            {
                isInCooldown = false;
                buttonPowerUp.interactable = true;
            }
        }
    }

    public void ApplyCooldown()
    {
        //Si es que tienes las monedas suficientes
        isInCooldown = true;
        cooldownTime = cooldownMaxTime;
    }
}
