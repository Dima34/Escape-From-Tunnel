using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "New Player Data", order = 52)]
public class PlayerData : ScriptableObject {
    [SerializeField] int _coinsAmount = 0;
}