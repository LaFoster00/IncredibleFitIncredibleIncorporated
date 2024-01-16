userSavedRecipes = [
    # [ useremail, recipename]
    [ 'incredible@fit.com', 'Garlic Chicken Stir Fry']
]

userSavedRecipesInsert = '''
INSERT INTO USER_SAVED_RECIPES (EMAIL, RECIPEID)
VALUES (
    '{useremail}',
    (SELECT RECIPEID FROM RECIPE WHERE NAME = '{recipename}')
    );'''

def generateUserSavedRecipes():
    for userSavedRecipeInfo in userSavedRecipes:
        print(userSavedRecipesInsert.format(
            useremail = userSavedRecipeInfo[0],
            recipename = userSavedRecipeInfo[1]
        ))

if __name__ == "__main__":
    generateUserSavedRecipes()