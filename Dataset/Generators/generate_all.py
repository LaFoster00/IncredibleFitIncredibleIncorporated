import employee_generator
import ingredient_generator
import manages_sport_generator
import recipe_generator
import recipecategory_generator
import track_generator
import user_generator
import user_saved_recipes

print('''
-- Fitnesslevel:
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
-- Sport:
INSERT INTO SPORT (NAME, DESCRIPTION) VALUES ('Strength training', 'Builds muscle strength using resistance, like weights.');
INSERT INTO SPORT (NAME, DESCRIPTION) VALUES ('Bodyweight training', 'Relies on the body's weight for exercises, e.g., push-ups.');
INSERT INTO SPORT (NAME, DESCRIPTION) VALUES ('Core training', 'Targets core muscles for stability and strength.');
INSERT INTO SPORT (NAME, DESCRIPTION) VALUES ('General fitness', 'Overall health improvement with varied exercises.');
INSERT INTO SPORT (NAME, DESCRIPTION) VALUES ('Yoga', 'Combines postures, breath control, and meditation.');
INSERT INTO SPORT (NAME, DESCRIPTION) VALUES ('Cardiovascular training', 'Boosts heart health through activities like running.');
''')
manages_sport_generator.generateManagesSport()
print('''
-- Exercise:
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (5, 'jumping jack', 'A jumping exercise with simultaneous arm and leg spreading and closing. Effective for cardiovascular training.', '0');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (2, 'pull up', 'An upper-body strength exercise involving lifting the body using the arms, targeting the upper back and arms.', '2');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (1, 'push up', 'A bodyweight exercise where the body is lifted and lowered by arm extension, primarily targeting the chest, shoulders, and triceps.', '0');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (2, 'dead lift', 'A fundamental weightlifting exercise involving lifting a barbell from the ground, targeting the lower back, legs, and glutes.', '2');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (2, 'kick back', 'Exercise for the glutes, extending one leg backward.', '2');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (3, 'Downward dog', 'A yoga position where the body forms an inverted "V," stretching the back and leg muscles.', '1');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (3, 'upward dog', 'A yoga position where the upper body is lifted off the ground, stretching the chest and abdominal muscles.', '1');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (2, 'military press', 'Standing shoulder press, lifting a barbell or dumbbells overhead. Focuses on the shoulder muscles.', '2');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (1, 'plank', 'Holding a position similar to a push-up to strengthen the core muscles.', '0');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (5, 'burpee', 'A full-body exercise combining a squat, push-up, and jump. Intensive for overall conditioning.', '0');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (1, 'crunches', 'Abdominal exercise involving lifting the upper body towards the knees.', '0');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (3, 'child’s pose', 'Relaxing yoga position where one sits on the heels and bends the upper body forward.', '1');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (3, 'pelvic curl', 'Lying on the back, lifting and lowering the pelvis to strengthen the glutes and lower back.', '1');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (2, 'chest lift', 'Lying on the back, lifting the upper body to activate the upper abdominal muscles.', '2');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (2, 'chest lift with rotation', 'Similar to the Chest Lift but includes rotation of the upper body, targeting the oblique abdominal muscles.', '2');
INSERT INTO EXERCISE (SPORTID, NAME, DESCRIPTION, EXERCISETYPE) VALUES (3, 'single leg stretch', 'Pilates exercise involving alternating leg lifts to target the abdominal muscles.', '1');
''')

# Training plans
# !!TODO!!