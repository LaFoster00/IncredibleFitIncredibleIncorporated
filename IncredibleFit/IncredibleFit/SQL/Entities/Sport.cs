using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("SPORT")]
    internal class Sport
    {
        [ID, Field("SPORTID", OracleDbType.Int32)]
        public int SportID { get; private set; } = -1;

        [Field("NAME", OracleDbType.Varchar2, 128)]
        public string Name { get; set; } = string.Empty;

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description { get; set; } = string.Empty;

        private Sport() { }

        public Sport(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
