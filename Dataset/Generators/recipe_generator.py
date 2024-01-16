from random import randrange

print('''
DELETE FROM "RECIPE";
COMMIT;
''')

# foodcategory: 0 meat, 1 vegetarian, 2 vegan
# mealtype: 0 breakfast, 1 supper, 2 dinner, 3 snack, 4 drink

recipes = {
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

recipeInsert = """
INSERT INTO "RECIPE" (recipecategoryid, email, name, description, instructions)
VALUES (
    (SELECT recipecategoryid FROM RECIPECATEGORY where mealtype = {meal_type} and foodcategory = {food_category}),
    '{email}',
    '{name}',
    '{descr}',
    '{instr}'
    );"""

recipeIngredientInsert = '''
INSERT INTO "RECIPEINGREDIENT" (recipeid, ingredientname, quantity)
VALUES (
    (select recipeid from RECIPE where RECIPE.name = '{}'),
    '{}',
    {}
    );
    '''

def generateRecipes():
    print("\n-- recipe\n")
    for name, recipe in recipes.items():
        print(recipeInsert.format(
            email=recipe.get("email", default_email).replace("'", "''"),
            name=name.replace("'", "''"),
            descr=recipe["description"].replace("\n", " ").replace("'", "''"),
            instr=instructions,
            meal_type=recipe["category"][1],
            food_category=recipe["category"][0]))

        print("-- recipeingredient\n")
        for ingredient in recipe["ingredients"]:
            print(recipeIngredientInsert.format(name.replace("'", "''"), ingredient, randrange(3) + 1))

if __name__ == "__main__":
    generateRecipes()