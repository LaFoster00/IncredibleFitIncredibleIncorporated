--Get the TrainingUnits for Samuel Hardy per weekday of the current training plan. 
--In this statement we use JOINs, COUNT, GROUP BY and ORDER BY.
SELECT PLANTRAININGUNIT.WEEKDAY,
	COUNT (TRAININGUNIT.TRAININGUNITID)
FROM TRAININGUNIT
JOIN PLAN_UNIT_UNIT
	ON TRAININGUNIT.TRAININGUNITID = PLAN_UNIT_UNIT.TRAININGUNITID
JOIN PLANTRAININGUNIT
	ON PLANTRAININGUNIT.PLANTRAININGUNITID = PLAN_UNIT_UNIT.PLANTRAININGUNITID
JOIN USER_PLAN
	ON PLANTRAININGUNIT.TRAININGPLANID = USER_PLAN.TRAININGPLANID
WHERE USER_PLAN.EMAIL = 'samuel.hardy@gmail.com'
GROUP BY PLANTRAININGUNIT.WEEKDAY
ORDER BY PLANTRAININGUNIT.WEEKDAY;

--Use this statement to read out all users who have entered a weight.
SELECT * 
FROM "USER"
WHERE "USER".WEIGHT IS NOT NULL;

--Get the whole data for Iris Hardy.
SELECT * 
FROM "USER"
WHERE "USER".LASTNAME = 'Hardy' AND "USER".FIRSTNAME = 'Iris';

--Update the weight from Iris Hardy.
UPDATE "USER"
SET "USER".WEIGHT = 65
WHERE "USER".LASTNAME = 'Hardy' AND "USER".FIRSTNAME = 'Iris';

--Check if the weight update for Iris Hardy has worked.
SELECT "USER".FIRSTNAME, "USER".LASTNAME, "USER".WEIGHT
FROM "USER"
WHERE "USER".LASTNAME = 'Hardy' AND "USER".FIRSTNAME = 'Iris';




--Trainingspläne einer Sportart löschen:

--daten anzeigen lasse:

SELECT *
FROM "TRAININGPLAN"
WHERE "TRAININGPLAN".SPORTNAME = 'Strength training';

--löschen

--KLAPPT NICHT!!

DELETE
FROM "TRAININGPLAN"
WHERE "TRAININGPLAN".SPORTNAME = 'Strength training';

--Löschung überprüfen → kein Ergebnis

SELECT *
FROM "TRAININGPLAN"
WHERE "TRAININGPLAN".SPORTNAME = 'Strength training';



--Show us a list of all the ingredients and in which recipes they are used.
--This statement uses LISTAGG, JOINs and GROUP BY.
SELECT INGREDIENT.INGREDIENTNAME, LISTAGG(RECIPE.NAME, ', ') AS RECIPE_NAMES
FROM RECIPE 
JOIN RECIPEINGREDIENT 
	ON RECIPE.RECIPEID = RECIPEINGREDIENT.RECIPEID
JOIN INGREDIENT 
	ON RECIPEINGREDIENT.INGREDIENTNAME = INGREDIENT.INGREDIENTNAME
GROUP BY INGREDIENT.INGREDIENTNAME

--Take all sports, list on which employee manages how many exercises of the sport and in total.
--This statement uses COUNT, JOINs and GROUP BY ROLLUP

SELECT EMPLOYEE.EMAIL,  SPORT.SPORTNAME, COUNT(EXERCISE.EXERCISEID)
FROM EMPLOYEE 
JOIN MANAGES_SPORT 
	ON EMPLOYEE.EMPLOYEEID = MANAGES_SPORT.EMPLOYEEID
JOIN SPORT 
	ON MANAGES_SPORT.SPORTNAME = SPORT.SPORTNAME 
JOIN EXERCISE 
	ON EXERCISE.SPORTNAME = SPORT.SPORTNAME
GROUP BY ROLLUP(EMPLOYEE.EMAIL, SPORT.SPORTNAME)

--Show us a list of all exercises that are not in an ExerciseUnit.
--This statement uses a LEFT OUTER JOIN.
SELECT EXERCISE.EXERCISEID, EXERCISE.name 
FROM EXERCISE
LEFT OUTER JOIN EXERCISEUNIT
	ON EXERCISE.EXERCISEID = EXERCISEUNIT.EXERCISEID
WHERE EXERCISEUNIT.EXERCISEID IS NULL

