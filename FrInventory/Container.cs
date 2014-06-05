using System;
namespace FrInventory
{
	public class Container
	{
		private string m_ContainerName;
		private string m_LocationName;
		private DateTime m_Data;
		private bool m_Deleted;
		
		public string ContainerName
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
		
		public string ContainerLocation
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

