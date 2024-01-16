tracks = {
    #email : [ "DATE", CALORIES, PROTEINS, FAT, CARBONHYDRATES ]
    'anne.mitchel@yahoo.com' : ['2023-12-24', 2600, 70, 46, 39]
}

trackInsert = '''
INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT) 
VALUES ('{email}', TO_DATE('{date}', 'YYYY-MM-DD'), {proteins}, {fat}, {carbonhydrates});
'''

for email, trackInfo in tracks.items():
    print(trackInsert.format(
        email = email,
        date = trackInfo[0],
        proteins = trackInfo[1],
        fat = trackInfo[2],
        carbonhydrates = trackInfo[3]
    ))