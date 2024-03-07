/*
	Author: Dustin Ollis
	File: convertDecimalToPercentage.cs
	Bindings: any decimal

	Usage: Takes in any binding (that is a number) and attempts to turn it into a percentage. If you pass something that isn't a number, your script WILL return an error. 



	Returns: Formatted string representing the percentage-value of a decimal object.
*/


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
			return "0%";
		}
		
	}
}