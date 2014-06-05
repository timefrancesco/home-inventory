using System;
namespace FrInventory
{
	public class Item
	{
		private string m_ItemName;
		private string m_ContainerName;
		private string m_LocationName;
		private DateTime m_Data;
		private bool m_Deleted;
		
		public string ItemName
        {
            get
            {
                return m_ItemName;
            }
            set
            {
                m_ItemName = value;
            }
        }
		
		public string ItemContainer
        {
            get
            {
                return m_ContainerName;
            }
            set
            {
                m_ContainerName = value;
            }
        }
		
		public string ItemLocation
        {
            get
            {
                return m_LocationName;
            }
            set
            {
                m_LocationName = value;
            }
        }
		
		public DateTime Date
        {
            get
            {
                return m_Data;
            }
            set
            {
                m_Data = value;
            }
        }
		
		public bool Deleted
        {
            get
            {
                return m_Deleted;
            }
            set
            {
                m_Deleted = value;
            }
        }
		
		
		
	}
}

