using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDVLD.Global
{
    public class clsLoginInfo
    {
        
            public static string CurrentUsername { get; set; }
            public static string CurrentPassword { get; set; }
            public static bool IsLoggedIn { get; set; }

            public static void ClearSession()
            {
                CurrentUsername = string.Empty;
                CurrentPassword = string.Empty;
                IsLoggedIn = false;
            }

        private static string currentDirectory = System.IO.Directory.GetCurrentDirectory();

        private static string CredentialsPath = currentDirectory + "\\data.txt";

        public static void SaveCredentials(string username, string password)
        {
            // Create directory if it doesn't exist
            string directory = Path.GetDirectoryName(CredentialsPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Write credentials to text file
            using (StreamWriter writer = new StreamWriter(CredentialsPath, false))
            {
                writer.WriteLine(username);
                writer.WriteLine(password);
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }

        public static (string Username, string Password) LoadCredentials()
        {
            if (!File.Exists(CredentialsPath))
                return (null, null);

            try
            {
                string[] lines = File.ReadAllLines(CredentialsPath);

                // Check if we have at least username and password
                if (lines.Length >= 2)
                {
                    string username = lines[0];
                    string password = lines[1];
                    // lines[2] would be the timestamp if needed

                    return (username, password);
                }
            }
            catch (Exception ex)
            {
                // Handle file read errors
                MessageBox.Show($"Error loading credentials: {ex.Message}");
            }

            return (null, null);
        }

        public static void ClearCredentials()
        {
            if (File.Exists(CredentialsPath))
            {
                File.Delete(CredentialsPath);
            }
        }
    }
}
