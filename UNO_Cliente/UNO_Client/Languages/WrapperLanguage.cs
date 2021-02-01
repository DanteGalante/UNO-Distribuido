using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace UNO_Client.Languages
{
    public class WrapperLanguage
    {
        private static ObjectDataProvider m_provider;

        public WrapperLanguage()
        {
        }

        //devuelve una instancia nueva de nuestros recursos.
        public Language GetResourceInstance()
        {
            return new Language();
        }

        //Esta propiedad devuelve el ObjectDataProvider en uso.
        public static ObjectDataProvider ResourceProvider
        {
            get
            {
                if (m_provider == null)
                    m_provider = (ObjectDataProvider)App.Current.FindResource("IdiomasRes");
                return m_provider;
            }
        }

        //Este método cambia la cultura aplicada a los recursos y refresca la propiedad ResourceProvider.
        public static void ChangeCulture(CultureInfo culture)
        {
            Properties.Resources.Culture = culture;
            ResourceProvider.Refresh();
        }
    }
}
