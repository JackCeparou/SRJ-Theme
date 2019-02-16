
// added
using System.Collections.Generic;
using System.Globalization;
using Turbo.Plugins.Default;

// namespace Turbo.Plugins.Default
namespace Turbo.Plugins._SR.LabelLists
{

    public class SR_AttributeLabelListPlugin : BasePlugin, ICustomizer, IInGameTopPainter
    {

        public HorizontalTopLabelList LabelList { get; private set; }

        public SR_AttributeLabelListPlugin()
            : base()
        {
            Enabled = true;
			Order = int.MaxValue; //Jack, make layer on top
        }
		
        public void Customize()
        {
			// disable DEFAULT
			Hud.TogglePlugin<AttributeLabelListPlugin>(false);
		}
		
        public override void Load(IController hud)
        {
            base.Load(hud);

            var expandedHintFont = Hud.Render.CreateFont("tahoma", 7, 255, 200, 200, 200, true, false, true);
            var expandedHintWidthMultiplier = 3;

            LabelList = new HorizontalTopLabelList(hud);

            LabelList.LeftFunc = () =>
            {
                var ui = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay");
                return ui.Rectangle.Left + ui.Rectangle.Width * 0.267f;
            };
            LabelList.TopFunc = () =>
            {
                var ui = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay");
                return ui.Rectangle.Top + ui.Rectangle.Height * 0.318f;
            };
            LabelList.WidthFunc = () =>
            {
                var ui = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay");
                return Hud.Window.Size.Height * 0.0621f;
            };
            LabelList.HeightFunc = () =>
            {
                var ui = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay");
                return Hud.Window.Size.Height * 0.025f;
            };
			
			/// added  // value_format can be 'dyn', 'F0', 'F1'

			
			/* add Flying Dragon buff in exp bar
			
			Hud.RunOnPlugin<AttributeLabelListPlugin>(plugin =>
			{
				var dpsDecorator = plugin.LabelList.LabelDecorators[2];
				dpsDecorator.TextFunc = () =>
				{
                    var dps = Hud.Game.Me.Offense.SheetDps * (Hud.Game.Me.Powers.BuffIsActive(246562, 1) ? 2 : 1);
                    return ValueToString(dps, ValueFormat.ShortNumber);
                };
                var apsDecorator = plugin.LabelList.LabelDecorators[3];
                apsDecorator.TextFunc = () =>
                {
                    var aps = Hud.Game.Me.Offense.AttackSpeed * (Hud.Game.Me.Powers.BuffIsActive(246562, 1) ? 2 : 1);
                    return aps.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) + "/s";
                };
            });
			 */
			
			// movement 1
            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.70f,
                TextFunc = () => (Hud.Game.Me.Stats.MoveSpeed).ToString("F1", CultureInfo.InvariantCulture) + "%",
                HintFunc = () => "Move Speed Total",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    /* new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
						BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
						BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 1.0f,
						TextFunc = () => (Hud.Game.Me.Stats.MoveSpeed - Hud.Game.Me.Stats.MoveSpeedBonus - 100).ToString("F1", CultureInfo.InvariantCulture) + "%",
						HintFunc = () => "Move Speed Base",
                    }, */
                    /* new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
						BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
						BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 1.0f,
						TextFunc = () => (Hud.Game.Me.Stats.MoveSpeedBonus + 100).ToString("F1", CultureInfo.InvariantCulture) + "%",
						HintFunc = () => "Move Speed Bonus",
                    }, */
                }
            });
			
			// defense 2
            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                BackgroundTextureOpacity2 = 0.70f,
                TextFunc = () => ValueToString(Hud.Game.Me.Defense.EhpCur, ValueFormat.ShortNumber),
                HintFunc = () => "EHP Current",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
						TextFunc = () => ValueToString(Hud.Game.Me.Defense.EhpMax, ValueFormat.ShortNumber),
						HintFunc = () => "EHP Max",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
						TextFunc = () => Hud.Game.Me.Defense.ResAverage.ToString("#,0", CultureInfo.InvariantCulture),
						HintFunc = () => "Average Resist",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => Hud.Game.Me.Defense.Armor.ToString("#,0", CultureInfo.InvariantCulture),
                        HintFunc = () => "Armor",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 1.0f,
                        TextFunc = () => (Hud.Game.Me.Defense.drCombined * 100).ToString("F1", CultureInfo.InvariantCulture),
                        HintFunc = () => "Damage Reduction",
                    },
                }
            });
			
			// ias 3
            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                BackgroundTextureOpacity2 = 0.3f,
                // TextFunc = () => Hud.Game.Me.Offense.AttackSpeed.ToString("F2", CultureInfo.InvariantCulture) + "/s",
                //jack's edit to include Flying Dragon staff buff
				TextFunc = () =>
                {
                    var aps = Hud.Game.Me.Offense.AttackSpeed * (Hud.Game.Me.Powers.BuffIsActive(246562, 1) ? 2 : 1);
                    return aps.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) + "/s";
                },
                HintFunc = () => "Attack Speed Per Sec",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
						BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
						BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
                        BackgroundTextureOpacity2 = 0.75f,
						// TextFunc = () => ValueToString(Hud.Game.Me.Offense.SheetDps, ValueFormat.ShortNumber),
						//jack's edit to include Flying Dragon staff buff
						TextFunc = () =>
		                {
							var dps = Hud.Game.Me.Offense.SheetDps * (Hud.Game.Me.Powers.BuffIsActive(246562, 1) ? 2 : 1);
							return BasePlugin.ValueToString(dps, ValueFormat.ShortNumber);
						},
						HintFunc = () => "Sheet DPS",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => ValueToString(Hud.Game.Me.Offense.MainHandIsActive ? Hud.Game.Me.Offense.WeaponDamageMainHand : Hud.Game.Me.Offense.WeaponDamageSecondHand, ValueFormat.ShortNumber),
                        HintFunc = () => "Weapon Damage",
                    },
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureYellow,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Offense.AttackSpeedPets.ToString("F2", CultureInfo.InvariantCulture) + "/s",
                        HintFunc = () => "Pet Attack Speed Per Sec",
                    }
                }
            });

			// chc 4
            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                BackgroundTextureOpacity2 = 0.3f,
                TextFunc = () => Hud.Game.Me.Offense.CriticalHitChance.ToString("F1", CultureInfo.InvariantCulture) + "%",
                HintFunc = () => "Crit Hit Chance",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                        BackgroundTextureOpacity2 = 0.75f,
                        TextFunc = () => Hud.Game.Me.Offense.CritDamage.ToString("F0", CultureInfo.InvariantCulture) + "%",
                        HintFunc = () => "Crit Hit Damage",
                    },
                    new TopLabelDecorator(Hud)
                    {
						TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 200, 200, 255, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
						BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
						BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                        BackgroundTextureOpacity2 = 0.75f,
						TextFunc = () => Hud.Game.Me.Offense.AreaDamageBonus.ToString("F0", CultureInfo.InvariantCulture) + "%",
						HintFunc = () => "Area Damage Bonus",
                    }
                }
            });

			//////////////////////
			
			// dps 5
            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.75f,
                TextFunc = () => ValueToString(Hud.Game.Me.Damage.CurrentDps, ValueFormat.LongNumber),
                HintFunc = () => "Current DPS",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
						TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
						BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
						BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
						BackgroundTextureOpacity2 = 0.75f,
						TextFunc = () => ValueToString(Hud.Game.Me.Damage.MaximumDps, ValueFormat.LongNumber),
						HintFunc = () => "Maximum DPS",
                    },
                    new TopLabelDecorator(Hud)
                    {
						TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
						BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
						BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
						BackgroundTextureOpacity2 = 0.75f,
						TextFunc = () => ValueToString(Hud.Game.Me.Damage.TotalDamage, ValueFormat.ShortNumber),
						HintFunc = () => "Total Damage",
                    },
                }
            });

			// dps 6
            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 255, 255, true, false, true),
				BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
				BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.7f,
                TextFunc = () => ValueToString(Hud.Game.Me.Damage.RunDps, ValueFormat.LongNumber),
                HintFunc = () => "Average DPS",
            });
			
			//////////////////////
			
			// cdr 7
            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 200, 200, 255, true, false, true),
                ExpandedHintFont = expandedHintFont,
                ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.75f,
                TextFunc = () => (Hud.Game.Me.Stats.CooldownReduction * 100).ToString("F1", CultureInfo.InvariantCulture) + "%",
                HintFunc = () => "Cooldown Reduction",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
						TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
						BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
						BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
						BackgroundTextureOpacity2 = 0.75f,
						TextFunc = () => (Hud.Game.Me.Stats.ResourceCostReduction * 100).ToString("F1", CultureInfo.InvariantCulture) + "%",
						HintFunc = () => "Resource Cost Reduction",
                    },
                }
            });
			
			// rcr 8
            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, true, false, true),
                BackgroundTexture1 = Hud.Texture.ButtonTextureBlue,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.75f,
                TextFunc = () => (Hud.Game.Me.Stats.ResourceCostReduction * 100).ToString("F1", CultureInfo.InvariantCulture) + "%",
                HintFunc = () => "Resource Cost Reduction",
            });
			
			// misc 9
            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, true, false, true),
                ExpandedHintFont = expandedHintFont,
                ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
				BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
				BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                BackgroundTextureOpacity2 = 0.75f,
				TextFunc = () => Hud.Game.Me.Stats.PickupRange.ToString("F0", CultureInfo.InvariantCulture),
				HintFunc = () => "Pickup Range",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
						TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, false, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
						BackgroundTextureOpacity2 = 0.75f,
						TextFunc = () => (Hud.Game.Me.Stats.GoldFind).ToString("#,0", CultureInfo.InvariantCulture) + "%",
						HintFunc = () => "Gold Find",
                    },
                    new TopLabelDecorator(Hud)
                    {
						TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                        BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                        BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
						BackgroundTextureOpacity2 = 0.75f,
						TextFunc = () => (Hud.Game.Me.Stats.MagicFind).ToString("F0", CultureInfo.InvariantCulture) + "%",
						HintFunc = () => "Magic Find",
                    },
                }
            });
			
			// exp 10
            LabelList.LabelDecorators.Add(new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, false, false, true),
                ExpandedHintFont = expandedHintFont,
                ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
                BackgroundTextureOpacity2 = 0.75f,
                TextFunc = () => ValueToString(Hud.Game.ExperiencePerHourToday, ValueFormat.ShortNumber) + "/h",
                HintFunc = () => "Exp Per Hour Today",
                ExpandUpLabels = new List<TopLabelDecorator>()
                {
                    new TopLabelDecorator(Hud)
                    {
						TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
						BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
						BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
						BackgroundTextureOpacity2 = 0.75f,
						TextFunc = () => (Hud.Game.Me.Stats.ExperiencePercentBonus * 100).ToString("F0", CultureInfo.InvariantCulture) + "%",
						HintFunc = () => "Bonus Exp",
                    },
                    new TopLabelDecorator(Hud)
                    {
						TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
						BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
						BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
						BackgroundTextureOpacity2 = 0.75f,
						TextFunc = () => Hud.Game.Me.Stats.ExpOnKill.ToString("F0", CultureInfo.InvariantCulture),
						HintFunc = () => "Exp On Kill",
                    },
                    new TopLabelDecorator(Hud)
                    {
						TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
						BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
						BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
						BackgroundTextureOpacity2 = 0.75f,
						TextFunc = () => Hud.Game.Me.Stats.ExperienceOnKillBonus.ToString("F0", CultureInfo.InvariantCulture),
						HintFunc = () => "Exp On Kill (Bonus)",
                    },
                    new TopLabelDecorator(Hud)
                    {
						TextFont = Hud.Render.CreateFont("tahoma", 7, 230, 255, 200, 200, true, false, true),
                        ExpandedHintFont = expandedHintFont,
                        ExpandedHintWidthMultiplier = expandedHintWidthMultiplier,
						BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
						BackgroundTexture2 = Hud.Texture.BackgroundTextureGreen,
						BackgroundTextureOpacity2 = 0.75f,
						TextFunc = () => Hud.Game.Me.Stats.ExpOnKillNoPenalty.ToString("F0", CultureInfo.InvariantCulture),
						HintFunc = () => "Exp On Kill (No Penalty)",
                    },
                }
            });
		}

        public void PaintTopInGame(ClipState clipState)
        {
			
            if (clipState != ClipState.BeforeClip) return;

            LabelList.Paint();
        }

    }

}