--------------------------------------------
-- Delete all the data that was previously in the tables
--------------------------------------------
    

DELETE FROM "EMPLOYEE";
COMMIT;


DELETE FROM "INGREDIENT";
COMMIT;


DELETE FROM "MANAGES_SPORT";
COMMIT;


DELETE FROM "RECIPE";
COMMIT;


DELETE FROM "RECIPECATEGORY";
COMMIT;


DELETE FROM "TRACK";
COMMIT;


DELETE FROM "USER";
COMMIT;


DELETE FROM "USER_SAVED_RECIPES";
COMMIT;

DELETE FROM FITNESSLEVEL;
DELETE FROM SPORT;
DELETE FROM EXERCISE;
DELETE FROM EXERCISEUNIT;
DELETE FROM TRAINING_UNIT_UNIT;
DELETE FROM TRAININGUNIT;
DELETE FROM PLAN_UNIT_UNIT;
DELETE FROM PLANTRAININGUNIT;
DELETE FROM TRAININGPLAN;
DELETE FROM APPOINTMENT;
DELETE FROM RECIPE_APPOINTMENT;
DELETE FROM USER_APPOINTMENT;
DELETE FROM USER_PLAN;

--------------------------------------------
-- Insert the default fitnesslevels
--------------------------------------------


INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Impairment');
INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Absolute beginner');
INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Beginner');
INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Advanced');
INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Fit');
INSERT INTO FITNESSLEVEL (FITNESSSTATUS) VALUES ('Professional');


--------------------------------------------
-- Generate the users. Since the password is a hashed representation of the
-- password itself and the salt there are two randomly seeming strings in each user.
--------------------------------------------


INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('iris.hardy@web.de', 'OPBBQ585Q0', 'B7C7DF9D67A1926A737406E2206630FF72AE7D55901425E656E9962891DD5F9BFC785311296B23DF8B19BD7152CDFD2C73DAFB7043D0F409D21D2FC7898C5132', 'Hardy', 'Iris', 68, 163, 25, 1600, 'Improving overall fitness', 62,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Impairment')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('matthew.fuller@gmail.com', '4M5CUR9S4C', 'CC58729DCED887AB4372B088042F12269732E0A1C071BD65A361A6146795D05EF79C33B648D57D12FE194A76EB63792F3B1DA0E94688E3904048920A0C8D32BB', 'Fuller', 'Matthew', 80, 175, 18, 1500, 'Maintaining weight and staying active', 80,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Beginner')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('blair.cooper@freenet.com', 'XFT82S8SP6', '4C17285B4203E964861A694F9B557DD055F14A2E5E8DBE63E51C369A73B3E1B2705EA4580A56B48C40545FD5D6D2D6C6CAE3512FA23CD99C9E850ABB38147F9D', 'Cooper', 'Blair', 65, 160, 22, 1300, 'Building lean muscle mass', 72,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Advanced')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('nora.bialik@yahoo.de', '97NQUS3Y7G', '19984FF01E6BB1C040C59B5410F6AFFDDD84DE1BF9EED5ED0D1F95417A4684454D6E75C47DF5A26508C0C36F7AAB0DFC2ADC783C987B7E868E2205E3653D48D3', 'Bialik', 'Nora', 77, 165, 15, 1400, 'Building lean muscle mass', 75,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Impairment')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('benedict.frakes@gmail.com', 'S4KK4HN3IZ', 'D8DCC51537F57B9C60C0D7756AB65E36DC52B596A308C616867A1B6DA6EC6FAA717DC66975EE607A4FD9D011ADF9400766E08FB88B01B56DBF2AE91DACA3FB7D', 'Frakes', 'Benedict', 112, 202, 20, 1800, 'Building muscle and strength', 120,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Absolute Beginner')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('sabine.baker@freenet.com', 'TAWITRIK4G', '2368F0FC11D61F6467FE9F7FFCF06655875513705D44372876114B530F7F8FE1B26174B38CEB89D971FA88C6AD31519B299BF19B6D9A4363BA602586359D686B', 'Baker', 'Sabine', 60, 168, 22, 1300, 'Losing weight and improving fitness', 55,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Beginner')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('leon.petterson@gmx.com', 'CIDERZE8B1', 'EB51F20126850B6E9EBE2C30C07BCC05B989E4B41825D551AD16EA1F2A3255A0C741A6E88515E893317F112475C7DA2DD5CC63BEFC327303C97F439A052E52C3', 'Petterson', 'Leon', 92, 179, 18, 1600, 'Improving overall fitness', 88,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Absolute Beginner')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('christin.blake@gmx.com', '82XPW2XHCK', '99612A6632501D6507FE8474C48394519EA2EEE01D351F02A703842B3B6DE4FE5FF5A15B30775BD779F52B056307A5BED3FB6F4D12CE104998174B02A6B50982', 'Blake', 'Christin', 49, 151, 12, 1200, 'Maintaining weight and staying active', 49,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Absolute Beginner')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('jonas.blake@web.de', 'S23MP3Z6AY', '3B79C123551F79DC276152470A55C90233322F9B6F4842EBE6C0CAB17843275A7A9B83B3020FEEC1EEA92CED2BB2D9C559FBA362DA8F437C925C790CC1D2BD4E', 'Blake', 'Jonas', 70, 175, 15, 1400, 'Improving cardiovascular health', 65,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Beginner')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('yvonne.smith@gmail.com', '9FGKUK4ZTF', '974B6BFFF17E2EF614C9E189214ED7C6A4C15F70AC6A8040431F7EEC1F52FF18AA22F3032F6647813197EA975216F745F1CB5E17A2C611FEF23DE7812C03D8FD', 'Smith', 'Yvonne', 73, 178, 16, 1550, 'Improving overall fitness', 70,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Advanced')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('anne.mitchel@yahoo.com', 'JV6GOQCT06', '33600901EA6BD5276BCCEE70DEA0D5FA558B903F13C26CF100B7280E0C6ED95797C1219FBCD88CBAF30C9081BF203BBF0CBCDADCBD1BBDEF125D49245A47F953', 'Mitchel', 'Anne', 57, 166, 16, 1500, 'Maintaining weight and staying active', 57,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Beginner')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('samuel.hardy@gmail.com', '2XP2PS0YFR', '8A6F2C46C051CD69337C330745C474AF7DA8F86D953D7EF0CBA5B96D901D4BBD14B0F6443932E426E543CD7DE9927A1ECD7225D1D4222F4F79E8C6040117B49D', 'Hardy', 'Samuel', 82, 181, 8, 1800, 'Building some muscles', 85,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Professional')
);

INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('wilson.stewart@yahoo.com', 'NWTQUHCGOK', 'F965509E188216DB838AA193F91756826D3FB90C01CE2439A1A5F8B94E85D3ACCDB633CF2C053618F52064E0A00612FEEF958AD9A7B7A5A0E2CDF39E0DA6315B', 'Stewart', 'Wilson', 111, 179, 15, 2600, 'Losing some fat', 99,
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = 'Advanced')
);

--------------------------------------------
-- Generate the employees. Employees are a simple link for a employeenumber to a user.
--------------------------------------------


DECLARE
    g_employeeid NUMBER;

BEGIN
    INSERT INTO EMPLOYEE (EMAIL, AUTHORIZATION) VALUES ('yvonne.smith@gmail.com', 0)
    RETURNING EMPLOYEEID INTO g_employeeid;

    UPDATE "USER" SET EMPLOYEEID = g_employeeid
    WHERE "USER".EMAIL = 'yvonne.smith@gmail.com';
END;
/

DECLARE
    g_employeeid NUMBER;

BEGIN
    INSERT INTO EMPLOYEE (EMAIL, AUTHORIZATION) VALUES ('benedict.frakes@gmail.com', 1)
    RETURNING EMPLOYEEID INTO g_employeeid;

    UPDATE "USER" SET EMPLOYEEID = g_employeeid
    WHERE "USER".EMAIL = 'benedict.frakes@gmail.com';
END;
/

DECLARE
    g_employeeid NUMBER;

BEGIN
    INSERT INTO EMPLOYEE (EMAIL, AUTHORIZATION) VALUES ('anne.mitchel@yahoo.com', 0)
    RETURNING EMPLOYEEID INTO g_employeeid;

    UPDATE "USER" SET EMPLOYEEID = g_employeeid
    WHERE "USER".EMAIL = 'anne.mitchel@yahoo.com';
END;
/

--------------------------------------------
-- Generate the calorie-tracks for some users.
--------------------------------------------


INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('anne.mitchel@yahoo.com', TO_DATE('2023-12-24', 'YYYY-MM-DD'), 2600, 80, 79, 201);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('anne.mitchel@yahoo.com', TO_DATE('2023-12-25', 'YYYY-MM-DD'), 2300, 99, 77, 190);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('anne.mitchel@yahoo.com', TO_DATE('2023-12-26', 'YYYY-MM-DD'), 2700, 103, 59, 178);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('anne.mitchel@yahoo.com', TO_DATE('2023-12-27', 'YYYY-MM-DD'), 2050, 120, 70, 211);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('anne.mitchel@yahoo.com', TO_DATE('2023-12-28', 'YYYY-MM-DD'), 2050, 111, 64, 244);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('anne.mitchel@yahoo.com', TO_DATE('2023-12-29', 'YYYY-MM-DD'), 2100, 117, 61, 243);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('anne.mitchel@yahoo.com', TO_DATE('2023-12-30', 'YYYY-MM-DD'), 2150, 90, 69, 210);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('anne.mitchel@yahoo.com', TO_DATE('2023-12-31', 'YYYY-MM-DD'), 2800, 80, 66, 190);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-14', 'YYYY-MM-DD'), 2400, 110, 85, 175);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-15', 'YYYY-MM-DD'), 2421, 89, 84, 179);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-16', 'YYYY-MM-DD'), 2376, 99, 77, 175);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-17', 'YYYY-MM-DD'), 2015, 112, 68, 150);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-18', 'YYYY-MM-DD'), 2342, 91, 65, 180);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-19', 'YYYY-MM-DD'), 2102, 103, 71, 232);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-20', 'YYYY-MM-DD'), 2320, 108, 78, 250);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-21', 'YYYY-MM-DD'), 2103, 97, 87, 179);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-22', 'YYYY-MM-DD'), 2233, 98, 81, 248);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-23', 'YYYY-MM-DD'), 2367, 99, 61, 215);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-24', 'YYYY-MM-DD'), 2328, 94, 75, 222);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-25', 'YYYY-MM-DD'), 2160, 113, 89, 204);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-26', 'YYYY-MM-DD'), 2145, 112, 66, 180);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-27', 'YYYY-MM-DD'), 2245, 107, 67, 213);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-28', 'YYYY-MM-DD'), 2307, 105, 61, 205);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-29', 'YYYY-MM-DD'), 2199, 81, 85, 198);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-30', 'YYYY-MM-DD'), 2379, 101, 86, 173);

INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES ('samuel.hardy@gmail.com', TO_DATE('2024-01-31', 'YYYY-MM-DD'), 2149, 110, 85, 228);

--------------------------------------------
-- Generate the ingredients. Since ingredients require a quantity price
-- they are more complex to create than usual and therefore the INSERTINGREDIENT
-- procedure is used to setup the dependencies indirectly.
--------------------------------------------

