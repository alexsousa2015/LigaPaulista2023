using System;

namespace LigaPaulista.Core.SDK.DAO.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CustomAttributesParameter : System.Attribute
    {
        private bool _ExcluirParametro = false;

        public bool ExcluirParametro
        {
            get { return _ExcluirParametro; }
            set { _ExcluirParametro = value; }
        }

        public CustomAttributesParameter()
        {}
    }
}
