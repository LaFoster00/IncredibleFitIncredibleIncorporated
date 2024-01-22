// Written by Lasse Foster https://github.com/LaFoster00 and Lisa Weikenmeier

using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("SPORT")]
    internal class Sport : BindableObject
    {
        [ID, Field("SPORTNAME", OracleDbType.Varchar2, 128)]
        public string Sportname
        {
            get => (string)GetValue(SportnameProperty);
            set => SetValue(SportnameProperty, value);
        }

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public static readonly BindableProperty SportnameProperty =
            BindableProperty.Create(
                nameof(Sportname), 
                typeof(string), 
                typeof(Sport), 
                string.Empty);

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(
                nameof(Description), 
                typeof(string), 
                typeof(Sport), 
                string.Empty);

        private Sport() { }

        public Sport(string name, string description)
        {
            this.Sportname = name;
            this.Description = description;
        }
    }
}
