using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "NewPlayerData", menuName = "New Player Data", order = 52)]
public class PlayerData : ScriptableObject
{
    [SerializeField] int _coinsAmount = 0;
}