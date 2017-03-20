using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Prime31.MessageKit;
using UnityEngine.UI;

namespace Managers {

    /**
    * Class to monitor the health and update the health bar - not really a manager, so move it?
    */
    public class HealthManager : Singleton<HealthManager> {
        protected HealthManager () {} // guarantee this will be always a singleton only - can't use the constructor!

        private RectTransform healthBar;
        private Text whiteHealthText;
        private Text blackHealthText;
        private Health playerHealth;
        private float originalWidth;
        private int startHealth;

        public void Awake ()
        {
            playerHealth = GameObject.Find("Player").GetComponent<Health>();

            healthBar = GameObject.Find("PlayerHealthBar").GetComponent<RectTransform>();
            whiteHealthText = GameObject.Find("WhiteText").GetComponent<Text>();
            blackHealthText = GameObject.Find("BlackText").GetComponent<Text>();

            startHealth = playerHealth.Hitpoints;
            originalWidth = healthBar.rect.width;
        }

        private void LateUpdate()
        {
            float percentage = (float)playerHealth.Hitpoints / (float)startHealth;

            healthBar.sizeDelta = new Vector2(originalWidth * percentage, healthBar.rect.height);

            whiteHealthText.text = blackHealthText.text = String.Format("{0}/{1}", playerHealth.Hitpoints, startHealth);
        }
    }

}

