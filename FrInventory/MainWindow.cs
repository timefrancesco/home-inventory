using System;
using Gtk;
using System.Collections;
using System.Threading;
using System.IO;


namespace FrInventory
{
	
	
	public partial class MainWindow : Gtk.Window
	{
	

		
		

		public MainWindow () : base(Gtk.WindowType.Toplevel)
		{
			Build ();
			CreateTreeView ();
			tbox_item.Visible = false;
			tbox_container.Visible = false;
			btn_AddItem.Visible = false;
			btn_RemoveItem.Visible = false;
			btn_AddContainer.Visible = false;
			btn_RemoveContainer.Visible = false;
			
#if UNIX
				DataAccess.Instance.DB_Path = "./Frinventory.sqlite";
#else	
				DataAccess.Instance.DB_Path = ".\\Frinventory.sqlite";
#endif
			
			ReadAllLocations ();
			//RetrieveContainers();
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		void CreateTreeView ()
		{
			

			
			//LOCATIONS
			Gtk.TreeViewColumn LocationsColumn = new Gtk.TreeViewColumn ();
			LocationsColumn.Title = "Locations";
			Gtk.CellRendererText LocationsColumnCell = new Gtk.CellRendererText ();
			LocationsColumn.PackStart (LocationsColumnCell, true);
			
			//creo la lista perchè nella treeview faccio vedere SOLO il nome e non la data
			//ListStore Lista_Locations = new ListStore (typeof(string));
			
			//foreach( Location actLocation in DataAccess.Instance.ListaLocations)
			//	Lista_Locations.AppendValues(actLocation.LocationName);

			//qui collego il nome con l'oggetto, la funzione è sotto
			LocationsColumn.SetCellDataFunc (LocationsColumnCell, new Gtk.TreeCellDataFunc (RenderLocation));
			
			LocationsGrid.AppendColumn (LocationsColumn);
			
			LocationsColumn.AddAttribute (LocationsColumnCell, "text", 0);
			
			//riempio la griglia
			LocationsGrid.Model = DataAccess.Instance.ListaLocations;
			//m_Lista_Locations;
			//CONTAINERS
			Gtk.TreeViewColumn ContainersColum = new Gtk.TreeViewColumn ();
			ContainersColum.Title = "Containers";
			Gtk.CellRendererText ContainersColumCell = new Gtk.CellRendererText ();
			ContainersColum.PackStart (ContainersColumCell, true);
			
			//creo la lista perchè nella treeview faccio vedere SOLO il nome e non la data
			//ListStore Lista_Containers = new ListStore (typeof(string));
			
			//foreach( Container actContainer in DataAccess.Instance.ListaContainers)
			//	Lista_Containers.AppendValues(actContainer.ContainerName);

			//qui collego il nome con l'oggetto, la funzione è sotto
			ContainersColum.SetCellDataFunc (ContainersColumCell, new Gtk.TreeCellDataFunc (RenderContainer));
			
			ContainersGrid.AppendColumn (ContainersColum);
			ContainersColum.AddAttribute (ContainersColumCell, "text", 0);
			
			//riempio la griglia
			ContainersGrid.Model = DataAccess.Instance.ListaContainers;
			
			//ITEMS
			Gtk.TreeViewColumn ItemsColum = new Gtk.TreeViewColumn ();
			ItemsColum.Title = "Items";
			Gtk.CellRendererText ItemsColumCell = new Gtk.CellRendererText ();
			ItemsColum.PackStart (ItemsColumCell, true);
			
			//creo la lista perchè nella treeview faccio vedere SOLO il nome e non la data
			//ListStore Lista_Item = new ListStore (typeof(string));
			
			//foreach( Item actItem in DataAccess.Instance.ListaItems)
			//	Lista_Item.AppendValues(actItem.ItemName);

			//qui collego il nome con l'oggetto, la funzione è sotto
			ItemsColum.SetCellDataFunc (ItemsColumCell, new Gtk.TreeCellDataFunc (RenderItem));

			
			ItemsGrid.AppendColumn (ItemsColum);
			ItemsColum.AddAttribute (ItemsColumCell, "text", 0);
			
			//riempio la griglia
			ItemsGrid.Model = DataAccess.Instance.ListaItems;
			
			
			
			
			
			
			this.ShowAll ();
		}
		
		//serve per linkare le linee della treeview con la lista degli oggetti e visualizzare solo il nome nella treeview
		private void RenderItem (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Item item = (Item) model.GetValue (iter, 0);
			(cell as Gtk.CellRendererText).Text = item.ItemName;

		}
		
		//serve per linkare le linee della treeview con la lista degli oggetti e visualizzare solo il nome nella treeview
		private void RenderContainer (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Container container = (Container) model.GetValue (iter, 0);
			(cell as Gtk.CellRendererText).Text = container.ContainerName;

		}
		
		//serve per linkare le linee della treeview con la lista degli oggetti e visualizzare solo il nome nella treeview
		private void RenderLocation (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Location location = (Location) model.GetValue (iter, 0);
			(cell as Gtk.CellRendererText).Text = location.LocationName;

		}

		
		protected virtual void OnBtnAddLocationClicked (object sender, System.EventArgs e)
		{
			string LocationtoAdd = tbox_Location.Text;
			SqlOperations sqlop = new SqlOperations ();
			int ret = sqlop.ChekIfExistLocation (LocationtoAdd);
			if (ret > 0) {
				MessageDialog md = new MessageDialog (null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "The location already exist");
				md.Run ();
				md.Destroy ();
			} else
				ret = sqlop.AddLocation (LocationtoAdd,System.DateTime.Now);
			ReadAllLocations ();
			tbox_Location.Text = string.Empty;
			
			
		}

		void ReadAllLocations ()
		{
			try
			{
				DataAccess.Instance.ListaLocations.Clear ();
				SqlOperations sqlop = new SqlOperations ();
				sqlop.ReadAllLocations ();
			}
			catch (Exception ex)
			{
			}
			
		}
		
	


		//Seleziono un elemento diverso nella grigla Locations
		protected virtual void OnLocationsGridCursorChanged (object sender, System.EventArgs e)
		{
			
			
			Gtk.TreeIter iter;
			LocationsGrid.Selection.GetSelected (out iter);
			if (iter.Stamp != 0)
			{
				DataAccess.Instance.SelectedLocation = (Location)DataAccess.Instance.ListaLocations.GetValue (iter, 0);
				DataAccess.Instance.SelectedContainer = null;
				DataAccess.Instance.ListaItems.Clear();
				RetrieveContainers ();
				tbox_item.Visible = false;
				tbox_container.Visible = false;
				btn_AddItem.Visible = false;
				btn_RemoveItem.Visible = false;
				btn_AddContainer.Visible = false;
				btn_RemoveContainer.Visible = false;
				tbox_Location.Visible = true;
				btn_AddLocation.Visible = true;
				btn_RemoveLocation.Visible = true;
			}
			
		}
		
		//seleziono un Container nella griglia
		protected virtual void OnContainersGridCursorChanged (object sender, System.EventArgs e)
		{
			Gtk.TreeIter iter;
			
			try{
				ContainersGrid.Selection.GetSelected (out iter);
				DataAccess.Instance.SelectedContainer = (Container)DataAccess.Instance.ListaContainers.GetValue (iter, 0);
				DataAccess.Instance.SelectedItem = null;
				RetrieveItems ();
				tbox_item.Visible = false;
				btn_AddItem.Visible = false;
				btn_RemoveItem.Visible = false;
				
				tbox_container.Visible = true;
				btn_AddContainer.Visible = true;
				btn_RemoveContainer.Visible = true;
				
				tbox_Location.Visible = false;
				btn_AddLocation.Visible = false;
				btn_RemoveLocation.Visible = false;
			}
			catch (Exception ex)
			{
				
			}
			
		}


		void RetrieveContainers ()
		{
			try{
				DataAccess.Instance.ListaContainers.Clear ();
				SqlOperations sqlop = new SqlOperations ();
				sqlop.ReadContainersOfLocation(DataAccess.Instance.SelectedLocation.LocationName);
			}
			catch (Exception ex)
			{
			}
		}
		
		void RetrieveItems()
		{
			try{
				DataAccess.Instance.ListaItems.Clear ();
				SqlOperations sqlop = new SqlOperations ();
				sqlop.ReadItemsByContainer(DataAccess.Instance.SelectedLocation.LocationName,DataAccess.Instance.SelectedContainer.ContainerName);
			}
			catch (Exception ex)
			{
			}
		}
		
		protected virtual void OnBtnAddContainerClicked (object sender, System.EventArgs e)
		{
			if (DataAccess.Instance.SelectedLocation.Equals(string.Empty))
				return;
			
			string ContainertoAdd = tbox_container.Text;
			SqlOperations sqlop = new SqlOperations ();
			int ret = sqlop.ChekIfExistContainer (DataAccess.Instance.SelectedLocation.LocationName,ContainertoAdd);
			if (ret > 0) {
				MessageDialog md = new MessageDialog (null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "The location already exist");
				md.Run ();
				md.Destroy ();
			} else
				 ret = sqlop.AddContainer(DataAccess.Instance.SelectedLocation.LocationName, ContainertoAdd,System.DateTime.Now);
			RetrieveContainers ();
			tbox_container.Text = string.Empty;
		}
		
		protected virtual void OnBtnAddItemClicked (object sender, System.EventArgs e)
		{
			
			SqlOperations sqlop = new SqlOperations();
			sqlop.AddItem(DataAccess.Instance.SelectedLocation.LocationName,DataAccess.Instance.SelectedContainer.ContainerName,tbox_item.Text,System.DateTime.Now);
			RetrieveItems();
			tbox_item.Text = string.Empty;
		}
		
	
		
		protected virtual void OnContainersGridFocusInEvent (object o, Gtk.FocusInEventArgs args)
		{
			
			if (DataAccess.Instance.SelectedLocation.LocationName != null)
			{
				tbox_container.Visible = true;
				btn_AddContainer.Visible = true;
				btn_RemoveContainer.Visible = true;
				
				tbox_Location.Visible = false;
				btn_AddLocation.Visible = false;
				btn_RemoveLocation.Visible = false;
				
				tbox_item.Visible = false;
				btn_AddItem.Visible = false;
				btn_RemoveItem.Visible = false;
			}
		}
		
		protected virtual void OnLocationsGridFocusInEvent (object o, Gtk.FocusInEventArgs args)
		{
			
				tbox_container.Visible = false;
				btn_AddContainer.Visible = false;
				btn_RemoveContainer.Visible = false;
				
				tbox_Location.Visible = true;
				btn_AddLocation.Visible = true;
				btn_RemoveLocation.Visible = true;
				
				tbox_item.Visible = false;
				btn_AddItem.Visible = false;
				btn_RemoveItem.Visible = false;
			
		}
		
		protected virtual void OnItemsGridFocusInEvent (object o, Gtk.FocusInEventArgs args)
		{
			
			
			if (DataAccess.Instance.SelectedContainer != null)
			{
				tbox_container.Visible = false;
				btn_AddContainer.Visible = false;
				btn_RemoveContainer.Visible = false;
				
				tbox_Location.Visible = false;
				btn_AddLocation.Visible = false;
				btn_RemoveLocation.Visible = false;
				
				tbox_item.Visible = true;
				btn_AddItem.Visible = true;
				btn_RemoveItem.Visible = true;
			}
		}
		
		protected virtual void OnBtnRemoveLocationClicked (object sender, System.EventArgs e)
		{
			MessageDialog md = new MessageDialog(this, 
                                   DialogFlags.DestroyWithParent,
	                               MessageType.Question, 
                                   ButtonsType.YesNo, "WARNING: All Items and containers in this Location will be deleted! Are you sure?");

			ResponseType result = (ResponseType)md.Run ();
					
			if (result == ResponseType.Yes)
			{
				
				
				SqlOperations sqlop = new SqlOperations();
				sqlop.RemoveAllLocationItems(DataAccess.Instance.SelectedLocation);
				sqlop.RemoveAllContainers(DataAccess.Instance.SelectedLocation);
				sqlop.RemoveSelectedLocation(DataAccess.Instance.SelectedLocation);
				RetrieveItems();
				RetrieveContainers();
				ReadAllLocations();
					
				
				DataAccess.Instance.SelectedContainer = null;
				DataAccess.Instance.SelectedItem = null;
			}
			md.Destroy();
		}
		
		protected virtual void OnBtnRemoveItemClicked (object sender, System.EventArgs e)
		{
			SqlOperations sqlop = new SqlOperations();
			sqlop.RemoveSelectedItem(DataAccess.Instance.SelectedItem);
			RetrieveItems();
			DataAccess.Instance.SelectedItem = null;
		}
		
		protected virtual void OnItemsGridCursorChanged (object sender, System.EventArgs e)
		{
			Gtk.TreeIter iter;
			
			try{
				ItemsGrid.Selection.GetSelected (out iter);
				DataAccess.Instance.SelectedItem = (Item)DataAccess.Instance.ListaItems.GetValue (iter, 0);
				if(!tbox_Search.Text.Equals(string.Empty))//in questo caso sono in modalita ricerca
				{
					DataAccess.Instance.ListaContainers.Clear();
					DataAccess.Instance.ListaLocations.Clear();
					Container container = new Container();
					container.ContainerLocation = DataAccess.Instance.SelectedItem.ItemLocation;
					container.ContainerName = DataAccess.Instance.SelectedItem.ItemContainer;
					container.Date = System.DateTime.Now;
					container.Deleted = false;
					DataAccess.Instance.ListaContainers.AppendValues(container);
					
					Location location = new Location();
					location.LocationName = container.ContainerLocation;
					location.Date = container.Date;
					location.Deleted = false;
					DataAccess.Instance.ListaLocations.AppendValues(location);
					
				}
				
			}
			catch (Exception ex)
			{
				
			}
		}
		
		protected virtual void OnBtnRemoveContainerClicked (object sender, System.EventArgs e)
		{
			MessageDialog md = new MessageDialog(this, 
                                   DialogFlags.DestroyWithParent,
	                               MessageType.Question, 
                                   ButtonsType.YesNo, "WARNING: All Items in containers will be deleted! Are you sure?");

			ResponseType result = (ResponseType)md.Run ();
					
			if (result == ResponseType.Yes)
			{
				
				
				SqlOperations sqlop = new SqlOperations();
				sqlop.RemoveAllContainerItems(DataAccess.Instance.SelectedContainer);
				sqlop.RemoveSelectedContainer(DataAccess.Instance.SelectedContainer);
				RetrieveItems();
				RetrieveContainers();
				DataAccess.Instance.SelectedContainer = null;
				DataAccess.Instance.SelectedItem = null;
			}
			md.Destroy();

			
		}
		
		protected virtual void OnTboxSearchTextInserted (object o, Gtk.TextInsertedArgs args)
		{
			Search();
		}
		
		void Search()
		{
			DataAccess.Instance.ListaContainers.Clear();
			DataAccess.Instance.ListaItems.Clear();
			DataAccess.Instance.ListaLocations.Clear();
			if (tbox_Search.Text.Equals(string.Empty))
			{
				
				ReadAllLocations();
			}
			else{
				SqlOperations sqlop = new SqlOperations();
				sqlop.Search(tbox_Search.Text);
			}
		}
		
		protected virtual void OnTboxSearchTextDeleted (object o, Gtk.TextDeletedArgs args)
		{
			Search();
		}
		
		protected virtual void OnOpenActionActivated (object sender, System.EventArgs e)
		{
			Gtk.FileChooserDialog fc=
			new Gtk.FileChooserDialog("Choose the Database",
			                            this,
			                            FileChooserAction.Open,
			                            "Cancel",ResponseType.Cancel,
			                            "Open",ResponseType.Accept);
	
			if (fc.Run() == (int)ResponseType.Accept) 
			{
				DataAccess.Instance.DB_Path = fc.Filename;
				ReadAllLocations();	

				
				
				
			}
			
			fc.Destroy();
			
			
		}
		
		protected virtual void OnDialogInfoActionActivated (object sender, System.EventArgs e)
		{
			InfoForm iform = new InfoForm();
			iform.Show();
			
		}
		
		
		
		
		
		
	
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}
}
