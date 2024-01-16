print('''
DELETE FROM "USER_SAVED_RECIPES";
COMMIT;
''')

userSavedRecipes = [
    # [ useremail, recipename]
    [ 'incredible@fit.com', 'Garlic Chicken Stir Fry'],
    [ 'anne.mitchel@yahoo.com', 'Salmon with sweet potatoes'],
    [ 'anne.mitchel@yahoo.com', 'Yoghurt with beeries'],
    [ 'benedict.frakes@gmail.com', 'Salmon with sweet potatoes'],
    [ 'wilson.stewart@yahoo.com', 'Yoghurt with beeries,'],
    [ 'jonas.blake@web.de', 'Chicken-Quinoa-salad'],
    [ 'samuel.hardy@gmail.com', 'Tomato Salad']
]

userSavedRecipesInsert = '''
INSERT INTO USER_SAVED_RECIPES (EMAIL, RECIPEID)
VALUES (
    '{useremail}',
    (SELECT RECIPEID FROM RECIPE WHERE NAME = '{recipename}')
    );'''

def generateUserSavedRecipes():
    print("\n-- usersavedrecipes\n")
    for userSavedRecipeInfo in userSavedRecipes:
        print(userSavedRecipesInsert.format(
            useremail = userSavedRecipeInfo[0],
            recipename = userSavedRecipeInfo[1]
        ))

if __name__ == "__main__":
    generateUserSavedRecipes()