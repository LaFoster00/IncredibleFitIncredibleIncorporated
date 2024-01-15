DELETE FROM "RECIPECATEGORY";
DELETE FROM "INGREDIENT";
DELETE FROM "RECIPE";
COMMIT;
-- recipecategory

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

-- ingredient

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

-- recipe

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 1 and foodcategory = 0),
    'incredible@fit.com',
    'Garlic Chicken Stir Fry',
    'Strips of skinless chicken breast stir it up with garlic, ginger, and tons of crunchy vegetables, including sliced cabbage, red bell pepper, and sugar snap peas.',
    'step one, step two, step three, enjoy!');

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Garlic Chicken Stir Fry'),
    'garlic',
    1);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Garlic Chicken Stir Fry'),
    'red bell pepper',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Garlic Chicken Stir Fry'),
    'chicken breast',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Garlic Chicken Stir Fry'),
    'potato',
    2);

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 2 and foodcategory = 0),
    'incredible@fit.com',
    'Lemon-Pepper Salmon',
    'Salmon sizzles in the pan with fresh garlic and then simmers briefly with chopped fresh tomatoes and cilantro until the fish is wonderfully flaky.',
    'step one, step two, step three, enjoy!');

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Lemon-Pepper Salmon'),
    'garlic',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Lemon-Pepper Salmon'),
    'tomato',
    1);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Lemon-Pepper Salmon'),
    'salmon',
    2);

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 2 and foodcategory = 1),
    'matthew.fuller@gmail.com',
    'Mediterranean Anitpasti',
    'Chopped and grilled legumes in white wine with goat''s cheese, olives, onions, and garlic.',
    'step one, step two, step three, enjoy!');

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Mediterranean Anitpasti'),
    'garlic',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Mediterranean Anitpasti'),
    'zucchini',
    2);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Mediterranean Anitpasti'),
    'tomato',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Mediterranean Anitpasti'),
    'aubergine',
    2);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Mediterranean Anitpasti'),
    'red bell pepper',
    2);

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 0 and foodcategory = 0),
    'incredible@fit.com',
    'Chicken Fiesta Salad',
    'Salad greens and tomato wedges with seasoned skinless, boneless chicken breast halves sauteed in a little vegetable oil, and then dress it all up with a tasty mixture of black beans, Mexican-style corn, tomato salsa, and fajita seasoning',
    'step one, step two, step three, enjoy!');

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Chicken Fiesta Salad'),
    'salad',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Chicken Fiesta Salad'),
    'tomato',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Chicken Fiesta Salad'),
    'chicken breast',
    2);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Chicken Fiesta Salad'),
    'carrot',
    2);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Chicken Fiesta Salad'),
    'red bell pepper',
    3);

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 3 and foodcategory = 0),
    'incredible@fit.com',
    'Chicken, Zucchini, and Artichoke Salad',
    'Pieces of skinless, boneless chicken breast are lightly pan-fried and tossed with sauteed zucchini, garbanzo beans, olives, and artichoke hearts.',
    'step one, step two, step three, enjoy!');

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Chicken, Zucchini, and Artichoke Salad'),
    'zucchini',
    2);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Chicken, Zucchini, and Artichoke Salad'),
    'tomato',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Chicken, Zucchini, and Artichoke Salad'),
    'chicken breast',
    2);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Chicken, Zucchini, and Artichoke Salad'),
    'salad',
    2);

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 3 and foodcategory = 2),
    'christin.blake@gmx.com',
    'Ratatouille',
    'This classic Mediterranean dish is loaded with healthy fresh vegetables, including zucchini, fresh tomatoes, eggplant, mushrooms, bell peppers, and onions.',
    'step one, step two, step three, enjoy!');

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'),
    'garlic',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'),
    'tomato',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'),
    'potato',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'),
    'aubergine',
    2);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'),
    'red bell pepper',
    1);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'),
    'zucchini',
    3);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Ratatouille'),
    'rice',
    3);

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 1 and foodcategory = 0),
    'christin.blake@gmx.com',
    'Pork mince salad',
    'Larb partnered with my favourite flat bread, fresh herbs, a good schmear of hoisin and some pork',
    'step one, step two, step three, enjoy!');

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Pork mince salad'),
    'garlic',
    1);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Pork mince salad'),
    'tomato',
    2);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Pork mince salad'),
    'salad',
    1);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Pork mince salad'),
    'pork',
    2);


INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Pork mince salad'),
    'cheese',
    1);

INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = 4 and foodcategory = 2),
    'incredible@fit.com',
    'Avocado banana smoothie',
    'Healthy blend for a perfect breakfast experience.',
    'step one, step two, step three, enjoy!');

INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = 'Avocado banana smoothie'),
    'banana',
    2);

