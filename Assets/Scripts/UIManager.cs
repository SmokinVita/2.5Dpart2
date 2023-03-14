using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get
        {
            if (_instance == null)
                Debug.LogError("UIManager is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField]
    private TMP_Text _updateCoin;

    public void UpdateCoinText(int coinAmount)
    {
        _updateCoin.SetText($"Coins: {coinAmount}");
    }
}
