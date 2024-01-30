// Written by Lisa Weickenmeier https://github.com/LisaWckn

using IncredibleFit.SQL.Entities;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using System.Data;

namespace IncredibleFit.SQL
{
    public static class SQLTimeline
    {
        /// <summary>
        /// Retrieves a collection of appointments for a specific date and user from the database.
        /// </summary>
        /// <param name="date">The date for which appointments are to be retrieved.</param>
        /// <param name="user">The user for whom appointments are to be retrieved.</param>
        /// <returns>An ObservableCollection of Appointment objects for the specified date and user.</returns>
        public static ObservableCollection<Appointment> getAllAppointmentsByDate(DateTime date, User user)
        {
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>();

            DateTime date2 = new DateTime(date.Year, date.Month, date.Day);

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "APPOINTMENT"
                 JOIN "USER_APPOINTMENT" ON APPOINTMENT.APPOINTMENTID = USER_APPOINTMENT.APPOINTMENTID
                 WHERE APPOINTMENT."DATE" = :PDATE AND USER_APPOINTMENT.EMAIL = '{user.Email}'
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

        /// <summary>
        /// Adds a appointment on a specified date to the database and links it with a user and a recipe.
        /// </summary>
        /// <param name="recipe">The recipe for which the appointment is being added.</param>
        /// <param name="user">The user for whom the appointment is being added.</param>
        /// <param name="date">The date of the appointment.</param>
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

            // Retrieve the generated appointment ID from the output parameter.
            int appointmentID = (int)command.Parameters["PappointmentID"].Value.ToSystemObject(typeof(int), OracleDbType.Int32)!;

            RecipeAppointment rA = new RecipeAppointment(recipe.RecipeID, appointmentID);
            OracleDatabase.InsertObject(rA);

            UserAppointment uA = new UserAppointment(appointmentID, user.Email);
            OracleDatabase.InsertObject(uA);
        }

        /// <summary>
        /// Retrieves the recipe associated with a specific appointment from the database.
        /// </summary>
        /// <param name="appointment">The appointment for which the associated recipe is to be retrieved.</param>
        /// <returns>
        /// If a recipe is found for the specified appointment, returns the associated Recipe object;
        /// otherwise, returns null.
        /// </returns>
        public static Recipe? getRecipeByAppointment(Appointment appointment)
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

        /// <summary>
        /// Retrieves the training unit associated with a specific appointment from the database.
        /// </summary>
        /// <param name="appointment">The appointment for which the associated training unit is to be retrieved.</param>
        /// <returns>
        /// If a training unit is found for the specified appointment, returns the associated TrainingUnit object;
        /// otherwise, returns null.
        /// </returns>
        public static TrainingUnit? getTrainingUnitByAppointment(Appointment appointment)
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

        /// <summary>
        /// Deletes appointments associated with the training units in an old training plan for a specific user.
        /// </summary>
        /// <param name="trainingPlan">The old training plan for which appointments are to be deleted.</param>
        /// <param name="user">The user for whom appointments are to be deleted.</param>
        public static void deleteAppointmentsForOldTrainingPlan(TrainingPlan trainingPlan, User user)
        {
            List<PlanTrainingUnit>? planTrainingUnits = SQLTraining.getPlanTrainingUnitsByTrainingPlan(trainingPlan);

            if(planTrainingUnits == null) { return; }

            for(int i = 0; i < planTrainingUnits.Count; i++)
            {
                TrainingUnit? tU = SQLTraining.getTrainingUnit(planTrainingUnits[i]);

                // Delete the appointments associated with the training unit for the specified user.
                deleteTrainingUnitAppointment(tU, user);
            }
        }

