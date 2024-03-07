using System;
using ATVO.ThemesSDK;
using ATVO.ThemeEditor.ThemeModels;
using ATVO.ThemeEditor.Scripting.DotNET;
using System.Globalization;

namespace Scripts
{
	public class convertDecimalToPercentage : IScript
	{
		public object Execute(ThemeContentItem item, object value, string parameter, ISimulation sim)
		{	
			if (value == null)
				Console.WriteLine("Val was null");
			else
			{
				double valueDec = double.Parse(value.ToString());
				NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
				nfi.PercentDecimalDigits = 0;
				return valueDec.ToString("P", nfi);
			}
			return "0";
		}
		
	}
}