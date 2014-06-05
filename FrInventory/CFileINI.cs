using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FrInventory
{
   class CFileINI
	{
      public string path;

      [DllImport("kernel32")]
      private static extern int GetPrivateProfileString(string section,
         string key,string def, StringBuilder retVal,
         int size,string filePath);
      [DllImport("kernel32")]
      private static extern long WritePrivateProfileString(string section,
          string key, string val, string filePath);


      /// <summary>
      /// INIFile Constructor.
      /// </summary>
      /// <PARAM name="INIPath"></PARAM>
      public CFileINI(string INIPath)
      {
         path = INIPath;
      }
        
      public string ReadValue( string Section, string Key, string strDefault )
      {
         string strRis = strDefault;

         StringBuilder temp = new StringBuilder( 255 );
         int i = GetPrivateProfileString( Section, Key, "", temp, 255, this.path );
         string strTmp = temp.ToString();
         if( strTmp.Length > 0 )
            strRis = strTmp;

         return ( strRis );
      }

      public int ReadValue( string Section, string Key, int nDefault )
      {
         int nRis = nDefault;

         StringBuilder temp = new StringBuilder( 255 );
         int i = GetPrivateProfileString( Section, Key, "", temp, 255, this.path );
         try
         {
            nRis = int.Parse( temp.ToString() );
         }
         catch{}

         return ( nRis );
      }

      public bool ReadValue( string Section, string Key, bool bDefault )
      {
         bool bRis = bDefault;

         StringBuilder temp = new StringBuilder( 255 );
         int i = GetPrivateProfileString( Section, Key, "", temp, 255, this.path );
         try
         {
            if( int.Parse(temp.ToString())!=0 ) 
               bRis = true;
         }
         catch
         {
         }

         return ( bRis );
      }

      public void WriteValue(string Section, string Key, string Value)
      {
          WritePrivateProfileString(Section, Key, Value, this.path);
      }

	}
}
