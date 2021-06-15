using Enums;
using UnityEngine;


namespace Configs
{
    [CreateAssetMenu(fileName = "UpgradeItemConfig", menuName = "Data/Upgrade item")]
    public class UpgradeItemConfig : ScriptableObject
    {
        public ItemConfig itemConfig;
        public UpgradeType type;
        public float Value;

        public int Id => itemConfig.Id;
    }

}
