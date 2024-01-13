using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncredibleFit.Models;
using IncredibleFit.SQL.Entities;

namespace IncredibleFit.SQL
{
    public static class SQLTraining
    {
        public static TrainingPlan getCurrentTrainingPlan()
        {
            //Get selected plan by user
            return getDummyTrainingPlan();
        }

        public static TrainingUnit getNextTrainingUnit()
        {
            //Get next Exercise for the currentUser from Database

            return getDummyTrainingUnit();
        }

        public static void setTrainingUnitDone(TrainingUnit unit)
        {
            //Set Appointment with unit done in database
        }

        private static TrainingUnit getDummyTrainingUnit()
        {
            TrainingUnit tU = new TrainingUnit("Legs", "Training für die Beine", "Schwer");
            Exercise e1 = new Exercise("Squats", "Stehe mit den Füßen schulterbreit auseinander, die Zehen zeigen leicht nach außen. Senke deinen Körper, indem du die Hüften nach hinten bewegst, als ob du dich setzen würdest. Achte darauf, dass die Knie nicht über die Zehen hinausragen. Drücke dich dann durch die Fersen nach oben, um in die Ausgangsposition zurückzukehren.", 2.5);
            Exercise e2 = new Exercise("Lunges", "Stehe aufrecht und mache mit einem Fuß einen großen Schritt nach vorne, so dass sich dein vorderes Knie über dem Fuß befindet. Senke deinen Körper, bis dein vorderes Bein einen 90-Grad-Winkel bildet, während dein hinteres Knie fast den Boden berührt. Kehre dann in die Ausgangsposition zurück und wiederhole mit dem anderen Bein.", 2.5);
            Exercise e3 = new Exercise("Leg Curls", "Lege dich auf den Bauch auf eine Bein-Curl-Maschine oder benutze ein Bein-Curl-Gerät. Beuge die Beine, indem du die Fersen zum Gesäß ziehst und halte kurz die Spannung. Senke die Beine dann langsam wieder ab.", 2.5);
            Exercise e4 = new Exercise("Calf Raises", "Stehe gerade und hebe die Fersen, indem du dich auf die Zehenspitzen stellst. Halte kurz die Spannung und senke die Fersen dann langsam wieder ab.", 2);
            Exercise e5 = new Exercise("Leg Press", "Setze dich in die Beinpresse und platziere die Füße auf der Plattform schulterbreit. Drücke die Plattform, indem du deine Knie beugst und dann langsam die Beine wieder streckst.", 2.5);
            tU.exercises.Add(e1);
            tU.exercises.Add(e2);
            tU.exercises.Add(e3);
            tU.exercises.Add(e4);
            tU.exercises.Add(e5);

            return tU;
        }

        private static TrainingPlan getDummyTrainingPlan()
        {
            TrainingPlan tP = new TrainingPlan("Dummy", "Hilfstrainingsplan zum testen. Wird später wieder gelöscht.", "Schwierig");

            tP.trainingUnits[0] = new TrainingPlanUnit("Montag", getDummyTrainingUnit());
            tP.trainingUnits[1] = new TrainingPlanUnit("Dienstag", null);
            tP.trainingUnits[2] = new TrainingPlanUnit("Mittwoch", getDummyTrainingUnit());
            tP.trainingUnits[3] = new TrainingPlanUnit("Donnerstag", null);
            tP.trainingUnits[4] = new TrainingPlanUnit("Freitag", getDummyTrainingUnit());
            tP.trainingUnits[5] = new TrainingPlanUnit("Samstag", null);
            tP.trainingUnits[6] = new TrainingPlanUnit("Sonntag", null);

            return tP;
        }
    }
}
