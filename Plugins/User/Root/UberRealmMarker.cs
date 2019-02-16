using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Turbo.Plugins.Default;

// glq SeaDragon
namespace Turbo.Plugins.User.Root
{

    public class UberRealmMarker : BasePlugin, IInGameWorldPainter, INewAreaHandler, IInGameTopPainter
    {

        public WorldDecoratorCollection MarkerDecorator { get; set; }
        public TopLabelWithTitleDecorator FinishedDecorator { get; set; }
        public TopLabelWithTitleDecorator TimesDecorator { get; set; }
        bool RedDoor0 { get; set; }
        bool RedDoor1 { get; set; }
        bool RedDoor2 { get; set; }
        bool RedDoor3 { get; set; }
        bool Finished { get; set; }
        int Times { get; set; }
        private HashSet<ActorSnoEnum> _actorSnoList = new HashSet<ActorSnoEnum>();
        public UberRealmMarker()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            RedDoor0 = false;
            RedDoor1 = false;
            RedDoor2 = false;
            RedDoor3 = false;
            Finished = false;
            Times = 0;
            MarkerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(192, 255, 255, 255, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 255, 255, 255, true, false, false),
                }
                );
            FinishedDecorator = new TopLabelWithTitleDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 0, 0, true, false, true),
            };
            TimesDecorator = new TopLabelWithTitleDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 239, 220, 129, false, false, true),
            };
            _actorSnoList.Add((ActorSnoEnum)258384); //Uber_PortalSpot0
            _actorSnoList.Add((ActorSnoEnum)258385); //Uber_PortalSpot1
            _actorSnoList.Add((ActorSnoEnum)258386); //Uber_PortalSpot2
            _actorSnoList.Add((ActorSnoEnum)366533); //Uber_PortalSpot3

        }
        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
            {
                RedDoor0 = false;
                RedDoor1 = false;
                RedDoor2 = false;
                RedDoor3 = false;
                Finished = false;
            }
        }
        private const ActorSnoEnum door0Sno = (ActorSnoEnum)258384;
        private const ActorSnoEnum door1Sno = (ActorSnoEnum)258385;
        private const ActorSnoEnum door2Sno = (ActorSnoEnum)258386;
        private const ActorSnoEnum door3Sno = (ActorSnoEnum)366533;
        public void PaintWorld(WorldLayer layer)
        {
            var mapSno = Hud.Game.Me.SnoArea.Sno;
            var actors = Hud.Game.Actors.Where(actor => actor.DisplayOnOverlay && _actorSnoList.Contains(actor.SnoActor.Sno));
            if (mapSno == 256767) RedDoor0 = true;
            if (mapSno == 256106) RedDoor1 = true;
            if (mapSno == 256742) RedDoor2 = true;
            if (mapSno == 374239) RedDoor3 = true;
            if (RedDoor0 && RedDoor1 && RedDoor2 && RedDoor3 && Finished == false)
            {
                Times++;
                Finished = true;
            }
            foreach (var actor in actors)
            {
                if (RedDoor0 && actor.SnoActor.Sno == door0Sno) MarkerDecorator.Paint(layer, null, actor.FloorCoordinate.Offset(0, 0, 6f), "A1Key Entered");
                if (RedDoor1 && actor.SnoActor.Sno == door1Sno) MarkerDecorator.Paint(layer, null, actor.FloorCoordinate.Offset(0, 0, 6f), "A2Key Entered");
                if (RedDoor2 && actor.SnoActor.Sno == door2Sno) MarkerDecorator.Paint(layer, null, actor.FloorCoordinate.Offset(0, 0, 6f), "A3Key Entered");
                if (RedDoor3 && actor.SnoActor.Sno == door3Sno) MarkerDecorator.Paint(layer, null, actor.FloorCoordinate.Offset(0, 0, 6f), "A4Key Entered");
            }
        }
        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            var ui = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.BoostWrapper.BoostsDifficultyStackPanel.clock");
			var ui2 = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.minimap_pve_main");
            var w = 0;
            var h = ui.Rectangle.Height;
            float XPos = ui2.Rectangle.Left + ui2.Rectangle.Width / 3.4f; //3.5f
            float YPos = ui.Rectangle.Top;
            if (Finished) FinishedDecorator.Paint(XPos, YPos - h, w, h, "All UberRealm Entered");
            if (Times != 0)
            {
                TimesDecorator.Paint(XPos, YPos, w, h, "HellfireAmulet mission: " + Times);
            }
        }

    }

}