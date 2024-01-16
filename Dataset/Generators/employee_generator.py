employees = {
    # email                         :   [ authorization ]
    'yvonne.smith@gmail.com'        :   [ 0 ],
    'benedict.frakes@freenet.com'   :   [ 1 ],
    'anne.mitchel.yahoo.com'        :   [ 0 ]
}

print('''
DECLARE
g_employeenid NUMBER;
''')

print("BEGIN")

employeeInsert = '''
INSERT INTO EMPLOYEE (EMAIL, AUTHORIZATION) VALUES ('{email}', {authorization})
RETURNING EMPLOYEEID INTO g_employeenid;

UPDATE "USER" SET EMPLOYEEID = g_employeenid
WHERE "USER".EMAIL = '{email}';
'''

for email, employeeInfo in employees.items():
    print(employeeInsert.format(
        email =         email,
        authorization = employeeInfo[0]
        ))

print("END;")