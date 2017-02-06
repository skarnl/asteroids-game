using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Prime31.MessageKit;
using UnityEngine.UI;

namespace Managers {

    public class HealthManager : Singleton<HealthManager> {
        protected HealthManager () {} // guarantee this will be always a singleton only - can't use the constructor!

        private const int MAX_PLAYER_HEALTH = 1000;
        public const int ASTEROID_HIT_DAMAGE = 250;

        private RectTransform healthBar;
        private Text whiteHealthText;
        private Text blackHealthText;
        private Health playerHealth;
        private float originalWidth;

        public void Awake ()
        {
            playerHealth = GameObject.Find("Player").GetComponent<Health>();

            healthBar = GameObject.Find("PlayerHealthBar").GetComponent<RectTransform>();
            whiteHealthText = GameObject.Find("WhiteText").GetComponent<Text>();
            blackHealthText = GameObject.Find("BlackText").GetComponent<Text>();

            playerHealth.hitPoints = MAX_PLAYER_HEALTH;
            originalWidth = healthBar.rect.width;
        }

        public void AddHealth(int addedHealth)
        {
            playerHealth.hitPoints = Math.Min(MAX_PLAYER_HEALTH, playerHealth.hitPoints + addedHealth);
        }

        public void SubstractHealth(int substractHealth)
        {
            playerHealth.hitPoints = Math.Max(0, playerHealth.hitPoints - substractHealth);
        }

        public void UpdateHealth(int health) {
            playerHealth.hitPoints = Math.Min(0, Math.Max(MAX_PLAYER_HEALTH, health));
        }

        private void LateUpdate()
        {
            float percentage = (float)playerHealth.hitPoints / (float)MAX_PLAYER_HEALTH;

            healthBar.sizeDelta = new Vector2(originalWidth * percentage, healthBar.rect.height);

            whiteHealthText.text = blackHealthText.text = String.Format("{0}/{1}", playerHealth.hitPoints, MAX_PLAYER_HEALTH);
        }
    }

}

