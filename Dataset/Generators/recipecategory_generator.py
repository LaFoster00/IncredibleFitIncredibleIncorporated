print('''
DELETE FROM "RECIPECATEGORY";
COMMIT;
''')

# foodcategory: 0 meat, 1 vegetarian, 2 vegan
# mealtype: 0 breakfast, 1 supper, 2 dinner, 3 snack, 4 drink

recipecategoryInsert = '''
insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES ({}, {});'''

def generateRecipeCategories():
    print('''
--------------------------------------------
-- Generate the recipe-categories. There is only a limited number of
-- possible categories, which is why we create all of them here.
--------------------------------------------
    ''')
    for food_category in range(3):
        for meal_type in range(5):
            print(recipecategoryInsert.format(meal_type, food_category))

if __name__ == "__main__":
    generateRecipeCategories()