EXECUTE INSERTINGREDIENT('aubergine', 2, 23, 2, 0, 3, 4, TO_NUMBER('0,7'), TO_NUMBER('1,2'));
EXECUTE INSERTINGREDIENT('beef', 0, 107, 22, 2, 0, 2, TO_NUMBER('6,0'), TO_NUMBER('12,0'));
EXECUTE INSERTINGREDIENT('banana', 2, 96, 1, 1, 22, 2, TO_NUMBER('6,0'), TO_NUMBER('12,0'));
EXECUTE INSERTINGREDIENT('carrot', 2, 135, 1, 0, 5, 2, TO_NUMBER('0,5'), TO_NUMBER('1,9'));
EXECUTE INSERTINGREDIENT('cheese', 1, 353, 24, 28, 0, 2, TO_NUMBER('3,2'), TO_NUMBER('8,0'));
EXECUTE INSERTINGREDIENT('chicken breast', 0, 152, 21, 8, 0, 2, TO_NUMBER('3,0'), TO_NUMBER('6,0'));
EXECUTE INSERTINGREDIENT('cream', 1, 293, 2, 30, 4, 3, TO_NUMBER('0,1'), TO_NUMBER('0,3'));
EXECUTE INSERTINGREDIENT('garlic', 2, 139, 6, 1, 28, 2, TO_NUMBER('0,1'), TO_NUMBER('0,7'));
EXECUTE INSERTINGREDIENT('pork', 0, 120, 28, 10, 0, 2, TO_NUMBER('4,0'), TO_NUMBER('7,0'));
EXECUTE INSERTINGREDIENT('potato', 2, 72, 2, 0, 15, 2, TO_NUMBER('0,4'), TO_NUMBER('2,1'));
EXECUTE INSERTINGREDIENT('red bell pepper', 2, 44, 1, 0, 3, 4, TO_NUMBER('0,5'), TO_NUMBER('0,9'));
EXECUTE INSERTINGREDIENT('rice', 2, 128, 8, 5, 58, 3, TO_NUMBER('0,8'), TO_NUMBER('4,4'));
EXECUTE INSERTINGREDIENT('salad', 2, 28, 2, 0, 2, 4, TO_NUMBER('0,7'), TO_NUMBER('3,0'));
EXECUTE INSERTINGREDIENT('salmon', 0, 188, 20, 12, 0, 2, TO_NUMBER('5,0'), TO_NUMBER('11,0'));
EXECUTE INSERTINGREDIENT('spaghetti', 2, 417, 4, 3, 70, 3, TO_NUMBER('0,5'), TO_NUMBER('2,7'));
EXECUTE INSERTINGREDIENT('tomato', 2, 19, 1, 1, 4, 2, TO_NUMBER('0,1'), TO_NUMBER('0,7'));
EXECUTE INSERTINGREDIENT('zucchini', 2, 20, 2, 0, 2, 4, TO_NUMBER('0,5'), TO_NUMBER('1,1'));
EXECUTE INSERTINGREDIENT('yoghurt', 1, 59, 10, 1, 3, 0, TO_NUMBER('3,0'), TO_NUMBER('6,0'));
EXECUTE INSERTINGREDIENT('beeries', 2, 54, 0, 1, 5, 0, TO_NUMBER('4,5'), TO_NUMBER('7,5'));
EXECUTE INSERTINGREDIENT('honey', 1, 304, 0, 0, 82, 0, TO_NUMBER('3,0'), TO_NUMBER('8,0'));
EXECUTE INSERTINGREDIENT('nuts', 2, 576, 21, 50, 22, 0, TO_NUMBER('5,5'), TO_NUMBER('10,0'));
EXECUTE INSERTINGREDIENT('qunioa', 2, 120, 31, 4, 17, 0, TO_NUMBER('7,0'), TO_NUMBER('11,0'));
EXECUTE INSERTINGREDIENT('lemon juice', 2, 22, 0, 0, 6, 0, TO_NUMBER('3,0'), TO_NUMBER('5,0'));
EXECUTE INSERTINGREDIENT('sweet potatoes', 2, 86, 2, 0, 20, 0, TO_NUMBER('9,0'), TO_NUMBER('15,0'));
EXECUTE INSERTINGREDIENT('sugar', 1, 400, 0, 0, 100, 0, TO_NUMBER('3,0'), TO_NUMBER('4,5'));
EXECUTE INSERTINGREDIENT('flour', 2, 300, 10, 1, 60, 0, TO_NUMBER('0,5'), TO_NUMBER('2,5'));
EXECUTE INSERTINGREDIENT('eggs', 1, 70, 6, 5, 1, 4, TO_NUMBER('5,0'), TO_NUMBER('7,0'));
EXECUTE INSERTINGREDIENT('olive oil', 1, 120, 0, 14, 0, 1, TO_NUMBER('0,1'), TO_NUMBER('0,2'));
EXECUTE INSERTINGREDIENT('basil', 2, 2, 0, 0, 0, 4, TO_NUMBER('1,5'), TO_NUMBER('2,0'));
EXECUTE INSERTINGREDIENT('ground beef', 0, 250, 26, 17, 0, 0, TO_NUMBER('0,5'), TO_NUMBER('1,0'));
EXECUTE INSERTINGREDIENT('tomato sauce', 2, 50, 2, 0, 10, 0, TO_NUMBER('0,05'), TO_NUMBER('0,1'));
EXECUTE INSERTINGREDIENT('quinoa', 2, 43, 4, 8, 9, 0, TO_NUMBER('0,5'), TO_NUMBER('1,0'));

--------------------------------------------
-- Generate the recipe-categories. There is only a limited number of
-- possible categories, which is why we create all of them here.
--------------------------------------------


insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (0, 0);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (1, 0);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (2, 0);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (3, 0);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (4, 0);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (0, 1);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (1, 1);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (2, 1);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (3, 1);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (4, 1);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (0, 2);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (1, 2);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (2, 2);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (3, 2);

insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES (4, 2);

--------------------------------------------
-- Generate the recipes. For each recipe there is a list of recipe ingredients
-- that need to be generated and linked to the actual recipe.
--------------------------------------------

----- Garlic Chicken Stir Fry -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 1 and foodcategory = 0),
    'anne.mitchel@yahoo.com', 'Garlic Chicken Stir Fry', 'Strips of skinless chicken breast stir it up with garlic, ginger, and tons of crunchy vegetables, including sliced cabbage, red bell pepper, and sugar snap peas.', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Garlic Chicken Stir Fry'), 'garlic', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Garlic Chicken Stir Fry'), 'red bell pepper', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Garlic Chicken Stir Fry'), 'chicken breast', 1 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Garlic Chicken Stir Fry'), 'potato', 1 );

----- Lemon-Pepper Salmon -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 2 and foodcategory = 0),
    'anne.mitchel@yahoo.com', 'Lemon-Pepper Salmon', 'Salmon sizzles in the pan with fresh garlic and then simmers briefly with chopped fresh tomatoes and cilantro until the fish is wonderfully flaky.', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Lemon-Pepper Salmon'), 'garlic', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Lemon-Pepper Salmon'), 'tomato', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Lemon-Pepper Salmon'), 'salmon', 3 );

----- Mediterranean Anitpasti -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 2 and foodcategory = 1),
    'matthew.fuller@gmail.com', 'Mediterranean Anitpasti', 'Chopped and grilled legumes in white wine with goat''s cheese, olives, onions, and garlic.', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Mediterranean Anitpasti'), 'garlic', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Mediterranean Anitpasti'), 'zucchini', 2 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Mediterranean Anitpasti'), 'tomato', 2 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Mediterranean Anitpasti'), 'aubergine', 2 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Mediterranean Anitpasti'), 'red bell pepper', 1 );

----- Chicken Fiesta Salad -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 0 and foodcategory = 0),
    'anne.mitchel@yahoo.com', 'Chicken Fiesta Salad', 'Salad greens and tomato wedges with seasoned skinless, boneless chicken breast halves sauteed in a little vegetable oil, and then dress it all up with a tasty mixture of black beans, Mexican-style corn, tomato salsa, and fajita seasoning', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken Fiesta Salad'), 'salad', 2 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken Fiesta Salad'), 'tomato', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken Fiesta Salad'), 'chicken breast', 1 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken Fiesta Salad'), 'carrot', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken Fiesta Salad'), 'red bell pepper', 3 );

----- Chicken, Zucchini, and Artichoke Salad -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 3 and foodcategory = 0),
    'anne.mitchel@yahoo.com', 'Chicken, Zucchini, and Artichoke Salad', 'Pieces of skinless, boneless chicken breast are lightly pan-fried and tossed with sauteed zucchini, garbanzo beans, olives, and artichoke hearts.', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken, Zucchini, and Artichoke Salad'), 'zucchini', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken, Zucchini, and Artichoke Salad'), 'tomato', 2 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken, Zucchini, and Artichoke Salad'), 'chicken breast', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken, Zucchini, and Artichoke Salad'), 'salad', 2 );

----- Ratatouille -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 3 and foodcategory = 2),
    'christin.blake@gmx.com', 'Ratatouille', 'This classic Mediterranean dish is loaded with healthy fresh vegetables, including zucchini, fresh tomatoes, eggplant, mushrooms, bell peppers, and onions.', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'), 'garlic', 1 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'), 'tomato', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'), 'potato', 2 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'), 'aubergine', 1 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'), 'red bell pepper', 2 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'), 'zucchini', 1 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'), 'rice', 2 );

----- Pork mince salad -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 1 and foodcategory = 0),
    'christin.blake@gmx.com', 'Pork mince salad', 'Larb partnered with my favourite flat bread, fresh herbs, a good schmear of hoisin and some pork', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Pork mince salad'), 'garlic', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Pork mince salad'), 'tomato', 2 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Pork mince salad'), 'salad', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Pork mince salad'), 'pork', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Pork mince salad'), 'cheese', 1 );

