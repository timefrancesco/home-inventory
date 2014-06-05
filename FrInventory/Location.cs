using System;
namespace FrInventory
{
	public class Location
	{
		private string m_LocationName;
		private DateTime m_Data;
		private bool m_Deleted;
		
		 public string LocationName
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