--Show us all the average calories of the ingredients and the FoodCategory, as well as the total average of all ingredients.
--This statement uses AVG and GROUP BY CUBE.
SELECT FOODCATEGORY, INGREDIENTNAME, AVG(CALORIES)
FROM INGREDIENT
GROUP BY CUBE (FOODCATEGORY, INGREDIENTNAME)

--Sample statements from the app:

--Get the user data from Samuel Hardy.
SELECT * 
FROM "USER"
WHERE EMAIL = 'samuel.hardy@gmail.com'

--Get the Appointments from the 30.01.2024 which are linked to Samuel Hardy.
--This statement uses a JOIN.
SELECT * 
FROM "APPOINTMENT"
JOIN "USER_APPOINTMENT" 
	ON APPOINTMENT.APPOINTMENTID = USER_APPOINTMENT.APPOINTMENTID
WHERE APPOINTMENT."DATE" = TO_DATE('2024-01-30', 'YYYY-MM-DD') AND USER_APPOINTMENT.EMAIL = 'samuel.hardy@gmail.com'

--Get the track from the 30.01.2024 from Samuel Hardy.
SELECT * 
FROM "TRACK"
WHERE "DATE" = TO_DATE('2024-01-30', 'YYYY-MM-DD') AND EMAIL='samuel.hardy@gmail.com'

--Get the favorite recipes from Samuel Hardy.
--This statement is a SUBSELECT.
SELECT *
FROM "RECIPE"
WHERE "RECIPEID" IN (
    SELECT "RECIPEID"
    FROM "USER_SAVED_RECIPES"
    WHERE "EMAIL" = 'samuel.hardy@gmail.com'
)

--Receive recipes based on filters.
--This statement uses a JOIN.
SELECT * 
FROM "RECIPE"
JOIN "RECIPEINGREDIENT"
	ON RECIPEINGREDIENT.RECIPEID = RECIPE.RECIPEID
WHERE (RECIPE.VISIBILITY=1 OR (RECIPE.VISIBILITY = 0 AND RECIPE.EMAIL = 'samuel.hardy@gmail.com')) 
	AND RECIPE.NAME LIKE '%Chicken%' AND RECIPEINGREDIENT.INGREDIENTNAME = 'tomato'

--Get the corresponding ingredients for a recipe.
--This statements uses JOINs.
SELECT * 
FROM "INGREDIENT" 
JOIN "RECIPEINGREDIENT" 
	ON RECIPEINGREDIENT.INGREDIENTNAME = INGREDIENT.INGREDIENTNAME
JOIN "RECIPE"
	ON RECIPEINGREDIENT.RECIPEID = RECIPE.RECIPEID
WHERE RECIPE.RECIPEID = 9

--Create a new appointment and the associated links to a user and a recipe.
--This statement are three insert with one returning value.
DECLARE
   PappointmentID NUMBER;
BEGIN
	INSERT INTO APPOINTMENT("DATE", STATUS)
	VALUES(TO_DATE('2024-02-10', 'YYYY-MM-DD'), 0)
	RETURNING APPOINTMENTID INTO PappointmentID;

	INSERT INTO RECIPE_APPOINTMENT(RECIPEID, APPOINTMENTID)
	VALUES(5, PappointmentID);

	INSERT INTO USER_APPOINTMENT(APPOINTMENTID, EMAIL)
	VALUES(PappointmentID, 'samuel.hardy@gmail.com');
END;

--Get the next unfinished appointment that is linked to a training session.
--This statement uses a JOIN and ORDER BY.
SELECT * 
FROM "APPOINTMENT" 
JOIN "USER_APPOINTMENT" 
	ON USER_APPOINTMENT.APPOINTMENTID = APPOINTMENT.APPOINTMENTID                 
WHERE APPOINTMENT.TRAININGUNITID IS NOT NULL AND USER_APPOINTMENT.EMAIL = 'samuel.hardy@gmail.com' AND APPOINTMENT.STATUS = 0
ORDER BY APPOINTMENT."DATE"

--Get the current trainingplan from Samuel Hardy.
--This statement is a SUBSELECT.
SELECT *
FROM "TRAININGPLAN"
WHERE "TRAININGPLANID" IN (
    SELECT "TRAININGPLANID"
    FROM "USER_PLAN"
    WHERE "EMAIL" = 'samuel.hardy@gmail.com'
)