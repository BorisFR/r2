using System;
using System.Collections.ObjectModel;

namespace R2B0app
{
	public class MenuGroup : ObservableCollection<Menu>
	{

		public MenuGroup(string title) {
			Title = title;
		}

		public string Title { get; private set; }

	}
}