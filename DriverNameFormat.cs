/*
	Author: Dustin Ollis
	File: DriverNameFormat.cs
	Bindings: entity_object

	Usage: Set label to pass entity_object and use this script as the data converter. Requires a dropdown to select which format to use. The dropdown is to be named 'nameMode' Capitalization is IMPORTANT.

		nameMode options: Full Name, Short Name, Last Name, Team Name. The specific text isn't important, but the order is always the same.
		Action when Any is selected: none
		Action when specific is selected: none

	Returns: Formatted String representing NAME of the entity. 
*/


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
   			if(dropdown == null)
      				return null;
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
