print('''
DELETE FROM "EMPLOYEE";
COMMIT;
''')

employees = {
    # email                         :   [ authorization ]
    'yvonne.smith@gmail.com'        :   [ 0 ],
    'benedict.frakes@freenet.com'   :   [ 1 ],
    'anne.mitchel.yahoo.com'        :   [ 0 ]
}

employeeInsert = '''
    INSERT INTO EMPLOYEE (EMAIL, AUTHORIZATION) VALUES ('{email}', {authorization})
    RETURNING EMPLOYEEID INTO g_employeenid;

    UPDATE "USER" SET EMPLOYEEID = g_employeenid
    WHERE "USER".EMAIL = '{email}';'''

def generateEmployees():
    print("\n-- employees\n")
    print('''
DECLARE
g_employeenid NUMBER;
    ''')

    print("BEGIN")
    for email, employeeInfo in employees.items():
        print(employeeInsert.format(
            email =         email,
            authorization = employeeInfo[0]
            ))
    print("END;")

if __name__ == "__main__":
    generateEmployees()