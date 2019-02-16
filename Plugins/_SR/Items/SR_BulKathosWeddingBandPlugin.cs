
// by StormReaver

namespace Turbo.Plugins._SR.Items
{
    using SharpDX.Direct2D1;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;
	
    public class SR_BulKathosWeddingBandPlugin : BasePlugin, IInGameWorldPainter
    {
		
        public WorldDecoratorCollection BKWeddingBandDecorator { get; set; }
		
		
        public SR_BulKathosWeddingBandPlugin()
        {
            Enabled = true;
        }
		
		
        public void Customize()
        {
			
			Hud.RunOnPlugin<PlayerSkillPlugin>(plugin =>
			{
				// disable DEFAULT
				plugin.Enabled = false;
			
			});
			
        }
		
		
        public override void Load(IController hud)
        {
            base.Load(hud);
			
			
            // Bul-Kathos Wedding Band, effect radius
			
            BKWeddingBandDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(120, 220, 50, 50, 1.2f, DashStyle.Dash),
                    Radius = 12, // tested in game
                });
				
        }
		
		
		// 3108358623	Bul-Kathos's Wedding Band
		// 63985		Ring_flippy Item
		// 364340		ItemPassive_Unique_Ring_020_x1	Life Drain	You drain life from enemies around you.
		
		
		//// old code, draws for all party if player has buff
		
		/* public void PaintWorld(WorldLayer layer)
        {
			
            var actors = Hud.Game.Actors;
            foreach (var actor in actors)
			
            {
                switch (actor.SnoActor.Sno)
                {
					case 3285:		//  BARB:	Female: 3285	| Male: 3301
					case 3301:		//  BARB:	Female: 3285	| Male: 3301
					case 238286:	//  CRUS: Female: 238286  |  Male: 238284
					case 238284:	//  CRUS: Female: 238286  |  Male: 238284
					case 4717:		//  MONK: Female: 4717  |  Male: 4721
					case 4721:		//  MONK: Female: 4717  |  Male: 4721
					case 74706:		//  DH: Female: 74706  |  Male: 75207
					case 75207:		//  DH: Female: 74706  |  Male: 75207
					case 6481:		//  WD: Female: 6481  |  Male: 6485
					case 6485:		//  WD: Female: 6481  |  Male: 6485
					case 6526:		//  WIZ: Female: 6526  |  Male: 6544
					case 6544:		//  WIZ: Female: 6526  |  Male: 6544
					case 454402:	//  NEC: Female: 454402  |  Male: 454021
					case 454021:	//  NEC: Female: 454402  |  Male: 454021
					
						if (Hud.Game.Me.Powers.BuffIsActive(364340, 0))
						{
							BKWeddingBandDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
						}
					   break;
                }
            }
        } */
		
		
		
		//// draws for party players, PortraitIndex 0 for player1 (me), up to PortraitIndex 4 for player4
		//// PortraitIndex is fixed: 0,1,2,3 top to bottom, player (me) is always 0
		
		/* public void PaintWorld(WorldLayer layer)
		{
			var playerByPortraitIndex = Hud.Game.Players.FirstOrDefault(p => p.PortraitIndex == 0);
			if (playerByPortraitIndex != null)
			{
				if (playerByPortraitIndex.Powers.BuffIsActive(364340, 0))
				{
					BKWeddingBandDecorator.Paint(layer, playerByPortraitIndex, playerByPortraitIndex.FloorCoordinate, null);
				}
			}
		} */
		
		
		
		// draws only for me
		
		public void PaintWorld(WorldLayer layer)
		{
			var playerMe = Hud.Game.Me;
			if (playerMe.Powers.BuffIsActive(364340, 0))
			{
				BKWeddingBandDecorator.Paint(layer, playerMe, playerMe.FloorCoordinate, null);
			}
		}
		
		
    }
}