        /// <summary>
        /// Deletes appointments associated with a specific training unit for a given user if there are no associated recipe.
        /// </summary>
        /// <param name="trainingUnit">The training unit for which appointments are to be deleted.</param>
        /// <param name="user">The user for whom appointments are to be deleted.</param>
        public static void deleteTrainingUnitAppointment(TrainingUnit? trainingUnit, User user)
        {
            if(trainingUnit == null) { return; }

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
                    // Create a SQL command to query the database for recipe appointments associated with the current appointment.
                    var command2 = OracleDatabase.CreateCommand(
                        $"""
                         SELECT * FROM "RECIPE_APPOINTMENT"
                         WHERE APPOINTMENTID = {appointment.AppointmentID}
                         """);
                    var reader2 = OracleDatabase.ExecuteQuery(command2);
                    var track2 = reader2.ToObjectList<RecipeAppointment>();
                    if (track2.Any())
                    {
                        // If recipe appointments are found, disassociate the training unit from the appointment.
                        appointment.TrainingUnitID = null;
                        OracleDatabase.UpdateObject(appointment);
                    }
                    else
                    {
                        // If no recipe appointments are found, directly delete the appointment.
                        // The links to the user will be deleted automatically.
                        OracleDatabase.DeleteObject(appointment);
                    }
                }
            }
        }

        /// <summary>
        /// Inserts appointments for the training units in a new training plan for a specific user.
        /// </summary>
        /// <param name="trainingPlan">The new training plan for which appointments are to be inserted.</param>
        /// <param name="user">The user for whom appointments are to be inserted.</param>
        public static void insertAppointmentsForNewTrainingPlan(TrainingPlan trainingPlan, User user)
        {
            List<PlanTrainingUnit>? planTrainingUnits = SQLTraining.getPlanTrainingUnitsByTrainingPlan(trainingPlan);

            if(planTrainingUnits == null) { return; }

            for (int i = 0; i < planTrainingUnits.Count; i++)
            {
                DateTime start = Next(planTrainingUnits[i].Weekday);
                for(int j = 0; j < 10; j++)
                {
                    DateTime current = start.AddDays(7 * j);
                    TrainingUnit? tU = SQLTraining.getTrainingUnit(planTrainingUnits[i]);
                    insertTrainingUnitAppointment(tU, user, current);
                }
            }
        }

        /// <summary>
        /// Inserts an appointment for a specific training unit and date into the database and links it to a user.
        /// </summary>
        /// <param name="trainingUnit">The training unit for which the appointment is being inserted.</param>
        /// <param name="user">The user for whom the appointment is being inserted.</param>
        /// <param name="date">The date of the appointment.</param>
        public static void insertTrainingUnitAppointment(TrainingUnit? trainingUnit, User user, DateTime date)
        {
            if(trainingUnit == null) { return; }

            var command = OracleDatabase.CreateCommand(
                $"""
                 INSERT INTO APPOINTMENT("DATE", STATUS, TRAININGUNITID)
                 VALUES(:PDate, 0, {trainingUnit.TrainingUnitID})
                 RETURNING APPOINTMENTID INTO :PappointmentID
                 """);
            command.Parameters.Add("PDate", OracleDbType.Date).Value = date;
            command.Parameters.Add("PappointmentID", OracleDbType.Int32).Direction = ParameterDirection.Output;

            OracleDatabase.ExecuteNonQuery(command);

            // Retrieve the generated appointment ID from the output parameter.
            int appointmentID = (int)command.Parameters["PappointmentID"].Value.ToSystemObject(typeof(int), OracleDbType.Int32)!;

            UserAppointment uA = new UserAppointment(appointmentID, user.Email);
            OracleDatabase.InsertObject(uA);
        }

        /// <summary>
        /// Calculates the next occurrence of a specific weekday from the current date.
        /// </summary>
        /// <param name="dayOfTheWeek">The weekday for which the next occurrence is to be calculated.</param>
        /// <returns>The DateTime representing the next occurrence of the specified weekday.</returns>
        public static DateTime Next(Weekday dayOfTheWeek)
        {
            DateTime now = DateTime.Now;
            var date = now.Date.AddDays(1);
            var days = ((int)dayOfTheWeek - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(days);
        }
    }
}
