using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDVLD.Global
{
    public class clsUtil
    {
        public static string GenerateGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public static string ReplaceFileNameWithGUID(string SourceFileName)
        {
            FileInfo fi = new FileInfo(SourceFileName);
            string Ext = fi.Extension;
            return GenerateGuid()+ Ext;
        }

        public static bool CreatFolderIfNotExist(string FolderName)
        {
            if (!Directory.Exists(FolderName))
            {
                try
                {
                    Directory.CreateDirectory(FolderName);
                    MessageBox.Show($"Folder '{FolderName}' created or already exists.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }
            }
            return true;
        }
        public static bool CopyImageToProgramFolder(ref string SourceFileName)
        {
            string FolderName = @"C:\Users\USER\Desktop\DVLD Course19\Project People Images\";
            if (!CreatFolderIfNotExist(FolderName))
                return false;

            string FileName = FolderName + ReplaceFileNameWithGUID(SourceFileName);

            try
            {
                File.Copy(SourceFileName, FileName);
            }
            catch(IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }


    }
}
