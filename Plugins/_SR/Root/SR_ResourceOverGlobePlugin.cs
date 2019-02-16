
// adaptation of StormReaver v6 xml theme
// by SeaDragon
// edited by SR


// added
using System.Globalization;
using Turbo.Plugins.Default;

// namespace Turbo.Plugins.Default
namespace Turbo.Plugins._SR.Root
{
    public class SR_ResourceOverGlobePlugin : BasePlugin, ICustomizer, IInGameTopPainter
	{

		// hp
        public TopLabelDecorator HealthDecorator { get; set; }
		public TopLabelDecorator HealthPCTDecorator { get; set; }
        public TopLabelDecorator HealingPosDecorator { get; set; }
        public TopLabelDecorator HealingNegDecorator { get; set; }
        public TopLabelDecorator HealingPosdetailsDecorator { get; set; }
        public TopLabelDecorator HealingNegdetailsDecorator { get; set; }
        public TopLabelDecorator ShieldDecorator { get; set; }
		
		// resource
        public TopLabelDecorator ArcanePCTDecorator { get; set; }
        public TopLabelDecorator ArcaneValueDecorator { get; set; }
        public TopLabelDecorator ArcaneRegenDecorator { get; set; }
        public TopLabelDecorator ManaPCTDecorator { get; set; }
        public TopLabelDecorator ManaValueDecorator { get; set; }
        public TopLabelDecorator ManaRegenDecorator { get; set; }
        public TopLabelDecorator SpiritPCTDecorator { get; set; }
        public TopLabelDecorator SpiritValueDecorator { get; set; }
        public TopLabelDecorator SpiritRegenDecorator { get; set; }
        public TopLabelDecorator FuryPCTDecorator { get; set; }
        public TopLabelDecorator FuryValueDecorator { get; set; }
        public TopLabelDecorator FuryRegenDecorator { get; set; }
        public TopLabelDecorator HatredPCTDecorator { get; set; }
        public TopLabelDecorator HatredValueDecorator { get; set; }
        public TopLabelDecorator HatredRegenDecorator { get; set; }
        public TopLabelDecorator DisciplinePCTDecorator { get; set; }
        public TopLabelDecorator DisciplineValueDecorator { get; set; }
        public TopLabelDecorator DisciplineRegenDecorator { get; set; }
        public TopLabelDecorator WrathPCTDecorator { get; set; }
        public TopLabelDecorator WrathValueDecorator { get; set; }
        public TopLabelDecorator WrathRegenDecorator { get; set; }

		public TopLabelDecorator EssencePCTDecorator { get; set; }
		public TopLabelDecorator EssenceValueDecorator { get; set; }
		public TopLabelDecorator EssenceRegenDecorator { get; set; }
		
		
        public SR_ResourceOverGlobePlugin()
		{
            Enabled = true; // .NET Framework does not contains CompilerServices for C# 6
		}
		
        public void Customize()
        {
			// disable DEFAULT
			Hud.TogglePlugin<ResourceOverGlobePlugin>(false);
		}
		
        public override void Load(IController hud)
        {
            base.Load(hud);

			// hp
			
            HealthDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 10, 240, 255, 200, 190, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Defense.HealthCur.ToString("#,0", CultureInfo.InvariantCulture),
            };
			
            HealthPCTDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 240, 255, 200, 190, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Defense.HealthPct.ToString("#,0", CultureInfo.InvariantCulture) + "%",
            };

            HealingPosdetailsDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 110, 205, 110, true, false, 255, 100, 0, 0, true),
                TextFunc = () => (Hud.Game.Me.Defense.CurrentEffectiveHealingPercent > 0 ? "+" : "") + Hud.Game.Me.Defense.CurrentHealingPerSecond.ToString("#,0", CultureInfo.InvariantCulture),
            };

            HealingNegdetailsDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 130, 130, true, false, 255, 100, 0, 0, true),
                TextFunc = () => (Hud.Game.Me.Defense.CurrentEffectiveHealingPercent > 0 ? "+" : "") + Hud.Game.Me.Defense.CurrentHealingPerSecond.ToString("#,0", CultureInfo.InvariantCulture),
            };

            HealingPosDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 110, 205, 110, true, false, 255, 100, 0, 0, true),
                TextFunc = () => (Hud.Game.Me.Defense.CurrentEffectiveHealingPercent > 0 ? "+" : "") + Hud.Game.Me.Defense.CurrentEffectiveHealingPercent.ToString("#,0", CultureInfo.InvariantCulture) + "%",
            };

            HealingNegDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 130, 130, true, false, 255, 100, 0, 0, true),
                TextFunc = () => (Hud.Game.Me.Defense.CurrentEffectiveHealingPercent > 0 ? "+" : "") + Hud.Game.Me.Defense.CurrentEffectiveHealingPercent.ToString("#,0", CultureInfo.InvariantCulture) + "%",
            };

            ShieldDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Defense.CurShield.ToString("#,0", CultureInfo.InvariantCulture),
            };
			
			
			// resource
			
            ArcanePCTDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourcePctArcane.ToString("F0", CultureInfo.InvariantCulture) + "%",
            };
			
            ArcaneValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceCurArcane.ToString("F0", CultureInfo.InvariantCulture),
            };

            ArcaneRegenDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceRegArcane <= 0 ? null : "+" + Hud.Game.Me.Stats.ResourceRegArcane.ToString("F0", CultureInfo.InvariantCulture) + "/s",
            };

			
            ManaPCTDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourcePctMana.ToString("F0", CultureInfo.InvariantCulture) + "%",
            };
			
            ManaValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceCurMana.ToString("F0", CultureInfo.InvariantCulture),
            };

            ManaRegenDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceRegMana <= 0 ? null : "+" + Hud.Game.Me.Stats.ResourceRegMana.ToString("F0", CultureInfo.InvariantCulture) + "/s",
            };

			
            SpiritPCTDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 0, 0, true, false, 255, 255, 255, 255, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourcePctSpirit.ToString("F0", CultureInfo.InvariantCulture) + "%",
            };
			
            SpiritValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 0, 0, 0, true, false, 255, 255, 255, 255, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceCurSpirit.ToString("F0", CultureInfo.InvariantCulture),
            };

            SpiritRegenDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 0, 0, 0, true, false, 255, 255, 255, 255, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceRegSpirit <= 0 ? null : "+" + Hud.Game.Me.Stats.ResourceRegSpirit.ToString("F0", CultureInfo.InvariantCulture) + "/s",
            };
			

            FuryPCTDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourcePctFury.ToString("F0", CultureInfo.InvariantCulture) + "%",
            };
			
            FuryValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceCurFury.ToString("F0", CultureInfo.InvariantCulture),
            };
			
            FuryRegenDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 0, 0, 0, true, false, 255, 255, 255, 255, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceRegFury <= 0 ? null : "+" + Hud.Game.Me.Stats.ResourceRegFury.ToString("F0", CultureInfo.InvariantCulture) + "/s",
            };
			

            HatredPCTDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 160, 160, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourcePctHatred.ToString("F0", CultureInfo.InvariantCulture) + "%",
            };
			
            HatredValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 255, 160, 160, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceCurHatred.ToString("F0", CultureInfo.InvariantCulture),
            };

            HatredRegenDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 160, 160, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceRegHatred <= 0 ? null : "+" + Hud.Game.Me.Stats.ResourceRegHatred.ToString("F0", CultureInfo.InvariantCulture) + "/s",
            };
			

            DisciplinePCTDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 160, 160, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourcePctDiscipline.ToString("F0", CultureInfo.InvariantCulture) + "%",
            };
			
            DisciplineValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 160, 160, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceCurDiscipline.ToString("F0", CultureInfo.InvariantCulture),
            };

            DisciplineRegenDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 160, 160, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceRegDiscipline <= 0 ? null : "+" + Hud.Game.Me.Stats.ResourceRegDiscipline.ToString("F0", CultureInfo.InvariantCulture) + "/s",
            };
			

            WrathPCTDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 0, 0, true, false, 255, 255, 255, 255, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourcePctWrath.ToString("F0", CultureInfo.InvariantCulture) + "%",
            };
			
            WrathValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 0, 0, 0, true, false, 255, 255, 255, 255, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceCurWrath.ToString("F0", CultureInfo.InvariantCulture),
            };

            WrathRegenDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 0, 0, 0, true, false, 255, 255, 255, 255, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceRegWrath <= 0 ? null : "+" + Hud.Game.Me.Stats.ResourceRegWrath.ToString("F0", CultureInfo.InvariantCulture) + "/s",
            };
			

			EssencePCTDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourcePctEssence.ToString("F0", CultureInfo.InvariantCulture) + "%",
            };
			
            EssenceValueDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
				TextFunc = () => Hud.Game.Me.Stats.ResourceCurEssence.ToString("F0", CultureInfo.InvariantCulture),
            };

            EssenceRegenDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
                TextFunc = () => Hud.Game.Me.Stats.ResourceRegEssence <= 0 ? null : "+" + Hud.Game.Me.Stats.ResourceRegEssence.ToString("F0", CultureInfo.InvariantCulture) + "/s",
            };
			
						
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

			// hp
			
            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_progressBar_healthBall").Rectangle;

            HealthPCTDecorator.Paint(uiRect.Left + uiRect.Width * 0.13f, uiRect.Top + uiRect.Height * 0.05f, uiRect.Width * 0.8f, uiRect.Height * 0.15f, HorizontalAlign.Center);
            HealthDecorator.Paint(uiRect.Left + uiRect.Width * 0.13f, uiRect.Top + uiRect.Height * 0.26f, uiRect.Width * 0.8f, uiRect.Height * 0.15f, HorizontalAlign.Center);

            if (Hud.Game.Me.Defense.CurrentEffectiveHealingPercent != 0)
            {
                (Hud.Game.Me.Defense.CurrentEffectiveHealingPercent > 0 ? HealingPosDecorator : HealingNegDecorator).Paint(uiRect.Left + uiRect.Width * 0.2f, uiRect.Top + uiRect.Height * 0.42f, uiRect.Width * 0.8f, uiRect.Height * 0.1f, HorizontalAlign.Center);
				(Hud.Game.Me.Defense.CurrentEffectiveHealingPercent > 0 ? HealingPosdetailsDecorator : HealingNegdetailsDecorator).Paint(uiRect.Left + uiRect.Width * 0.2f, uiRect.Top + uiRect.Height * 0.52f, uiRect.Width * 0.8f, uiRect.Height * 0.1f, HorizontalAlign.Center);
            }

            if (Hud.Game.Me.Defense.CurShield > 0)
            {
                ShieldDecorator.Paint(uiRect.Left + uiRect.Width * 0.13f, uiRect.Top + uiRect.Height * 0.75f, uiRect.Width * 0.63f, uiRect.Height * 0.12f, HorizontalAlign.Right);
            }

			// resource
			
            uiRect = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_progressBar_manaBall").Rectangle;

            switch (Hud.Game.Me.HeroClassDefinition.HeroClass)
            {
                case HeroClass.Wizard:
                    ArcanePCTDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.05f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    ArcaneValueDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.30f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    ArcaneRegenDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.55f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    break;
                case HeroClass.WitchDoctor:
                    ManaPCTDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.05f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    ManaValueDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.30f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    ManaRegenDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.55f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    break;
				case HeroClass.Necromancer:
                    EssencePCTDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.05f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    EssenceValueDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.30f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    EssenceRegenDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.55f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    break;
                case HeroClass.DemonHunter:
					HatredPCTDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.05f, uiRect.Width * 0.62f, uiRect.Height * 0.23f, HorizontalAlign.Center);
                    HatredValueDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.30f, uiRect.Width * 0.5f, uiRect.Height * 0.15f, HorizontalAlign.Center);
					DisciplinePCTDecorator.Paint(uiRect.Left + uiRect.Width * 0.5f, uiRect.Top + uiRect.Height * 0.05f, uiRect.Width * 0.35f, uiRect.Height * 0.23f, HorizontalAlign.Center);
                    DisciplineValueDecorator.Paint(uiRect.Left + uiRect.Width * 0.5f, uiRect.Top + uiRect.Height * 0.30f, uiRect.Width * 0.45f, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    HatredRegenDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.55f, uiRect.Width * 0.55f, uiRect.Height * 0.23f, HorizontalAlign.Center);
                    DisciplineRegenDecorator.Paint(uiRect.Left + uiRect.Width * 0.5f, uiRect.Top + uiRect.Height * 0.55f, uiRect.Width * 0.35f, uiRect.Height * 0.23f, HorizontalAlign.Center);
                    break;
				case HeroClass.Barbarian:
                    FuryPCTDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.05f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    FuryValueDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.30f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    FuryRegenDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.55f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    break;
                case HeroClass.Crusader:
                    WrathPCTDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.05f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    WrathValueDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.30f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    WrathRegenDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.55f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    break;
                case HeroClass.Monk:
                    SpiritPCTDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.05f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    SpiritValueDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.30f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    SpiritRegenDecorator.Paint(uiRect.Left, uiRect.Top + uiRect.Height * 0.55f, uiRect.Width, uiRect.Height * 0.15f, HorizontalAlign.Center);
                    break;
            }
        }

    }

}