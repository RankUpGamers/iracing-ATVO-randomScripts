/*
	Author: Dustin Ollis
	File: opposingFontColorCheck.cs
	Bindings: none, this script goes in "Override Text Color" 
		I have occationally had to bind something random in the past to get the script to run. Haven't tested the best option for this.

	Usage: Set this to a label's "Override Text Color" and it will inspect the background and choose white/black text color based on the calculated luminance value.

	Returns: Color object representing black or white text.
*/


using System;
using ATVO.ThemesSDK;
using ATVO.ThemeEditor.ThemeModels;
using ATVO.ThemeEditor.Scripting.DotNET;
using System.Windows.Media;

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
