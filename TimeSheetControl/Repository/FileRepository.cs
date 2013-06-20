using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TimeSheetControl.Repository
{
    class FileRepository
    {
         private static FileRepository instance = null; 
        // Pour éviter, lors de l’utilisation de multiple thread, que plusieurs singleton soit instanciés.
        private static readonly object myLock = new object();

       
        // Le constructeur d’un singleton est TOUJOURS privée. 
        private FileRepository() {
        }

        // La méthode qui va nous permettre de récupérer l’unique instance de notre singleton.
        // La méthode doit être statique pour être appelé depuis le nom de la classe maClasse.getInstance();
        public static FileRepository getInstance() 
        { 
            //lock permet de s’assurer qu’un thread n’entre pas dans une section critique du code pendant qu’un autre thread s’y trouve.  
            //Si un autre thread tente d’entrer dans un code verrouillé, il attendra, bloquera, jusqu’à ce que l’objet soit libéré.
            lock (myLock) 
            { 
                // Si on demande une instance qui n’existe pas, alors on crée notre RessourceManager.
                if (instance == null) instance = new FileRepository();
                // Dans tous les cas on retourne l’unique instance de notre RessourceManager.
                return instance; 
            } 
        }

        public String appData { get; set; }

        public void initialiseApp()
        {
            this.appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ @"\TimeSheetControl\";
           
            if (!Directory.Exists(this.appData))
            {
                Directory.CreateDirectory(this.appData);
            }
        }
    }
}
