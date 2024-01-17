import employee_generator
import ingredient_generator
import manages_sport_generator
import recipe_generator
import recipecategory_generator
import track_generator
import user_generator
import user_saved_recipes

print("DELETE FROM FITNESSLEVEL;")
print("DELETE FROM SPORT;")
print("DELETE FROM EXERCISE;")
print("DELETE FROM EXERCISEUNIT;")
print("DELETE FROM TRAINING_UNIT_UNIT;")
print("DELETE FROM TRAININGUNIT;")
print("DELETE FROM PLAN_UNIT_UNIT;")
print("DELETE FROM PLANTRAININGUNIT;")
print("DELETE FROM TRAININGPLAN;")
print("DELETE FROM APPOINTMENT;")
print("DELETE FROM RECIPE_APPOINTMENT;")
print("DELETE FROM USER_APPOINTMENT;")
print("DELETE FROM USER_PLAN;")

print('''
INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Impairment');
INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Absolute beginner');
INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Beginner');
INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Advanced');
INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Fit');
INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Professional');
''')
user_generator.generateUsers()
employee_generator.generateEmployees()
track_generator.generateTracks()

# Ingredients and recipes
ingredient_generator.generateIngredients()
recipecategory_generator.generateRecipeCategories()
recipe_generator.generateRecipes()
user_saved_recipes.generateUserSavedRecipes()

# Sport
print('''
INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('Strength training', 'Builds muscle strength using resistance, like weights.');
INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('Bodyweight training', 'Relies on the body''s weight for exercises, e.g., push-ups.');
INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('Core training', 'Targets core muscles for stability and strength.');
INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('General fitness', 'Overall health improvement with varied exercises.');
INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('Yoga', 'Combines postures, breath control, and meditation.');
INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('Cardiovascular training', 'Boosts heart health through activities like running.');
''')
manages_sport_generator.generateManagesSport()
print('''
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('General fitness', 'jumping jack', 'A jumping exercise with simultaneous arm and leg spreading and closing. Effective for cardiovascular training.', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'pull up', 'An upper-body strength exercise involving lifting the body using the arms, targeting the upper back and arms.', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Bodyweight training', 'push up', 'A bodyweight exercise where the body is lifted and lowered by arm extension, primarily targeting the chest, shoulders, and triceps.', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'kick back', 'Exercise for the glutes, extending one leg backward.', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Yoga', 'Downward dog', 'A yoga position where the body forms an inverted \"V\", stretching the back and leg muscles.', 1);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Yoga', 'upward dog', 'A yoga position where the upper body is lifted off the ground, stretching the chest and abdominal muscles.', 1);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'military press', 'Standing shoulder press, lifting a barbell or dumbbells overhead. Focuses on the shoulder muscles.', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Bodyweight training', 'plank', 'Holding a position similar to a push-up to strengthen the core muscles.', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Bodyweight training', 'burpee', 'A full-body exercise combining a squat, push-up, and jump. Intensive for overall conditioning.', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Bodyweight training', 'crunches', 'Abdominal exercise involving lifting the upper body towards the knees.', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Yoga', 'childs pose', 'Relaxing yoga position where one sits on the heels and bends the upper body forward.', 1);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Core training', 'pelvic curl', 'Lying on the back, lifting and lowering the pelvis to strengthen the glutes and lower back.', 1);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'chest lift', 'Lying on the back, lifting the upper body to activate the upper abdominal muscles.', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'chest lift with rotation', 'Similar to the Chest Lift but includes rotation of the upper body, targeting the oblique abdominal muscles.', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Core training', 'single leg stretch', 'Pilates exercise involving alternating leg lifts to target the abdominal muscles.', 1);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Cardiovascular training', 'Running in the Park', 'Jogging for endurance', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Yoga', 'Vinyasa Yoga', 'Dynamic yoga', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'Bench Press', 'Upper body strength training', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('General fitness', 'Sprint Training', 'Intensive sprinting for the legs', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Yoga', 'Hatha Yoga', 'Slow yoga poses for balance and relaxation', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'Squats', 'Leg training with squats', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Bodyweight training', 'Interval Training', 'Alternating between sprinting and walking', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Yoga', 'Ashtanga Yoga', 'Dynamic yoga style for strength and flexibility', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'Deadlifts', 'Back and leg training with deadlifts', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Cardiovascular training', 'Stair Climbing', 'Cardio training through stair climbing', 1);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Yoga', 'Yin Yoga', 'Long-held yoga poses for deep stretching', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'Lunges', 'Leg training with lunges', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Bodyweight training', 'Obstacle Course', 'Running over obstacles for endurance and strength', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Yoga', 'Power Yoga', 'Dynamic yoga for strength and energy', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'Lat Pulldown', 'Back training with lat pulldowns', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Cardiovascular training', 'Cycling', 'Cardio training with the bicycle', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Yoga', 'Kundalini Yoga', 'Spiritual yoga for consciousness expansion', 1);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'Triceps Dips', 'Arm strength training with triceps dips', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Cardiovascular training', 'Swimming', 'Cardio training in the water', 1);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Yoga', 'Restorative Yoga', 'Gentle yoga for regeneration', 1);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'Lateral Raises', 'Shoulder training with lateral raises', 2);
''')

