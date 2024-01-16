print('DELETE FROM "RECIPECATEGORY";')
print('COMMIT;')

print("-- recipecategory")
print()

# foodcategory: 0 meat, 1 vegetarian, 2 vegan
# mealtype: 0 breakfast, 1 supper, 2 dinner, 3 snack, 4 drink

for food_category in range(3):
    for meal_type in range(5):
        s = '''insert into RECIPECATEGORY (mealtype, foodcategory)
VALUES ({}, {});'''
        print(s.format(meal_type, food_category))