----- Avocado banana smoothie -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 4 and foodcategory = 2),
    'anne.mitchel@yahoo.com', 'Avocado banana smoothie', 'Healthy blend for a perfect breakfast experience.', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Avocado banana smoothie'), 'banana', 2 );

----- Yoghurt with beeries -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 1 and foodcategory = 0),
    'anne.mitchel@yahoo.com', 'Yoghurt with beeries', 'Sweet yoghurt with some fresh berries and nuts.', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Yoghurt with beeries'), 'yoghurt', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Yoghurt with beeries'), 'beeries', 1 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Yoghurt with beeries'), 'honey', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Yoghurt with beeries'), 'nuts', 3 );

----- Chicken-Quinoa-salad -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 0 and foodcategory = 0),
    'anne.mitchel@yahoo.com', 'Chicken-Quinoa-salad', 'A salad based on quinoa, chicken and vegetables', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken-Quinoa-salad'), 'chicken breast', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken-Quinoa-salad'), 'quinoa', 1 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken-Quinoa-salad'), 'olive oil', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Chicken-Quinoa-salad'), 'lemon juice', 3 );

----- Salmon with sweet potatoes -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 1 and foodcategory = 0),
    'anne.mitchel@yahoo.com', 'Salmon with sweet potatoes', 'Some salmon out of the oven with sweet potato slices', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Salmon with sweet potatoes'), 'lemon juice', 1 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Salmon with sweet potatoes'), 'salmon', 2 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Salmon with sweet potatoes'), 'sweet potatoes', 1 );

----- Cheesecake -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 0 and foodcategory = 1),
    'anne.mitchel@yahoo.com', 'Cheesecake', 'A delicious cheesecake', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Cheesecake'), 'sugar', 2 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Cheesecake'), 'flour', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Cheesecake'), 'eggs', 2 );

----- Tomato Salad -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 2 and foodcategory = 2),
    'anne.mitchel@yahoo.com', 'Tomato Salad', 'Fresh tomato salad', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Tomato Salad'), 'tomato', 3 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Tomato Salad'), 'olive oil', 2 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Tomato Salad'), 'basil', 1 );

----- Pasta Bolognese -----

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions, visibility)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 1 and foodcategory = 2),
    'anne.mitchel@yahoo.com', 'Pasta Bolognese', 'Classic pasta Bolognese', 'step one, step two, step three, enjoy!', 1);

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Pasta Bolognese'), 'ground beef', 1 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Pasta Bolognese'), 'tomato sauce', 1 );


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES ( (select recipeid from RECIPE where RECIPE.name = 'Pasta Bolognese'), 'spaghetti', 1 );


--------------------------------------------
-- Generate the user-saved-recipes.
--------------------------------------------


INSERT INTO USER_SAVED_RECIPES (EMAIL, RECIPEID)
VALUES ('anne.mitchel@yahoo.com', (SELECT RECIPEID FROM RECIPE WHERE NAME = 'Salmon with sweet potatoes') );

INSERT INTO USER_SAVED_RECIPES (EMAIL, RECIPEID)
VALUES ('anne.mitchel@yahoo.com', (SELECT RECIPEID FROM RECIPE WHERE NAME = 'Yoghurt with beeries') );

INSERT INTO USER_SAVED_RECIPES (EMAIL, RECIPEID)
VALUES ('benedict.frakes@gmail.com', (SELECT RECIPEID FROM RECIPE WHERE NAME = 'Salmon with sweet potatoes') );

INSERT INTO USER_SAVED_RECIPES (EMAIL, RECIPEID)
VALUES ('wilson.stewart@yahoo.com', (SELECT RECIPEID FROM RECIPE WHERE NAME = 'Yoghurt with beeries') );

INSERT INTO USER_SAVED_RECIPES (EMAIL, RECIPEID)
VALUES ('jonas.blake@web.de', (SELECT RECIPEID FROM RECIPE WHERE NAME = 'Chicken-Quinoa-salad') );

INSERT INTO USER_SAVED_RECIPES (EMAIL, RECIPEID)
VALUES ('samuel.hardy@gmail.com', (SELECT RECIPEID FROM RECIPE WHERE NAME = 'Tomato Salad') );

--------------------------------------------
-- Insert the sports. Sports are used to manage multiple other aspects of user specific data.
--------------------------------------------


INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('Strength training', 'Builds muscle strength using resistance, like weights.');
INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('Bodyweight training', 'Relies on the body''s weight for exercises, e.g., push-ups.');
INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('Core training', 'Targets core muscles for stability and strength.');
INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('General fitness', 'Overall health improvement with varied exercises.');
INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('Yoga', 'Combines postures, breath control, and meditation.');
INSERT INTO SPORT (SPORTNAME, DESCRIPTION) VALUES ('Cardiovascular training', 'Boosts heart health through activities like running.');


--------------------------------------------
-- Generate the MANAGES_SPORT relations.
--------------------------------------------


INSERT INTO MANAGES_SPORT (SPORTNAME, EMPLOYEEID)
VALUES ('Bodyweight training', (SELECT EMPLOYEEID FROM EMPLOYEE WHERE EMAIL = 'yvonne.smith@gmail.com') );

INSERT INTO MANAGES_SPORT (SPORTNAME, EMPLOYEEID)
VALUES ('Core training', (SELECT EMPLOYEEID FROM EMPLOYEE WHERE EMAIL = 'yvonne.smith@gmail.com') );

INSERT INTO MANAGES_SPORT (SPORTNAME, EMPLOYEEID)
VALUES ('Strength training', (SELECT EMPLOYEEID FROM EMPLOYEE WHERE EMAIL = 'anne.mitchel@yahoo.com') );

--------------------------------------------
-- Insert the Exercises for the sports.
--------------------------------------------


INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('General fitness', 'jumping jack', 'A jumping exercise with simultaneous arm and leg spreading and closing. Effective for cardiovascular training.', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'pull up', 'An upper-body strength exercise involving lifting the body using the arms, targeting the upper back and arms.', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Bodyweight training', 'push up', 'A bodyweight exercise where the body is lifted and lowered by arm extension, primarily targeting the chest, shoulders, and triceps.', 0);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Strength training', 'kick back', 'Exercise for the glutes, extending one leg backward.', 2);
INSERT INTO EXERCISE (SPORTNAME, NAME, DESCRIPTION, EXERCISETYPE) VALUES ('Yoga', 'Downward dog', 'A yoga position where the body forms an inverted "V", stretching the back and leg muscles.', 1);
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


--------------------------------------------
-- Insert the trainingplans.
--------------------------------------------


INSERT INTO TRAININGPLAN (EMPLOYEEID, SPORTNAME, NAME, DESCRIPTION, TRAININGPLANDIFFICULTY) VALUES (1, 'Cardiovascular training', 'Running Plan', 'Plan for regular running', 1);  
INSERT INTO TRAININGPLAN (EMPLOYEEID, SPORTNAME, NAME, DESCRIPTION, TRAININGPLANDIFFICULTY) VALUES (1, 'Yoga', 'Yoga Relaxation', 'Yoga for stress relief and flexibility', 0);    
INSERT INTO TRAININGPLAN (EMPLOYEEID, SPORTNAME, NAME, DESCRIPTION, TRAININGPLANDIFFICULTY) VALUES (1, 'Strength training', 'Strength Training', 'Plan for muscle building and strength', 2);


--------------------------------------------
-- Insert the plantrainingunit which is a wrapper for multiple exercises on a specific workday.
--------------------------------------------


INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (1, 'Running training in the Park', 1);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (1, 'Sprint intervals', 3);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (1, 'Stair climbing', 5);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (2, 'Yoga for relaxation', 2);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (2, 'Ashtanga Yoga for strength', 4);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (2, 'Yin Yoga for flexibility', 6);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (3, 'Strength training at the gym', 1);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (3, 'Back and leg training', 3);
INSERT INTO PLANTRAININGUNIT (TRAININGPLANID, DESCRIPTION, WEEKDAY) VALUES (3, 'Arm training and Cardio', 5);


--------------------------------------------
-- Insert the trainingunit which is a wrapper for multiple exercises in a specific plantrainingunit.
--------------------------------------------


INSERT INTO TRAININGUNIT (NAME, DESCRIPTION, TRAININGUNITDIFFICULTY) VALUES ('Running in the Park', 'Jogging for endurance', 1);
INSERT INTO TRAININGUNIT (NAME, DESCRIPTION, TRAININGUNITDIFFICULTY) VALUES ('Vinyasa Yoga', 'Dynamic yoga', 0);
INSERT INTO TRAININGUNIT (NAME, DESCRIPTION, TRAININGUNITDIFFICULTY) VALUES ('Bench Press', 'Upper body strength training', 2);


