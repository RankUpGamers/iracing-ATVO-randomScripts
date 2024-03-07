/*
	Author: Dustin Ollis
	File: weatherFriendlyText.cs
	Bindings: none. A binding may be required to get this to update with the sim weather. Send in track temp or something similar. Still testing this.

	Usage: Gives you a 'friendly' string representing the current weather. Includes support for rain.

	Known Errors: VSCode will often report sim.Telemetry.Precipitation as 'not included in ISimulation, but it does in fact work post-tempest. version stable 1.52.0.0

	Returns: Formatted string representing the current weather, or Unknown if the sim is not returning telemetry.
*/

using System;
using ATVO.ThemesSDK;
using ATVO.ThemeEditor.ThemeModels;
using ATVO.ThemeEditor.Scripting.DotNET;
using ATVO.ThemesSDK.Data.Location;
using ATVO.ThemesSDK.Data.Weather;

namespace Scripts
{
	public class weatherFriendlyText : IScript
	{
		public object Execute(ThemeContentItem item, object value, string parameter, ISimulation sim)
		{	
			if (sim.Telemetry.Precipitation > 0)
			{
				if(sim.Telemetry.Precipitation > 0.9)
					return "Heavy Shower";
				else if (sim.Telemetry.Precipitation > 0.75)
					return "Moderate Shower";
				else if (sim.Telemetry.Precipitation > 0.60)
					return "Heavy Rain";
				else if (sim.Telemetry.Precipitation > 0.40)
					return "Moderate Rain";
				else if (sim.Telemetry.Precipitation > 0.15)
					return "Light Rain";
				else if (sim.Telemetry.Precipitation > 0)
					return "Drizzle";			}
			else
			{
				if(sim.Telemetry.Skies == 0)
					return "Clear";
				else if (sim.Telemetry.Skies == 1)
					return "Partly Cloudy";
				else if (sim.Telemetry.Skies == 2)
					return "Mostly Cloudy";	
				else 
					return "Overcast";
 			} 
			return "Unknown";
		}
	}
}
