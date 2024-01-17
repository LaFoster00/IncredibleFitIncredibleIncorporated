print('''
DELETE FROM "USER";
COMMIT;
''')

users = {
    # email                 :   [FITNESSLEVEL, SALT, PASSWORD, NAME, FIRST_NAME, WEIGHT, HEIGHT, BODY_FAT_PERCENTAGE, BASAL_METABOLIC_RATE, TARGETDESCRIPTION, TARGETWEIGHT]
    'iris.hardy@web.de'     :   ['Impairment', 'OPBBQ585Q0', 'B7C7DF9D67A1926A737406E2206630FF72AE7D55901425E656E9962891DD5F9BFC785311296B23DF8B19BD7152CDFD2C73DAFB7043D0F409D21D2FC7898C5132', 'Hardy', 'Iris', 68, 163, 25, 1600, 'Improving overall fitness', 62],
    'matthew.fuller@gmail.com' : ['Beginner', '4M5CUR9S4C', 'CC58729DCED887AB4372B088042F12269732E0A1C071BD65A361A6146795D05EF79C33B648D57D12FE194A76EB63792F3B1DA0E94688E3904048920A0C8D32BB', 'Fuller', 'Matthew', 80, 175, 18, 1500, 'Maintaining weight and staying active', 80],
    'blair.cooper@freenet.com' : ['Advanced', 'XFT82S8SP6', '4C17285B4203E964861A694F9B557DD055F14A2E5E8DBE63E51C369A73B3E1B2705EA4580A56B48C40545FD5D6D2D6C6CAE3512FA23CD99C9E850ABB38147F9D', 'Cooper', 'Blair', 65, 160, 22, 1300, 'Building lean muscle mass', 72],
    'nora.bialik@yahoo.de' : ['Impairment', '97NQUS3Y7G', '19984FF01E6BB1C040C59B5410F6AFFDDD84DE1BF9EED5ED0D1F95417A4684454D6E75C47DF5A26508C0C36F7AAB0DFC2ADC783C987B7E868E2205E3653D48D3', 'Bialik', 'Nora', 77, 165, 15, 1400, 'Building lean muscle mass', 75],
    'benedict.frakes@gmail.com' : ['Absolute Beginner', 'S4KK4HN3IZ', 'D8DCC51537F57B9C60C0D7756AB65E36DC52B596A308C616867A1B6DA6EC6FAA717DC66975EE607A4FD9D011ADF9400766E08FB88B01B56DBF2AE91DACA3FB7D', 'Frakes', 'Benedict', 112, 202, 20, 1800, 'Building muscle and strength', 120],
    'sabine.baker@freenet.com' : ['Beginner', 'TAWITRIK4G', '2368F0FC11D61F6467FE9F7FFCF06655875513705D44372876114B530F7F8FE1B26174B38CEB89D971FA88C6AD31519B299BF19B6D9A4363BA602586359D686B', 'Baker', 'Sabine', 60, 168, 22, 1300, 'Losing weight and improving fitness', 55],
    'leon.petterson@gmx.com' : ['Absolute Beginner', 'CIDERZE8B1', 'EB51F20126850B6E9EBE2C30C07BCC05B989E4B41825D551AD16EA1F2A3255A0C741A6E88515E893317F112475C7DA2DD5CC63BEFC327303C97F439A052E52C3', 'Petterson', 'Leon', 92, 179, 18, 1600, 'Improving overall fitness', 88],
    'christin.blake@gmx.com' : ['Absolute Beginner', '82XPW2XHCK', '99612A6632501D6507FE8474C48394519EA2EEE01D351F02A703842B3B6DE4FE5FF5A15B30775BD779F52B056307A5BED3FB6F4D12CE104998174B02A6B50982', 'Blake', 'Christin', 49, 151, 12, 1200, 'Maintaining weight and staying active', 49],
    'jonas.blake@web.de' : ['Beginner', 'S23MP3Z6AY', '3B79C123551F79DC276152470A55C90233322F9B6F4842EBE6C0CAB17843275A7A9B83B3020FEEC1EEA92CED2BB2D9C559FBA362DA8F437C925C790CC1D2BD4E', 'Blake', 'Jonas', 70, 175, 15, 1400, 'Improving cardiovascular health', 65],
    'yvonne.smith@gmail.com' : ['Advanced', '9FGKUK4ZTF', '974B6BFFF17E2EF614C9E189214ED7C6A4C15F70AC6A8040431F7EEC1F52FF18AA22F3032F6647813197EA975216F745F1CB5E17A2C611FEF23DE7812C03D8FD', 'Smith', 'Yvonne', 73, 178, 16, 1550, 'Improving overall fitness', 70],
    'anne.mitchel@yahoo.com' : ['Beginner', 'JV6GOQCT06', '33600901EA6BD5276BCCEE70DEA0D5FA558B903F13C26CF100B7280E0C6ED95797C1219FBCD88CBAF30C9081BF203BBF0CBCDADCBD1BBDEF125D49245A47F953', 'Mitchel', 'Anne', 57, 166, 16, 1500, 'Maintaining weight and staying active', 57],
    'samuel.hardy@gmail.com' : ['Professional', '2XP2PS0YFR', '8A6F2C46C051CD69337C330745C474AF7DA8F86D953D7EF0CBA5B96D901D4BBD14B0F6443932E426E543CD7DE9927A1ECD7225D1D4222F4F79E8C6040117B49D', 'Hardy', 'Samuel', 82, 181, 8, 1800, 'Building some muscles', 85],
    'wilson.stewart@yahoo.com' : ['Advanced', 'NWTQUHCGOK', 'F965509E188216DB838AA193F91756826D3FB90C01CE2439A1A5F8B94E85D3ACCDB633CF2C053618F52064E0A00612FEEF958AD9A7B7A5A0E2CDF39E0DA6315B', 'Stewart', 'Wilson', 111, 179, 15, 2600, 'Losing some fat', 99]
}

userInsert = '''
INSERT INTO "USER" (EMAIL, SALT, PASSWORD, LASTNAME, FIRSTNAME, WEIGHT, HEIGHT, BODYFATPERCENTAGE, BASALMETABOLICRATE, TARGETDESCRIPTION, TARGETWEIGHT, FITNESSLEVELID)
VALUES ('{email}', '{salt}', '{password}', '{name}', '{firstName}', {weight}, {height}, {bodyFatPercentage}, {basalMetabolicRate}, '{targetDescription}', {targetWeight}, 
    (SELECT FITNESSLEVELID FROM FITNESSLEVEL WHERE FITNESSSTATUS = '{fitnesslevel}')
);'''

def generateUsers():
    print("\n-- user\n")
    for email, userInfos in users.items():
        print(userInsert.format(
            email = email,
            fitnesslevel =          userInfos[0],
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