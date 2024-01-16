users = {
    # email                 :   [FITNESSLEVELID, SALT, PASSWORD, NAME, FIRST_NAME, WEIGHT, HEIGHT, BODY_FAT_PERCENTAGE, BASAL_METABOLIC_RATE, TARGETDESCRIPTION, TARGETWEIGHT]
    'iris.hardy@web.de'     :   [1, 'OPBBQ585Q0', 'B7C7DF9D67A1926A737406E2206630FF72AE7D55901425E656E9962891DD5F9BFC785311296B23DF8B19BD7152CDFD2C73DAFB7043D0F409D21D2FC7898C5132', 'Hardy', 'Iris', 68, 163, 25, 1600, 'Improving overall fitness', 62]
}

userInsert = '''
INSERT INTO USER (EMAIL, FITNESSLEVELID, SALT, PASSWORD, NAME, FIRST_NAME, WEIGHT, HEIGHT, BODY_FAT_PERCENTAGE, BASAL_METABOLIC_RATE, TARGETDESCRIPTION, TARGETWEIGHT)
VALUES ('{email}', {fitnesslevelid}, '{salt}', '{password}', '{name}', '{firstName}', {weight}, {height}, {bodyFatPercentage}, {basalMetabolicRate}, '{targetDescription}', {targetWeight});'''

def generateUsers():
    for email, userInfos in users.items():
        print(userInsert.format(
            email = email,
            fitnesslevelid =        userInfos[0],
            salt =                  userInfos[1],
            password =              userInfos[2],
            name =                  userInfos[3],
            firstName =             userInfos[4],
            weight =                userInfos[5],
            height =                userInfos[6],
            bodyFatPercentage =     userInfos[7],
            basalMetabolicRate =    userInfos[8],
            targetDescription =     userInfos[9],
            targetWeight =          userInfos[10]))
        
if __name__ == "__main__":
    generateUsers()