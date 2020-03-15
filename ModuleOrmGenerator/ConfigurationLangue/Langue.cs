using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleOrmGenerator.ConfigurationLangue
{
    public class Langue
    {

        public string Authentification_CheckBox_Enable { get; set; }
        public string Authentification_CheckBox_Disable { get; set; }
        public string Authentification_BDD_NOK { get; set; }
        public string Authentification_BDD_OK { get; set; }
        public string ComboBox_Table_Empty { get; set; }

        public Langue()
        {
            LoadConfigurationLanguage();
        }

        public void LoadConfigurationLanguage()
        {
            try
            {
                Authentification_CheckBox_Disable = LangueRessources.Authentification_CheckBox_Disable;
                Authentification_CheckBox_Enable = LangueRessources.Authentification_CheckBox_Enable;
                Authentification_BDD_NOK = LangueRessources.Authentification_BDD_NOK;
                Authentification_BDD_OK = LangueRessources.Authentification_BDD_OK;
                ComboBox_Table_Empty = LangueRessources.ComboBox_Table_Empty;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
