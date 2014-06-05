using System;
using Gtk;
namespace FrInventory
{
	public class DataAccess
	{
		 
		 private static DataAccess _instance;
        private ListStore m_ListaLocations = new ListStore (typeof (Location));
        private ListStore m_ListaContainers = new ListStore (typeof (Container));
        private ListStore m_ListaItems = new ListStore (typeof (Item));
		private Location m_SelectedLocation = new Location();
		private Container m_SelectedContainer = new Container();
		private Item m_SelectedItem = new Item();
		private string m_DatabasePath = string.Empty;


        public static DataAccess Instance
        {

            get
            {
                if (_instance == null)
                    _instance = new DataAccess();

                return _instance;
            }
        }

      

        public ListStore ListaLocations
        {
            get
            {
                return m_ListaLocations;
            }
            set
            {
                m_ListaLocations = value;
            }
        }
		
		public ListStore ListaContainers
        {
            get
            {
                return m_ListaContainers;
            }
            set
            {
                m_ListaContainers = value;
            }
        }
		
		public ListStore ListaItems
        {
            get
            {
                return m_ListaItems;
            }
            set
            {
                m_ListaItems = value;
            }
        }
		
		public Location SelectedLocation
        {
            get
            {
                return m_SelectedLocation;
            }
            set
            {
                m_SelectedLocation = value;
            }
        }
		
		public Container SelectedContainer
        {
            get
            {
                return m_SelectedContainer;
            }
            set
            {
                m_SelectedContainer = value;
            }
        }
		
		public Item SelectedItem
        {
            get
            {
                return m_SelectedItem;
            }
            set
            {
                m_SelectedItem = value;
            }
        }
		
		public string DB_Path
        {
            get
            {
                return m_DatabasePath;
            }
            set
            {
                m_DatabasePath = value;
            }
        }
		
		 private DataAccess()
        {


        }

	}
}

