using IncredibleFit.SQL.Entities;
using System.Collections;
using System.Collections.ObjectModel;

namespace IncredibleFit.SQL
{
    public static class SQLTraining
    {
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
        public static TrainingPlan getCurrentTrainingPlan(User user)
        {
            //Get selected plan by user

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "TRAININGPLAN" 
                 JOIN "USER_PLAN" 
                 ON USER_PLAN.TRAININGPLANID = TRAININGPLAN.TRAININGPLANID
                 WHERE USER_PLAN.EMAIL = '{user.Email}'
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<TrainingPlan>();

            return track.Any() ? track[0] : null;
        }

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

        public static void setNewTrainingplan(TrainingPlan trainingPlan, User user)
        {
            UserPlan userPlan = new UserPlan(trainingPlan.TrainingPlanID, user.Email);
            OracleDatabase.InsertObject(userPlan);

            SQLTimeline.insertAppointmentsForNewTrainingPlan(trainingPlan, user);
        }

        public static List<PlanTrainingUnit> getPlanTrainingUnitsByTrainingPlan(TrainingPlan trainingPlan)
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

        public static TrainingUnit getTrainingUnit(PlanTrainingUnit unit)
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

        public static int getExerciseCount(TrainingUnit trainingUnit)
        {
            if(trainingUnit == null)
            { 
                return 0; 
            }

            ObservableCollection<ExerciseUnit> exercises = SQLTraining.getExerciseUnits(trainingUnit);

            return exercises.Count();
        }

        public static TrainingUnit getNextTrainingUnit(User user)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "APPOINTMENT" 
                 JOIN "USER_APPOINTMENT" ON USER_APPOINTMENT.APPOINTMENTID = APPOINTMENT.APPOINTMENTID                 
                 WHERE APPOINTMENT.TRAININGUNITID IS NOT NULL AND USER_APPOINTMENT.EMAIL = '{user.Email}'
                 ORDER BY APPOINTMENT."DATE"
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Appointment>();

            Appointment appointment = track.Any() ? track[0] : null;

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

        public static void setTrainingUnitDone(TrainingUnit unit)
        {
            //Set Appointment with unit done in database
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "APPOINTMENT" 
                 WHERE TRAININGUNITID = {unit.TrainingUnitID}
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Appointment>();

            Appointment appointment = track.Any() ? track[0] : null;

            if(appointment == null) { return;}

            appointment.Status = AppointmentStatus.Closed;

            OracleDatabase.UpdateObject(appointment);
        }

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

        public static Exercise getExerciseByExerciseUnit(ExerciseUnit exerciseUnit)
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
