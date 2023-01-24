using GamePlay.Common.Paths;
using UnityEngine;

namespace GamePlay.Services.MenuUI.Runtime
{
    [CreateAssetMenu(fileName = "Config_AlertScreen", menuName = MenuAssetsPaths.Root + "AlertConfig")]
    public class AlertScreenConfigAsset : ScriptableObject
    {
        [SerializeField] private string _ownerName;

        public string OwnerName => _ownerName;
    }
}