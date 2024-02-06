print('''
DELETE FROM "EMPLOYEE";
COMMIT;
''')

employees = {
    # email                         :   [ authorization ]
    'yvonne.smith@gmail.com'        :   [ 0 ],
    'benedict.frakes@gmail.com'   :   [ 1 ],
    'anne.mitchel@yahoo.com'        :   [ 0 ]
}

employeeInsert = '''
DECLARE
    g_employeeid NUMBER;

BEGIN
    INSERT INTO EMPLOYEE (EMAIL, AUTHORIZATION) VALUES ('{email}', {authorization})
    RETURNING EMPLOYEEID INTO g_employeeid;

    UPDATE "USER" SET EMPLOYEEID = g_employeeid
    WHERE "USER".EMAIL = '{email}';
END;
/'''

def generateEmployees():
    print('''
--------------------------------------------
-- Generate the employees. Employees are a simple link for a employeenumber to a user.
--------------------------------------------
    ''')
    for email, employeeInfo in employees.items():
        print(employeeInsert.format(
            email =         email,
            authorization = employeeInfo[0]
            ))

if __name__ == "__main__":
    generateEmployees()