--------------------------------------------
-- Insert the plan-unit-unit which relates the trainingplan plantrainingunit and trainingunit.
--------------------------------------------


INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (1, 1, 1);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (1, 2, 1);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (1, 3, 1);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (2, 4, 2);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (2, 5, 2);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (2, 6, 2);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (3, 7, 3);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (3, 8, 3);
INSERT INTO PLAN_UNIT_UNIT (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID) VALUES (3, 9, 3);


--------------------------------------------
-- Insert the exercise-units which is a wrapper to give more precise instructions on how to execute an exercise.
--------------------------------------------


INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (16, 'Slow jogging for 30 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (17, 'Vinyasa Flow for 60 minutes', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (18, 'Bench Press with 3 sets of 12 repetitions', 2, 12);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (19, 'Sprints and walking alternation for 20 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (20, 'Yoga poses for balance and relaxation', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (21, 'Squats with weights for 3 sets of 15 repetitions', 2, 15);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (22, 'Intervals of sprinting and walking for 15 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (23, 'Dynamic Ashtanga Yoga style for 75 minutes', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (24, 'Heavy Deadlifts with 3 sets of 10 repetitions', 2, 10);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (25, 'Stair climbing for 20 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (26, 'Yin Yoga for deep stretching', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (27, 'Lunges for leg training', 2, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (28, 'Obstacle course for 30 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (29, 'Dynamic Power Yoga for energy and strength', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (30, 'Lat Pulldown for back training', 2, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (31, 'Outdoor cycling for 45 minutes', 1, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (32, 'Kundalini Yoga for consciousness expansion', 0, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (33, 'Triceps Dips for arm strength', 2, 0);
INSERT INTO EXERCISEUNIT (EXERCISEID, DESCRIPTION, EXERCISEDIFFICULTY, REPETITIONS) VALUES (34, 'Swimming in the pool for 30 minutes', 1, 0);


--------------------------------------------
-- Insert the training-unit-units which is a relation mapping the exercise-units to the training-units.
--------------------------------------------


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


--------------------------------------------
-- Insert some of the training-units into the appointments.
--------------------------------------------


INSERT INTO APPOINTMENT (TRAININGUNITID, "DATE", STATUS)
VALUES (NULL, TO_DATE('2024-01-14', 'YYYY-MM-DD'), 0);
INSERT INTO APPOINTMENT (TRAININGUNITID, "DATE", STATUS)
VALUES (1, TO_DATE('2024-01-17', 'YYYY-MM-DD'), 0);
INSERT INTO APPOINTMENT (TRAININGUNITID, "DATE", STATUS)
VALUES (1, TO_DATE('2024-01-21', 'YYYY-MM-DD'), 0 );
INSERT INTO APPOINTMENT (TRAININGUNITID, "DATE", STATUS)
VALUES (NULL, TO_DATE('2024-01-26', 'YYYY-MM-DD'), 0);


--------------------------------------------
-- Insert some of the recipes into the appointments.
--------------------------------------------


INSERT INTO RECIPE_APPOINTMENT (RECIPEID, APPOINTMENTID)
VALUES (3, 4);
INSERT INTO RECIPE_APPOINTMENT (RECIPEID, APPOINTMENTID)
VALUES (1, 1);


--------------------------------------------
-- Map some of the appointments to the user
--------------------------------------------


INSERT INTO USER_APPOINTMENT (APPOINTMENTID, EMAIL)
VALUES (1, 'samuel.hardy@gmail.com');
INSERT INTO USER_APPOINTMENT (APPOINTMENTID, EMAIL)
VALUES (2, 'samuel.hardy@gmail.com');
INSERT INTO USER_APPOINTMENT (APPOINTMENTID, EMAIL)
VALUES (3, 'samuel.hardy@gmail.com');
INSERT INTO USER_APPOINTMENT (APPOINTMENTID, EMAIL)
VALUES (4, 'samuel.hardy@gmail.com');


--------------------------------------------
-- Map a trainingplan to a user
--------------------------------------------


INSERT INTO USER_PLAN (TRAININGPLANID, EMAIL)
VALUES (1, 'samuel.hardy@gmail.com');

COMMIT;