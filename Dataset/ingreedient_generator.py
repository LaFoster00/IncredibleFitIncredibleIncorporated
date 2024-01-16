print('DELETE FROM "INGREDIENT";')
print('COMMIT;')

print("-- ingredient")
print()

# foodcategory: 0 meat, 1 vegetarian, 2 vegan
# mealtype: 0 breakfast, 1 supper, 2 dinner, 3 snack, 4 drink

ingredients = {
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

for name, ingredientParams in ingredients.items():
    a = insert.format(name, *ingredientParams[:-2], str(ingredientParams[-2]).replace('.', ','), str(ingredientParams[-1]).replace('.', ','))
    print(a)