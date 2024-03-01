using System;
using ATVO.ThemesSDK;
using ATVO.ThemeEditor.ThemeModels;
using ATVO.ThemeEditor.Scripting.DotNET;
using System.Windows.Media;

//This script should be bound to the 'overridefontcolor' of a label. It doesn't require a specific binding,
//but ATVO may require a bind of some sort anyway, so just pass in shortname or something.

//Script determines the luminance value of a color (obtained from the Background COLOR /not image/ of the parent label
//then decides whether white or black font would show better.
namespace Scripts
{
	public class opposingFontColorCheck : IScript
	{
		public object Execute(ThemeContentItem item, object value, string parameter, ISimulation sim)
		{	
			var label = (Label) item;
			
			if(label == null)
				return null;

			var currBGR = label.Background.BackgroundColor.R;
			var currBGG = label.Background.BackgroundColor.G;
			var currBGB = label.Background.BackgroundColor.B;
			var brightness = (float) currBGR *0.299 + currBGG * 0.587 + currBGB * 0.114;
			if(brightness > 160)
			{
				return Color.FromRgb(0,0,0);
			}
			return Color.FromRgb(255,255,255);
		}
	}
}
