#nullable enable
using System;
using ATVO.ThemesSDK;
using ATVO.ThemeEditor.ThemeModels;
using ATVO.ThemeEditor.Scripting.DotNET;
using ATVO.ThemesSDK.Data;
using ATVO.ThemesSDK.Data.Entity;
using Scripts;
using System.Collections.Generic;
using ATVO.ThemeEditor.Data;
namespace Scripts
{
	public enum NameFormats {Full, Short, Last, Team};
	public class DriverNameFormat : IScript
	{
		public object Execute(ThemeContentItem item, object value, string parameter, ISimulation sim)
		{
			IEntity? ent = (IEntity) value;
			string text = "";
			if(ent == null)
				return null;

			// Find the dropdown and the index of the selected item
			var dropdown = (Dropdown) item.Theme.Dropdowns.Find("nameMode");
			var selectedIndex = dropdown.Items.IndexOf(dropdown.SelectedItem);


			if(selectedIndex == (int) NameFormats.Full)
			{
				text = ent.CurrentDriver.Name;
			}
			else if(selectedIndex == (int) NameFormats.Short)
			{
				text = ent.CurrentDriver.ShortName;
			}
			else if(selectedIndex == (int) NameFormats.Last)
			{
				text = ent.CurrentDriver.LastName;
			}
			else
			{
				text = ent.Name;
			}
			
			return text;
		}
	}
}
