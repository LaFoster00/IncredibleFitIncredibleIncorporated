using IncredibleFit.SQL.Entities;
using System.Collections.ObjectModel;

namespace IncredibleFit.SQL
{
    public static class SQLTraining
    {
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

        public static ObservableCollection<PlanTrainingUnit> getTrainingUnitsByTrainingPlan(TrainingPlan trainingPlan)
        {
            if(trainingPlan == null)
            {
                return null;
            }

            ObservableCollection<PlanTrainingUnit> planTrainingUnits = new ObservableCollection<PlanTrainingUnit>(); ;

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "PLANTRAININGUNIT" 
                 WHERE TRAININGPLANID = {trainingPlan.TrainingPlanID}
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<PlanTrainingUnit>();
            if(track.Any())
            {
                for(int i = 0; i < track.Count(); i++)
                {
                    planTrainingUnits.Add(track[i]);
                }
            }

            return planTrainingUnits;
        }

        public static TrainingUnit getNextTrainingUnit()
        {
            //Get next Exercise for the currentUser from Database
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "APPOINTMENT" 
                 WHERE TRAININGUNITID IS NOT NULL
                 ORDER BY "DATE"
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
            ObservableCollection<ExerciseUnit> exerciseUnits = new ObservableCollection<ExerciseUnit>();

            //TODO get exercises from DB
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "EXERCISEUNIT" 
                 JOIN "TRAINING_UNIT_UNIT" 
                 ON TRAINING_UNIT_UNIT.EXERCISEID = EXERCISEUNIT.EXERCISEID
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
    }
}
