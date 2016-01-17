namespace UbwTools.Launch
{
    public abstract class LaunchItemBase
    {
        public const int GroupInternal = 0;
        public const int GroupDatabases = 1;
        public const int GroupExecutables = 2;

        public int GroupOrder { get; private set; }
        public string ItemName { get; private set; }
        public int IconId { get; private set; }
        public string Tooltip { get; private set; }

        protected LaunchItemBase(int groupOrder, string itemName, int iconId, string tooltip)
        {
            GroupOrder = groupOrder;
            ItemName = itemName;
            IconId = iconId;
            Tooltip = tooltip;
        }

        public abstract bool DefaultAction(bool ctrl);
    }
}
