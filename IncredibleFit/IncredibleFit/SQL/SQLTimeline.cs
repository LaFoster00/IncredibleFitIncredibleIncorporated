using IncredibleFit.SQL.Entities;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using System.Data;

namespace IncredibleFit.SQL
{
    public static class SQLTimeline
    {
        public static ObservableCollection<Appointment> getAllAppointmentsByDate(DateTime date)
        {
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>();
            DateTime date2 = new DateTime(date.Year, date.Month, date.Day);

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "APPOINTMENT"
                 WHERE "DATE" = :PDATE
                 """);
            command.Parameters.Add(new OracleParameter("PDATE", OracleDbType.Date)).Value = date2;

            var reader = OracleDatabase.ExecuteQuery(command);
            var track = reader.ToObjectList<Appointment>();

            if(track.Any())
            {
                for(int i=0; i<track.Count(); i++)
                {
                    appointments.Add(track[i]);
                }
            }

            return appointments;
        }

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

        public static Recipe getRecipeByAppointment(Appointment appointment)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "RECIPE"
                 JOIN "RECIPE_APPOINTMENT" ON RECIPE.RECIPEID = RECIPE_APPOINTMENT.RECIPEID
                 WHERE RECIPE_APPOINTMENT.APPOINTMENTID = {appointment.AppointmentID}
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);
            var track = reader.ToObjectList<Recipe>();

            return track.Any() ? track[0] : null;
        }

        public static TrainingUnit getTrainingUnitByAppointment(Appointment appointment)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "TRAININGUNIT"
                 WHERE TRAININGUNITID = {appointment.TrainingUnitID}
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);
            var track = reader.ToObjectList<TrainingUnit>();

            return track.Any() ? track[0] : null;
        }

        public static void deleteAppointmentsForOldTrainingPlan(TrainingPlan trainingPlan, User user)
        {
            List<PlanTrainingUnit> planTrainingUnits = SQLTraining.getPlanTrainingUnitsByTrainingPlan(trainingPlan);

            for(int i = 0; i < planTrainingUnits.Count; i++)
            {
                TrainingUnit tU = SQLTraining.getTrainingUnit(planTrainingUnits[i]);
                deleteTrainingUnitAppointment(tU, user);
            }
        }

        public static void deleteTrainingUnitAppointment(TrainingUnit trainingUnit, User user)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "APPOINTMENT"
                 JOIN "USER_APPOINTMENT" ON APPOINTMENT.APPOINTMENTID = USER_APPOINTMENT.APPOINTMENTID
                 WHERE USER_APPOINTMENT.EMAIL = '{user.Email}' AND APPOINTMENT.TRAININGUNITID = {trainingUnit.TrainingUnitID}
                 """);
            var reader = OracleDatabase.ExecuteQuery(command);
            var track = reader.ToObjectList<Appointment>();
            if (track.Any())
            {
                foreach (Appointment appointment in track)
                {
                    var command3 = OracleDatabase.CreateCommand(
                        $"""
                         SELECT * FROM "RECIPE_APPOINTMENT"
                         WHERE APPOINTMENTID = {appointment.AppointmentID}
                         """);
                    var reader3 = OracleDatabase.ExecuteQuery(command3);
                    var track3 = reader3.ToObjectList<RecipeAppointment>();
                    if (track3.Any())
                    {
                        appointment.TrainingUnitID = null;
                        OracleDatabase.UpdateObject(appointment);
                    }
                    else
                    {
                        //User_Appointment deletet automatically?
                        OracleDatabase.DeleteObject(appointment);
                    }
                }
            }
        }

        public static void insertAppointmentsForNewTrainingPlan(TrainingPlan trainingPlan, User user)
        {
            List<PlanTrainingUnit> planTrainingUnits = SQLTraining.getPlanTrainingUnitsByTrainingPlan(trainingPlan);

            for (int i = 0; i < planTrainingUnits.Count; i++)
            {
                DateTime start = Next(planTrainingUnits[i].Weekday);
                for(int j = 0; j < 10; j++)
                {
                    DateTime current = start.AddDays(7 * j);
                    TrainingUnit tU = SQLTraining.getTrainingUnit(planTrainingUnits[i]);
                    insertTrainingUnitAppointment(tU, user, current);
                }
            }
        }

        public static void insertTrainingUnitAppointment(TrainingUnit trainingUnit, User user, DateTime date)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 INSERT INTO APPOINTMENT("DATE", STATUS, TRAININGUNITID)
                 VALUES(:PDate, 0, {trainingUnit.TrainingUnitID})
                 RETURNING APPOINTMENTID INTO :PappointmentID
                 """);
            command.Parameters.Add("PDate", OracleDbType.Date).Value = date;
            command.Parameters.Add("PappointmentID", OracleDbType.Int32).Direction = ParameterDirection.Output;

            OracleDatabase.ExecuteNonQuery(command);

            int appointmentID = (int)command.Parameters["PappointmentID"].Value.ToSystemObject(OracleDbType.Int32, typeof(int))!;

            UserAppointment uA = new UserAppointment(appointmentID, user.Email);
            OracleDatabase.InsertObject(uA);
        }

        public static DateTime Next(Weekday dayOfTheWeek)
        {
            DateTime now = DateTime.Now;
            var date = now.Date.AddDays(1);
            var days = ((int)dayOfTheWeek - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(days);
        }
    }
}
