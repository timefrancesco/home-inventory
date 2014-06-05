using System;
using System.Data;
using Gtk;
using System.Data.SQLite;
using System.Collections; 


namespace FrInventory
{
	public class SqlOperations
	{
		
//#if UNIX		
//		static string m_DBConnString = "Data Source = "+  DataAccess.Instance.m_DatabasePath;
//#else
		 static string m_DBConnString = string.Format("Data Source = {0}",  DataAccess.Instance.DB_Path); 
//#endif
	
		#region Locations
		public int AddLocation(string Location,DateTime Data)
		{
			int ret = -1;

            //Apro la connessione al database
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);

                //INSERISCO DATI IN DB
				string cmd = String.Format("INSERT INTO Locations (LocName,Date) VALUES (\"{0}\",\"{1}\")",Location,Data);
                DBcmd.CommandText = cmd;
                
                DBcmd.ExecuteNonQuery();
                ret = 1;
            }
            catch (Exception ex)
            {
                ret = -1;
            }
            finally
            {
                DBConn.Close();
            }

            return ret;
		}
		
		
		
		public int ChekIfExistLocation(string Location)
		{
			 int ret = -2;
			int open = 0;

            //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
                string strcmd = string.Format("SELECT count(*) LocName from Locations where LocName = \"{0}\" and Deleted = \"0\"", Location);
                
                DBcmd.CommandText = strcmd;
                DBreader = DBcmd.ExecuteReader();
                if (DBreader.HasRows)
                {
                    DBreader.Read();
                   int a = DBreader.GetInt32(0);
					ret = a;
                }
                else
                    ret = 0;
            }
            catch (Exception ex)
            {
                ret = -1;
            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
            
            return ret;
		}
		
		
		public int ReadAllLocations()
		{
			
			int open = 0;
			
			 //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
                string strcmd = "SELECT * from Locations where deleted = '0'";

                DBcmd.CommandText = strcmd;
                DBreader = DBcmd.ExecuteReader();
                if (DBreader.HasRows)
                {
                    while (DBreader.Read())
                    {
						Location location = new Location();
						location.LocationName = DBreader.GetString(0);
						location.Date = Convert.ToDateTime(DBreader.GetString(2));
						location.Deleted = DBreader.GetBoolean(1);
						
						
						DataAccess.Instance.ListaLocations.AppendValues(location);

                    }

                }

            }
            catch (Exception ex)
            {

            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
           
			
			return 1;
		}
		
		public int RemoveSelectedLocation(Location location)
		{
			 int ret = -2;
			int open = 0;

            //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
                string strcmd = string.Format("UPDATE LOCATIONS SET DELETED = '1' WHERE LOCNAME = \"{0}\"",location.LocationName);
                			
				DBcmd.CommandText = strcmd;
                DBcmd.ExecuteNonQuery();
			
			}
            catch (Exception ex)
            {
                ret = -1;
            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
            
            return ret;
		}
		
		#endregion
		
		#region container
		
		public int AddContainer(string Location,string Container, DateTime Data)
		{
			int ret = -1;

            //Apro la connessione al database
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);

                //INSERISCO DATI IN DB
				string cmd = String.Format("INSERT INTO Containers (Location,Container,Date) VALUES (\"{0}\",\"{1}\",\"{2}\")",Location,Container,Data);
                DBcmd.CommandText = cmd;
                
                DBcmd.ExecuteNonQuery();
                ret = 1;
            }
            catch (Exception ex)
            {
                ret = -1;
            }
            finally 
            {
                DBConn.Close();
            }

            return ret;
		}
		
		public int ReadContainersOfLocation(string Location)
		{
			
			int open = 0;
			
			 //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
                string strcmd = string.Format("SELECT * from Containers where Location = \"{0}\" and deleted = '0'",Location);

                DBcmd.CommandText = strcmd;
                DBreader = DBcmd.ExecuteReader();
                if (DBreader.HasRows)
                {
                    while (DBreader.Read())
                    {
						Container container = new Container();
						container.ContainerLocation = DBreader.GetString(0);
						container.ContainerName = DBreader.GetString(1);
						container.Deleted = DBreader.GetBoolean(2);
						container.Date = Convert.ToDateTime(DBreader.GetString(3));						
						
						DataAccess.Instance.ListaContainers.AppendValues(container);

                    }

                }

            }
            catch (Exception ex)
            {

            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
           
			
			return 1;
		}
		
		public int ChekIfExistContainer(string Location,string Container)
		{
			 int ret = -2;
			int open = 0;

            //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
                string strcmd = string.Format("SELECT count(*) Container from Containers where Container = \"{0}\"and Location = \"{1}\" and Deleted = \"0\" ", Location, Container);
                
				
				
                DBcmd.CommandText = strcmd;
                DBreader = DBcmd.ExecuteReader();
                if (DBreader.HasRows)
                {
                    DBreader.Read();
                   int a = DBreader.GetInt32(0);
					ret = a;
                }
                else
                    ret = 0;
            }
            catch (Exception ex)
            {
                ret = -1;
            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
            
            return ret;
		}
		
		public int RemoveSelectedContainer(Container container)
		{
			 int ret = -2;
			int open = 0;

            //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
                string strcmd = string.Format("UPDATE CONTAINERS SET DELETED = '1' WHERE LOCATION = \"{0}\" AND CONTAINER =\"{1}\" AND DATE = \"{2}\"",container.ContainerLocation,container.ContainerName,container.Date);
                			
				DBcmd.CommandText = strcmd;
                DBcmd.ExecuteNonQuery();
			
			}
            catch (Exception ex)
            {
                ret = -1;
            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
            
            return ret;
		}
		
		public int RemoveAllContainers(Location ContainersLocation)
		{
			int ret = -2;
			int open = 0;
	
            //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;			
					
				SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
            	string strcmd = string.Format("UPDATE CONTAINERS SET DELETED = '1' WHERE LOCATION = \"{0}\" ",ContainersLocation.LocationName);
            	DBcmd.CommandText = strcmd;
           		DBcmd.ExecuteNonQuery();			
			 			
			}
            catch (Exception ex)
            {
                ret = -1;
            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
            
            return ret;
		}
		
		#endregion
		
		
		#region item
		public int AddItem(string Location,string Container,string Item,DateTime Data)
		{
			int ret = -1;

            //Apro la connessione al database
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);

                //INSERISCO DATI IN DB
				string cmd = String.Format("INSERT INTO Items (Location,Container,Item,Date) VALUES (\"{0}\",\"{1}\",\"{2}\",\"{3}\")",Location,Container,Item,Data);
                
				DBcmd.CommandText = cmd;
                
                DBcmd.ExecuteNonQuery();
                ret = 1;
            }
            catch (Exception ex)
            {
                ret = -1;
            }
            finally 
            {
                DBConn.Close();
            }

            return ret;
		}
		
		public int ReadItemsByContainer(string Location,string Container)
		{
			
			int open = 0;
			int ret = 0;
			
			 //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
                string strcmd = string.Format("SELECT * from Items where Location = \"{0}\" and Container = \"{1}\" and deleted = '0'",Location,Container);

                DBcmd.CommandText = strcmd;
                DBreader = DBcmd.ExecuteReader();
                if (DBreader.HasRows)
                {
                    while (DBreader.Read())
                    {
						Item itemletto = new Item();	
						itemletto.ItemLocation = DBreader.GetString(0);
						itemletto.ItemContainer = DBreader.GetString(1);
						itemletto.ItemName = DBreader.GetString(2);							
						itemletto.Date = Convert.ToDateTime(DBreader.GetString(3));	
						itemletto.Deleted = DBreader.GetBoolean(4);
						DataAccess.Instance.ListaItems.AppendValues(itemletto);

                    }

                }

            }
            catch (Exception ex)
            {
				ret = 0;
            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
           
			
			return 1;
		}
		
		public int ChekIfExistItem(string Location,string Container,string Item)
		{
			 int ret = -2;
			int open = 0;

            //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
                string strcmd = string.Format("SELECT count(*) Container from Containers where Container = \"{0}\"and Location = \"{1}\"and Item = \"{2}\" and Deleted = \"0\" ", Location, Container,Item);
                
				
				
                DBcmd.CommandText = strcmd;
                DBreader = DBcmd.ExecuteReader();
                if (DBreader.HasRows)
                {
                    DBreader.Read();
                   int a = DBreader.GetInt32(0);
					ret = a;
                }
                else
                    ret = 0;
            }
            catch (Exception ex)
            {
                ret = -1;
            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
            
            return ret;
		}
		
		public int RemoveSelectedItem(Item itemToRemove)
		{
			 int ret = -2;
			int open = 0;

            //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
                string strcmd = string.Format("UPDATE ITEMS SET DELETED = '1' WHERE LOCATION = \"{0}\" AND CONTAINER =\"{1}\" AND ITEM = \"{2}\" AND DATE = \"{3}\"",itemToRemove.ItemLocation,itemToRemove.ItemContainer,itemToRemove.ItemName,itemToRemove.Date);
                	
				
				
                DBcmd.CommandText = strcmd;
                DBcmd.ExecuteNonQuery();
                
            
			
			}
            catch (Exception ex)
            {
                ret = -1;
            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
            
            return ret;
		}
		
		public int RemoveAllContainerItems(Container ItemsContainer)
		{
			int ret = -2;
			int open = 0;
	
            //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;			
					
				SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
            	string strcmd = string.Format("UPDATE ITEMS SET DELETED = '1' WHERE LOCATION = \"{0}\" AND CONTAINER =\"{1}\" ",ItemsContainer.ContainerLocation, ItemsContainer.ContainerName);
            	DBcmd.CommandText = strcmd;
           		DBcmd.ExecuteNonQuery();			
			 			
			}
            catch (Exception ex)
            {
                ret = -1;
            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
            
            return ret;
		}
		
		public int RemoveAllLocationItems(Location ItemsLocation)
		{
			int ret = -2;
			int open = 0;
	
            //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;			
					
				SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
            	string strcmd = string.Format("UPDATE ITEMS SET DELETED = '1' WHERE LOCATION = \"{0}\"",ItemsLocation.LocationName);
            	DBcmd.CommandText = strcmd;
           		DBcmd.ExecuteNonQuery();			
			 			
			}
            catch (Exception ex)
            {
                ret = -1;
            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
            
            return ret;
		}
		
		public int Search(string strToFind)
		{
			
			int open = 0;
			int ret = 0;
			
			 //Apro la connessione al database
            SQLiteDataReader DBreader = null;
            SQLiteConnection DBConn = new SQLiteConnection(m_DBConnString);
            try
            {
                DBConn.Open();
				open = 1;
                SQLiteCommand DBcmd = new SQLiteCommand(DBConn);
                string strcmd = string.Format("SELECT * from Items where Item like \"%{0}%\" and deleted = '0'",strToFind);
                DBcmd.CommandText = strcmd;
                DBreader = DBcmd.ExecuteReader();
                if (DBreader.HasRows)
                {
                    while (DBreader.Read())
                    {
						Item itemletto = new Item();	
						itemletto.ItemLocation = DBreader.GetString(0);
						itemletto.ItemContainer = DBreader.GetString(1);
						itemletto.ItemName = DBreader.GetString(2);							
						itemletto.Date = Convert.ToDateTime(DBreader.GetString(3));	
						itemletto.Deleted = DBreader.GetBoolean(4);
						DataAccess.Instance.ListaItems.AppendValues(itemletto);

                    }

                }

            }
            catch (Exception ex)
            {
				ret = 0;
            }
            
                if (DBreader != null)
                    DBreader.Close();
			if (open == 1)
                DBConn.Close();
           
			
			return 1;
		}
		
		#endregion
	}
}

