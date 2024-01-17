print('''
DELETE FROM "MANAGES_SPORT";
COMMIT;
''')

managesSport = [
    #[ employeeEmail, sport]
    [ 'yvonne.smith@gmail.com', 'Bodyweight training'],
    [ 'yvonne.smith@gmail.com', 'Core training'],
    [ 'anne.mitchel@yahoo.com', 'Strength training']
]

managesSportInsert = '''
INSERT INTO MANAGES_SPORT (SPORTNAME, EMPLOYEEID)
VALUES 
    (
    '{sport}',
    (SELECT EMPLOYEEID FROM EMPLOYEE WHERE EMAIL = '{email}')
    );'''

def generateManagesSport():
    print("\n-- managessport\n")

    for managesSportInfo in managesSport:
        print(managesSportInsert.format(
            email = managesSportInfo[0],
            sport = managesSportInfo[1]
        ))

if __name__ == "__main__":
    generateManagesSport()