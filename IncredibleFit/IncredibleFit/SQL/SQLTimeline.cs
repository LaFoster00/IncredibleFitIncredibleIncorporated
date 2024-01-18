using IncredibleFit.SQL.Entities;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace IncredibleFit.SQL
{
    public static class SQLTimeline
    {
        public static void addRecipeAppointment(Recipe recipe, User user, DateTime date)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 INSERT INTO APPOINTMENT("DATE", STATUS)
                 VALUES(:PDate, 0)
                 RETURNING APPOINTMENTID INTO :PappointmentID
                 """);
            command.Parameters.Add("PDate", OracleDbType.Date).Value = date;
            command.Parameters.Add("PappointmentID", OracleDbType.Int32).Direction = ParameterDirection.Output;

            OracleDatabase.ExecuteNonQuery(command);

            int appointmentID = (int)command.Parameters["PappointmentID"].Value.ToSystemObject(OracleDbType.Int32, typeof(int))!;

            RecipeAppointment rA = new RecipeAppointment(recipe.RecipeID, appointmentID);
            OracleDatabase.InsertObject(rA);

            UserAppointment uA = new UserAppointment(appointmentID, user.Email);
            OracleDatabase.InsertObject(uA);
        }
    }
}
