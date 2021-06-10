﻿using UnityEngine;
using TMPro;

namespace UI
{
    public class CoinsUIManager : MonoBehaviour
    {
        #region Fields
        [Header("Award menu")]
        [SerializeField] TextMeshProUGUI awardTMP;
        [Header("Number of coins")]
        [SerializeField] TextMeshProUGUI numberOfCoinsTMP;
        [SerializeField] GameObject coinsDecoration;
        [Header("Gameplay menu")]
        [SerializeField] TextMeshProUGUI coinCount;
        static CoinsUIManager instance;
        #endregion

        #region Methods
        private void Awake()
        {
            if (instance == null)
                instance = this;
            if (numberOfCoinsTMP && coinsDecoration)
                TryToOutputTheNumberOfCoins();
        }

        public void OutputAward()
        {
            // Ran 5000 cubes and...
            awardTMP.text = "You earned " + (CoinController.AwardCoinsCount).ToString() + " coins, keep it up!!!";
            SaveAwardCoins();
        }
        void SaveAwardCoins()
        {
            PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins") + CoinController.AwardCoinsCount);
            CoinController.ResetAwardCoinsCount();
        }

        public void TryToOutputTheNumberOfCoins()
        {
            if (PlayerPrefs.GetInt("NumberOfCoins") > 0)
            {
                numberOfCoinsTMP.text = PlayerPrefs.GetInt("NumberOfCoins").ToString();
                numberOfCoinsTMP.gameObject.SetActive(true);
                coinsDecoration.SetActive(true);
            }
            else
            {
                numberOfCoinsTMP.text = (0).ToString();
                numberOfCoinsTMP.gameObject.SetActive(false);
                coinsDecoration.SetActive(false);
            }
        }

        public static void UpdateOutputTheNumberOfCoins() => instance.TryToOutputTheNumberOfCoins();
        public static void CoinPick()
        {
            instance.coinCount.text = (CoinController.AwardCoinsCount).ToString("000");
        }
        #endregion
    }
}