# Training plans
print('''
INSERT INTO TRAININGPLAN (EMPLOYEEID, SPORTNAME, NAME, DESCRIPTION, TRAININGPLANDIFFICULTY) VALUES (1, 'Cardiovascular training', 'Running Plan', 'Plan for regular running', 1);
INSERT INTO TRAININGPLAN (EMPLOYEEID, SPORTNAME, NAME, DESCRIPTION, TRAININGPLANDIFFICULTY) VALUES (1, 'Yoga', 'Yoga Relaxation', 'Yoga for stress relief and flexibility', 0);
INSERT INTO TRAININGPLAN (EMPLOYEEID, SPORTNAME, NAME, DESCRIPTION, TRAININGPLANDIFFICULTY) VALUES (1, 'Strength training', 'Strength Training', 'Plan for muscle building and strength', 2);
''')

# PlanTrainingUnit
print('''
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (1, 'Running training in the Park', 1);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (1, 'Sprint intervals', 3);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (1, 'Stair climbing', 5);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (2, 'Yoga for relaxation', 2);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (2, 'Ashtanga Yoga for strength', 4);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (2, 'Yin Yoga for flexibility', 6);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (3, 'Strength training at the gym', 1);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (3, 'Back and leg training', 3);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (3, 'Arm training and Cardio', 5);      
''')

# Trainingunit
print('''
INSERT INTO TRAININGUNIT (NAME, DESCRIPTION, TRAININGUNITDIFFICULTY) VALUES ('Running in the Park', 'Jogging for endurance', 1);
INSERT INTO TRAININGUNIT (NAME, DESCRIPTION, TRAININGUNITDIFFICULTY) VALUES ('Vinyasa Yoga', 'Dynamic yoga', 0);
INSERT INTO TRAININGUNIT (NAME, DESCRIPTION, TRAININGUNITDIFFICULTY) VALUES ('Bench Press', 'Upper body strength training', 2);
''')

# Plan Unit Unit
print('''
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (1, 1, 1);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (1, 2, 4);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (1, 3, 10);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (2, 4, 2);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (2, 5, 8);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (2, 6, 11);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (3, 7, 3);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (3, 8, 15);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (3, 9, 18);  
''')

# Exerciseunit
print('''
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (1, 'Slow jogging for 30 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (2, 'Vinyasa Flow for 60 minutes', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (3, 'Bench Press with 3 sets of 12 repetitions', 2, 12);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (4, 'Sprints and walking alternation for 20 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (5, 'Yoga poses for balance and relaxation', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (6, 'Squats with weights for 3 sets of 15 repetitions', 2, 15);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (7, 'Intervals of sprinting and walking for 15 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (8, 'Dynamic Ashtanga Yoga style for 75 minutes', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (9, 'Heavy Deadlifts with 3 sets of 10 repetitions', 2, 10);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (10, 'Stair climbing for 20 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (11, 'Yin Yoga for deep stretching', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (12, 'Lunges for leg training', 2, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (13, 'Obstacle course for 30 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (14, 'Dynamic Power Yoga for energy and strength', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (15, 'Lat Pulldown for back training', 2, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (16, 'Outdoor cycling for 45 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (17, 'Kundalini Yoga for consciousness expansion', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (18, 'Triceps Dips for arm strength', 2, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (19, 'Swimming in the pool for 30 minutes', 1, 0);
''')

# Training_Unit_Unit
print('''
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (1, 1);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (2, 2);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (3, 3);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (4, 1);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (5, 2);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (6, 3);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (7, 1);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (8, 2);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (9, 3);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (10, 1);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (11, 2);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (12, 3);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (13, 1);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (14, 2);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (15, 3);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (16, 1);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (17, 2);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (18, 3);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (19, 1);
INSERT INTO TRAINING_UNIT_UNIT (EXERCISEUNITID, TRAININGUNITID) VALUES (20, 2);
''')

# Appointments
print('''
INSERT INTO APPOINTMENT (TRAININGUNITID, "DATE", STATUS) 
VALUES (NULL, TO_DATE('2024-01-14', 'YYYY-MM-DD'), 0);
INSERT INTO APPOINTMENT (TRAININGUNITID, "DATE", STATUS) 
VALUES (1, TO_DATE('2024-01-17', 'YYYY-MM-DD'), 0);
INSERT INTO APPOINTMENT (TRAININGUNITID, "DATE", STATUS) 
VALUES (1, TO_DATE('2024-01-21', 'YYYY-MM-DD'), 0 );
INSERT INTO APPOINTMENT (TRAININGUNITID, "DATE", STATUS) 
VALUES (NULL, TO_DATE('2024-01-26', 'YYYY-MM-DD'), 0);
''')

# Recipe Appointment
print('''
INSERT INTO RECIPE_APPOINTMENT (RECIPEID, APPOINTMENTID) 
VALUES (3, 4);
INSERT INTO RECIPE_APPOINTMENT (RECIPEID, APPOINTMENTID) 
VALUES (1, 1);
''')

# User Appointment
print('''
INSERT INTO USER_APPOINTMENT (APPOINTMENTID, EMAIL) 
VALUES (1, 'samuel.hardy@gmail.com'); 
INSERT INTO USER_APPOINTMENT (APPOINTMENTID, EMAIL) 
VALUES (2, 'samuel.hardy@gmail.com'); 
INSERT INTO USER_APPOINTMENT (APPOINTMENTID, EMAIL) 
VALUES (3, 'samuel.hardy@gmail.com'); 
INSERT INTO USER_APPOINTMENT (APPOINTMENTID, EMAIL) 
VALUES (4, 'samuel.hardy@gmail.com'); 
''')

# User Plan
print('''
INSERT INTO USER_PLAN (TRAININGPLANID, EMAIL) 
VALUES (1, 'samuel.hardy@gmail.com');
''')

print("COMMIT;")