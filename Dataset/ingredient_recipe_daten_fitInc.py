from random import randrange


print('DELETE FROM "RECIPECATEGORY";')
print('DELETE FROM "INGREDIENT";')
print('DELETE FROM "RECIPE";')
print('COMMIT;')

# foodcategory: 0 meat, 1 vegetarian, 2 vegan
# mealtype: 0 breakfast, 1 supper, 2 dinner, 3 snack, 4 drink

print("-- recipecategory")
print()

for food_category in range(3):
    for meal_type in range(5):
        s = '''insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES ({}, {});'''
        print(s.format(meal_type, food_category))
print()
print("-- ingredient")
print()

zutaten = {
    # foodcategory, brennwert, fett, protein, kohlenhydrate
    # unit, pricelower, priceupper
    'aubergine': [
        2, 23, 2, 0, 3,
        4, 0.70, 1.20],
    'beef': [
        0, 107, 22, 2, 0,
        2, 6.0, 12.0],
    'banana': [
        2, 96, 1, 1, 22,
        2, 6.0, 12.0],
    'carrot': [
        2, 135, 1, 0, 5,
        2, 0.5, 1.9],
    'cheese': [
        1, 353, 24, 28, 0,
        2, 3.20, 8.0],
    'chicken breast': [
        0, 152, 21, 8, 0,
        2, 3.0, 6.0],
    'cream': [
        1, 293, 2, 30, 4,
        3, .1, .3],
    'garlic': [
        2, 139, 6, 1, 28,
        2, .1, .7],
    'pork': [
        0, 120, 28, 10, 0,
        2, 4.0, 7.0],
    'potato': [
        2, 72, 2, 0, 15,
        2, 0.40, 2.10],
    'red bell pepper': [
        2, 44, 1, 0, 3,
        4, 0.50, 0.90],
    'rice': [
        2, 128, 8, 5, 58,
        3, 0.80, 4.40],
    'salad': [
        2, 28, 2, 0, 2,
        4, 0.70, 3.00],
    'salmon': [
        0, 188, 20, 12, 0,
        2, 5.0, 11.0],
    'spaghetti': [
        2, 417, 4, 3, 70,
        3, 0.50, 2.70],
    'tomato': [
        2, 19, 1, 1, 4,
        2, .1, .7],
    'zucchini': [
        2, 20, 2, 0, 2,
        4, 0.50, 1.10],
}

# unit: 0 gram, 1 liter, 2 pfund, 3 unze, 4 stück

insert = '''EXECUTE INSERTINGREDIENT('{}', {}, {}, {}, {}, {}, {}, TO_NUMBER('{}'), TO_NUMBER('{}'));'''

for name, z in zutaten.items():
    a = insert.format(name, *z[:-2], str(z[-2]).replace('.', ','), str(z[-1]).replace('.', ','))
    print(a)

print()
print("-- recipe")
print()

rs = {
    "Garlic Chicken Stir Fry": {
        "description": """Strips of skinless chicken breast stir it up with garlic,
ginger, and tons of crunchy vegetables, including sliced cabbage, red bell pepper,
and sugar snap peas.""",
        "ingredients": ['garlic', 'red bell pepper', 'chicken breast', 'potato'],
        "category": [0, 1],
    },
    "Lemon-Pepper Salmon": {
        "description": """Salmon sizzles in the pan with fresh garlic and then simmers briefly with chopped fresh tomatoes
and cilantro until the fish is wonderfully flaky.""",
        "ingredients": ['garlic', 'tomato', 'salmon'],
        "category": [0, 2],
    },
    "Mediterranean Anitpasti": {
        "description": """Chopped and grilled legumes in white wine with goat's cheese, olives, onions, and garlic.""",
        "email": 'matthew.fuller@gmail.com',
        "ingredients": ['garlic', 'zucchini', 'tomato', 'aubergine', 'red bell pepper'],
        "category": [1, 2],
    },
    "Chicken Fiesta Salad": {
        "description": """Salad greens and tomato wedges with seasoned skinless, boneless chicken breast halves sauteed
in a little vegetable oil, and then dress it all up with a tasty mixture of black beans, Mexican-style corn,
tomato salsa, and fajita seasoning""",
        "ingredients": ['salad', 'tomato', 'chicken breast', 'carrot', 'red bell pepper'],
        "category": [0, 0],
    },
    "Chicken, Zucchini, and Artichoke Salad": {
        "description": """Pieces of skinless, boneless chicken breast are lightly pan-fried and tossed with sauteed zucchini,
garbanzo beans, olives, and artichoke hearts.""",
        "ingredients": ['zucchini', 'tomato', 'chicken breast', 'salad'],
        "category": [0, 3],
    },
    "Ratatouille": {
        "description": """This classic Mediterranean dish is loaded with healthy fresh vegetables, including zucchini, fresh tomatoes,
eggplant, mushrooms, bell peppers, and onions.""",
        "email": 'christin.blake@gmx.com',
        "ingredients": ['garlic', 'tomato', 'potato', 'aubergine', 'red bell pepper', 'zucchini', 'rice'],
        "category": [2, 3],
    },
    "Pork mince salad": {
        "description": """Larb partnered with my favourite flat bread, fresh herbs, a good schmear of hoisin and some pork""",
        "email": 'christin.blake@gmx.com',
        "ingredients": ['garlic', 'tomato', 'salad', 'pork', 'cheese'],
        "category": [0, 1],
    },
    "Avocado banana smoothie": {
        "description": """Healthy blend for a perfect breakfast experience.""",
        "ingredients": ['banana'],
        "category": [2, 4],
    },
}

default_email = 'incredible@fit.com'
instructions = "step one, step two, step three, enjoy!"

for name, r in rs.items():
    s = """INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = {meal_type} and foodcategory = {food_category}),
    '{email}',
    '{name}',
    '{descr}',
    '{instr}');"""

    print(s.format(
        email=r.get("email", default_email).replace("'", "''"),
        name=name.replace("'", "''"),
        descr=r["description"].replace("\n", " ").replace("'", "''"),
        instr=instructions,
        meal_type=r["category"][1],
        food_category=r["category"][0]))

    for ingr in r["ingredients"]:
        s = '''
INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = '{}'),
    '{}',
    {});
'''
        print(s.format(name.replace("'", "''"), ingr, randrange(3) + 1))




# print('VARIABLE unit_id NUMBER; VARIABLE ingredient_id NUMBER;')
insert = '''INSERT INTO "INGREDIENT"
    (INGREDIENTNAME, FOODCATEGORY, CALORIES, PROTEIN, FAT, CARBONHYDRATES)
VALUES
    ('{0}', {1}, {2}, {3}, {4}, {5})
    RETURNING INGREDIENTID INTO :ingredient_id;
INSERT INTO QUANTITYPRICE
    (INGREDIENTNAME, QUANTITYUNIT, PRICELOWER, PRICEUPPER)
VALUES ('{0}', {6}, {7}, {8})
    RETURNING QUANTITYPRICEID INTO :unit_id;
UPDATE "INGREDIENT" SET QUANTITYPRICEID = :unit_id WHERE = :ingredient_id;'''