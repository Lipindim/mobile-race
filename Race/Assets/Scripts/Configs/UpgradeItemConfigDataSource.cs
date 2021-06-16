using UnityEngine;


namespace Configs
{
    [CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", menuName = "Data/UpgradeItemConfigDataSource", order = 0)]
    public class UpgradeItemConfigDataSource : ScriptableObject
    {
        public UpgradeItemConfig[] ItemConfigs;
    }

}
