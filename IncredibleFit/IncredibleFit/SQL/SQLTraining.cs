// Written by Lisa Weickenmeier https://github.com/LisaWckn

using IncredibleFit.SQL.Entities;
using System.Collections.ObjectModel;

namespace IncredibleFit.SQL
{
    public static class SQLTraining
    {
        /// <summary>
        /// Retrieves all training plans from the database.
        /// </summary>
        /// <returns>An ObservableCollection containing all TrainingPlan objects.</returns>
        public static ObservableCollection<TrainingPlan> getAllTrainingPlans()
        {
            ObservableCollection<TrainingPlan> TrainingPlans = new ObservableCollection<TrainingPlan>();

            var command = OracleDatabase.CreateCommand(
               $"""
                 SELECT * FROM "TRAININGPLAN" 
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<TrainingPlan>();

            if (track.Any())
            {
                for( int i = 0; i < track.Count(); i++)
                {
                    TrainingPlans.Add(track[i]);
                }
            }

            return TrainingPlans;
        }

        /// <summary>
        /// Retrieves the current training plan associated with a specific user from the database.
        /// </summary>
        /// <param name="user">The user for whom the current training plan is to be retrieved.</param>
        /// <returns>
        /// If a current training plan is found for the specified user, returns the associated TrainingPlan object;
        /// otherwise, returns null.
        /// </returns>
        public static TrainingPlan? getCurrentTrainingPlan(User user)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT *
                 FROM "TRAININGPLAN"
                 WHERE "TRAININGPLANID" IN (
                     SELECT "TRAININGPLANID"
                     FROM "USER_PLAN"
                     WHERE "EMAIL" = '{user.Email}'
                 )
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<TrainingPlan>();

            return track.Any() ? track[0] : null;
        }

        /// <summary>
        /// Deletes the current training plan associated with a specific user and the associated appointments from the database.
        /// </summary>
        /// <param name="user">The user for whom the current training plan is to be deleted.</param>
        public static void deleteCurrentTrainingplan(User user)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "TRAININGPLAN" 
                 JOIN "USER_PLAN" 
                 ON USER_PLAN.TRAININGPLANID = TRAININGPLAN.TRAININGPLANID
                 WHERE USER_PLAN.EMAIL = '{user.Email}'
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<TrainingPlan>();

            if (track.Any())
            {
                for(int i = 0; i < track.Count(); i++)
                {
                    UserPlan userPlan = new UserPlan(track[i].TrainingPlanID, user.Email);
                    OracleDatabase.DeleteObject(userPlan);

                    SQLTimeline.deleteAppointmentsForOldTrainingPlan(track[i], user);
                }
            }


        }

        /// <summary>
        /// Sets a new training plan for a specific user, creating the necessary associations and appointments.
        /// </summary>
        /// <param name="trainingPlan">The new training plan to be set for the user.</param>
        /// <param name="user">The user for whom the new training plan is to be set.</param>
        public static void setNewTrainingplan(TrainingPlan trainingPlan, User user)
        {
            UserPlan userPlan = new UserPlan(trainingPlan.TrainingPlanID, user.Email);
            OracleDatabase.InsertObject(userPlan);

            SQLTimeline.insertAppointmentsForNewTrainingPlan(trainingPlan, user);
        }

        /// <summary>
        /// Retrieves a list of plan training units associated with a specific training plan from the database.
        /// </summary>
        /// <param name="trainingPlan">The training plan for which plan training units are to be retrieved.</param>
        /// <returns>
        /// If the training plan is not null, returns a list of PlanTrainingUnit objects associated with the training plan;
        /// otherwise, returns null.
        /// </returns>
        public static List<PlanTrainingUnit>? getPlanTrainingUnitsByTrainingPlan(TrainingPlan trainingPlan)
        {
            if(trainingPlan == null)
            {
                return null;
            }

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "PLANTRAININGUNIT" 
                 WHERE TRAININGPLANID = {trainingPlan.TrainingPlanID}
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<PlanTrainingUnit>();

            return track;
        }

        /// <summary>
        /// Retrieves the training unit associated with a specific plan training unit from the database.
        /// </summary>
        /// <param name="unit">The plan training unit for which the associated training unit is to be retrieved.</param>
        /// <returns>
        /// If the plan training unit is not null, returns the associated TrainingUnit object;
        /// otherwise, returns null.
        /// </returns>
        public static TrainingUnit? getTrainingUnit(PlanTrainingUnit unit)
        {
            if(unit == null)
            {
                return null;
            }

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "TRAININGUNIT" 
                 JOIN "PLAN_UNIT_UNIT"
                 ON TRAININGUNIT.TRAININGUNITID = PLAN_UNIT_UNIT.TRAININGUNITID
                 JOIN "PLANTRAININGUNIT"
                 ON PLANTRAININGUNIT.PLANTRAININGUNITID = PLAN_UNIT_UNIT.PLANTRAININGUNITID
                 WHERE PLANTRAININGUNIT.PLANTRAININGUNITID = {unit.PlanTrainingUnitID}
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<TrainingUnit>();

            return track.Any() ? track[0] : null;
        }

        /// <summary>
        /// Retrieves the count of exercise units associated with a specific training unit from the database.
        /// </summary>
        /// <param name="trainingUnit">The training unit for which the count of associated exercise units is to be retrieved.</param>
        /// <returns>The count of exercise units associated with the training unit. Returns 0 if the training unit is null.</returns>
        public static int getExerciseCount(TrainingUnit trainingUnit)
        {
            if(trainingUnit == null)
            { 
                return 0; 
            }

            ObservableCollection<ExerciseUnit> exercises = getExerciseUnits(trainingUnit);

            return exercises.Count();
        }

        /// <summary>
        /// Retrieves the next scheduled training unit for a specific user from the database.
        /// </summary>
        /// <param name="user">The user for whom the next scheduled training unit is to be retrieved.</param>
        /// <returns>
        /// If there is a next scheduled training unit, returns the associated TrainingUnit object;
        /// otherwise, returns null.
        /// </returns>
        public static TrainingUnit? getNextTrainingUnit(User user)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "APPOINTMENT" 
                 JOIN "USER_APPOINTMENT" ON USER_APPOINTMENT.APPOINTMENTID = APPOINTMENT.APPOINTMENTID                 
                 WHERE APPOINTMENT.TRAININGUNITID IS NOT NULL AND USER_APPOINTMENT.EMAIL = '{user.Email}' AND APPOINTMENT.STATUS = 0
                 ORDER BY APPOINTMENT."DATE"
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Appointment>();

            Appointment? appointment = track.Any() ? track[0] : null;

            if(appointment == null)
            {
                return null;
            }

            var command2 = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "TRAININGUNIT" 
                 WHERE TRAININGUNITID = {appointment.TrainingUnitID}
                 """);

            var reader2 = OracleDatabase.ExecuteQuery(command2);

            var track2 = reader2.ToObjectList<TrainingUnit>();

            return track2.Any() ? track2[0] : null;
        }

