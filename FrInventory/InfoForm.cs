using System;
namespace FrInventory
{
	public partial class InfoForm : Gtk.Dialog
	{
		protected virtual void OnButtonOkActivated (object sender, System.EventArgs e)
		{
			
		}
		
		public InfoForm ()
		{
			this.Build ();
			button53.Visible = false;
		}
	}
}

