
namespace Chivalry.code
{
    internal class stats
    {
        public static void Init()
        {
            BaseStatAsset Knight = new BaseStatAsset();
            Knight.id = "Knight";
            Knight.normalize = true;
            Knight.normalize_min = -999999;
            Knight.normalize_max = 999999;
            Knight.mod = true;
            Knight.used_only_for_civs = false;
            AssetManager.base_stats_library.add(Knight);
        }
    }
}
