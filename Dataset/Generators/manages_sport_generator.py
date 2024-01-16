print('''
DELETE FROM "MANAGES_SPORT";
COMMIT;
''')

managesSport = [
    #[ employeeEmail, sport]
    [ 'incredible@fit.com', 'Yoga']
]

managesSportInsert = '''
INSERT INTO MANAGES_SPORT (SPORTID, EMPLOYEEID)
VALUES 
    (
    (SELECT SPORTID FROM SPORT WHERE NAME = '{sport}' ),
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