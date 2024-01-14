using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("SPORT")]
    internal class Sport : BindableObject
    {
        [ID, Field("SPORTID", OracleDbType.Int32), AutoIncrement]
        public int SportID
        {
            get => (int)GetValue(SportIDProperty);
            private set => SetValue(SportIDProperty, value);
        }

        [Field("NAME", OracleDbType.Varchar2, 128)]
        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public static readonly BindableProperty SportIDProperty =
            BindableProperty.Create(
                nameof(SportID), 
                typeof(int), 
                typeof(Sport), 
                -1);

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(
                nameof(Name), 
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
            this.Name = name;
            this.Description = description;
        }
    }
}
