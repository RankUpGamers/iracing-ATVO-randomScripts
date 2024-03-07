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
			return "Overcast";
		}
	}
}
