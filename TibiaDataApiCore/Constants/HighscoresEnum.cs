using System.ComponentModel;

namespace TibiaDataApiCore.Constants {
    public enum HighscoresCategoryEnum {
        [Description("experience")]
        Experience,
        [Description("magic")]
        Magic,
        [Description("shielding")]
        Shielding,
        [Description("distance")]
        Distance,
        [Description("sword")]
        Sword,
        [Description("club")]
        Club,
        [Description("axe")]
        Axe,
        [Description("fist")]
        Fist,
        [Description("fishing")]
        Fishing,
        [Description("achievements")]
        Achievements,
        [Description("charmpoints")]
        CharmPoints,
        [Description("goshnarstaint")]
        GoshnarsTaint,
        [Description("loyalty")]
        Loyalty
    }

    public enum HighscoreVocationEnum {
        [Description("all")]
        All,
        [Description("none")]
        None,
        [Description("druid")]
        Druid,
        [Description("knight")]
        Knight,
        [Description("paladin")]
        Paladin,
        [Description("sorcerer")]
        Sorcerer
    }
}
