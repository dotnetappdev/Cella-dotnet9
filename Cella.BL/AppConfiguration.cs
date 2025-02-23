using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cella.BL.Helpers {
    public class AppConfiguration {
        private static AppConfiguration _instance;
        private static readonly object ObjLocked = new object();


        public string FTPHost { get; set; }

        public string FTPUserName { get; set; }

        public string FTPPassword { get; set; }

        public string PortNumber { get; set; }

        public string FileUploadPath { get; set; }
        public static AppConfiguration Instance {
            get {
                if (null == _instance) {
                    lock (ObjLocked) {
                        if (null == _instance)
                            _instance = new AppConfiguration();
                    }
                }
                return _instance;
            }
        }



    }
}
