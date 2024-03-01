using System;
using ATVO.ThemesSDK;
using ATVO.ThemeEditor.ThemeModels;
using ATVO.ThemeEditor.Scripting.DotNET;
using System.Windows.Media;
using ATVO.ThemesSDK.Data.Results;
using ATVO.ThemesSDK.Data.Enums;
using ATVO.ThemesSDK.Data.Entity;
using System.Runtime.InteropServices;

namespace Scripts
{
	public class ColorizeFocusPosition : IScript
	{

		Color RED = Color.FromRgb(255,0,0);
		Color YELLOW = Color.FromRgb(255,255,0);
		Color WHITE = Color.FromRgb(255,255,255);
		Color ORANGE = Color.FromRgb(255,165,0);
		Color GRAY = Color.FromRgb(100,100,100);
		Color BLUE = Color.FromRgb(20,20,255);
		public object Execute(ThemeContentItem item, object value, string parameter, ISimulation sim)
		{	
			IEntitySessionResult? result = (IEntitySessionResult) value;
			if(result != null)
			{
				if(result.Entity?.IsFollowedEntity == true)
					return BLUE;
				if(result.Finished)
					return GRAY;
			}
				
			return WHITE;
		}
	}
}