using System;
    using System.IO;
namespace CRMOntology.RDFLayer
{

    /// <summary>
    /// This class provides a common place for all of the sample applications to initialize the
    /// BrightstarDB . Once you have updated this file for one sample to build and run correctly, 
    /// all the others should also then build and run without any further changes required.
    /// </summary>
    static class Configuration
    {
        /// <summary>
        /// OPTIONAL: If you would like to store their data in a different folder, replace
        /// the value of this property with the path to use (the directory will be created if it does not exist)
        /// </summary>
        public static string StoresDirectory = Path.Combine(@"C:\D\Private\Master\Graduate Thesis\BrightstarDB\", "CRM");

        public static void Register()
        {
            // Ensure that the directory we want to use for storing samples data exists.
            // If it does not, create it.
            var dir = new DirectoryInfo(StoresDirectory);
            if (!dir.Exists)
            {
                dir.Create();
            }
        }
    }

}