        /// <summary>
        /// Marks a specific training unit as done for a specific user by updating the status of associated appointments in the database.
        /// </summary>
        /// <param name="unit">The training unit to be marked as done.</param>
        /// <param name="user">The user for whom the training unit is to be marked as done.</param>
        public static void setTrainingUnitDone(TrainingUnit? unit, User user)
        {
            if(unit == null) { return; }

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "APPOINTMENT" 
                 JOIN "USER_APPOINTMENT" ON APPOINTMENT.APPOINTMENTID = USER_APPOINTMENT.APPOINTMENTID
                 WHERE APPOINTMENT.TRAININGUNITID = {unit.TrainingUnitID} AND USER_APPOINTMENT.EMAIL = '{user.Email}'
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Appointment>();

            Appointment? appointment = track.Any() ? track[0] : null;

            if(appointment == null) { return;}

            appointment.Status = AppointmentStatus.Closed;

            OracleDatabase.UpdateObject(appointment);
        }

        /// <summary>
        /// Retrieves a collection of exercise units associated with a specific training unit from the database.
        /// </summary>
        /// <param name="trainingUnit">The training unit for which exercise units are to be retrieved.</param>
        /// <returns>
        /// If the training unit is not null, returns an ObservableCollection of ExerciseUnit objects associated with the training unit;
        /// otherwise, returns an empty ObservableCollection.
        /// </returns>
        public static ObservableCollection<ExerciseUnit> getExerciseUnits(TrainingUnit trainingUnit)
        {
            if(trainingUnit == null)
            {
                return new ObservableCollection<ExerciseUnit>();
            }
            ObservableCollection<ExerciseUnit> exerciseUnits = new ObservableCollection<ExerciseUnit>();

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "EXERCISEUNIT" 
                 JOIN "TRAINING_UNIT_UNIT" 
                 ON TRAINING_UNIT_UNIT.EXERCISEUNITID = EXERCISEUNIT.EXERCISEUNITID
                 JOIN "TRAININGUNIT"
                 ON TRAINING_UNIT_UNIT.TRAININGUNITID = TRAININGUNIT.TRAININGUNITID
                 WHERE TRAININGUNIT.TRAININGUNITID = {trainingUnit.TrainingUnitID}
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<ExerciseUnit>();

            if (track.Any())
            {
                for(int i = 0; i < track.Count(); i++)
                {
                    exerciseUnits.Add(track[i]);
                }
            }

            return exerciseUnits;
        }

        /// <summary>
        /// Retrieves the exercise associated with a specific exercise unit from the database.
        /// </summary>
        /// <param name="exerciseUnit">The exercise unit for which the associated exercise is to be retrieved.</param>
        /// <returns>
        /// If there is an associated exercise, returns the associated Exercise object;
        /// otherwise, returns null.
        /// </returns>
        public static Exercise? getExerciseByExerciseUnit(ExerciseUnit exerciseUnit)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "EXERCISE"
                 WHERE EXERCISEID = {exerciseUnit.ExerciseID}
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Exercise>();

            return track.Any() ? track[0] : null;
        }
    }
}
